using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using Be.Windows.Forms;

namespace HexExplorer
{

    [Serializable]
    [XmlRoot("UserProfile")]
    public class MUserProfile : INotifyPropertyChanged
    {

        #region 预定义默认颜色和笔刷

        public static Color DefaultSelBackColor = Color.FromArgb(100, 66, 137, 202);
        public static Color DefaultSelTextColor = Color.White;
        public static Color DefaultShadowSelColor = Color.FromArgb(100, 60, 188, 255);
        public static Color DefaultLineInfoBackColor = Color.Cyan;
        public static Color DefaultColInfoBackColor = Color.FromArgb(255, 255, 255, 128);
        public static Color DefaultIMAGE_DOS_HEADER_Color = Color.FromArgb(255, 240, 230, 140);
        public static Color DefaultIMAGE_NT_HEADERS_Color = Color.FromArgb(255, 200, 250, 200);
        public static Color DefaultIMAGE_FILE_HEADER_Color = Color.FromArgb(255, 226, 93, 124);
        public static Color DefaultIMAGE_OPTIONAL_HEADER_Color = Color.FromArgb(255, 200, 200, 250);
        public static Color DefaultIMAGE_SECTION_HEADER_Color = Color.FromArgb(255, 255, 192, 192);
        public static Color DefaultIMAGE_DATA_DIRECTORY_Color = Color.FromArgb(255, 173, 239, 237);
        public static Color DefaultIMAGE_IMPORT_DESCRIPTOR_Color = Color.FromArgb(255, 120, 204, 252);
        public static Color DefaultIMAGE_BASE_RELOCATION_Color = Color.FromArgb(255, 252, 120, 213);
        public static Color DefaultIMAGE_EXPORT_DIRECTORY_Color = Color.FromArgb(255, 252, 144, 120);
        public static Color DefaultIMAGE_RESOURCE_DIRECTORY_Color = Color.FromArgb(255, 215, 185, 78);
        public static Color DefaultIMAGE_Debug_DIRECTORY_Color = Color.FromArgb(255, 197, 61, 76);
        public static Color DefaultIMAGE_dotNetDIRECTORY_Color = Color.FromArgb(255, 66, 202, 166);
        public static Color DefaultImage_OtherColor = Color.FromArgb(255, 247, 247, 140);
        public static Color DefaultBookMarkDefaultColor = Color.FromArgb(100, 255, 0, 195);

        public static PenF DefaultGroupLinePen = new PenF()
        {
            Color = Color.Green,
            Alignment = PenAlignment.Center,
            DashCap = DashCap.Flat,
            DashOffset = 0,
            DashStyle = DashStyle.Solid,
            EndCap = LineCap.Flat,
            StartCap = LineCap.Flat,
            Width = 1
        };

        public static PenF DefaultHexStringLinePen = new PenF()
        {
            Color = Color.Fuchsia,
            Alignment = PenAlignment.Center,
            DashCap = DashCap.Flat,
            DashOffset = 0,
            DashStyle = DashStyle.Dash,
            EndCap = LineCap.Flat,
            StartCap = LineCap.Flat,
            Width = 1
        };

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        #region 私有变量

        private Color iMAGE_DOS_HEADER_Color;
        private Color iMAGE_NT_HEADERS_Color;
        private Color iMAGE_FILE_HEADER_Color;
        private Color iMAGE_OPTIONAL_HEADER_Color;
        private Color iMAGE_SECTION_HEADER_Color;
        private Color iMAGE_DATA_DIRECTORY_Color;
        private Color iMAGE_IMPORT_DESCRIPTOR_Color;
        private Color iMAGE_BASE_RELOCATION_Color;
        private Color iMAGE_EXPORT_DIRECTORY_Color;
        private Color iMAGE_RESOURCE_DIRECTORY_Color;
        private Color iMAGE_Debug_DIRECTORY_Color;
        private Color iMAGE_dotNetDIRECTORY_Color;
        private Color image_OtherColor;
        private Font programFont;
        private bool enablePE;
        private int stringViewEncoding;
        private uint scalingPercent;
        private bool enableStringView;
        private bool enableLineInfo;
        private bool enableColInfo;
        private bool enableGroupLine;
        private bool enableHexStringLine;
        private Color selBackColor;
        private Color selTextColor;
        private Color lineInfoBackColor;
        private Color colInfoBackColor;
        private Color shadowSelColor;
        private PenF groupLinePen;
        private PenF hexStringLinePen;
        private bool enableAdvBookMark;
        private List<BookMarkProperty> markProperties;
        private bool adminStart;
        private Color bookMarkDefaultColor;

        #endregion

        public MUserProfile()
        {
            ProgramFont = SystemFonts.DefaultFont;
            StringViewEncoding = 0;
            ScalingPercent = 100;
            EnableStringView = true;
            EnableLineInfo = true;
            EnableColInfo = true;
            EnableGroupLine = true;
            EnableHexStringLine = true;
            AdminStart = false;

            SelBackColor = DefaultSelBackColor;
            SelTextColor = DefaultSelTextColor;
            ShadowSelColor = DefaultShadowSelColor;

            GroupLinePen = DefaultGroupLinePen;
            HexStringLinePen = DefaultHexStringLinePen;
            LineInfoBackColor = DefaultLineInfoBackColor;
            ColInfoBackColor = DefaultColInfoBackColor;
            BookMarkDefaultColor = DefaultBookMarkDefaultColor;
            IMAGE_DOS_HEADER_Color = DefaultIMAGE_DOS_HEADER_Color;
            IMAGE_NT_HEADERS_Color = DefaultIMAGE_NT_HEADERS_Color;
            IMAGE_FILE_HEADER_Color = DefaultIMAGE_FILE_HEADER_Color;
            IMAGE_OPTIONAL_HEADER_Color = DefaultIMAGE_OPTIONAL_HEADER_Color;
            IMAGE_SECTION_HEADER_Color = DefaultIMAGE_SECTION_HEADER_Color;
            IMAGE_DATA_DIRECTORY_Color = DefaultIMAGE_DATA_DIRECTORY_Color;
            IMAGE_IMPORT_DESCRIPTOR_Color = DefaultIMAGE_IMPORT_DESCRIPTOR_Color;
            IMAGE_BASE_RELOCATION_Color = DefaultIMAGE_BASE_RELOCATION_Color;
            IMAGE_EXPORT_DIRECTORY_Color = DefaultIMAGE_EXPORT_DIRECTORY_Color;
            IMAGE_RESOURCE_DIRECTORY_Color = DefaultIMAGE_RESOURCE_DIRECTORY_Color;
            IMAGE_Debug_DIRECTORY_Color = DefaultIMAGE_Debug_DIRECTORY_Color;
            IMAGE_dotNetDIRECTORY_Color = DefaultIMAGE_dotNetDIRECTORY_Color;
            Image_OtherColor = DefaultImage_OtherColor;

            EnableAdvBookMark = true;
            MarkProperties = null;

            EnablePlugin = true;
            DisableGuid = null;

            EnablePE = true;

        }

        #region 常规

        public Color BookMarkDefaultColor
        {
            get => bookMarkDefaultColor; set
            {
                bookMarkDefaultColor = value;
                NotifyPropertyChanged();
            }
        }

        public Font ProgramFont
        {
            get => programFont;
            set
            {
                programFont = value;
                NotifyPropertyChanged("ProgramFontName");
                NotifyPropertyChanged();
            }
        }
        public bool EnablePE
        {
            get => enablePE;
            set
            {
                enablePE = value;
                NotifyPropertyChanged();

            }
        }
        public int StringViewEncoding
        {
            get => stringViewEncoding;
            set
            {
                stringViewEncoding = value;
                NotifyPropertyChanged();
            }
        }
        public uint ScalingPercent
        {
            get => scalingPercent;
            set
            {
                scalingPercent = value;
                NotifyPropertyChanged();
            }
        }
        public bool EnableStringView
        {
            get => enableStringView;
            set
            {
                enableStringView = value;
                NotifyPropertyChanged();
            }
        }
        public bool EnableLineInfo
        {
            get => enableLineInfo;
            set
            {
                enableLineInfo = value;
                NotifyPropertyChanged();
            }
        }
        public bool EnableColInfo
        {
            get => enableColInfo;
            set
            {
                enableColInfo = value;
                NotifyPropertyChanged();
            }
        }
        public bool EnableGroupLine
        {
            get => enableGroupLine;
            set
            {
                enableGroupLine = value;
                NotifyPropertyChanged();
            }
        }

        public bool AdminStart
        {
            get => adminStart;
            set
            {
                adminStart = value;
                NotifyPropertyChanged();
            }
        }

        public bool EnableHexStringLine
        {
            get => enableHexStringLine;
            set
            {
                enableHexStringLine = value;
                NotifyPropertyChanged();
            }
        }
        public Color SelBackColor
        {
            get => selBackColor;
            set
            {
                selBackColor = value;
                NotifyPropertyChanged();
            }
        }
        public Color SelTextColor
        {
            get => selTextColor;
            set
            {
                selTextColor = value;
                NotifyPropertyChanged();
            }
        }
        public Color LineInfoBackColor
        {
            get => lineInfoBackColor;
            set
            {
                lineInfoBackColor = value;
                NotifyPropertyChanged();
            }
        }
        public Color ColInfoBackColor
        {
            get => colInfoBackColor;
            set
            {
                colInfoBackColor = value;
                NotifyPropertyChanged();
            }
        }
        public Color ShadowSelColor
        {
            get => shadowSelColor;
            set
            {
                shadowSelColor = value;
                NotifyPropertyChanged();
            }
        }
        public PenF GroupLinePen
        {
            get => groupLinePen;
            set
            {
                groupLinePen = value;
                NotifyPropertyChanged();
            }
        }
        public PenF HexStringLinePen
        {
            get => hexStringLinePen;
            set
            {
                hexStringLinePen = value;
                NotifyPropertyChanged();
            }
        }

        #endregion

        #region PE结构

        public Color IMAGE_DOS_HEADER_Color
        {
            get => iMAGE_DOS_HEADER_Color;
            set
            {
                iMAGE_DOS_HEADER_Color = value;
                NotifyPropertyChanged();
            }
        }

        public Color IMAGE_NT_HEADERS_Color
        {
            get => iMAGE_NT_HEADERS_Color;
            set
            {
                iMAGE_NT_HEADERS_Color = value;
                NotifyPropertyChanged();
            }
        }

        public Color IMAGE_FILE_HEADER_Color
        {
            get => iMAGE_FILE_HEADER_Color;
            set
            {
                iMAGE_FILE_HEADER_Color = value;
                NotifyPropertyChanged();
            }
        }

        public Color IMAGE_OPTIONAL_HEADER_Color
        {
            get => iMAGE_OPTIONAL_HEADER_Color; set
            {
                iMAGE_OPTIONAL_HEADER_Color = value;
                NotifyPropertyChanged();
            }
        }
        public Color IMAGE_SECTION_HEADER_Color
        {
            get => iMAGE_SECTION_HEADER_Color; set
            {
                iMAGE_SECTION_HEADER_Color = value;
                NotifyPropertyChanged();
            }
        }
        public Color IMAGE_DATA_DIRECTORY_Color
        {
            get => iMAGE_DATA_DIRECTORY_Color;
            set
            {
                iMAGE_DATA_DIRECTORY_Color = value;
                NotifyPropertyChanged();
            }
        }
        public Color IMAGE_IMPORT_DESCRIPTOR_Color
        {
            get => iMAGE_IMPORT_DESCRIPTOR_Color; set
            {
                iMAGE_IMPORT_DESCRIPTOR_Color = value;
                NotifyPropertyChanged();
            }
        }
        public Color IMAGE_BASE_RELOCATION_Color
        {
            get => iMAGE_BASE_RELOCATION_Color; set
            {
                iMAGE_BASE_RELOCATION_Color = value;
                NotifyPropertyChanged();
            }
        }
        public Color IMAGE_EXPORT_DIRECTORY_Color
        {
            get => iMAGE_EXPORT_DIRECTORY_Color; set
            {
                iMAGE_EXPORT_DIRECTORY_Color = value;
                NotifyPropertyChanged();
            }
        }
        public Color IMAGE_RESOURCE_DIRECTORY_Color
        {
            get => iMAGE_RESOURCE_DIRECTORY_Color; set
            {
                iMAGE_RESOURCE_DIRECTORY_Color = value;
                NotifyPropertyChanged();

            }
        }
        public Color IMAGE_Debug_DIRECTORY_Color
        {
            get => iMAGE_Debug_DIRECTORY_Color; set
            {
                iMAGE_Debug_DIRECTORY_Color = value;
                NotifyPropertyChanged();

            }
        }
        public Color IMAGE_dotNetDIRECTORY_Color
        {
            get => iMAGE_dotNetDIRECTORY_Color; set
            {
                iMAGE_dotNetDIRECTORY_Color = value;
                NotifyPropertyChanged();

            }
        }
        public Color Image_OtherColor
        {
            get => image_OtherColor; set
            {
                image_OtherColor = value;
                NotifyPropertyChanged();

            }
        }

        #endregion

        #region 书签

        public bool EnableAdvBookMark
        {
            get => enableAdvBookMark;
            set
            {
                enableAdvBookMark = value;
                NotifyPropertyChanged();
            }
        }
        public List<BookMarkProperty> MarkProperties
        {
            get => markProperties;
            set
            {
                markProperties = value;
                NotifyPropertyChanged();
            }
        }

        #endregion

        #region 插件

        public bool EnablePlugin { get; set; }
        public List<string> DisableGuid { get; set; }


        #endregion

    }
}
