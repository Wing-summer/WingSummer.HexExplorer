
using System;

namespace PEHexExplorer
{
    partial class FrmInsert
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInsert));
            this.hexBoxFill = new Be.Windows.Forms.HexBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // hexBoxFill
            // 
            this.hexBoxFill.BaseAddr = ((long)(0));
            this.hexBoxFill.ColumnInfoBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.hexBoxFill.ColumnInfoVisible = true;
            this.hexBoxFill.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.hexBoxFill.GroupLinePen.Alignment = System.Drawing.Drawing2D.PenAlignment.Center;
            this.hexBoxFill.GroupLinePen.Color = System.Drawing.Color.Gray;
            this.hexBoxFill.GroupLinePen.DashCap = System.Drawing.Drawing2D.DashCap.Flat;
            this.hexBoxFill.GroupLinePen.DashOffset = 0F;
            this.hexBoxFill.GroupLinePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.hexBoxFill.GroupLinePen.EndCap = System.Drawing.Drawing2D.LineCap.Flat;
            this.hexBoxFill.GroupLinePen.StartCap = System.Drawing.Drawing2D.LineCap.Flat;
            this.hexBoxFill.GroupLinePen.Width = 1F;
            this.hexBoxFill.GroupSeparatorVisible = true;
            this.hexBoxFill.HexStringLinePen = ((Be.Windows.Forms.PenF)(resources.GetObject("hexBoxFill.HexStringLinePen")));
            this.hexBoxFill.HScrollBarVisible = true;
            this.hexBoxFill.LineInfoBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.hexBoxFill.Location = new System.Drawing.Point(23, 41);
            this.hexBoxFill.Name = "hexBoxFill";
            this.hexBoxFill.Scaling = 1F;
            this.hexBoxFill.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.hexBoxFill.ShowColumnInfoBackColor = true;
            this.hexBoxFill.ShowLineInfoBackColor = true;
            this.hexBoxFill.Size = new System.Drawing.Size(504, 159);
            this.hexBoxFill.TabIndex = 0;
            this.hexBoxFill.UseFixedBytesPerLine = true;
            this.hexBoxFill.VScrollBarVisible = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "请输入插入字节：";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(23, 218);
            this.btnOk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(238, 31);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(289, 218);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(238, 31);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // FrmInsert
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(553, 268);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hexBoxFill);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "FrmInsert";
            this.Text = "插入数据";
            this.VisibleChanged += new System.EventHandler(this.FrmFill_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private Be.Windows.Forms.HexBox hexBoxFill;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;

    }
}