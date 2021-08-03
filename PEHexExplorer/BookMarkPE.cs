using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;

using System.Drawing;
using Be.Windows.Forms;
using PEProcesser;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PEHexExplorer
{
    class BookMarkPE
    {

        public Dictionary<Type, List<HexBox.HighlightedRegion>> peRegions;
        public List<HexBox.HighlightedRegion> regions;

        [DefaultValue(typeof(Color), "BlueViolet")]
        public Color IMAGE_DOS_HEADER_Color { get; set; }


        [DefaultValue(typeof(Color), "BlueViolet")]
        public Color IMAGE_DATA_DIRECTORY_Color { get; set; }

        [DefaultValue(typeof(Color), "BlueViolet")]
        public Color IMAGE_NT_HEADERS_Color { get; set; }

        [DefaultValue(typeof(Color), "BlueViolet")]
        public Color IMAGE_OPTIONAL_HEADER_Color { get; set; }

        [DefaultValue(typeof(Color), "BlueViolet")]
        public Color IMAGE_DATA_DIRECTORY_Item_Color { get; set; }

        private bool Is32bit;
        private bool loaded;
        private bool processed;
        private const string exe32bit = "PE 文件 (32位)";
        private const string exe64bit = "PE 文件 (64位)";
        private const string exedefault = "PE 文件";
        private const string exeno = "PE 文件 (非PE文件)";

        public BookMarkPE(PEPParser parser)
        {
            if (parser == null)
            {
                throw new ArgumentNullException("PEPParser");
            }

            loaded = parser.LoadedFile;
            processed = parser.Processed;

            if (!loaded)
                return;

            List<HexBox.HighlightedRegion> regions;

            peRegions = new Dictionary<Type, List<HexBox.HighlightedRegion>>();
            HexBox.HighlightedRegion region;
            Type type;

            type = typeof(PEPParser.IMAGE_DOS_HEADER);
            regions = new List<HexBox.HighlightedRegion>();
            region = new HexBox.HighlightedRegion
            {
                Color = IMAGE_DOS_HEADER_Color,
                Start = 0,
                Length = Marshal.SizeOf(type)
            };

            regions.Add(region);
            peRegions.Add(type, regions);

            type = typeof(PEPParser.IMAGE_DATA_DIRECTORY);
            regions = new List<HexBox.HighlightedRegion>();

            int DATA_DIRECTORIES_Size = Marshal.SizeOf(type);
            for (int i = 0; i < PEPParser.IMAGE_NUMBEROF_DIRECTORY_ENTRIES; i++)
            {
            region = new HexBox.HighlightedRegion
            {
                Color = IMAGE_DATA_DIRECTORY_Color,
                    Start = (int)parser.PEData.DATA_DIRECTORIES_FOA + DATA_DIRECTORIES_Size * i,
                    Length = DATA_DIRECTORIES_Size
                };
                regions.Add(region);
            }
            peRegions.Add(type, regions);

            PEPParser.IMAGE_DATA_DIRECTORY[] idds = parser.IMAGE_DATA_DIRECTORIES;
            foreach (var item in idds)
            {
                if (item.VirtualAddress!=0&&item.Size!=0)
                {
                    
                }
            }

            if (parser.Is32Bit)
            {
                Is32bit = true;
                type = typeof(PEPParser.IMAGE_NT_HEADERS32);
                regions = new List<HexBox.HighlightedRegion>();
                region = new HexBox.HighlightedRegion
                {
                    Color = IMAGE_NT_HEADERS_Color,
                    Start = (int)parser.PEData.NT_HEADER_FOA,
                    Length = Marshal.SizeOf(type)
                };
                regions.Add(region);
                peRegions.Add(type,regions);

                type = typeof(PEPParser.IMAGE_OPTIONAL_HEADER32);
                regions = new List<HexBox.HighlightedRegion>();
                region = new HexBox.HighlightedRegion
                {
                    Color = IMAGE_OPTIONAL_HEADER_Color,
                    Start = (int)parser.PEData.OPTIONAL_HEADER_FOA,
                    Length = Marshal.SizeOf(type) - DATA_DIRECTORIES_Size * PEPParser.IMAGE_NUMBEROF_DIRECTORY_ENTRIES
                };
                regions.Add(region);
                peRegions.Add(type, regions);



            }
            else
            {
                Is32bit = false;
                type = typeof(PEPParser.IMAGE_NT_HEADERS64);
                regions = new List<HexBox.HighlightedRegion>();
                region = new HexBox.HighlightedRegion
                {
                    Color = IMAGE_NT_HEADERS_Color,
                    Start = (int)parser.PEData.NT_HEADER_FOA,
                Length = Marshal.SizeOf(type)
            };
                regions.Add(region);
                peRegions.Add(type, regions);

                type = typeof(PEPParser.IMAGE_OPTIONAL_HEADER64);
                regions = new List<HexBox.HighlightedRegion>();
                region = new HexBox.HighlightedRegion
                {
                    Color = IMAGE_OPTIONAL_HEADER_Color,
                    Start = (int)parser.PEData.OPTIONAL_HEADER_FOA,
                    Length = Marshal.SizeOf(type) - DATA_DIRECTORIES_Size * PEPParser.IMAGE_NUMBEROF_DIRECTORY_ENTRIES
                };
            regions.Add(region);
            peRegions.Add(type, regions);
            }

        }

        public void ApplyTreeView(in TreeView treeView)
        {

            TreeNodeCollection collection = treeView.Nodes;
            try
            {
                if (!loaded)
                {
                    if (processed)
                    {
                        collection[0].Text = exeno;
                    }
                    else
                    {
                        collection[0].Text = exedefault;
                    }
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
            catch
            {

                throw;
            }

        }

    }
}
