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

        public BookMarkPE(PEPParser parser)
        {
            if (parser==null)
            {
                throw new ArgumentNullException("PEPParser");
            }

            if (!parser.LoadedFile)
            {
                throw new ArgumentException("PE分析器未分析文件，请重新创建该类");
            }

            regions = new List<HexBox.HighlightedRegion>();
            peRegions = new Dictionary<Type, List<HexBox.HighlightedRegion>>();
            HexBox.HighlightedRegion region;
            Type type;

            type = typeof(PEPParser.IMAGE_DOS_HEADER);

            region = new HexBox.HighlightedRegion
            {
                Color = IMAGE_DOS_HEADER_Color,
                Start = 0,
                Length = Marshal.SizeOf(type)
            };

            regions.Add(region);
            peRegions.Add(type, regions);

            type = typeof(PEPParser.IMAGE_DATA_DIRECTORY);
            region = new HexBox.HighlightedRegion
            {
                Color = IMAGE_DATA_DIRECTORY_Color,
                Start = (int)parser.PEData.SECTION_HEADERS_FOA,
                Length = Marshal.SizeOf(type)
            };

            regions.Add(region);
            peRegions.Add(type, regions);



            if (parser.Is32Bit)
            {
                type = typeof(PEPParser.IMAGE_NT_HEADERS32);
            }
            else
            {

            }

        }
    }
}
