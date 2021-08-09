using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Be.Windows.Forms
{
    /// <summary>
    /// Pen类型的一个简单的设计接口
    /// </summary>
    [Browsable(true)]
    [Serializable]

    public class PenF : ICloneable
    {
        /// <summary>
        /// 指定虚线中在每一划线段的两端使用的图形形状的类型
        /// </summary>
        [Description("指定虚线中在每一划线段的两端使用的图形形状的类型")]
        public DashCap DashCap { get; set; }

        /// <summary>
        /// 指定绘制的虚线的样式
        /// </summary>
        [Description("指定绘制的虚线的样式")]
        public DashStyle DashStyle { get; set; }

        /// <summary>
        /// 指定可用结束线帽样式
        /// </summary>
        [Description("指定可用结束线帽样式")]
        public LineCap EndCap { get; set; }

        /// <summary>
        /// 指定可用起始线帽样式
        /// </summary>
        [Description("指定可用起始线帽样式")]
        public LineCap StartCap { get; set; }

        /// <summary>
        /// 指定可用起始线帽样式
        /// </summary>
        [Description("指定可用起始线帽样式")]
        public float Width { get; set; }

        /// <summary>
        /// 指定线条的颜色
        /// </summary>
        [Description("指定线条的颜色")]
        public Color Color { get; set; }

        /// <summary>
        /// 指定相对于理论上、零宽度的线条的对齐方式
        /// </summary>
        [Description("指定相对于理论上、零宽度的线条的对齐方式")]
        public PenAlignment Alignment { get; set; }

        /// <summary>
        /// 获取或设置直线的起点到短划线图案起始处的距离
        /// </summary>
        [Description("获取或设置直线的起点到短划线图案起始处的距离")]
        public float DashOffset { get; set; }

        /// <summary>
        /// 生成浅层拷贝
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return MemberwiseClone();
        }

        /// <summary>
        /// 将Pen转化为PenF对象
        /// </summary>
        /// <param name="pen">需要转化的Pen对象</param>
        public static implicit operator PenF(Pen pen)
        {
            return new PenF()
            {
                Color = pen.Color,
                DashStyle = pen.DashStyle,
                DashCap = pen.DashCap,
                StartCap = pen.StartCap,
                EndCap = pen.EndCap,
                Width = pen.Width,
                Alignment = pen.Alignment,
                DashOffset = pen.DashOffset,
            };
        }

        /// <summary>
        ///  将PenF转化为Pen对象
        /// </summary>
        /// <param name="penF">需要转化的PenF对象</param>
        public static implicit operator Pen(PenF penF)
        {
            Pen pen = new Pen(penF.Color, penF.Width)
            {
                DashStyle = penF.DashStyle,
                StartCap = penF.StartCap,
                EndCap = penF.EndCap,
                DashCap = penF.DashCap,
                Alignment = penF.Alignment,
                DashOffset = penF.DashOffset
            };
            return pen;
        }
    }
}