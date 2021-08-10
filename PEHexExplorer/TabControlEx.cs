using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System;
using System.Collections.Generic;

namespace PEHexExplorer
{

    /// <summary>
    /// 关闭按钮重绘由本人编写
    /// 标签拖拽参考：https://www.codeproject.com/Articles/2445/Drag-and-Drop-Tab-Control
    /// </summary>
    public class TabControlEx : TabControl
    {
        public class ClosingPageArgs : EventArgs
        {
            [DefaultValue(false)]
            public  bool Cancel { get; set; }
        }

        public event EventHandler<ClosingPageArgs> OnClosingPage;

        private int _CloseButtonSize = 12;
        public int CloseButtonSize { get => _CloseButtonSize; set { if (value > 0) _CloseButtonSize = value; } }

        private Color _SelTextColor;
        public Color SelTextColor
        {
            get { return _SelTextColor; }
            set { _SelTextColor = value; }
        }

        private bool isMouseDown = false;
        private EditPage DragDropPage = null;

        #region 隐藏的属性

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new TabDrawMode DrawMode { get; set; }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new bool AllowDrop { get; set; }

        #endregion

        public TabControlEx()
        {
            Point padding = Padding;
            Padding = new Point(padding.X + 3, padding.Y);
            SetStyle(
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.ResizeRedraw |
                ControlStyles.SupportsTransparentBackColor,
                true);
            base.DrawMode = TabDrawMode.OwnerDrawFixed;

            _CloseButtonSize = 12;
            _SelTextColor = Color.White;

            UpdateStyles();

            base.AllowDrop = true;
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            SelectedTab?.Focus();       //清除虚框
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);
            e.DrawBackground();

            var tabPage = TabPages[e.Index];
            var tabRect = GetTabRect(e.Index);
            tabRect.Inflate(-2, -2);

            Image img = null;

            if (tabPage.ImageIndex >= 0)
                img = ImageList.Images[tabPage.ImageIndex];


            if (tabPage.ImageKey.Length > 0)
                img = ImageList.Images[tabPage.ImageKey];

            int imgwidth = 0;

            if (img != null)
            {
                e.Graphics.DrawImageUnscaled(img, tabRect.X + 2, tabRect.Y);
                imgwidth = img.Width + 2;
            }

            SizeF sizeF = e.Graphics.MeasureString(tabPage.Text, tabPage.Font);

            e.Graphics.DrawString(tabPage.Text, tabPage.Font, new SolidBrush( e.State== DrawItemState.Selected?_SelTextColor: tabPage.ForeColor),
                tabRect.Left + imgwidth + 2, tabRect.Top + (tabRect.Height - sizeF.Height) / 2);

            e.Graphics.DrawImage(Properties.Resources.close,
           tabRect.Right - CloseButtonSize - 2,
           tabRect.Top + (tabRect.Height - CloseButtonSize) / 2, CloseButtonSize, CloseButtonSize);

        }

        protected override void OnDragOver(DragEventArgs e)
        {
            base.OnDragOver(e);
            Point pt = new Point(e.X, e.Y);
            //We need client coordinates.
            pt = PointToClient(pt);

            //Get the tab we are hovering over.
            EditPage hover_tab = GetTabPageByTab(pt,out _);

            //Make sure we are on a tab.
            if (hover_tab != null)
            {
                //Make sure there is a TabPage being dragged.
                if (e.Data.GetDataPresent(typeof(EditPage)))
                {
                    e.Effect = DragDropEffects.Move;
                    EditPage drag_tab = e.Data.GetData(typeof(EditPage)) as EditPage;

                    int item_drag_index = FindIndex(drag_tab);
                    int drop_location_index = FindIndex(hover_tab);

                    //Don't do anything if we are hovering over ourself.
                    if (item_drag_index != drop_location_index)
                    {
                        List<TabPage> pages = new List<TabPage>();

                        //Put all tab pages into an array.
                        for (int i = 0; i < TabPages.Count; i++)
                        {
                            //Except the one we are dragging.
                            if (i != item_drag_index)
                                pages.Add(TabPages[i]);
                        }

                        //Now put the one we are dragging it at the proper location.
                        pages.Insert(drop_location_index, drag_tab);

                        //Make them all go away for a nanosec.
                        TabPages.Clear();

                        //Add them all back in.
                        TabPages.AddRange(pages.ToArray());

                        //Make sure the drag tab is selected.
                        SelectedTab = drag_tab;
                    }
                }
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }

        }

        protected override void OnDragDrop(DragEventArgs drgevent)
        {
            isMouseDown = false;
            DragDropPage = null;
            base.OnDragDrop(drgevent);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            isMouseDown = false;
            DragDropPage = null;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (isMouseDown)
                DoDragDrop(DragDropPage, DragDropEffects.All);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            isMouseDown = false;
            DragDropPage = null;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            EditPage tp = GetTabPageByTab(e.Location, out int index);
            if (tp != null)
            {

                if (e.Button == MouseButtons.Left)
                {
                    var tabPage = TabPages[index];
                    var tabRect = GetTabRect(index);
                    tabRect.Inflate(-2, -2);

                    Rectangle closebtnRec = new Rectangle(tabRect.Right - CloseButtonSize - 2,
                        tabRect.Top + (tabRect.Height - CloseButtonSize) / 2, CloseButtonSize, CloseButtonSize);
                    if (closebtnRec.Contains(e.Location))
                    {
                        ClosingPageArgs args = new ClosingPageArgs();
                        OnClosingPage?.Invoke(tp, args);
                        if (!args.Cancel)
                        {
                            TabPages.RemoveAt(index);
                            tabPage.Dispose();
                        }
                        Refresh();
                        return;
                    }
                }

                if (e.Button == MouseButtons.Middle)
                {
                    ClosingPageArgs args0 = new ClosingPageArgs();
                    OnClosingPage?.Invoke(tp, args0);
                    if (!args0.Cancel)
                        TabPages.RemoveAt(index);
                    Refresh();
                    return;
                }

            }

            if (e.Button== MouseButtons.Left)
            {
                if (tp != null)
                {
                    DragDropPage = tp;
                    isMouseDown = true;
                }
            }         
        }

        /// <summary>
        /// Finds the TabPage whose tab is contains the given point.
        /// </summary>
        /// <param name="pt">The point (given in client coordinates) to look for a TabPage.</param>
        /// <returns>The TabPage whose tab is at the given point (null if there isn't one).</returns>
        private EditPage GetTabPageByTab(Point pt,out int index)
        {
            EditPage tp = null;
            int fi = -1;
            for (int i = 0; i < TabPages.Count; i++)
            {
                if (GetTabRect(i).Contains(pt))
                {
                    tp = (EditPage)TabPages[i];
                    fi = i;
                    break;
                }
            }
            index = fi;
            return tp;
        }

        /// <summary>
        /// Loops over all the TabPages to find the index of the given TabPage.
        /// </summary>
        /// <param name="page">The TabPage we want the index for.</param>
        /// <returns>The index of the given TabPage(-1 if it isn't found.)</returns>
        private int FindIndex(EditPage page)
        {
            for (int i = 0; i < TabPages.Count; i++)
            {
                if (TabPages[i] == page)
                    return i;
            }

            return -1;
        }

    }
}
