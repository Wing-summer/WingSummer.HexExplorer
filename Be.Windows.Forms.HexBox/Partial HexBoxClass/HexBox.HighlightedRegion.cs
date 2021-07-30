using System.Drawing;

namespace Be.Windows.Forms
{
    public partial class HexBox
    {
        /// <summary>
		/// 高亮区域类
		/// </summary>
        public class HighlightedRegion
        {
            /// <summary>
            /// 高亮区块选择开始字节数偏移
            /// </summary>
            public int Start;

            /// <summary>
            /// 高亮区块选择字节长度
            /// </summary>
            public int Length;

            /// <summary>
            /// 高亮区块最后一个字节数偏移
            /// </summary>
            public int End { get { return Start + Length - 1; } }

            /// <summary>
            /// 背景色
            /// </summary>
            public Color Color;

            /// <summary>
            /// 构造函数
            /// </summary>
            public HighlightedRegion()
            {
            }

            /// <summary>
            /// 构造函数
            /// </summary>
            /// <param name="Start">高亮区块选择开始字节数偏移</param>
            /// <param name="Length">高亮区块选择字节长度</param>
            /// <param name="Color">背景色</param>
            public HighlightedRegion(int Start, int Length, Color Color)
            {
                this.Start = Start;
                this.Length = Length;
                this.Color = Color;
            }

            /// <summary>
            /// 判断某字节偏移是否处于高亮区域
            /// </summary>
            /// <param name="BytePos"></param>
            /// <returns></returns>
            public bool IsByteSelected(long BytePos)
            {
                return BytePos >= Start && BytePos <= End;
            }
        }
    }
}