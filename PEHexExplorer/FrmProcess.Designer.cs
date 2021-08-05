
namespace PEHexExplorer
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
            System.Windows.Forms.MenuStrip menuStrip1;
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lbProcess = new System.Windows.Forms.ListBox();
            this.pg = new System.Windows.Forms.PropertyGrid();
            this.MIOK = new System.Windows.Forms.ToolStripMenuItem();
            this.MICancel = new System.Windows.Forms.ToolStripMenuItem();
            this.MIRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.MIOpenR = new System.Windows.Forms.ToolStripMenuItem();
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            menuStrip1.SuspendLayout();
            this.SuspendLayout();
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
            this.splitContainer1.Size = new System.Drawing.Size(682, 425);
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
            this.lbProcess.Size = new System.Drawing.Size(322, 425);
            this.lbProcess.TabIndex = 1;
            this.lbProcess.SelectedIndexChanged += new System.EventHandler(this.LbProcess_SelectedIndexChanged);
            // 
            // pg
            // 
            this.pg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pg.Location = new System.Drawing.Point(0, 0);
            this.pg.Name = "pg";
            this.pg.Size = new System.Drawing.Size(356, 425);
            this.pg.TabIndex = 2;
            // 
            // menuStrip1
            // 
            menuStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MIOK,
            this.MIOpenR,
            this.MICancel,
            this.MIRefresh});
            menuStrip1.Location = new System.Drawing.Point(0, 425);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new System.Drawing.Size(682, 28);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // MIOK
            // 
            this.MIOK.Name = "MIOK";
            this.MIOK.Size = new System.Drawing.Size(113, 24);
            this.MIOK.Text = "确定（可写）";
            this.MIOK.Click += new System.EventHandler(this.MIOK_Click);
            // 
            // MICancel
            // 
            this.MICancel.Name = "MICancel";
            this.MICancel.Size = new System.Drawing.Size(53, 24);
            this.MICancel.Text = "取消";
            this.MICancel.Click += new System.EventHandler(this.MICancel_Click);
            // 
            // MIRefresh
            // 
            this.MIRefresh.Name = "MIRefresh";
            this.MIRefresh.Size = new System.Drawing.Size(53, 24);
            this.MIRefresh.Text = "刷新";
            this.MIRefresh.Click += new System.EventHandler(this.MIRefresh_Click);
            // 
            // MIOpenR
            // 
            this.MIOpenR.Name = "MIOpenR";
            this.MIOpenR.Size = new System.Drawing.Size(113, 24);
            this.MIOpenR.Text = "确定（只读）";
            this.MIOpenR.Click += new System.EventHandler(this.MIOpenR_Click);
            // 
            // FrmProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 453);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MainMenuStrip = menuStrip1;
            this.Name = "FrmProcess";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "请选择进程";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmProcess_FormClosed);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox lbProcess;
        private System.Windows.Forms.PropertyGrid pg;
        private System.Windows.Forms.ToolStripMenuItem MIRefresh;
        private System.Windows.Forms.ToolStripMenuItem MIOK;
        private System.Windows.Forms.ToolStripMenuItem MICancel;
        private System.Windows.Forms.ToolStripMenuItem MIOpenR;
    }
}