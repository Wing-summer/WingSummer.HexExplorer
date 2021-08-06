using System;
using System.Collections.Generic;
using Be.Windows.Forms;
using PEProcesser;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PEHexExplorer
{
    class BookMarkPE
    {

        public Dictionary<PEPParser.PEStructType, List<HexBox.HighlightedRegion>> peRegions;

        //public List<HexBox.HighlightedRegion> regions;
        readonly MUserProfile mUser = UserSetting.UserProfile;

        private readonly bool Is32bit;
        private readonly bool processed;
        private readonly bool haserror;
        private const string exe32bit = "PE 文件 (32位)";
        private const string exe64bit = "PE 文件 (64位)";
        private const string exedefault = "PE 文件";
        private const string exeno = "PE 文件 (非PE文件或已损坏)";

        enum PEIndex
        {

        }

        public BookMarkPE(PEPParser parser)
        {
            if (parser == null)
            {
                throw new ArgumentNullException("PEPParser");
            }

            processed = parser.Processed;
            haserror = parser.OccurError;

            PEPParser.PEStructData data = parser.PEData;

            List<HexBox.HighlightedRegion> regions;

            peRegions = new Dictionary<PEPParser.PEStructType, List<HexBox.HighlightedRegion>>();
            HexBox.HighlightedRegion region;
            Type type;

            /*IMAGE_DOS_HEADER*/

            type = typeof(PEPParser.IMAGE_DOS_HEADER);
            regions = new List<HexBox.HighlightedRegion>();

            if (parser.IMAGE_DOS_HEADER_!=null)
            {
                region = new HexBox.HighlightedRegion
                {
                    Color = mUser.IMAGE_DOS_HEADER_Color,
                    Start = 0,
                    Length = Marshal.SizeOf(type)
                };

                regions.Add(region);
                peRegions.Add(PEPParser.PEStructType.IMAGE_DOS_HEADER, regions);
            }

            /*非32位和64位程序通用结构体处理*/

            if (parser.Is32Bit)
            {
                Is32bit = true;
                //type = typeof(PEPParser.IMAGE_NT_HEADERS32);
                if (data.NT_HEADER_Addr != 0)
                {
                    regions = new List<HexBox.HighlightedRegion>();
                    region = new HexBox.HighlightedRegion
                    {
                        Color = mUser.IMAGE_NT_HEADERS_Color,
                        Start = (int)data.NT_HEADER_Addr,
                        Length = sizeof(uint)
                    };
                    regions.Add(region);
                    peRegions.Add(PEPParser.PEStructType.IMAGE_NT_HEADERS, regions);
                }
            }
            else
            {
                Is32bit = false;
                //type = typeof(PEPParser.IMAGE_NT_HEADERS64);
                if (data.NT_HEADER_Addr != 0)
                {
                    regions = new List<HexBox.HighlightedRegion>();
                    region = new HexBox.HighlightedRegion
                    {
                        Color = mUser.IMAGE_NT_HEADERS_Color,
                        Start = (int)data.NT_HEADER_Addr,
                        Length = sizeof(uint)
                    };
                    regions.Add(region);
                    peRegions.Add(PEPParser.PEStructType.IMAGE_NT_HEADERS, regions);
                }
            }

            /*IMAGE_FILE_HEADER*/

            //type = typeof(PEPParser.IMAGE_FILE_HEADER);
            if (data.FILE_HEADER_Addr != 0)
            {
                regions = new List<HexBox.HighlightedRegion>();
                region = new HexBox.HighlightedRegion
                {
                    Color = mUser.IMAGE_FILE_HEADER_Color,
                    Start = (long)data.FILE_HEADER_Addr,
                    Length = PEPParser.IMAGE_SIZEOF_FILE_HEADER
                };
                regions.Add(region);
                peRegions.Add(PEPParser.PEStructType.IMAGE_FILE_HEADER, regions);
            }

            //type = typeof(PEPParser.IMAGE_OPTIONAL_HEADER32);
            if (data.OPTIONAL_HEADER_Addr != 0)
            {
                regions = new List<HexBox.HighlightedRegion>();
                region = new HexBox.HighlightedRegion
                {
                    Color = mUser.IMAGE_OPTIONAL_HEADER_Color,
                    Start = (int)data.OPTIONAL_HEADER_Addr,
                    Length = data.SizeOPTIONAL_HEADER
                };
                regions.Add(region);
                peRegions.Add(PEPParser.PEStructType.IMAGE_OPTIONAL_HEADER, regions);
            }

            /*IMAGE_DATA_DIRECTORY*/

            if (data.DATA_DIRECTORIES_Addr != 0)
            {
                type = typeof(PEPParser.IMAGE_DATA_DIRECTORY);
                regions = new List<HexBox.HighlightedRegion>();

                int DATA_DIRECTORIES_Size = Marshal.SizeOf(type);
                for (int i = 0; i < PEPParser.IMAGE_NUMBEROF_DIRECTORY_ENTRIES; i++)
                {
                    region = new HexBox.HighlightedRegion
                    {
                        Color = mUser.IMAGE_DATA_DIRECTORY_Color,
                        Start = (int)data.DATA_DIRECTORIES_Addr + DATA_DIRECTORIES_Size * i,
                        Length = DATA_DIRECTORIES_Size
                    };
                    regions.Add(region);
                }
                peRegions.Add(PEPParser.PEStructType.IMAGE_DATA_DIRECTORY, regions);
            }

            /*IMAGE_SECTION_HEADER*/

            if (data.SECTION_HEADERS_Addr!=0)
            {
                type = typeof(PEPParser.IMAGE_SECTION_HEADER);
                regions = new List<HexBox.HighlightedRegion>();
                int SECTION_HEADER_Size = Marshal.SizeOf(type);

                for (int i = 0; i < parser.PEData.NumberOfSections; i++)
                {
                    region = new HexBox.HighlightedRegion
                    {
                        Color = mUser.IMAGE_SECTION_HEADER_Color,
                        Start = (long)data.SECTION_HEADERS_Addr + i * SECTION_HEADER_Size,
                        Length = SECTION_HEADER_Size
                    };
                    regions.Add(region);
                }
                peRegions.Add(PEPParser.PEStructType.IMAGE_SECTION_HEADER, regions);
            }

            /*IMAGE_DATA_DIRECTORY_Item*/

            PEPParser.IMAGE_DATA_DIRECTORY[] idds = parser.IMAGE_DATA_DIRECTORIES; 
            regions = new List<HexBox.HighlightedRegion>();

            if (idds!=null)
            {
                for (int i = 0; i < PEPParser.IMAGE_NUMBEROF_DIRECTORY_ENTRIES; i++)
                {
                    PEPParser.IMAGE_DATA_DIRECTORY item = idds[i];
                    switch ((PEPParser.DirectoryEntries)i)
                    {
                        case PEPParser.DirectoryEntries.IMAGE_DIRECTORY_ENTRY_EXPORT:
                            if (item.VirtualAddress != 0 && item.Size != 0)
                            {
                                region = new HexBox.HighlightedRegion
                                {
                                    Color = mUser.IMAGE_EXPORT_DIRECTORY_Color,
                                    Start = (long)parser.RVA2FOA(item.VirtualAddress).Value,
                                    Length = item.Size
                                };
                                regions.Add(region);
                            }
                            break;
                        case PEPParser.DirectoryEntries.IMAGE_DIRECTORY_ENTRY_IMPORT:
                            if (item.VirtualAddress != 0 && item.Size != 0)
                            {
                                region = new HexBox.HighlightedRegion
                                {
                                    Color = mUser.IMAGE_IMPORT_DESCRIPTOR_Color,
                                    Start = (long)parser.RVA2FOA(item.VirtualAddress).Value,
                                    Length = item.Size
                                };
                                regions.Add(region);
                            }
                            break;
                        case PEPParser.DirectoryEntries.IMAGE_DIRECTORY_ENTRY_RESOURCE:
                            if (item.VirtualAddress != 0 && item.Size != 0)
                            {
                                region = new HexBox.HighlightedRegion
                                {
                                    Color = mUser.IMAGE_RESOURCE_DIRECTORY_Color,
                                    Start = (long)parser.RVA2FOA(item.VirtualAddress).Value,
                                    Length = item.Size
                                };
                                regions.Add(region);
                            }
                            break;
                        case PEPParser.DirectoryEntries.IMAGE_DIRECTORY_ENTRY_BASERELOC:
                            if (item.VirtualAddress != 0 && item.Size != 0)
                            {
                                region = new HexBox.HighlightedRegion
                                {
                                    Color = mUser.IMAGE_BASE_RELOCATION_Color,
                                    Start = (long)parser.RVA2FOA(item.VirtualAddress).Value,
                                    Length = item.Size
                                };
                                regions.Add(region);
                            }
                            break;
                        case PEPParser.DirectoryEntries.IMAGE_DIRECTORY_ENTRY_DEBUG:
                            if (item.VirtualAddress != 0 && item.Size != 0)
                            {
                                region = new HexBox.HighlightedRegion
                                {
                                    Color = mUser.IMAGE_Debug_DIRECTORY_Color,
                                    Start = (long)parser.RVA2FOA(item.VirtualAddress).Value,
                                    Length = item.Size
                                };
                                regions.Add(region);
                            }
                            break;
                        case PEPParser.DirectoryEntries.IMAGE_DIRECTORY_ENTRY_COM_DESCRIPTOR:
                            if (item.VirtualAddress != 0 && item.Size != 0)
                            {
                                region = new HexBox.HighlightedRegion
                                {
                                    Color = mUser.IMAGE_dotNetDIRECTORY_Color,
                                    Start = (long)parser.RVA2FOA(item.VirtualAddress).Value,
                                    Length = item.Size
                                };
                                regions.Add(region);
                            }
                            break;
                        case PEPParser.DirectoryEntries.IMAGE_DIRECTORY_ENTRY_EXCEPTION:
                        case PEPParser.DirectoryEntries.IMAGE_DIRECTORY_ENTRY_SECURITY:
                        case PEPParser.DirectoryEntries.IMAGE_DIRECTORY_ENTRY_ARCHITECTURE:
                        case PEPParser.DirectoryEntries.IMAGE_DIRECTORY_ENTRY_GLOBALPTR:
                        case PEPParser.DirectoryEntries.IMAGE_DIRECTORY_ENTRY_TLS:
                        case PEPParser.DirectoryEntries.IMAGE_DIRECTORY_ENTRY_LOAD_CONFIG:
                        case PEPParser.DirectoryEntries.IMAGE_DIRECTORY_ENTRY_BOUND_IMPORT:
                        case PEPParser.DirectoryEntries.IMAGE_DIRECTORY_ENTRY_IAT:
                        case PEPParser.DirectoryEntries.IMAGE_DIRECTORY_ENTRY_DELAY_IMPORT:

                            if (item.VirtualAddress != 0 && item.Size != 0)
                            {
                                region = new HexBox.HighlightedRegion
                                {
                                    Color = mUser.Image_OtherColor,
                                    Start = (long)parser.RVA2FOA(item.VirtualAddress).Value,
                                    Length = item.Size
                                };
                                regions.Add(region);
                            }
                            break;
                    }
                }
                peRegions.Add(PEPParser.PEStructType.IMAGE_DATA_DIRECTORY_Content, regions);
            }


        }

        public void ApplyHexbox(in HexBox hexBox)
        {
            if (hexBox == null)
            {
                throw new ArgumentNullException();
            }
            if (peRegions == null)
            {
                return;
            }
            foreach (var item in peRegions)
            {
                foreach (var iitem in item.Value)
                {
                    hexBox.AddHighligedRegion(iitem);
                }
            }
        }

        public void ApplyTreeView(in TreeView treeView)
        {

            TreeNodeCollection collection = treeView.Nodes;
            try
            {
                if (processed)
                {
                    if (haserror)
                    {
                        collection[0].Text = exeno;
                    }
                    else
                    {
                        if (Is32bit)
                        {
                            collection[0].Text = exe32bit;
                        }
                        else
                        {
                            collection[0].Text = exe64bit;
                        }
                    }
                }
                else
                {
                    collection[0].Text = exedefault;
                }
            }
            catch
            {
            }

            collection = collection[0].Nodes;

        }

    }
}
