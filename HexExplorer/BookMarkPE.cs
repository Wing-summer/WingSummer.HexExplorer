using System;
using System.Collections.Generic;
using Be.Windows.Forms;
using PEProcesser;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace HexExplorer
{
    class BookMarkPE
    {

        public Dictionary<PEPParser.PEStructType, HexBox.HighlightedRegion> peRegions;
        private readonly List<TreeNode> tnDataDir;
        private readonly List<TreeNode> tnSection;

        readonly MUserProfile mUser = UserSetting.UserProfile;

        private readonly bool Is32bit;
        private readonly bool processed;
        private readonly bool haserror;
        private const string exe32bit = "PE 文件 (32位)";
        private const string exe64bit = "PE 文件 (64位)";
        private const string exedefault = "PE 文件";
        private const string exeno = "PE 文件 (非PE文件或已损坏)";


        public BookMarkPE(PEPParser parser)
        {
            if (parser == null)
            {
                throw new ArgumentNullException("PEPParser");
            }

            processed = parser.Processed;
            haserror = parser.OccurError;

            PEPParser.PEStructData data = parser.PEData;


            peRegions = new Dictionary<PEPParser.PEStructType, HexBox.HighlightedRegion>();

            HexBox.HighlightedRegion region;
            Type type;

            /*IMAGE_DOS_HEADER*/

            type = typeof(PEPParser.IMAGE_DOS_HEADER);

            if (parser.IMAGE_DOS_HEADER_!=null)
            {
                region = new HexBox.HighlightedRegion
                {
                    Color = mUser.IMAGE_DOS_HEADER_Color,
                    Start = 0,
                    Length = Marshal.SizeOf(type)
                };

                peRegions.Add(PEPParser.PEStructType.IMAGE_DOS_HEADER, region);
            }

            /*非32位和64位程序通用结构体处理*/

            if (parser.Is32Bit)
            {
                Is32bit = true;
                //type = typeof(PEPParser.IMAGE_NT_HEADERS32);
                if (data.NT_HEADER_Addr != 0)
                {
                    region = new HexBox.HighlightedRegion
                    {
                        Color = mUser.IMAGE_NT_HEADERS_Color,
                        Start = (int)data.NT_HEADER_Addr,
                        Length = sizeof(uint)
                    };
                    peRegions.Add(PEPParser.PEStructType.IMAGE_NT_HEADERS, region);
                }
            }
            else
            {
                Is32bit = false;
                //type = typeof(PEPParser.IMAGE_NT_HEADERS64);
                if (data.NT_HEADER_Addr != 0)
                {
                    region = new HexBox.HighlightedRegion
                    {
                        Color = mUser.IMAGE_NT_HEADERS_Color,
                        Start = (int)data.NT_HEADER_Addr,
                        Length = sizeof(uint)
                    };
                    peRegions.Add(PEPParser.PEStructType.IMAGE_NT_HEADERS, region);
                }
            }

            /*IMAGE_FILE_HEADER*/

            //type = typeof(PEPParser.IMAGE_FILE_HEADER);
            if (data.FILE_HEADER_Addr != 0)
            {
                region = new HexBox.HighlightedRegion
                {
                    Color = mUser.IMAGE_FILE_HEADER_Color,
                    Start = (long)data.FILE_HEADER_Addr,
                    Length = PEPParser.IMAGE_SIZEOF_FILE_HEADER
                };
                peRegions.Add(PEPParser.PEStructType.IMAGE_FILE_HEADER, region);
            }

            //type = typeof(PEPParser.IMAGE_OPTIONAL_HEADER32);
            if (data.OPTIONAL_HEADER_Addr != 0)
            {
                region = new HexBox.HighlightedRegion
                {
                    Color = mUser.IMAGE_OPTIONAL_HEADER_Color,
                    Start = (int)data.OPTIONAL_HEADER_Addr,
                    Length = data.SizeOPTIONAL_HEADER
                };
                peRegions.Add(PEPParser.PEStructType.IMAGE_OPTIONAL_HEADER, region);
            }

            /*IMAGE_DATA_DIRECTORY*/
            tnDataDir = new List<TreeNode>();
            TreeNode node;

            if (data.DATA_DIRECTORIES_Addr != 0)
            {
                type = typeof(PEPParser.IMAGE_DATA_DIRECTORY);

                int DATA_DIRECTORIES_Size = Marshal.SizeOf(type);
                node = new TreeNode("IMAGE_DATA_DIRECTORY_Item", 2, 2);
                region = new HexBox.HighlightedRegion
                {
                    Color = mUser.IMAGE_DATA_DIRECTORY_Color,
                    Start = (int)data.DATA_DIRECTORIES_Addr,
                    Length = DATA_DIRECTORIES_Size
                };
                node.Tag = region;
                tnDataDir.Add(node);
                peRegions.Add(PEPParser.PEStructType.IMAGE_DATA_DIRECTORY, region);
            }

            /*IMAGE_SECTION_HEADER*/
            tnSection = new List<TreeNode>();


            if (data.SECTION_HEADERS_Addr!=0)
            {
                type = typeof(PEPParser.IMAGE_SECTION_HEADER);
                int SECTION_HEADER_Size = Marshal.SizeOf(type);

                node = new TreeNode("IMAGE_SECTION_HEADER", 2, 2);
                region = new HexBox.HighlightedRegion
                {
                    Color = mUser.IMAGE_SECTION_HEADER_Color,
                    Start = (long)data.SECTION_HEADERS_Addr,
                    Length = SECTION_HEADER_Size
                };
                node.Tag = region;
                tnSection.Add(node);
                peRegions.Add(PEPParser.PEStructType.IMAGE_SECTION_HEADER, region);
            }

            /*IMAGE_DATA_DIRECTORY_Item*/

            //PEPParser.IMAGE_DATA_DIRECTORY[] idds = parser.IMAGE_DATA_DIRECTORIES; 

            //if (idds!=null)
            //{
            //    for (int i = 0; i < PEPParser.IMAGE_NUMBEROF_DIRECTORY_ENTRIES; i++)
            //    {
            //        PEPParser.IMAGE_DATA_DIRECTORY item = idds[i];
            //        switch ((PEPParser.DirectoryEntries)i)
            //        {
            //            case PEPParser.DirectoryEntries.IMAGE_DIRECTORY_ENTRY_EXPORT:
            //                if (item.VirtualAddress != 0 && item.Size != 0)
            //                {
            //                    region = new HexBox.HighlightedRegion
            //                    {
            //                        Color = mUser.IMAGE_EXPORT_DIRECTORY_Color,
            //                        Start = (long)parser.RVA2FOA(item.VirtualAddress).Value,
            //                        Length = item.Size
            //                    };
            //                }
            //                break;
            //            case PEPParser.DirectoryEntries.IMAGE_DIRECTORY_ENTRY_IMPORT:
            //                if (item.VirtualAddress != 0 && item.Size != 0)
            //                {
            //                    region = new HexBox.HighlightedRegion
            //                    {
            //                        Color = mUser.IMAGE_IMPORT_DESCRIPTOR_Color,
            //                        Start = (long)parser.RVA2FOA(item.VirtualAddress).Value,
            //                        Length = item.Size
            //                    };
            //                }
            //                break;
            //            case PEPParser.DirectoryEntries.IMAGE_DIRECTORY_ENTRY_RESOURCE:
            //                if (item.VirtualAddress != 0 && item.Size != 0)
            //                {
            //                    region = new HexBox.HighlightedRegion
            //                    {
            //                        Color = mUser.IMAGE_RESOURCE_DIRECTORY_Color,
            //                        Start = (long)parser.RVA2FOA(item.VirtualAddress).Value,
            //                        Length = item.Size
            //                    };
            //                }
            //                break;
            //            case PEPParser.DirectoryEntries.IMAGE_DIRECTORY_ENTRY_BASERELOC:
            //                if (item.VirtualAddress != 0 && item.Size != 0)
            //                {
            //                    region = new HexBox.HighlightedRegion
            //                    {
            //                        Color = mUser.IMAGE_BASE_RELOCATION_Color,
            //                        Start = (long)parser.RVA2FOA(item.VirtualAddress).Value,
            //                        Length = item.Size
            //                    };
            //                }
            //                break;
            //            case PEPParser.DirectoryEntries.IMAGE_DIRECTORY_ENTRY_DEBUG:
            //                if (item.VirtualAddress != 0 && item.Size != 0)
            //                {
            //                    region = new HexBox.HighlightedRegion
            //                    {
            //                        Color = mUser.IMAGE_Debug_DIRECTORY_Color,
            //                        Start = (long)parser.RVA2FOA(item.VirtualAddress).Value,
            //                        Length = item.Size
            //                    };
            //                }
            //                break;
            //            case PEPParser.DirectoryEntries.IMAGE_DIRECTORY_ENTRY_COM_DESCRIPTOR:
            //                if (item.VirtualAddress != 0 && item.Size != 0)
            //                {
            //                    region = new HexBox.HighlightedRegion
            //                    {
            //                        Color = mUser.IMAGE_dotNetDIRECTORY_Color,
            //                        Start = (long)parser.RVA2FOA(item.VirtualAddress).Value,
            //                        Length = item.Size
            //                    };
            //                }
            //                break;
            //            case PEPParser.DirectoryEntries.IMAGE_DIRECTORY_ENTRY_EXCEPTION:
            //            case PEPParser.DirectoryEntries.IMAGE_DIRECTORY_ENTRY_SECURITY:
            //            case PEPParser.DirectoryEntries.IMAGE_DIRECTORY_ENTRY_ARCHITECTURE:
            //            case PEPParser.DirectoryEntries.IMAGE_DIRECTORY_ENTRY_GLOBALPTR:
            //            case PEPParser.DirectoryEntries.IMAGE_DIRECTORY_ENTRY_TLS:
            //            case PEPParser.DirectoryEntries.IMAGE_DIRECTORY_ENTRY_LOAD_CONFIG:
            //            case PEPParser.DirectoryEntries.IMAGE_DIRECTORY_ENTRY_BOUND_IMPORT:
            //            case PEPParser.DirectoryEntries.IMAGE_DIRECTORY_ENTRY_IAT:
            //            case PEPParser.DirectoryEntries.IMAGE_DIRECTORY_ENTRY_DELAY_IMPORT:

            //                if (item.VirtualAddress != 0 && item.Size != 0)
            //                {
            //                    region = new HexBox.HighlightedRegion
            //                    {
            //                        Color = mUser.Image_OtherColor,
            //                        Start = (long)parser.RVA2FOA(item.VirtualAddress).Value,
            //                        Length = item.Size
            //                    };
            //                }
            //                break;
            //        }
            //    }
            //    //peRegions.Add(PEPParser.PEStructType.IMAGE_DATA_DIRECTORY_Content, region);
            //}


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
            foreach (var item in peRegions.Values)
            {
                hexBox.AddHighligedRegion(item);
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
                        collection[0].Text = Is32bit ? exe32bit : exe64bit;
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

            //IMAGE_DOS_HEADER 到 IMAGE_RESOURCE_DIRECTORY
            for (int i = 0; i < 10; i++)
            {
                if (peRegions.ContainsKey((PEPParser.PEStructType)i))
                {
                    collection[i].Tag = peRegions[(PEPParser.PEStructType)i];
                }
            }

            if (peRegions.ContainsKey(PEPParser.PEStructType.DotNetDir))
            {
                treeView.Nodes[0]
              .Nodes[(int)PEPParser.PEStructType.DotNetDir]
              .Nodes[0].Tag = peRegions[PEPParser.PEStructType.IMAGE_COR20_HEADER];
            }
          
            TreeNodeCollection nodeCollection = collection[(int)PEPParser.PEStructType.IMAGE_DATA_DIRECTORY].Nodes;
            nodeCollection.Clear();
            nodeCollection.AddRange(tnDataDir.ToArray());
            nodeCollection = collection[(int)PEPParser.PEStructType.IMAGE_SECTION_HEADER].Nodes;
            nodeCollection.Clear();
            nodeCollection.AddRange(tnSection.ToArray());
        }

    }
}
