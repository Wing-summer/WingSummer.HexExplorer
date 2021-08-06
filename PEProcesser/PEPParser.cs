using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Runtime.InteropServices;
using System.Text;

namespace PEProcesser
{
    public partial class PEPParser : IDisposable
    {
        private MemoryMappedFile mappedFile;

        public PEPParser(string filename)
        {
            Processed = false;
            OccurError = false;

            if (ProcessPE(filename)!= ParserError.Success)
            {
                OccurError = true;
            }
           
            Processed = true;
        }

        public PEPParser(Stream stream)
        {
            Processed = false;
            OccurError = false;
            if (ProcessImagePE(stream)!= ParserError.Success)
            {
                OccurError = true;
            }

            Processed = true;
        }

        public void Dispose()
        {
            _viewAccessor?.Dispose();
            mappedFile?.Dispose();
        }

        public ulong? RVA2FOA(ulong rva)
        {
            if (rva > peData.ImageSize)
            {
                return null;
            }
            if (peData.FileAlign <= 0 || peData.VirtualAlign <= 0)
            {
                return null;
            }

            if (peData.SizeOfHeaders >= 0)
            {
                if (rva <= peData.SizeOfHeaders)
                {
                    return rva;
                }
                else
                {
                    if (_SECTION_HEADERS[0].VirtualAddress > rva)
                    {
                        return rva;
                    }

                    for (int i = 0; i < peData.NumberOfSections; i++)
                    {
                        if (rva >= _SECTION_HEADERS[i].VirtualAddress &&
                            rva <= _SECTION_HEADERS[i].VirtualAddress + _SECTION_HEADERS[i].SizeOfRawData)
                        {
                            return _SECTION_HEADERS[i].PointerToRawData + rva - _SECTION_HEADERS[i].VirtualAddress;
                        }
                        if (i != peData.NumberOfSections - 1)
                        {
                            if (rva < _SECTION_HEADERS[i + 1].VirtualAddress)
                            {
                                return _SECTION_HEADERS[i + 1].PointerToRawData + rva - _SECTION_HEADERS[i + 1].VirtualAddress;
                            }
                        }
                        else
                        {
                            if (rva > _SECTION_HEADERS[i].VirtualAddress + _SECTION_HEADERS[i].SizeOfRawData)
                            {
                                return _SECTION_HEADERS[i].PointerToRawData + rva - _SECTION_HEADERS[i].VirtualAddress;
                            }
                        }
                    }
                }
            }
            return null;
        }

        public ulong? FOA2RVA(ulong foa)
        {
            if (foa > peData.FileSize)
            {
                return null;
            }
            if (peData.FileAlign <= 0 || peData.VirtualAlign <= 0)
            {
                return null;
            }
            if (peData.SizeOfHeaders >= 0)
            {
                if (foa <= peData.SizeOfHeaders)
                {
                    return foa;
                }
                else
                {
                    if (_SECTION_HEADERS[0].PointerToRawData > foa)
                    {
                        return foa;
                    }
                    for (int i = 1; i < peData.NumberOfSections; i++)
                    {
                        if (foa >= _SECTION_HEADERS[i].PointerToRawData &&
                            foa <= _SECTION_HEADERS[i].PointerToRawData + _SECTION_HEADERS[i].SizeOfRawData)
                        {
                            return _SECTION_HEADERS[i].VirtualAddress + foa - _SECTION_HEADERS[i].PointerToRawData;
                        }
                        if (i != peData.NumberOfSections - 1)
                        {
                            if (foa < _SECTION_HEADERS[i + 1].PointerToRawData)
                            {
                                return _SECTION_HEADERS[i + 1].VirtualAddress + foa - _SECTION_HEADERS[i + 1].PointerToRawData;
                            }
                        }
                        else
                        {
                            if (foa > _SECTION_HEADERS[i].PointerToRawData + _SECTION_HEADERS[i].SizeOfRawData)
                            {
                                return _SECTION_HEADERS[i].VirtualAddress + foa - _SECTION_HEADERS[i].PointerToRawData;
                            }
                        }
                    }
                }
            }
            return null;
        }

        private string GetStringUFromAddr(long p, int len)
        {
            char[] buffer = new char[len];
            _viewAccessor.ReadArray(p, buffer, 0, len);
            return new string(buffer);
        }

        private string GetStringAFromAddr(long p)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                byte ch;
                while ((ch = _viewAccessor.ReadByte(p)) != 0)
                {
                    memory.WriteByte(ch);
                    p++;
                }
                return Encoding.ASCII.GetString(memory.ToArray());
            }
        }

        private string GetStringAFromRVA(ulong rva)
        {
            ulong addr = RVA2FOA(rva).Value;
            using (MemoryStream memory = new MemoryStream())
            {
                byte ch;
                while ((ch = _viewAccessor.ReadByte((long)addr)) != 0)
                {
                    memory.WriteByte(ch);
                    addr++;
                }
                return Encoding.ASCII.GetString(memory.ToArray());
            }
        }

        private unsafe ParserError ProcessPE(string filename)
        {
            if (filename == null)
            {
                return ParserError.NullObject;
            }

            FileInfo fileInfo = new FileInfo(filename);
            if (!fileInfo.Exists)
            {
                return ParserError.FileNotExist;
            }
            FileName = filename;

            FileStream fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            mappedFile = MemoryMappedFile.CreateFromFile(fileStream, null, 0, MemoryMappedFileAccess.Read,
                HandleInheritability.None, false);

            _viewAccessor = mappedFile.CreateViewAccessor(0, fileInfo.Length, MemoryMappedFileAccess.Read);

            IMAGE_DATA_DIRECTORY[] _DATA_DIRECTORYS = null;
            peData = new PEStructData();

            bool isPEDamaged = false;

            try
            {
                try
                {
                    _viewAccessor.Read(0, out IMAGE_DOS_HEADER _DOS_HEADER);

                    if (_DOS_HEADER.e_magic != IMAGE_DOS_SIGNATURE)
                    {
                        ViewAccessor.Dispose();
                        mappedFile.Dispose();
                        _viewAccessor = null;
                        return ParserError.PEDamaged;
                    }
                    IMAGE_DOS_HEADER_ = _DOS_HEADER;
                    peData.NT_HEADER_Addr = _DOS_HEADER.e_lfanew;

                }
                catch
                {
                    isPEDamaged = true;
                }

                try
                {
                    uint ntsig = (uint)_viewAccessor.ReadInt32((long)peData.NT_HEADER_Addr);

                    if (ntsig != IMAGE_NT_SIGNATURE)
                    {
                        ViewAccessor.Dispose();
                        mappedFile.Dispose();
                        _viewAccessor = null;
                        return ParserError.PEDamaged;
                    }

                    ushort exe32bit = (ushort)_viewAccessor.ReadInt16((long)(peData.NT_HEADER_Addr + 4 + IMAGE_SIZEOF_FILE_HEADER));
                    switch (exe32bit)
                    {
                        case IMAGE_NT_OPTIONAL_HDR32_MAGIC:
                            Is32Bit = true;
                            goto Process32Bit;
                        case IMAGE_NT_OPTIONAL_HDR64_MAGIC:
                            Is32Bit = false;
                            goto Process64Bit;
                    }
                }
                catch
                {
                    isPEDamaged = true;
                }

            Process32Bit:
                IMAGE_NT_HEADERS32 _NT_HEADERS32 = new IMAGE_NT_HEADERS32();
                int _len = Marshal.SizeOf(typeof(IMAGE_NT_HEADERS32));
                byte[] buffer = new byte[_len];

                try
                {
                    _viewAccessor.ReadArray((long)peData.NT_HEADER_Addr, buffer, 0, _len);

                    IntPtr intPtr = Marshal.AllocHGlobal(_len);
                    Marshal.Copy(buffer, 0, intPtr, _len);
                    Marshal.PtrToStructure(intPtr, _NT_HEADERS32);
                    Marshal.FreeHGlobal(intPtr);

                    peData.NumberOfSections = _NT_HEADERS32.FileHeader.NumberOfSections;
                    peData.FileAlign = _NT_HEADERS32.OptionalHeader.FileAlignment;
                    peData.VirtualAlign = _NT_HEADERS32.OptionalHeader.SectionAlignment;
                    peData.SizeOfHeaders = _NT_HEADERS32.OptionalHeader.SizeOfHeaders;
                    peData.ImageSize = _NT_HEADERS32.OptionalHeader.SizeOfImage;
                    peData.ImageBase = _NT_HEADERS32.OptionalHeader.ImageBase;

                    _DATA_DIRECTORYS = IMAGE_DATA_DIRECTORIES = _NT_HEADERS32.OptionalHeader.DataDirectory;

                    peData.FILE_HEADER_Addr = peData.NT_HEADER_Addr + sizeof(uint);
                    peData.OPTIONAL_HEADER_Addr = peData.FILE_HEADER_Addr + IMAGE_SIZEOF_FILE_HEADER;
                    peData.SECTION_HEADERS_Addr = peData.OPTIONAL_HEADER_Addr + _NT_HEADERS32.FileHeader.SizeOfOptionalHeader;
                    peData.SizeOPTIONAL_HEADER = _NT_HEADERS32.FileHeader.SizeOfOptionalHeader;
                }
                catch
                {
                    isPEDamaged = true;
                }

                goto CommonProcess;

            Process64Bit:

                try
                {
                    IMAGE_NT_HEADERS64 _NT_HEADERS64 = new IMAGE_NT_HEADERS64();

                    int len0 = Marshal.SizeOf(typeof(IMAGE_NT_HEADERS64));
                    byte[] buffer0 = new byte[len0];
                    _viewAccessor.ReadArray((long)peData.NT_HEADER_Addr, buffer0, 0, len0);

                    IntPtr intPtr0 = Marshal.AllocHGlobal(len0);
                    Marshal.Copy(buffer0, 0, intPtr0, len0);
                    Marshal.PtrToStructure(intPtr0, _NT_HEADERS64);
                    Marshal.FreeHGlobal(intPtr0);

                    peData.NumberOfSections = _NT_HEADERS64.FileHeader.NumberOfSections;
                    peData.FileAlign = _NT_HEADERS64.OptionalHeader.FileAlignment;
                    peData.VirtualAlign = _NT_HEADERS64.OptionalHeader.SectionAlignment;
                    peData.SizeOfHeaders = _NT_HEADERS64.OptionalHeader.SizeOfHeaders;
                    peData.ImageSize = _NT_HEADERS64.OptionalHeader.SizeOfImage;
                    peData.ImageBase = _NT_HEADERS64.OptionalHeader.ImageBase;

                    _DATA_DIRECTORYS = IMAGE_DATA_DIRECTORIES = _NT_HEADERS64.OptionalHeader.DataDirectory;

                    peData.FILE_HEADER_Addr = peData.NT_HEADER_Addr + sizeof(uint);
                    peData.OPTIONAL_HEADER_Addr = peData.FILE_HEADER_Addr + IMAGE_SIZEOF_FILE_HEADER;
                    peData.SECTION_HEADERS_Addr = peData.OPTIONAL_HEADER_Addr + _NT_HEADERS64.FileHeader.SizeOfOptionalHeader;
                    peData.SizeOPTIONAL_HEADER = _NT_HEADERS64.FileHeader.SizeOfOptionalHeader;
                }
                catch
                {
                    isPEDamaged = true;
                }

            CommonProcess:

                _SECTION_HEADERS = new IMAGE_SECTION_HEADER[peData.NumberOfSections];

                peData.DATA_DIRECTORIES_Addr = peData.SECTION_HEADERS_Addr -
                  (ulong)sizeof(IMAGE_DATA_DIRECTORY) * IMAGE_NUMBEROF_DIRECTORY_ENTRIES;

                try
                {
                    _viewAccessor.ReadArray((long)peData.SECTION_HEADERS_Addr, _SECTION_HEADERS, 0, (int)peData.NumberOfSections);
                }
                catch
                {
                    isPEDamaged = true;
                }

                IMAGE_DATA_DIRECTORY idd;

                if (_DATA_DIRECTORYS == null)
                {
                    isPEDamaged = true;
                    throw new NullReferenceException();
                }

                // ====================获得导出表

                try
                {
                    idd = _DATA_DIRECTORYS[(int)DirectoryEntries.IMAGE_DIRECTORY_ENTRY_EXPORT];
                    if (idd.VirtualAddress != 0 && idd.Size != 0)
                    {
                        _viewAccessor.Read((long)RVA2FOA(idd.VirtualAddress).Value, out IMAGE_EXPORT_DIRECTORY _EXPORT_DIRECTORY);

                        uint mcount = _EXPORT_DIRECTORY.NumberOfFunctions;
                        uint ncount = _EXPORT_DIRECTORY.NumberOfNames;
                        uint _base = _EXPORT_DIRECTORY.Base;

                        Dictionary<uint, string> nexp = new Dictionary<uint, string>();

                        uint[] PAddressOfNames = new uint[ncount];
                        _viewAccessor.ReadArray((long)RVA2FOA(_EXPORT_DIRECTORY.AddressOfNames).Value, PAddressOfNames, 0, (int)ncount);

                        ushort[] PAddressOfNameOrdinals = new ushort[ncount];
                        _viewAccessor.ReadArray((long)RVA2FOA(_EXPORT_DIRECTORY.AddressOfNameOrdinals).Value, PAddressOfNameOrdinals, 0, (int)ncount);

                        uint[] PAddressOfFunctions = new uint[mcount];
                        _viewAccessor.ReadArray((long)RVA2FOA(_EXPORT_DIRECTORY.AddressOfFunctions).Value, PAddressOfFunctions, 0, (int)ncount);

                        for (int i = 0; i < ncount; i++)
                        {
                            nexp.Add(_base + PAddressOfNameOrdinals[i], GetStringAFromRVA(PAddressOfNames[i]));
                        }

                        exportTables = new List<ExportTable>();

                        ExportTable exptable = new ExportTable();

                        uint off = 0;
                        for (uint i = 0; i < mcount; i++)
                        {
                            if (PAddressOfFunctions[i + off] == 0)
                            {
                                off++;
                                i--;
                                continue;
                            }
                            exptable.FuncRVA = PAddressOfFunctions[i + off];
                            exptable.Ordinal = _base + i + off;

                            if (nexp.ContainsKey(_base + i + off))
                            {
                                exptable.Name = nexp[_base + i + off];
                            }
                            ExportTables.Add(exptable);
                            exptable.Name = string.Empty;
                        }
                    }

                }
                catch
                {

                }

                // ====================获取导入表

                try
                {

                    idd = _DATA_DIRECTORYS[(int)DirectoryEntries.IMAGE_DIRECTORY_ENTRY_IMPORT];

                    IMAGE_IMPORT_DESCRIPTOR _IMPORT_DESCRIPTOR = new IMAGE_IMPORT_DESCRIPTOR();
                    int null_IMPORT_DESCRIPTOR = _IMPORT_DESCRIPTOR.GetHashCode();
                    ImportTable importTable;

                    if (idd.VirtualAddress != 0 && idd.Size != 0)
                    {
                        ulong IMPORT_DESCRIPTORBase = RVA2FOA(idd.VirtualAddress).Value;

                        _viewAccessor.Read((long)IMPORT_DESCRIPTORBase, out _IMPORT_DESCRIPTOR);

                        importTables = new List<ImportTable>();

                        if (Is32Bit)
                        {
                            while (_IMPORT_DESCRIPTOR.GetHashCode() != null_IMPORT_DESCRIPTOR)
                            {
                                importTable = new ImportTable
                                {
                                    Exports = new List<ExportTable>(),
                                    Name = GetStringAFromRVA(_IMPORT_DESCRIPTOR.Name)
                                };

                                IMAGE_THUNK_DATA32 _THUNK_DATA32 = new IMAGE_THUNK_DATA32();
                                int null_THUNK_DATA32 = _THUNK_DATA32.GetHashCode();
                                ulong FirstThunkInter = RVA2FOA(_IMPORT_DESCRIPTOR.FirstThunk).Value;
                                _viewAccessor.Read((long)FirstThunkInter, out _THUNK_DATA32);

                                ExportTable ext;

                                while (_THUNK_DATA32.GetHashCode() != null_THUNK_DATA32)
                                {
                                    ext = new ExportTable();
                                    if ((_THUNK_DATA32.AddressOfData >> 31) == 1)
                                    {
                                        ext.Ordinal = (ushort)_THUNK_DATA32.AddressOfData;
                                        ext.Name = string.Empty;
                                    }
                                    else
                                    {
                                        ulong oraddr = RVA2FOA(_THUNK_DATA32.AddressOfData).Value;
                                        _viewAccessor.Read((long)oraddr, out IMAGE_IMPORT_BY_NAME iibn);
                                        ext.Ordinal = iibn.Hint;
                                        ext.Name = GetStringAFromAddr((long)(oraddr + sizeof(short)));
                                    }
                                    ext.FuncRVA = null;
                                    importTable.Exports.Add(ext);

                                    FirstThunkInter += (uint)sizeof(IMAGE_THUNK_DATA32);
                                    _viewAccessor.Read((long)FirstThunkInter, out _THUNK_DATA32);
                                }

                                importTables.Add(importTable);

                                IMPORT_DESCRIPTORBase += (uint)sizeof(IMAGE_IMPORT_DESCRIPTOR);
                                _viewAccessor.Read((long)IMPORT_DESCRIPTORBase, out _IMPORT_DESCRIPTOR);
                            }
                        }
                        else
                        {
                            while (_IMPORT_DESCRIPTOR.GetHashCode() != null_IMPORT_DESCRIPTOR)
                            {
                                importTable = new ImportTable
                                {
                                    Exports = new List<ExportTable>(),
                                    Name = GetStringAFromRVA(_IMPORT_DESCRIPTOR.Name)
                                };

                                IMAGE_THUNK_DATA64 _THUNK_DATA64 = new IMAGE_THUNK_DATA64();
                                int null_THUNK_DATA64 = _THUNK_DATA64.GetHashCode();
                                ulong FirstThunkInter = RVA2FOA(_IMPORT_DESCRIPTOR.FirstThunk).Value;
                                _viewAccessor.Read((long)FirstThunkInter, out _THUNK_DATA64);

                                ExportTable ext;

                                while (_THUNK_DATA64.GetHashCode() != null_THUNK_DATA64)
                                {
                                    ext = new ExportTable();
                                    if ((_THUNK_DATA64.AddressOfData >> 63) == 1)
                                    {
                                        ext.Ordinal = (ushort)_THUNK_DATA64.AddressOfData;
                                        ext.Name = string.Empty;
                                    }
                                    else
                                    {
                                        _viewAccessor.Read((long)RVA2FOA(_THUNK_DATA64.AddressOfData).Value, out IMAGE_IMPORT_BY_NAME iibn);
                                        ext.Ordinal = iibn.Hint;
                                        ext.Name = GetStringAFromAddr(iibn.Name);
                                    }
                                    ext.FuncRVA = null;
                                    importTable.Exports.Add(ext);

                                    FirstThunkInter += (uint)sizeof(IMAGE_THUNK_DATA64);
                                    _viewAccessor.Read((long)FirstThunkInter, out _THUNK_DATA64);
                                }

                                importTables.Add(importTable);

                                IMPORT_DESCRIPTORBase += (uint)sizeof(IMAGE_IMPORT_DESCRIPTOR);
                                _viewAccessor.Read((long)IMPORT_DESCRIPTORBase, out _IMPORT_DESCRIPTOR);
                            }
                        }
                    }
                }
                catch
                {
                    isPEDamaged = true;
                }


                // ====================获取重定位表

                try
                {
                    idd = _DATA_DIRECTORYS[(int)DirectoryEntries.IMAGE_DIRECTORY_ENTRY_BASERELOC];
                    if (idd.VirtualAddress != 0 && idd.Size != 0)
                    {
                        var rInter = RVA2FOA(idd.VirtualAddress).Value;
                        _viewAccessor.Read((long)rInter, out IMAGE_BASE_RELOCATION ir);
                        RelocateTable rt;
                        ulong rlimit = rInter + idd.Size;
                        uint rcount;
                        relocateTables = new List<RelocateTable>();

                        while (rInter < rlimit)
                        {
                            rt = new RelocateTable
                            {
                                VirtualBase = ir.VirtualAddress
                            };
                            rcount = ir.SizeOfBlock / 2 - sizeof(int);

                            RelocateItem[] ritem = new RelocateItem[rcount];

                            _viewAccessor.ReadArray((long)(rInter + sizeof(long)), ritem, 0, (int)rcount);
                            rt.Relocitems = ritem;

                            relocateTables.Add(rt);

                            rInter += ir.SizeOfBlock;
                            _viewAccessor.Read((long)rInter, out ir);
                        }
                    }
                }
                catch
                {
                    isPEDamaged = true;
                }

                // ==================== 获取资源表

                try
                {

                    idd = _DATA_DIRECTORYS[(int)DirectoryEntries.IMAGE_DIRECTORY_ENTRY_RESOURCE];
                    if (idd.VirtualAddress != 0 && idd.Size != 0)
                    {
                        peData.RESOURCE_DIR_Addr = RVA2FOA(idd.VirtualAddress).Value;

                        IMAGE_RESOURCE_DIRECTORY ird3;
                        IMAGE_RESOURCE_DIRECTORY_ENTRY[] pirde, pirde2, pirde3;
                        IMAGE_RESOURCE_DATA_ENTRY irdata;

                        ulong irdebase = peData.RESOURCE_DIR_Addr + (uint)sizeof(IMAGE_RESOURCE_DIRECTORY);

                        _viewAccessor.Read((long)peData.RESOURCE_DIR_Addr, out IMAGE_RESOURCE_DIRECTORY ird);

                        int len = ird.NumberOfIdEntries + ird.NumberOfNamedEntries;

                        ResourceTable res = new ResourceTable();
                        IMAGE_RESOURCE_DIR_STRING_U stringu;

                        pirde = new IMAGE_RESOURCE_DIRECTORY_ENTRY[len];
                        _viewAccessor.ReadArray((long)irdebase, pirde, 0, len);

                        resourceTables = new List<ResourceTable>();

                        for (int i = 0; i < len; i++)
                        {
                            if (pirde[i].NameIsString)
                            {
                                _viewAccessor.Read((long)(peData.RESOURCE_DIR_Addr + pirde[i].NameOffset), out stringu);
                                res.ResType = (ResourceType)pirde[i].Id;
                                res.Name = GetStringUFromAddr((long)(peData.RESOURCE_DIR_Addr + pirde[i].NameOffset + sizeof(short)), stringu.Length);
                                res.ID = null;
                            }
                            else
                            {
                                res.Name = string.Empty;
                                res.ID = pirde[i].Id;
                            }

                            if (pirde[i].DataIsDirectory)
                            {
                                ulong irdebase2 = peData.RESOURCE_DIR_Addr + pirde[i].OffsetToDirectory;
                                _viewAccessor.Read((long)irdebase2, out IMAGE_RESOURCE_DIRECTORY ird2);
                                irdebase2 += (uint)sizeof(IMAGE_RESOURCE_DIRECTORY);
                                int len1 = ird2.NumberOfIdEntries + ird2.NumberOfNamedEntries;

                                pirde2 = new IMAGE_RESOURCE_DIRECTORY_ENTRY[len1];

                                _viewAccessor.ReadArray((long)irdebase2, pirde2, 0, len1);

                                for (int ii = 0; ii < len1; ii++) //第二层
                                {
                                    if (pirde2[ii].NameIsString)
                                    {
                                        _viewAccessor.Read((long)(peData.RESOURCE_DIR_Addr + pirde2[ii].NameOffset), out stringu);
                                        res.ResName = GetStringUFromAddr((long)(peData.RESOURCE_DIR_Addr +
                                            pirde2[ii].NameOffset + sizeof(short)), stringu.Length);
                                        res.ResID = null;
                                    }
                                    else
                                    {
                                        res.ResName = string.Empty;
                                        res.ResID = pirde2[ii].Id;
                                    }

                                    ulong irdebase3 = peData.RESOURCE_DIR_Addr + pirde2[ii].OffsetToDirectory;
                                    _viewAccessor.Read((long)irdebase3, out ird3);
                                    irdebase3 += (uint)sizeof(IMAGE_RESOURCE_DIRECTORY);

                                    int len2 = ird3.NumberOfIdEntries + ird3.NumberOfNamedEntries;

                                    pirde3 = new IMAGE_RESOURCE_DIRECTORY_ENTRY[len2];
                                    _viewAccessor.ReadArray((long)irdebase3, pirde3, 0, len2);

                                    for (int iii = 0; iii < len2; iii++) //第三层
                                    {
                                        _viewAccessor.Read((long)(peData.RESOURCE_DIR_Addr + pirde3[iii].OffsetToData), out irdata);
                                        res.CodePage = irdata.CodePage;
                                        res.FOA = RVA2FOA(irdata.OffsetToData).Value;
                                        res.Size = irdata.Size;
                                        resourceTables.Add(res);
                                    }
                                }
                            }
                            else
                            {
                                res.ResID = res.ID;
                                res.ResName = (string)res.Name.Clone();
                                res.ID = null;
                                res.ResName = string.Empty;

                                ulong irdebase3 = peData.RESOURCE_DIR_Addr + pirde[i].OffsetToDirectory;
                                _viewAccessor.Read((long)irdebase3, out ird3);
                                irdebase3 += (uint)sizeof(IMAGE_RESOURCE_DIRECTORY);

                                int len2 = ird3.NumberOfIdEntries + ird3.NumberOfNamedEntries;

                                pirde3 = new IMAGE_RESOURCE_DIRECTORY_ENTRY[len2];
                                _viewAccessor.ReadArray((long)irdebase3, pirde3, 0, len2);

                                for (int iii = 0; iii < len2; iii++) //第三层
                                {
                                    _viewAccessor.Read((long)(peData.RESOURCE_DIR_Addr + pirde3[iii].OffsetToData), out irdata);
                                    res.CodePage = irdata.CodePage;
                                    res.FOA = RVA2FOA(irdata.OffsetToData).Value;
                                    res.Size = irdata.Size;
                                    resourceTables.Add(res);
                                }
                            }
                        }
                    }
                }
                catch
                {
                    isPEDamaged = true;
                }

                // ====================获取调试目录

                try
                {
                    idd = _DATA_DIRECTORYS[(int)DirectoryEntries.IMAGE_DIRECTORY_ENTRY_DEBUG];
                    if (idd.VirtualAddress != 0 && idd.Size != 0)
                    {
                        _viewAccessor.Read((long)RVA2FOA(idd.VirtualAddress), out IMAGE_DEBUG_DIRECTORY _DEBUG_DIRECTORY);
                        peData.SizeofDEBUG_DIR = _DEBUG_DIRECTORY.AddressOfRawData;
                        peData.DEBUG_DIR_Addr = _DEBUG_DIRECTORY.PointerToRawData;
                    }
                }
                catch
                {
                    isPEDamaged=true;
                }

                // ====================NET程序目录

                try
                {
                    idd = _DATA_DIRECTORYS[(int)DirectoryEntries.IMAGE_DIRECTORY_ENTRY_COM_DESCRIPTOR];
                    if (idd.VirtualAddress != 0 && idd.Size != 0)
                    {
                        peData.COR20_HEADER_Addr = RVA2FOA(idd.VirtualAddress).Value;
                        _viewAccessor.Read((long)peData.COR20_HEADER_Addr, out IMAGE_COR20_HEADER _COR20_HEADER);

                        netMeta = new DotNetMetaInfo();

                        if (_COR20_HEADER.MetaData.VirtualAddress != 0 && _COR20_HEADER.MetaData.Size != 0)
                        {
                            peData.MetaData_Addr = RVA2FOA(_COR20_HEADER.MetaData.VirtualAddress).Value;
                            netMeta.STORAGESIGNATURE = new STORAGESIGNATURE();
                            netMeta.STORAGEHEADER = new STORAGEHEADER();

                            _viewAccessor.Read((long)peData.MetaData_Addr, out netMeta.STORAGESIGNATURE);
                            ulong pos = peData.MetaData_Addr + (uint)sizeof(STORAGESIGNATURE);
                            netMeta.pVersion = GetStringUTF8FromAddr(pos, (int)netMeta.STORAGESIGNATURE.iVersionString);
                            pos += netMeta.STORAGESIGNATURE.iVersionString;
                            _viewAccessor.Read((long)pos, out netMeta.STORAGEHEADER);
                            pos += (uint)sizeof(STORAGEHEADER);
                            iStreams = new Dictionary<string, STORAGESTREAM>();


                            for (int i = 0; i < netMeta.STORAGEHEADER.iStreams; i++)
                            {
                                _viewAccessor.Read((long)pos, out STORAGESTREAM sTORAGESTREAM);
                                pos += (uint)sizeof(STORAGESTREAM);
                                string tmp = GetStringAFromAddr((long)pos);
                                iStreams.Add(tmp, sTORAGESTREAM);
                                pos += (ulong)Math.Ceiling((tmp.Length + 1) / 4.0D) * 4;
                            }

                            if (iStreams.ContainsKey("#~"))
                            {
                                pos = peData.MetaData_Addr + iStreams["#~"].iOffset;
                                _viewAccessor.Read((long)pos, out MDStreamHeader mDStreamHeader);

                                BitArray bitArray = new BitArray(BitConverter.GetBytes(mDStreamHeader.MaskValid));
                                int bcount = 0;

                                foreach (bool item in bitArray)
                                {
                                    if (item) bcount++;
                                }

                                //Dictionary<DotNetTables,>
                                pos += (uint)sizeof(MDStreamHeader);
                                int[] bu = new int[bcount];
                                _viewAccessor.ReadArray((long)pos, bu, 0, bcount);
                                //FieldInfo fieldInfo;
                            }
                        }
                        IsdotNetFile = true;
                    }
                }
                catch 
                {
                    isPEDamaged = true;
                }
            }
            catch 
            {
                isPEDamaged = true;
            }

            if (isPEDamaged)
                return ParserError.PEDamaged;

            return ParserError.Success;

        }

        private unsafe ParserError ProcessImagePE(Stream stream)
        {
            if (stream == null)
            {
                return ParserError.NullObject;
            }

            mappedFile = MemoryMappedFile.CreateNew(null, stream.Length, MemoryMappedFileAccess.ReadWrite);
            using (var tmpstream = mappedFile.CreateViewStream())
            {
                stream.CopyTo(tmpstream);
                tmpstream.Flush();
                tmpstream.Close();

                _viewAccessor = mappedFile.CreateViewAccessor();

                bool isPEDamaged = false;

                try
                {
                    peData = new PEStructData();
                    IMAGE_DATA_DIRECTORY[] _DATA_DIRECTORYS=null;

                    try
                    {
                        _viewAccessor.Read(0, out IMAGE_DOS_HEADER _DOS_HEADER);

                        if (_DOS_HEADER.e_magic != IMAGE_DOS_SIGNATURE)
                        {
                            ViewAccessor.Dispose();
                            mappedFile.Dispose();
                            _viewAccessor = null;
                            return ParserError.PEDamaged;
                        }
                        IMAGE_DOS_HEADER_ = _DOS_HEADER;
                        peData.NT_HEADER_Addr = _DOS_HEADER.e_lfanew;

                    }
                    catch
                    {
                        isPEDamaged = true;
                    }

                    try
                    {
                        uint ntsig = (uint)_viewAccessor.ReadInt32((long)peData.NT_HEADER_Addr);

                        if (ntsig != IMAGE_NT_SIGNATURE)
                        {
                            ViewAccessor.Dispose();
                            mappedFile.Dispose();
                            _viewAccessor = null;
                            return ParserError.PEDamaged;
                        }
                    }
                    catch
                    {
                        isPEDamaged = true;
                    }


                    try
                    {
                        ushort exe32bit = (ushort)_viewAccessor.ReadInt16((long)(peData.NT_HEADER_Addr + 4 + IMAGE_SIZEOF_FILE_HEADER));
                        switch (exe32bit)
                        {
                            case IMAGE_NT_OPTIONAL_HDR32_MAGIC:
                                Is32Bit = true;
                                goto Process32Bit;
                            case IMAGE_NT_OPTIONAL_HDR64_MAGIC:
                                Is32Bit = false;
                                goto Process64Bit;
                        }
                    }
                    catch 
                    {
                        isPEDamaged = true;
                    }


                Process32Bit:
                    IMAGE_NT_HEADERS32 _NT_HEADERS32 = new IMAGE_NT_HEADERS32();
                    int _len = Marshal.SizeOf(typeof(IMAGE_NT_HEADERS32));
                    byte[] buffer = new byte[_len];

                    try
                    {
                        _viewAccessor.ReadArray((long)peData.NT_HEADER_Addr, buffer, 0, _len);

                        IntPtr intPtr = Marshal.AllocHGlobal(_len);
                        Marshal.Copy(buffer, 0, intPtr, _len);
                        Marshal.PtrToStructure(intPtr, _NT_HEADERS32);
                        Marshal.FreeHGlobal(intPtr);

                        peData.NumberOfSections = _NT_HEADERS32.FileHeader.NumberOfSections;
                        peData.FileAlign = _NT_HEADERS32.OptionalHeader.FileAlignment;
                        peData.VirtualAlign = _NT_HEADERS32.OptionalHeader.SectionAlignment;
                        peData.SizeOfHeaders = _NT_HEADERS32.OptionalHeader.SizeOfHeaders;
                        peData.ImageSize = _NT_HEADERS32.OptionalHeader.SizeOfImage;
                        peData.ImageBase = _NT_HEADERS32.OptionalHeader.ImageBase;

                        _DATA_DIRECTORYS = IMAGE_DATA_DIRECTORIES = _NT_HEADERS32.OptionalHeader.DataDirectory;

                        peData.FILE_HEADER_Addr = peData.NT_HEADER_Addr + sizeof(uint);
                        peData.OPTIONAL_HEADER_Addr = peData.FILE_HEADER_Addr + IMAGE_SIZEOF_FILE_HEADER;
                        peData.SECTION_HEADERS_Addr = peData.OPTIONAL_HEADER_Addr + _NT_HEADERS32.FileHeader.SizeOfOptionalHeader;
                        peData.SizeOPTIONAL_HEADER = _NT_HEADERS32.FileHeader.SizeOfOptionalHeader;
                    }
                    catch 
                    {
                        isPEDamaged = true;
                    }

                   

                    goto CommonProcess;
                Process64Bit:

                    IMAGE_NT_HEADERS64 _NT_HEADERS64 = new IMAGE_NT_HEADERS64();

                    int len0 = Marshal.SizeOf(typeof(IMAGE_NT_HEADERS64));
                    byte[] buffer0 = new byte[len0];
                    _viewAccessor.ReadArray((long)peData.NT_HEADER_Addr, buffer0, 0, len0);

                    IntPtr intPtr0 = Marshal.AllocHGlobal(len0);
                    Marshal.Copy(buffer0, 0, intPtr0, len0);
                    Marshal.PtrToStructure(intPtr0, _NT_HEADERS64);
                    Marshal.FreeHGlobal(intPtr0);

                    peData.NumberOfSections = _NT_HEADERS64.FileHeader.NumberOfSections;
                    peData.FileAlign = _NT_HEADERS64.OptionalHeader.FileAlignment;
                    peData.VirtualAlign = _NT_HEADERS64.OptionalHeader.SectionAlignment;
                    peData.SizeOfHeaders = _NT_HEADERS64.OptionalHeader.SizeOfHeaders;
                    peData.ImageSize = _NT_HEADERS64.OptionalHeader.SizeOfImage;
                    peData.ImageBase = _NT_HEADERS64.OptionalHeader.ImageBase;

                    _DATA_DIRECTORYS = IMAGE_DATA_DIRECTORIES = _NT_HEADERS64.OptionalHeader.DataDirectory;

                    peData.FILE_HEADER_Addr = peData.NT_HEADER_Addr + sizeof(uint);
                    peData.OPTIONAL_HEADER_Addr = peData.FILE_HEADER_Addr + IMAGE_SIZEOF_FILE_HEADER;
                    peData.SECTION_HEADERS_Addr = peData.OPTIONAL_HEADER_Addr + _NT_HEADERS64.FileHeader.SizeOfOptionalHeader;
                    peData.SizeOPTIONAL_HEADER = _NT_HEADERS64.FileHeader.SizeOfOptionalHeader;

                CommonProcess:

                    if (_DATA_DIRECTORYS==null)
                    {
                        isPEDamaged = true;
                        throw new ArgumentNullException();
                    }

                    _SECTION_HEADERS = new IMAGE_SECTION_HEADER[peData.NumberOfSections];

                    peData.DATA_DIRECTORIES_Addr = peData.SECTION_HEADERS_Addr -
                      (ulong)sizeof(IMAGE_DATA_DIRECTORY) * IMAGE_NUMBEROF_DIRECTORY_ENTRIES;

                    try
                    {
                        _viewAccessor.ReadArray((long)peData.SECTION_HEADERS_Addr, _SECTION_HEADERS, 0, (int)peData.NumberOfSections);
                    }
                    catch 
                    {
                        isPEDamaged=true;
                    }

                    IMAGE_DATA_DIRECTORY idd;

                    // ====================获得导出表

                    try
                    {

                        idd = _DATA_DIRECTORYS[(int)DirectoryEntries.IMAGE_DIRECTORY_ENTRY_EXPORT];
                        if (idd.VirtualAddress != 0 && idd.Size != 0)
                        {
                            _viewAccessor.Read(idd.VirtualAddress, out IMAGE_EXPORT_DIRECTORY _EXPORT_DIRECTORY);

                            uint mcount = _EXPORT_DIRECTORY.NumberOfFunctions;
                            uint ncount = _EXPORT_DIRECTORY.NumberOfNames;
                            uint _base = _EXPORT_DIRECTORY.Base;

                            Dictionary<uint, string> nexp = new Dictionary<uint, string>();

                            uint[] PAddressOfNames = new uint[ncount];
                            _viewAccessor.ReadArray(_EXPORT_DIRECTORY.AddressOfNames, PAddressOfNames, 0, (int)ncount);

                            ushort[] PAddressOfNameOrdinals = new ushort[ncount];
                            _viewAccessor.ReadArray(_EXPORT_DIRECTORY.AddressOfNameOrdinals, PAddressOfNameOrdinals, 0, (int)ncount);

                            uint[] PAddressOfFunctions = new uint[mcount];
                            _viewAccessor.ReadArray(_EXPORT_DIRECTORY.AddressOfFunctions, PAddressOfFunctions, 0, (int)ncount);

                            for (int i = 0; i < ncount; i++)
                            {
                                nexp.Add(_base + PAddressOfNameOrdinals[i], GetStringAFromAddr(PAddressOfNames[i]));
                            }

                            exportTables = new List<ExportTable>();

                            ExportTable exptable = new ExportTable();

                            uint off = 0;
                            for (uint i = 0; i < mcount; i++)
                            {
                                if (PAddressOfFunctions[i + off] == 0)
                                {
                                    off++;
                                    i--;
                                    continue;
                                }
                                exptable.FuncRVA = PAddressOfFunctions[i + off];
                                exptable.Ordinal = _base + i + off;

                                if (nexp.ContainsKey(_base + i + off))
                                {
                                    exptable.Name = nexp[_base + i + off];
                                }
                                ExportTables.Add(exptable);
                                exptable.Name = string.Empty;
                            }
                        }
                    }
                    catch
                    {
                        isPEDamaged = true;
                    }

                    // ====================获取导入表

                    idd = _DATA_DIRECTORYS[(int)DirectoryEntries.IMAGE_DIRECTORY_ENTRY_IMPORT];

                    try
                    {
                        IMAGE_IMPORT_DESCRIPTOR _IMPORT_DESCRIPTOR = new IMAGE_IMPORT_DESCRIPTOR();
                        int null_IMPORT_DESCRIPTOR = _IMPORT_DESCRIPTOR.GetHashCode();
                        ImportTable importTable;

                        if (idd.VirtualAddress != 0 && idd.Size != 0)
                        {
                            ulong IMPORT_DESCRIPTORBase = idd.VirtualAddress;

                            _viewAccessor.Read((long)IMPORT_DESCRIPTORBase, out _IMPORT_DESCRIPTOR);

                            importTables = new List<ImportTable>();

                            if (Is32Bit)
                            {
                                while (_IMPORT_DESCRIPTOR.GetHashCode() != null_IMPORT_DESCRIPTOR)
                                {
                                    importTable = new ImportTable
                                    {
                                        Exports = new List<ExportTable>(),
                                        Name = GetStringAFromAddr(_IMPORT_DESCRIPTOR.Name)
                                    };

                                    IMAGE_THUNK_DATA32 _THUNK_DATA32 = new IMAGE_THUNK_DATA32();
                                    int null_THUNK_DATA32 = _THUNK_DATA32.GetHashCode();
                                    ulong FirstThunkInter = _IMPORT_DESCRIPTOR.Characteristics_OriginalFirstThunk;
                                    _viewAccessor.Read((long)FirstThunkInter, out _THUNK_DATA32);

                                    ExportTable ext;

                                    while (_THUNK_DATA32.GetHashCode() != null_THUNK_DATA32)
                                    {
                                        ext = new ExportTable();
                                        if ((_THUNK_DATA32.AddressOfData >> 31) == 1)
                                        {
                                            ext.Ordinal = (ushort)_THUNK_DATA32.AddressOfData;
                                            ext.Name = string.Empty;
                                        }
                                        else
                                        {
                                            ulong oraddr = _THUNK_DATA32.AddressOfData;
                                            _viewAccessor.Read((long)oraddr, out IMAGE_IMPORT_BY_NAME iibn);
                                            ext.Ordinal = iibn.Hint;
                                            ext.Name = GetStringAFromAddr((long)(oraddr + sizeof(short)));
                                        }
                                        ext.FuncRVA = null;
                                        importTable.Exports.Add(ext);

                                        FirstThunkInter += (uint)sizeof(IMAGE_THUNK_DATA32);
                                        _viewAccessor.Read((long)FirstThunkInter, out _THUNK_DATA32);
                                    }

                                    importTables.Add(importTable);

                                    IMPORT_DESCRIPTORBase += (uint)sizeof(IMAGE_IMPORT_DESCRIPTOR);
                                    _viewAccessor.Read((long)IMPORT_DESCRIPTORBase, out _IMPORT_DESCRIPTOR);
                                }
                            }
                            else
                            {
                                while (_IMPORT_DESCRIPTOR.GetHashCode() != null_IMPORT_DESCRIPTOR)
                                {
                                    importTable = new ImportTable
                                    {
                                        Exports = new List<ExportTable>(),
                                        Name = GetStringAFromAddr(_IMPORT_DESCRIPTOR.Name)
                                    };

                                    IMAGE_THUNK_DATA64 _THUNK_DATA64 = new IMAGE_THUNK_DATA64();
                                    int null_THUNK_DATA64 = _THUNK_DATA64.GetHashCode();
                                    ulong FirstThunkInter = _IMPORT_DESCRIPTOR.Characteristics_OriginalFirstThunk;
                                    _viewAccessor.Read((long)FirstThunkInter, out _THUNK_DATA64);

                                    ExportTable ext;

                                    while (_THUNK_DATA64.GetHashCode() != null_THUNK_DATA64)
                                    {
                                        ext = new ExportTable();
                                        if ((_THUNK_DATA64.AddressOfData >> 63) == 1)
                                        {
                                            ext.Ordinal = (ushort)_THUNK_DATA64.AddressOfData;
                                            ext.Name = string.Empty;
                                        }
                                        else
                                        {
                                            _viewAccessor.Read((long)_THUNK_DATA64.AddressOfData, out IMAGE_IMPORT_BY_NAME iibn);
                                            ext.Ordinal = iibn.Hint;
                                            ext.Name = GetStringAFromAddr(iibn.Name);
                                        }
                                        ext.FuncRVA = null;
                                        importTable.Exports.Add(ext);

                                        FirstThunkInter += (uint)sizeof(IMAGE_THUNK_DATA64);
                                        _viewAccessor.Read((long)FirstThunkInter, out _THUNK_DATA64);
                                    }

                                    importTables.Add(importTable);

                                    IMPORT_DESCRIPTORBase += (uint)sizeof(IMAGE_IMPORT_DESCRIPTOR);
                                    _viewAccessor.Read((long)IMPORT_DESCRIPTORBase, out _IMPORT_DESCRIPTOR);
                                }
                            }
                        }
                    }
                    catch 
                    {
                        isPEDamaged = true;
                    }

                    // ====================获取重定位表

                    try
                    {

                        idd = _DATA_DIRECTORYS[(int)DirectoryEntries.IMAGE_DIRECTORY_ENTRY_BASERELOC];
                        if (idd.VirtualAddress != 0 && idd.Size != 0)
                        {
                            var rInter = idd.VirtualAddress;
                            _viewAccessor.Read((long)rInter, out IMAGE_BASE_RELOCATION ir);
                            RelocateTable rt;
                            ulong rlimit = rInter + idd.Size;
                            uint rcount;
                            relocateTables = new List<RelocateTable>();

                            while (rInter < rlimit)
                            {
                                rt = new RelocateTable
                                {
                                    VirtualBase = ir.VirtualAddress
                                };
                                rcount = ir.SizeOfBlock / 2 - sizeof(int);

                                RelocateItem[] ritem = new RelocateItem[rcount];

                                _viewAccessor.ReadArray((long)(rInter + sizeof(long)), ritem, 0, (int)rcount);
                                rt.Relocitems = ritem;

                                relocateTables.Add(rt);

                                rInter += ir.SizeOfBlock;
                                _viewAccessor.Read((long)rInter, out ir);
                            }
                        }
                    }
                    catch 
                    {
                        isPEDamaged = true;
                    }

                    // ====================获取资源表

                    try
                    {
                        idd = _DATA_DIRECTORYS[(int)DirectoryEntries.IMAGE_DIRECTORY_ENTRY_RESOURCE];
                        if (idd.VirtualAddress != 0 && idd.Size != 0)
                        {
                            peData.RESOURCE_DIR_Addr = idd.VirtualAddress;

                            IMAGE_RESOURCE_DIRECTORY ird3;
                            IMAGE_RESOURCE_DIRECTORY_ENTRY[] pirde, pirde2, pirde3;
                            IMAGE_RESOURCE_DATA_ENTRY irdata;

                            ulong irdebase = peData.RESOURCE_DIR_Addr + (uint)sizeof(IMAGE_RESOURCE_DIRECTORY);

                            _viewAccessor.Read((long)peData.RESOURCE_DIR_Addr, out IMAGE_RESOURCE_DIRECTORY ird);

                            int len = ird.NumberOfIdEntries + ird.NumberOfNamedEntries;

                            ResourceTable res = new ResourceTable();
                            IMAGE_RESOURCE_DIR_STRING_U stringu;

                            pirde = new IMAGE_RESOURCE_DIRECTORY_ENTRY[len];
                            _viewAccessor.ReadArray((long)irdebase, pirde, 0, len);

                            resourceTables = new List<ResourceTable>();

                            for (int i = 0; i < len; i++)
                            {
                                if (pirde[i].NameIsString)
                                {
                                    _viewAccessor.Read((long)(peData.RESOURCE_DIR_Addr + pirde[i].NameOffset), out stringu);
                                    res.ResType = (ResourceType)pirde[i].Id;
                                    res.Name = GetStringUFromAddr((long)(peData.RESOURCE_DIR_Addr + pirde[i].NameOffset + sizeof(short)), stringu.Length);
                                    res.ID = null;
                                }
                                else
                                {
                                    res.Name = string.Empty;
                                    res.ID = pirde[i].Id;
                                }

                                if (pirde[i].DataIsDirectory)
                                {
                                    ulong irdebase2 = peData.RESOURCE_DIR_Addr + pirde[i].OffsetToDirectory;
                                    _viewAccessor.Read((long)irdebase2, out IMAGE_RESOURCE_DIRECTORY ird2);
                                    irdebase2 += (uint)sizeof(IMAGE_RESOURCE_DIRECTORY);
                                    int len1 = ird2.NumberOfIdEntries + ird2.NumberOfNamedEntries;

                                    pirde2 = new IMAGE_RESOURCE_DIRECTORY_ENTRY[len1];

                                    _viewAccessor.ReadArray((long)irdebase2, pirde2, 0, len1);

                                    for (int ii = 0; ii < len1; ii++) //第二层
                                    {
                                        if (pirde2[ii].NameIsString)
                                        {
                                            _viewAccessor.Read((long)(peData.RESOURCE_DIR_Addr + pirde2[ii].NameOffset), out stringu);
                                            res.ResName = GetStringUFromAddr((long)(peData.RESOURCE_DIR_Addr +
                                                pirde2[ii].NameOffset + sizeof(short)), stringu.Length);
                                            res.ResID = null;
                                        }
                                        else
                                        {
                                            res.ResName = string.Empty;
                                            res.ResID = pirde2[ii].Id;
                                        }

                                        ulong irdebase3 = peData.RESOURCE_DIR_Addr + pirde2[ii].OffsetToDirectory;
                                        _viewAccessor.Read((long)irdebase3, out ird3);
                                        irdebase3 += (uint)sizeof(IMAGE_RESOURCE_DIRECTORY);

                                        int len2 = ird3.NumberOfIdEntries + ird3.NumberOfNamedEntries;

                                        pirde3 = new IMAGE_RESOURCE_DIRECTORY_ENTRY[len2];
                                        _viewAccessor.ReadArray((long)irdebase3, pirde3, 0, len2);

                                        for (int iii = 0; iii < len2; iii++) //第三层
                                        {
                                            _viewAccessor.Read((long)(peData.RESOURCE_DIR_Addr + pirde3[iii].OffsetToData), out irdata);
                                            res.CodePage = irdata.CodePage;
                                            res.FOA = RVA2FOA(irdata.OffsetToData).Value;
                                            res.Size = irdata.Size;
                                            resourceTables.Add(res);
                                        }
                                    }
                                }
                                else
                                {
                                    res.ResID = res.ID;
                                    res.ResName = (string)res.Name.Clone();
                                    res.ID = null;
                                    res.ResName = string.Empty;

                                    ulong irdebase3 = peData.RESOURCE_DIR_Addr + pirde[i].OffsetToDirectory;
                                    _viewAccessor.Read((long)irdebase3, out ird3);
                                    irdebase3 += (uint)sizeof(IMAGE_RESOURCE_DIRECTORY);

                                    int len2 = ird3.NumberOfIdEntries + ird3.NumberOfNamedEntries;

                                    pirde3 = new IMAGE_RESOURCE_DIRECTORY_ENTRY[len2];
                                    _viewAccessor.ReadArray((long)irdebase3, pirde3, 0, len2);

                                    for (int iii = 0; iii < len2; iii++) //第三层
                                    {
                                        _viewAccessor.Read((long)(peData.RESOURCE_DIR_Addr + pirde3[iii].OffsetToData), out irdata);
                                        res.CodePage = irdata.CodePage;
                                        res.FOA = RVA2FOA(irdata.OffsetToData).Value;
                                        res.Size = irdata.Size;
                                        resourceTables.Add(res);
                                    }
                                }
                            }
                        }
                    }
                    catch 
                    {
                        isPEDamaged = true;
                    }

                    // ==================== 获取调试目录

                    try
                    {
                        idd = _DATA_DIRECTORYS[(int)DirectoryEntries.IMAGE_DIRECTORY_ENTRY_DEBUG];
                        if (idd.VirtualAddress != 0 && idd.Size != 0)
                        {
                            _viewAccessor.Read(idd.VirtualAddress, out IMAGE_DEBUG_DIRECTORY _DEBUG_DIRECTORY);
                            peData.SizeofDEBUG_DIR = _DEBUG_DIRECTORY.AddressOfRawData;
                            peData.DEBUG_DIR_Addr = _DEBUG_DIRECTORY.PointerToRawData;
                        }
                    }
                    catch
                    {
                        isPEDamaged = true;
                    }

                    // ==================== .NET程序目录

                    try
                    {
                        idd = _DATA_DIRECTORYS[(int)DirectoryEntries.IMAGE_DIRECTORY_ENTRY_COM_DESCRIPTOR];
                        if (idd.VirtualAddress != 0 && idd.Size != 0)
                        {
                            peData.COR20_HEADER_Addr = idd.VirtualAddress;
                            _viewAccessor.Read((long)peData.COR20_HEADER_Addr, out IMAGE_COR20_HEADER _COR20_HEADER);

                            netMeta = new DotNetMetaInfo();

                            if (_COR20_HEADER.MetaData.VirtualAddress != 0 && _COR20_HEADER.MetaData.Size != 0)
                            {
                                peData.MetaData_Addr = _COR20_HEADER.MetaData.VirtualAddress;
                                netMeta.STORAGESIGNATURE = new STORAGESIGNATURE();
                                netMeta.STORAGEHEADER = new STORAGEHEADER();

                                _viewAccessor.Read((long)peData.MetaData_Addr, out netMeta.STORAGESIGNATURE);
                                ulong pos = peData.MetaData_Addr + (uint)sizeof(STORAGESIGNATURE);
                                netMeta.pVersion = GetStringUTF8FromAddr(pos, (int)netMeta.STORAGESIGNATURE.iVersionString);
                                pos += netMeta.STORAGESIGNATURE.iVersionString;
                                _viewAccessor.Read((long)pos, out netMeta.STORAGEHEADER);
                                pos += (uint)sizeof(STORAGEHEADER);
                                iStreams = new Dictionary<string, STORAGESTREAM>();


                                for (int i = 0; i < netMeta.STORAGEHEADER.iStreams; i++)
                                {
                                    _viewAccessor.Read((long)pos, out STORAGESTREAM sTORAGESTREAM);
                                    pos += (uint)sizeof(STORAGESTREAM);
                                    string tmp = GetStringAFromAddr((long)pos);
                                    iStreams.Add(tmp, sTORAGESTREAM);
                                    pos += (ulong)Math.Ceiling((tmp.Length + 1) / 4.0D) * 4;
                                }

                                if (iStreams.ContainsKey("#~"))
                                {
                                    pos = peData.MetaData_Addr + iStreams["#~"].iOffset;
                                    _viewAccessor.Read((long)pos, out MDStreamHeader mDStreamHeader);

                                    BitArray bitArray = new BitArray(BitConverter.GetBytes(mDStreamHeader.MaskValid));
                                    int bcount = 0;

                                    foreach (bool item in bitArray)
                                    {
                                        if (item) bcount++;
                                    }

                                    //Dictionary<DotNetTables,>
                                    pos += (uint)sizeof(MDStreamHeader);
                                    int[] bu = new int[bcount];
                                    _viewAccessor.ReadArray((long)pos, bu, 0, bcount);
                                    //FieldInfo fieldInfo;
                                }
                            }

                            IsdotNetFile = true;
                        }
                    }
                    catch 
                    {
                        isPEDamaged = true;
                    }

                }
                catch
                {
                    isPEDamaged = true;
                }

                if (isPEDamaged)
                    return ParserError.PEDamaged;

                return ParserError.Success;

            }
        }

        private string GetStringUTF8FromAddr(ulong pos, int len)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                byte ch;
                for (uint i = 0; i < len; i++)
                {
                    ch = _viewAccessor.ReadByte((long)(pos + i));
                    if (ch == 0)
                    {
                        break;
                    }
                    memory.WriteByte(ch);
                }
                return Encoding.UTF8.GetString(memory.ToArray());
            }
        }

    }
}