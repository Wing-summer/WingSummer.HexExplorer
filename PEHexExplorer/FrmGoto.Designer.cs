
namespace PEHexExplorer
{
    partial class FrmGoto
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.GroupBox groupBox1;
            System.Windows.Forms.Panel panel1;
            System.Windows.Forms.Panel panel2;
            this.rbRow = new System.Windows.Forms.RadioButton();
            this.rbOffset = new System.Windows.Forms.RadioButton();
            this.rbBase = new System.Windows.Forms.RadioButton();
            this.rbCur = new System.Windows.Forms.RadioButton();
            this.btnJmp = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbOffset = new System.Windows.Forms.GroupBox();
            this.cbHex = new System.Windows.Forms.CheckBox();
            this.ntOffset = new PEHexExplorer.NumericTextbox(this.components);
            this.ntRow = new PEHexExplorer.NumericTextbox(this.components);
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            groupBox1 = new System.Windows.Forms.GroupBox();
            panel1 = new System.Windows.Forms.Panel();
            panel2 = new System.Windows.Forms.Panel();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            this.gbOffset.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(23, 23);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(52, 15);
            label1.TabIndex = 1;
            label1.Text = "行号：";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(239, 23);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(52, 15);
            label2.TabIndex = 1;
            label2.Text = "偏移：";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(panel1);
            groupBox1.Location = new System.Drawing.Point(23, 69);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(210, 119);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "跳转方式";
            // 
            // panel1
            // 
            panel1.Controls.Add(this.rbRow);
            panel1.Controls.Add(this.rbOffset);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(3, 21);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(204, 95);
            panel1.TabIndex = 5;
            // 
            // rbRow
            // 
            this.rbRow.AutoSize = true;
            this.rbRow.Checked = true;
            this.rbRow.Location = new System.Drawing.Point(30, 17);
            this.rbRow.Name = "rbRow";
            this.rbRow.Size = new System.Drawing.Size(112, 19);
            this.rbRow.TabIndex = 4;
            this.rbRow.TabStop = true;
            this.rbRow.Text = "行号跳转(&N)";
            this.rbRow.UseVisualStyleBackColor = true;
            this.rbRow.CheckedChanged += new System.EventHandler(this.rbGotoGroup_CheckedChanged);
            // 
            // rbOffset
            // 
            this.rbOffset.AutoSize = true;
            this.rbOffset.Location = new System.Drawing.Point(30, 54);
            this.rbOffset.Name = "rbOffset";
            this.rbOffset.Size = new System.Drawing.Size(112, 19);
            this.rbOffset.TabIndex = 4;
            this.rbOffset.Text = "偏移跳转(&O)";
            this.rbOffset.UseVisualStyleBackColor = true;
            this.rbOffset.CheckedChanged += new System.EventHandler(this.rbGotoGroup_CheckedChanged);
            // 
            // panel2
            // 
            panel2.Controls.Add(this.rbBase);
            panel2.Controls.Add(this.rbCur);
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Location = new System.Drawing.Point(3, 21);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(204, 95);
            panel2.TabIndex = 5;
            // 
            // rbBase
            // 
            this.rbBase.AutoSize = true;
            this.rbBase.Checked = true;
            this.rbBase.Location = new System.Drawing.Point(22, 17);
            this.rbBase.Name = "rbBase";
            this.rbBase.Size = new System.Drawing.Size(157, 19);
            this.rbBase.TabIndex = 4;
            this.rbBase.TabStop = true;
            this.rbBase.Text = "从文件基址开始(&B)";
            this.rbBase.UseVisualStyleBackColor = true;
            // 
            // rbCur
            // 
            this.rbCur.AutoSize = true;
            this.rbCur.Location = new System.Drawing.Point(22, 54);
            this.rbCur.Name = "rbCur";
            this.rbCur.Size = new System.Drawing.Size(157, 19);
            this.rbCur.TabIndex = 4;
            this.rbCur.Text = "从当前当前开始(&C)";
            this.rbCur.UseVisualStyleBackColor = true;
            // 
            // btnJmp
            // 
            this.btnJmp.Location = new System.Drawing.Point(26, 208);
            this.btnJmp.Name = "btnJmp";
            this.btnJmp.Size = new System.Drawing.Size(161, 43);
            this.btnJmp.TabIndex = 0;
            this.btnJmp.Text = "跳转";
            this.btnJmp.UseVisualStyleBackColor = true;
            this.btnJmp.Click += new System.EventHandler(this.btnJmp_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(204, 208);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(161, 43);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // gbOffset
            // 
            this.gbOffset.Controls.Add(panel2);
            this.gbOffset.Enabled = false;
            this.gbOffset.Location = new System.Drawing.Point(239, 69);
            this.gbOffset.Name = "gbOffset";
            this.gbOffset.Size = new System.Drawing.Size(210, 119);
            this.gbOffset.TabIndex = 3;
            this.gbOffset.TabStop = false;
            this.gbOffset.Text = "偏移方式";
            // 
            // cbHex
            // 
            this.cbHex.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbHex.Location = new System.Drawing.Point(371, 208);
            this.cbHex.Name = "cbHex";
            this.cbHex.Size = new System.Drawing.Size(75, 43);
            this.cbHex.TabIndex = 6;
            this.cbHex.Text = "Hex(&H)";
            this.cbHex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbHex.UseVisualStyleBackColor = true;
            this.cbHex.CheckedChanged += new System.EventHandler(this.cbHex_CheckedChanged);
            // 
            // ntOffset
            // 
            this.ntOffset.Enabled = false;
            this.ntOffset.Location = new System.Drawing.Point(297, 18);
            this.ntOffset.Name = "ntOffset";
            this.ntOffset.Size = new System.Drawing.Size(149, 25);
            this.ntOffset.TabIndex = 2;
            // 
            // ntRow
            // 
            this.ntRow.Location = new System.Drawing.Point(81, 18);
            this.ntRow.Name = "ntRow";
            this.ntRow.Size = new System.Drawing.Size(149, 25);
            this.ntRow.TabIndex = 2;
            // 
            // FrmGoto
            // 
            this.AcceptButton = this.btnJmp;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(474, 268);
            this.Controls.Add(this.cbHex);
            this.Controls.Add(this.gbOffset);
            this.Controls.Add(groupBox1);
            this.Controls.Add(this.ntOffset);
            this.Controls.Add(this.ntRow);
            this.Controls.Add(label2);
            this.Controls.Add(label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnJmp);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmGoto";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "定位";
            this.VisibleChanged += new System.EventHandler(this.FrmGoto_VisibleChanged);
            groupBox1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            this.gbOffset.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnJmp;
        private System.Windows.Forms.Button btnCancel;
        private NumericTextbox ntRow;
        private NumericTextbox ntOffset;
        private System.Windows.Forms.RadioButton rbRow;
        private System.Windows.Forms.RadioButton rbOffset;
        private System.Windows.Forms.RadioButton rbBase;
        private System.Windows.Forms.RadioButton rbCur;
        private System.Windows.Forms.GroupBox gbOffset;
        private System.Windows.Forms.CheckBox cbHex;
    }
}