
namespace HexExplorer
{
    partial class FrmProcess
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ToolStrip toolStrip1;
            System.Windows.Forms.ToolStripSeparator ts1;
            System.Windows.Forms.ToolStripLabel lbl;
            this.MIOK = new System.Windows.Forms.ToolStripButton();
            this.MIOpenR = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.txtSearch = new System.Windows.Forms.ToolStripTextBox();
            this.MICancel = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lbProcess = new System.Windows.Forms.ListBox();
            this.pg = new System.Windows.Forms.PropertyGrid();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            ts1 = new System.Windows.Forms.ToolStripSeparator();
            lbl = new System.Windows.Forms.ToolStripLabel();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MIOK,
            this.MIOpenR,
            this.toolStripButton4,
            this.toolStripButton1,
            ts1,
            lbl,
            this.txtSearch});
            toolStrip1.Location = new System.Drawing.Point(0, 420);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new System.Windows.Forms.Padding(3);
            toolStrip1.Size = new System.Drawing.Size(682, 33);
            toolStrip1.TabIndex = 2;
            // 
            // MIOK
            // 
            this.MIOK.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.MIOK.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MIOK.Name = "MIOK";
            this.MIOK.Size = new System.Drawing.Size(103, 24);
            this.MIOK.Text = "确定（可写）";
            this.MIOK.ToolTipText = "Ctrl + Enter";
            this.MIOK.Click += new System.EventHandler(this.MIOK_Click);
            // 
            // MIOpenR
            // 
            this.MIOpenR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.MIOpenR.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MIOpenR.Name = "MIOpenR";
            this.MIOpenR.Size = new System.Drawing.Size(103, 24);
            this.MIOpenR.Text = "确定（只读）";
            this.MIOpenR.ToolTipText = "Ctrl + Shift +Enter";
            this.MIOpenR.Click += new System.EventHandler(this.MIOpenR_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(43, 24);
            this.toolStripButton4.Text = "取消";
            this.toolStripButton4.ToolTipText = "Escape";
            this.toolStripButton4.Click += new System.EventHandler(this.MICancel_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(43, 24);
            this.toolStripButton1.Text = "刷新";
            // 
            // ts1
            // 
            ts1.Name = "ts1";
            ts1.Size = new System.Drawing.Size(6, 27);
            // 
            // lbl
            // 
            lbl.Name = "lbl";
            lbl.Size = new System.Drawing.Size(54, 24);
            lbl.Text = "搜索：";
            // 
            // txtSearch
            // 
            this.txtSearch.AutoSize = false;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(220, 27);
            this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);
            // 
            // MICancel
            // 
            this.MICancel.Name = "MICancel";
            this.MICancel.Size = new System.Drawing.Size(53, 24);
            this.MICancel.Text = "刷新";
            this.MICancel.Click += new System.EventHandler(this.MIRefresh_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lbProcess);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pg);
            this.splitContainer1.Size = new System.Drawing.Size(682, 420);
            this.splitContainer1.SplitterDistance = 322;
            this.splitContainer1.TabIndex = 0;
            // 
            // lbProcess
            // 
            this.lbProcess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbProcess.FormattingEnabled = true;
            this.lbProcess.HorizontalScrollbar = true;
            this.lbProcess.ItemHeight = 15;
            this.lbProcess.Location = new System.Drawing.Point(0, 0);
            this.lbProcess.Name = "lbProcess";
            this.lbProcess.Size = new System.Drawing.Size(322, 420);
            this.lbProcess.TabIndex = 1;
            this.lbProcess.SelectedIndexChanged += new System.EventHandler(this.LbProcess_SelectedIndexChanged);
            // 
            // pg
            // 
            this.pg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pg.Location = new System.Drawing.Point(0, 0);
            this.pg.Name = "pg";
            this.pg.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
            this.pg.Size = new System.Drawing.Size(356, 420);
            this.pg.TabIndex = 2;
            this.pg.ToolbarVisible = false;
            // 
            // FrmProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 453);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(toolStrip1);
            this.KeyPreview = true;
            this.Name = "FrmProcess";
            this.Text = "请选择进程";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmProcess_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmProcess_KeyDown);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox lbProcess;
        private System.Windows.Forms.PropertyGrid pg;
        private System.Windows.Forms.ToolStripMenuItem MICancel;
        private System.Windows.Forms.ToolStripButton MIOK;
        private System.Windows.Forms.ToolStripButton MIOpenR;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripTextBox txtSearch;
    }
}