using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace PEProcesser
{
    public partial class PEPParser
    {
        #region 自定义的结构体

        public struct PEStructData
        {
            public uint ImageSize;
            public ulong FileSize;
            public uint SizeOfHeaders;

            public ulong ImageBase;
            public uint FileAlign;
            public uint VirtualAlign;
            public uint NumberOfSections;
            public ulong NT_HEADER_Addr;
            public ulong FILE_HEADER_Addr;
            public ulong OPTIONAL_HEADER_Addr;
            public uint SizeOPTIONAL_HEADER;
            public ulong DATA_DIRECTORIES_Addr;
            public ulong DEBUG_DIR_Addr;
            public uint SizeofDEBUG_DIR;
            public ulong RESOURCE_DIR_Addr;
            public ulong SECTION_HEADERS_Addr;
            public ulong COR20_HEADER_Addr;
            public ulong MetaData_Addr;
        };

        public struct ExportTable
        {
            public uint Ordinal;
            public string Name;
            public uint? FuncRVA;
        };

        public struct ImportTable
        {
            public string Name;
            public List<ExportTable> Exports;
        };

        public struct RelocateItem
        {
#pragma warning disable CS0649
            private readonly ushort Data;
#pragma warning restore CS0649

            public uint Offset { get { return (uint)(Data & 0xFFF); } }
            public uint Type { get { return (uint)(Data >> 12); } }
        };

        public struct RelocateTable
        {
            public uint VirtualBase;
            public RelocateItem[] Relocitems;
        };

        public struct ResourceTable
        {
            public ResourceType ResType; //数据类型
            public string Name;         //数据根目录名称
            public string ResName;      //资源名称
            public uint? ID;               //根目录ID
            public uint? ResID;            //数据ID
            public uint CodePage;         //代码页
            public ulong FOA;        //数据FOA
            public ulong Size;            //大小
        };

        public struct DotNetMetaInfo
        {
            public STORAGESIGNATURE STORAGESIGNATURE;
            public string pVersion;
            public STORAGEHEADER STORAGEHEADER;
        }

        #endregion

        #region 普通PE文件结构体

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public unsafe struct IMAGE_DOS_HEADER
        {      // DOS .EXE header
            public ushort e_magic;                     // Magic number
            public ushort e_cblp;                      // Bytes on last page of file
            public ushort e_cp;                        // Pages in file
            public ushort e_crlc;                      // Relocations
            public ushort e_cparhdr;                   // Size of header in paragraphs
            public ushort e_minalloc;                  // Minimum extra paragraphs needed
            public ushort e_maxalloc;                  // Maximum extra paragraphs needed
            public ushort e_ss;                        // Initial (relative) SS value
            public ushort e_sp;                        // Initial SP value
            public ushort e_csum;                      // Checksum
            public ushort e_ip;                        // Initial IP value
            public ushort e_cs;                        // Initial (relative) CS value
            public ushort e_lfarlc;                    // File address of relocation table
            public ushort e_ovno;                      // Overlay number

            public fixed ushort e_res[4];                  // Reserved shorts
            public ushort e_oemid;                     // OEM identifier (for e_oeminfo)
            public ushort e_oeminfo;                   // OEM information; e_oemid specific

            public fixed ushort e_res2[10];                  // Reserved shorts
            public uint e_lfanew;                    // File address of new exe header
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public class IMAGE_NT_HEADERS64
        {
            public uint Signature;
            public IMAGE_FILE_HEADER FileHeader;
            public IMAGE_OPTIONAL_HEADER64 OptionalHeader;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public class IMAGE_NT_HEADERS32
        {
            public uint Signature;
            public IMAGE_FILE_HEADER FileHeader;
            public IMAGE_OPTIONAL_HEADER32 OptionalHeader;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct IMAGE_FILE_HEADER
        {
            public ushort Machine;
            public ushort NumberOfSections;
            public uint TimeDateStamp;
            public uint PointerToSymbolTable;
            public uint NumberOfSymbols;
            public ushort SizeOfOptionalHeader;
            public ushort Characteristics;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public unsafe struct IMAGE_OPTIONAL_HEADER32
        {
            //
            // Standard fields.
            //

            public ushort Magic;
            public byte MajorLinkerVersion;
            public byte MinorLinkerVersion;
            public uint SizeOfCode;
            public uint SizeOfInitializedData;
            public uint SizeOfUninitializedData;
            public uint AddressOfEntryPoint;
            public uint BaseOfCode;
            public uint BaseOfData;

            //
            // NT additional fields.
            //

            public uint ImageBase;
            public uint SectionAlignment;
            public uint FileAlignment;
            public ushort MajorOperatingSystemVersion;
            public ushort MinorOperatingSystemVersion;
            public ushort MajorImageVersion;
            public ushort MinorImageVersion;
            public ushort MajorSubsystemVersion;
            public ushort MinorSubsystemVersion;
            public uint Win32VersionValue;
            public uint SizeOfImage;
            public uint SizeOfHeaders;
            public uint CheckSum;
            public ushort Subsystem;
            public ushort DllCharacteristics;
            public uint SizeOfStackReserve;
            public uint SizeOfStackCommit;
            public uint SizeOfHeapReserve;
            public uint SizeOfHeapCommit;
            public uint LoaderFlags;
            public uint NumberOfRvaAndSizes;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = IMAGE_NUMBEROF_DIRECTORY_ENTRIES,
                ArraySubType = UnmanagedType.Struct)]
            public IMAGE_DATA_DIRECTORY[] DataDirectory;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public unsafe struct IMAGE_OPTIONAL_HEADER64
        {
            public ushort Magic;
            public byte MajorLinkerVersion;
            public byte MinorLinkerVersion;
            public uint SizeOfCode;
            public uint SizeOfInitializedData;
            public uint SizeOfUninitializedData;
            public uint AddressOfEntryPoint;
            public uint BaseOfCode;
            public ulong ImageBase;
            public uint SectionAlignment;
            public uint FileAlignment;
            public ushort MajorOperatingSystemVersion;
            public ushort MinorOperatingSystemVersion;
            public ushort MajorImageVersion;
            public ushort MinorImageVersion;
            public ushort MajorSubsystemVersion;
            public ushort MinorSubsystemVersion;
            public uint Win32VersionValue;
            public uint SizeOfImage;
            public uint SizeOfHeaders;
            public uint CheckSum;
            public ushort Subsystem;
            public ushort DllCharacteristics;
            public ulong SizeOfStackReserve;
            public ulong SizeOfStackCommit;
            public ulong SizeOfHeapReserve;
            public ulong SizeOfHeapCommit;
            public uint LoaderFlags;
            public uint NumberOfRvaAndSizes;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = IMAGE_NUMBEROF_DIRECTORY_ENTRIES)]
            public IMAGE_DATA_DIRECTORY[] DataDirectory;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct IMAGE_DATA_DIRECTORY
        {
            public uint VirtualAddress;
            public uint Size;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public unsafe struct IMAGE_SECTION_HEADER
        {
            public fixed byte Name[IMAGE_SIZEOF_SHORT_NAME];
            public uint VirtualSize_PhysicalAddress;
            public uint VirtualAddress;
            public uint SizeOfRawData;
            public uint PointerToRawData;
            public uint PointerToRelocations;
            public uint PointerToLinenumbers;
            public ushort NumberOfRelocations;
            public ushort NumberOfLinenumbers;
            public uint Characteristics;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct IMAGE_EXPORT_DIRECTORY
        {
            public uint Characteristics;
            public uint TimeDateStamp;
            public ushort MajorVersion;
            public ushort MinorVersion;
            public uint Name;
            public uint Base;
            public uint NumberOfFunctions;
            public uint NumberOfNames;
            public uint AddressOfFunctions;     // RVA from base of image
            public uint AddressOfNames;         // RVA from base of image
            public uint AddressOfNameOrdinals;  // RVA from base of image
        }

        [StructLayout(LayoutKind.Explicit, Pack = 1)]
        public struct IMAGE_THUNK_DATA32
        {
            [FieldOffset(0)]
            public uint ForwarderString;      // PBYTE

            [FieldOffset(0)]
            public uint Function;             // PDWORD

            [FieldOffset(0)]
            public uint Ordinal;

            [FieldOffset(0)]
            public uint AddressOfData;        // PIMAGE_IMPORT_BY_NAME
        }

        [StructLayout(LayoutKind.Explicit, Pack = 1)]
        public struct IMAGE_THUNK_DATA64
        {
            [FieldOffset(0)]
            public ulong ForwarderString;      // PBYTE

            [FieldOffset(0)]
            public ulong Function;             // PDWORD

            [FieldOffset(0)]
            public ulong Ordinal;

            [FieldOffset(0)]
            public ulong AddressOfData;        // PIMAGE_IMPORT_BY_NAME
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct IMAGE_IMPORT_DESCRIPTOR
        {
            public uint Characteristics_OriginalFirstThunk;

            // 0 for terminating null import descriptor
            // RVA to original unbound IAT (PIMAGE_THUNK_DATA)
            public uint TimeDateStamp;   // 0 if not bound,

            // -1 if bound, and real date\time stamp
            //     in IMAGE_DIRECTORY_ENTRY_BOUND_IMPORT (new BIND)
            // O.W. date/time stamp of DLL bound to (Old BIND)

            public uint ForwarderChain;                 // -1 if no forwarders
            public uint Name;
            public uint FirstThunk;                     // RVA to IAT (if bound this IAT has actual addresses)
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public unsafe struct IMAGE_IMPORT_BY_NAME
        {
            public ushort Hint;
            public byte Name;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct IMAGE_RESOURCE_DIRECTORY
        {
            public uint Characteristics;
            public uint TimeDateStamp;
            public ushort MajorVersion;
            public ushort MinorVersion;
            public ushort NumberOfNamedEntries;
            public ushort NumberOfIdEntries;
            //  IMAGE_RESOURCE_DIRECTORY_ENTRY DirectoryEntries[];
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct IMAGE_RESOURCE_DIRECTORY_ENTRY
        {
            public uint Name;
            public uint OffsetToData;

            public uint NameOffset { get { return (uint)(Name & 0x7FFFFFFF); } }
            public ushort Id { get { return (ushort)Name; } }
            public bool NameIsString { get { return (Name >> 31 == 1); } }

            public uint OffsetToDirectory { get { return (uint)(OffsetToData & 0x7FFFFFFF); } }
            public bool DataIsDirectory { get { return (OffsetToData >> 31 == 1); } }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct IMAGE_RESOURCE_DATA_ENTRY
        {
            public uint OffsetToData;
            public uint Size;
            public uint CodePage;
            public uint Reserved;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct IMAGE_RESOURCE_DIR_STRING_U
        {
            public ushort Length;
            public char NameString;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct IMAGE_BASE_RELOCATION
        {
            public uint VirtualAddress;
            public uint SizeOfBlock;
            //  WORD    TypeOffset[1];
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct IMAGE_DEBUG_DIRECTORY
        {
            public uint Characteristics;
            public uint TimeDateStamp;
            public ushort MajorVersion;
            public ushort MinorVersion;
            public uint Type;
            public uint SizeOfData;
            public uint AddressOfRawData;
            public uint PointerToRawData;
        }

        #endregion

        #region Net程序文件结构体

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct IMAGE_COR20_HEADER
        {
            // Header versioning
            public uint cb;

            public ushort MajorRuntimeVersion;
            public ushort MinorRuntimeVersion;

            // Symbol table and startup information
            public IMAGE_DATA_DIRECTORY MetaData;

            public uint Flags;

            // If COMIMAGE_FLAGS_NATIVE_ENTRYPOINT is not set, EntryPointToken represents a managed entrypoint.
            // If COMIMAGE_FLAGS_NATIVE_ENTRYPOINT is set, EntryPointRVA represents an RVA to a native entrypoint.
            public uint EntryPointToken_EntryPointRVA;

            // Binding information
            public IMAGE_DATA_DIRECTORY Resources;

            public IMAGE_DATA_DIRECTORY StrongNameSignature;

            // Regular fixup and binding information
            public IMAGE_DATA_DIRECTORY CodeManagerTable;

            public IMAGE_DATA_DIRECTORY VTableFixups;
            public IMAGE_DATA_DIRECTORY ExportAddressTableJumps;

            // Precompiled image info (internal use only - set to zero)
            public IMAGE_DATA_DIRECTORY ManagedNativeHeader;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct STORAGESIGNATURE
        {
            public uint lSignature;
            public ushort iMajorVer;
            public ushort iMinorVer;
            public uint iExtraData;
            public uint iVersionString;
            // public byte pVersion;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct STORAGEHEADER
        {
            public byte fFlags;
            public byte pad;
            public ushort iStreams;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct STORAGESTREAM
        {
            public uint iOffset;
            public uint iSize;

            //public byte rcName;  按4个字节对齐
            public ulong GetFOA(ulong Base)
            {
                return Base + iOffset;
            }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct MDStreamHeader
        {
            public uint Reserved;
            public byte Major;
            public byte Minor;
            public byte Heaps;
            public byte Rid;
            public ulong MaskValid;
            public ulong Sorted;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct DotNetModule
        {
            public ushort Generation;   //2-byte value, reserved, shall be zero
            public ushort Name;         // index into the String heap
            public ushort Mvid;           //index into the GUID heap; simply a GUID used to distinguish between

            //two versions of the same module
            public ushort EncId;            // index into GUID heap, reserved, shall be zero

            public ushort EncBaseId;     // index into GUID heap, reserved, shall be zero
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct DotNetTypeRef
        {
            public ushort ResolutionScope;      // index into Module, ModuleRef, AssemblyRef or TypeRef tables, or null;

            // more precisely, a ResolutionScope coded index
            public ushort TypeName;             // index into String heap

            public ushort TypeNamespace;        // index into String heap
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct DotNetTypeDef
        {
            public CorTypeAttr Flags;                             // a 4-byte bit mask of type TypeAttributes
            public ushort TypeName;                // index into String heap
            public ushort TypeNamespace;        // index into String heap
            public ushort Extends;                      // index into TypeDef, TypeRef or TypeSpec table; more precisely,

            // a TypeDefOrRef coded index
            public ushort FieldList;            // index into Field table

            public ushort MethodList;       // index into MethodDef table
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct DotNetField
        {
            public CorFieldAttr Flags;            // a 2-byte bit mask of type FieldAttributes
            public ushort Name;         // index into String heap
            public ushort Signature;    // index into Blob heap
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct DotNetMethodDef
        {
            public uint RVA;// a 4-byte constant
            public ushort ImplFlags;// a 2-byte bit mask of type MethodImplAttributes
            public ushort Flags;// a 2-byte bit mask of type MethodAttribute
            public ushort Name;// index into String heap
            public ushort Signature;// index into Blob heap
            public ushort ParamList;// index into the Param table
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct DotNetParam
        {
            public CorParamAttr Flags;        // a 2-byte bit mask of type ParamAttributes
            public ushort Sequence; // a 2-byte constant
            public ushort Name;       // index into String heap
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct DotNetInterfaceImpl
        {
            public ushort Class;        // index into the TypeDef table
            public ushort Interface; // index into the TypeDef, TypeRef or TypeSpec table; more precisely, a TypeDefOrRef coded index
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct DotNetMemberRef
        {
            public ushort Class;       // index into the TypeRef, ModuleRef, MethodDef, TypeSpec, or TypeDef tables;

            // more precisely, a MemberRefParent coded index
            public ushort Name;     // index into String heap

            public ushort Signature;// index into Blob heap
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct DotNetConstant
        {
            public byte Type;           // a 1-byte constant, followed by a 1-byte padding zero
            public byte Padding;    //对齐用，没啥用，值为0
            public ushort Parent;   //index into the Param or Field or Property table; more precisely, a HasConstant coded index
            public ushort Value;    // index into Blob heap
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct DotNetCustomAttribute
        {
            public ushort Parent;      // index into any metadata table, except the CustomAttribute table itself;

            // more precisely, a HasCustomAttribute coded index
            public ushort Type;     // index into the MethodDef or MethodRef table; more precisely, a CustomAttributeType coded index

            public ushort Value;    // index into Blob heap
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct DotNetFieldMarshal
        {
            public ushort Parent;           // index into Field or Param table; more precisely, a HasFieldMarshal coded index
            public ushort NativeType;   // index into the Blob heap
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct DotNetDeclSecurity
        {
            public ushort Action;   // 2-byte value
            public ushort Parent;   // index into the TypeDef, MethodDef, or Assembly table; more precisely, a HasDeclSecurity coded index
            public ushort PermissionSet;    // index into Blob heap
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct DotNetClassLayout
        {
            public ushort PackingSize;      // a 2-byte constant
            public uint ClassSize;              // a 4-byte constant
            public ushort Parent;              // index into TypeDef table
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct DotNetFieldLayout
        {
            public uint Offset;      // a 4-byte constant
            public ushort Field;    // index into the Field table
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct DotNetStandAloneSig
        {
            public ushort Signature;// index into Blob heap
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct DotNetEventMap
        {
            public ushort Parent;       // index into the TypeDef table
            public ushort EventList;    //index into Event table
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct DotNetEvent
        {
            public ushort EventFlags;// a 2-byte bit mask of type EventAttribute
            public ushort Name;// index into String heap
            public CorEventAttr EventType;// index into TypeDef, TypeRef, or TypeSpec tables; more precisely, a TypeDefOrRef coded index)
                                          // [this corresponds to the Type of the Event; it is not the Type that owns this event].
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct DotNetPropertyMap
        {
            public ushort Parent;// index into the TypeDef table
            public ushort PropertyList;// index into Property table
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct DotNetProperty
        {
            public ushort Flags;// a 2-byte bit mask of type PropertyAttributes
            public ushort Name;// index into String heap
            public ushort ushortType;//(index into Blob heap [The name of this column is misleading.It does not index a TypeDef or
                                     //TypeRef table – instead it indexes the signature in the Blob heap of the Property
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct DotNetMethodSemantics
        {
            public ushort Semantics;        // a 2-byte bit mask of type MethodSemanticsAttributes
            public ushort Method;           // index into the MethodDef table
            public ushort Association;      // index into the Event or Property table; more precisely, a HasSemantics coded index
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct DotNetMethodImpl
        {
            public ushort Class;        // index into TypeDef table
            public ushort MethodBody;           // index into MethodDef or MemberRef table; more precisely, a MethodDefOrRef coded index
            public ushort MethodDeclaration;      // index into MethodDef or MemberRef table; more precisely, a MethodDefOrRef coded index
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct DotNetModuleRef
        {
            public ushort Name;// index into String heap
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct DotNetTypeSpec
        {
            public ushort Signature;// index into Blob heap
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct DotNetImplMap
        {
            public ushort MappingFlags;   //a 2-byte bit mask of type PInvokeAttributes
            public ushort MemberForwarded;         //index into the Field or MethodDef table; more precisely, a MemberForwarded coded index.

            //However, it only ever indexes the MethodDef table, since Field export is not supported
            public ushort ImportName;           //index into the String heap

            public ushort ImportScope;            // index into the ModuleRef table
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct DotNetFieldRVA
        {
            public uint RVA;// a 4-byte constant
            public ushort Field;// index into Field table
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct DotNetAssembly
        {
            public uint HashAlgId;// a 4-byte constant of type AssemblyHashAlgorithm

            public ushort MajorVersion;
            public ushort MinorVersion;
            public ushort BuildNumber;
            public ushort RevisionNumber;

            public uint Flags;// a 4-byte bit mask of type AssemblyFlags
            public ushort PublicKey;// index into Blob heap
            public ushort Name;// index into String heap
            public ushort Culture;// index into the String table
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct DotNetAssemblyProcessor
        {
            public uint Processor;// a 4-byte constant
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct DotNetAssemblyOS
        {
            public uint OSPlatformID;// a 4-byte constant
            public uint OSMajorVersion;// a 4-byte constant
            public uint OSMinorVersion;// a 4-byte constant
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct DotNetAssemblyRef
        {
            public ushort MajorVersion;
            public ushort MinorVersion;
            public ushort BuildNumber;
            public ushort RevisionNumber;
            public uint Flags;// a 4-byte bit mask of type AssemblyFlags
            public ushort PublicKey_Token;// index into Blob heap
            public ushort Name;// index into String heap
            public ushort Culture;// index into the String table
            public ushort HashValue;// index into the Blob  table
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct DotNetAssemblyRefProcessor
        {
            public uint Processor;// a 4-byte constant
            public ushort AssemblyRef;//index into the AssemblyRef table
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct DotNetAssemblyRefOS
        {
            public uint OSPlatformID;// a 4-byte constant
            public uint OSMajorVersion;// a 4-byte constant
            public uint OSMinorVersion;// a 4-byte constant
            public ushort AssemblyRef;//index into the AssemblyRef table
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct DotNetFile
        {
            public uint Flags;//a 4-byte bit mask of type FileAttributes
            public ushort Name;//index into the String table
            public ushort HashValue;//index into the Blob table
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct DotNetExportedType
        {
            public uint Flags;//a 4-byte bit mask of type TypeAttributes
            public uint TypeDefId;//4-byte index into a TypeDef table of another module in this Assembly
            public ushort TypeName;//index into the String  table
            public ushort TypeNamespace;//index into the String  table
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct DotNetManifestResource
        {
            public uint Offset;//a 4-byte constant
            public uint Flags;//a 4-byte bit mask of type TypeAttributes
            public ushort Name;//index into the String  table
            public ushort Implementation;//index into File table, or AssemblyRef table, or null; more precisely, an Implementation coded index
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct DotNetNestedClass
        {
            public ushort NestedClass;//index into the TypeDef table
            public ushort EnclosingClass;//index into the TypeDef table
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct DotNetGenericParam
        {
            public ushort Number;//the 2-byte index of the generic parameter, numbered left-to-right, from zero
            public ushort Flags;//a 2-byte bitmask of type GenericParamAttributes
            public ushort Owner;//an index into the TypeDef or MethodDef table,

            //specifying the Type or Method to which this generic parameter applies; more precisely,
            //a TypeOrMethodDef coded index
            public ushort Name;//a non-null index into the String heap, giving the name for the generic parameter.

            //This is purely descriptive and is used only by source language compilers and by Reflection
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct DotNetGenericParamConstraint
        {
            public ushort Owner;//an index into the GenericParam table, specifying to which generic parameter this row refers
            public ushort Constraint;//an index into the TypeDef, TypeRef, or TypeSpec tables, specifying from which class this
                                     //generic parameter is constrained to derive; or which interface this generic parameter is constrained
                                     //to implement; more precisely, a TypeDefOrRef coded index
        }

        #endregion
    }
}