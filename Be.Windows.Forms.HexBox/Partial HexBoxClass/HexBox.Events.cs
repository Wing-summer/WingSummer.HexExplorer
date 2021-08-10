using System;
using System.ComponentModel;

namespace Be.Windows.Forms
{
    public partial class HexBox
    {
        /// <summary>
        /// Occurs, when the value of InsertActive property has changed.
        /// </summary>
        [Description("Occurs, when the value of InsertActive property has changed.")]
        public event EventHandler InsertActiveChanged;

        /// <summary>
        /// Occurs, when the value of ReadOnly property has changed.
        /// </summary>
        [Description("Occurs, when the value of ReadOnly property has changed.")]
        public event EventHandler ReadOnlyChanged;

        /// <summary>
        /// Occurs, when the value of ByteProvider property has changed.
        /// </summary>
        [Description("Occurs, when the value of ByteProvider property has changed.")]
        public event EventHandler ByteProviderChanged;

        /// <summary>
        /// Occurs, when the value of SelectionStart property has changed.
        /// </summary>
        [Description("Occurs, when the value of SelectionStart property has changed.")]
        public event EventHandler SelectionStartChanged;

        /// <summary>
        /// Occurs, when the value of SelectionLength property has changed.
        /// </summary>
        [Description("Occurs, when the value of SelectionLength property has changed.")]
        public event EventHandler SelectionLengthChanged;

        /// <summary>
        /// Occurs, when the value of LineInfoVisible property has changed.
        /// </summary>
        [Description("Occurs, when the value of LineInfoVisible property has changed.")]
        public event EventHandler LineInfoVisibleChanged;

        /// <summary>
        /// Occurs, when the value of ColumnInfoVisibleChanged property has changed.
        /// </summary>
        [Description("Occurs, when the value of ColumnInfoVisibleChanged property has changed.")]
        public event EventHandler ColumnInfoVisibleChanged;

        /// <summary>
        /// Occurs, when the value of GroupSeparatorVisibleChanged property has changed.
        /// </summary>
        [Description("Occurs, when the value of GroupSeparatorVisibleChanged property has changed.")]
        public event EventHandler GroupSeparatorVisibleChanged;

        /// <summary>
        /// Occurs, when the value of StringViewVisible property has changed.
        /// </summary>
        [Description("Occurs, when the value of StringViewVisible property has changed.")]
        public event EventHandler StringViewVisibleChanged;

        /// <summary>
        /// Occurs, when the value of BorderStyle property has changed.
        /// </summary>
        [Description("Occurs, when the value of BorderStyle property has changed.")]
        public event EventHandler BorderStyleChanged;

        /// <summary>
        /// Occurs, when the value of ColumnWidth property has changed.
        /// </summary>
        [Description("Occurs, when the value of GroupSize property has changed.")]
        public event EventHandler GroupSizeChanged;

        /// <summary>
        /// Occurs, when the value of BytesPerLine property has changed.
        /// </summary>
        [Description("Occurs, when the value of BytesPerLine property has changed.")]
        public event EventHandler BytesPerLineChanged;

        /// <summary>
        /// Occurs, when the value of UseFixedBytesPerLine property has changed.
        /// </summary>
        [Description("Occurs, when the value of UseFixedBytesPerLine property has changed.")]
        public event EventHandler UseFixedBytesPerLineChanged;

        /// <summary>
        /// Occurs, when the value of VScrollBarVisible property has changed.
        /// </summary>
        [Description("Occurs, when the value of VScrollBarVisible property has changed.")]
        public event EventHandler VScrollBarVisibleChanged;

        /// <summary>
        /// 当 HScrollBarVisible 属性改变完成后会触发该事件
        /// </summary>
        [Description("当 HScrollBarVisible 属性改变完成后会触发该事件")]
        public event EventHandler HScrollBarVisibleChanged;

        /// <summary>
        /// Occurs, when the value of HexCasing property has changed.
        /// </summary>
        [Description("Occurs, when the value of HexCasing property has changed.")]
        public event EventHandler HexCasingChanged;

        /// <summary>
        /// Occurs, when the value of HorizontalByteCount property has changed.
        /// </summary>
        [Description("Occurs, when the value of HorizontalByteCount property has changed.")]
        public event EventHandler HorizontalByteCountChanged;

        /// <summary>
        /// Occurs, when the value of VerticalByteCount property has changed.
        /// </summary>
        [Description("Occurs, when the value of VerticalByteCount property has changed.")]
        public event EventHandler VerticalByteCountChanged;

        /// <summary>
        /// Occurs, when the value of CurrentLine property has changed.
        /// </summary>
        [Description("Occurs, when the value of CurrentLine property has changed.")]
        public event EventHandler CurrentLineChanged;

        /// <summary>
        /// Occurs, when the value of CurrentPositionInLine property has changed.
        /// </summary>
        [Description("Occurs, when the value of CurrentPositionInLine property has changed.")]
        public event EventHandler CurrentPositionInLineChanged;

        /// <summary>
        /// 当光标位置发生改变时会触发该事件
        /// </summary>
        [Description("当光标位置发生改变时会触发该事件")]
        public event EventHandler CurrentPositionChanged;

        /// <summary>
        /// Occurs, when Copy method was invoked and ClipBoardData changed.
        /// </summary>
        [Description("Occurs, when Copy method was invoked and ClipBoardData changed.")]
        public event EventHandler Copied;

        /// <summary>
        /// Occurs, when CopyHex method was invoked and ClipBoardData changed.
        /// </summary>
        [Description("Occurs, when CopyHex method was invoked and ClipBoardData changed.")]
        public event EventHandler CopiedHex;

        /// <summary>
        /// Occurs, when the CharSize property has changed
        /// </summary>
        [Description("Occurs, when the CharSize property has changed")]
        public event EventHandler CharSizeChanged;

        /// <summary>
        /// Occurs, when the RequiredWidth property changes
        /// </summary>
        [Description("Occurs, when the RequiredWidth property changes")]
        public event EventHandler RequiredWidthChanged;

        /// <summary>
        /// 当Scaling(缩放)属性更改时会触发该事件
        /// </summary>
        [Description("当Scaling(缩放)属性更改时会触发该事件")]
        public event EventHandler ScalingChanged;

        /// <summary>
        /// 当有更改完成后会触发该事件
        /// </summary>
        [Description("当有保存状态改变后会触发该事件")]
        public event EventHandler SavedStatusChanged;

        /// <summary>
        /// 当越界锁状态改变后会触发该事件
        /// </summary>
        [Description("当越界锁状态改变后会触发该事件")]
        public event EventHandler LockedBufferChanged;

        /// <summary>
        /// 当是否显示列信息背景色状态改变后会触发该事件
        /// </summary>
        [Description("当是否显示列信息背景色状态改变后会触发该事件")]
        public event EventHandler ShowColumnInfoBackColorChanged;

        /// <summary>
        /// 当是否显示行信息背景色状态改变后会触发该事件
        /// </summary>
        [Description("当是否显示行信息背景色状态改变后会触发该事件")]
        public event EventHandler ShowLineInfoBackColorChanged;

        /// <summary>
        /// 当是字符表编码改变后会触发该事件
        /// </summary>
        [Description("当字符表编码改变后会触发该事件")]
        public event EventHandler EncodingChanged;


        /// <summary>
        /// 当主书签背景指示状态改变后会触发该事件
        /// </summary>
        [Description("当主书签背景指示状态改变后会触发该事件")]
        public event EventHandler ShowBookMarkMainChanged;

        /// <summary>
        /// 当书签背景指示状态改变后会触发该事件
        /// </summary>
        [Description("当书签背景指示状态改变后会触发该事件")]
        public event EventHandler ShowBookMarkChanged;
    }
}