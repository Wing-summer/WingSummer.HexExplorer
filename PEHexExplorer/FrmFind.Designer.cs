
using System;
using System.Windows.Forms;

namespace PEHexExplorer
{
    partial class FrmFind
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.RadioButton rbString;
        private System.Windows.Forms.RadioButton rbHex;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkMatchCase;
        private System.Windows.Forms.Timer timerPercent;
        private System.Windows.Forms.Timer timer;

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
            Be.Windows.Forms.PenF penF1 = new Be.Windows.Forms.PenF();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.rbString = new System.Windows.Forms.RadioButton();
            this.rbHex = new System.Windows.Forms.RadioButton();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkMatchCase = new System.Windows.Forms.CheckBox();
            this.timerPercent = new System.Windows.Forms.Timer(this.components);
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.hexFind = new Be.Windows.Forms.HexBox();
            this.lblPercent = new System.Windows.Forms.Label();
            this.lblFinding = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(20, 42);
            this.txtFind.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(504, 25);
            this.txtFind.TabIndex = 2;
            this.txtFind.TextChanged += new System.EventHandler(this.TxtString_TextChanged);
            // 
            // rbString
            // 
            this.rbString.Checked = true;
            this.rbString.Location = new System.Drawing.Point(20, 17);
            this.rbString.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbString.Name = "rbString";
            this.rbString.Size = new System.Drawing.Size(92, 18);
            this.rbString.TabIndex = 0;
            this.rbString.TabStop = true;
            this.rbString.Text = "字符串";
            this.rbString.CheckedChanged += new System.EventHandler(this.Rb_CheckedChanged);
            // 
            // rbHex
            // 
            this.rbHex.Location = new System.Drawing.Point(20, 83);
            this.rbHex.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbHex.Name = "rbHex";
            this.rbHex.Size = new System.Drawing.Size(92, 18);
            this.rbHex.TabIndex = 1;
            this.rbHex.Text = "十六进制";
            this.rbHex.CheckedChanged += new System.EventHandler(this.Rb_CheckedChanged);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(228, 278);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(145, 40);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(379, 278);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(145, 40);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // chkMatchCase
            // 
            this.chkMatchCase.AutoSize = true;
            this.chkMatchCase.Location = new System.Drawing.Point(429, 17);
            this.chkMatchCase.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkMatchCase.Name = "chkMatchCase";
            this.chkMatchCase.Size = new System.Drawing.Size(104, 19);
            this.chkMatchCase.TabIndex = 4;
            this.chkMatchCase.Text = "匹配大小写";
            this.chkMatchCase.UseVisualStyleBackColor = true;
            // 
            // timerPercent
            // 
            this.timerPercent.Tick += new System.EventHandler(this.TimerPercent_Tick);
            // 
            // timer
            // 
            this.timer.Interval = 50;
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // hexFind
            // 
            this.hexFind.ColumnInfoBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.hexFind.ColumnInfoVisible = true;
            this.hexFind.Enabled = false;
            this.hexFind.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.hexFind.GroupLinePen.Alignment = System.Drawing.Drawing2D.PenAlignment.Center;
            this.hexFind.GroupLinePen.Color = System.Drawing.Color.Gray;
            this.hexFind.GroupLinePen.DashCap = System.Drawing.Drawing2D.DashCap.Flat;
            this.hexFind.GroupLinePen.DashOffset = 0F;
            this.hexFind.GroupLinePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.hexFind.GroupLinePen.EndCap = System.Drawing.Drawing2D.LineCap.Flat;
            this.hexFind.GroupLinePen.StartCap = System.Drawing.Drawing2D.LineCap.Flat;
            this.hexFind.GroupLinePen.Width = 1F;
            this.hexFind.GroupSeparatorVisible = true;
            penF1.Alignment = System.Drawing.Drawing2D.PenAlignment.Center;
            penF1.Color = System.Drawing.Color.Gray;
            penF1.DashCap = System.Drawing.Drawing2D.DashCap.Flat;
            penF1.DashOffset = 0F;
            penF1.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            penF1.EndCap = System.Drawing.Drawing2D.LineCap.Flat;
            penF1.StartCap = System.Drawing.Drawing2D.LineCap.Flat;
            penF1.Width = 1F;
            this.hexFind.HexStringLinePen = penF1;
            this.hexFind.HScrollBarVisible = true;
            this.hexFind.LineInfoBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.hexFind.Location = new System.Drawing.Point(20, 106);
            this.hexFind.Name = "hexFind";
            this.hexFind.Scaling = 1F;
            this.hexFind.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.hexFind.ShowColumnInfoBackColor = true;
            this.hexFind.ShowLineInfoBackColor = true;
            this.hexFind.Size = new System.Drawing.Size(504, 159);
            this.hexFind.TabIndex = 3;
            this.hexFind.UseFixedBytesPerLine = true;
            this.hexFind.VScrollBarVisible = true;
            this.hexFind.EnabledChanged += new System.EventHandler(this.HexFind_EnabledChanged);
            // 
            // lblPercent
            // 
            this.lblPercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPercent.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPercent.Location = new System.Drawing.Point(20, 278);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(106, 40);
            this.lblPercent.TabIndex = 7;
            this.lblPercent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFinding
            // 
            this.lblFinding.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFinding.ForeColor = System.Drawing.Color.Blue;
            this.lblFinding.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblFinding.Location = new System.Drawing.Point(131, 278);
            this.lblFinding.Name = "lblFinding";
            this.lblFinding.Size = new System.Drawing.Size(88, 40);
            this.lblFinding.TabIndex = 8;
            // 
            // FrmFind
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(543, 332);
            this.Controls.Add(this.lblFinding);
            this.Controls.Add(this.lblPercent);
            this.Controls.Add(this.rbHex);
            this.Controls.Add(this.chkMatchCase);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.rbString);
            this.Controls.Add(this.txtFind);
            this.Controls.Add(this.hexFind);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmFind";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查找";
            this.Activated += new System.EventHandler(this.FrmFind_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmFind_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Be.Windows.Forms.HexBox hexFind;
        private Label lblPercent;
        private Label lblFinding;
    }

    #endregion
}
