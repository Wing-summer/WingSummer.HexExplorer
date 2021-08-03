﻿
namespace PEHexExplorer
{
    partial class FrmAddrConvert
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
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            this.ntValue = new System.Windows.Forms.NumericUpDown();
            this.ntOffset = new System.Windows.Forms.NumericUpDown();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ntValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ntOffset)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(25, 80);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(84, 20);
            label2.TabIndex = 13;
            label2.Text = "虚拟偏移：";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(25, 27);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(84, 20);
            label1.TabIndex = 12;
            label1.Text = "文件偏移：";
            // 
            // ntValue
            // 
            this.ntValue.Enabled = false;
            this.ntValue.Hexadecimal = true;
            this.ntValue.Location = new System.Drawing.Point(113, 75);
            this.ntValue.Name = "ntValue";
            this.ntValue.Size = new System.Drawing.Size(181, 27);
            this.ntValue.TabIndex = 8;
            this.ntValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ntValue.ValueChanged += new System.EventHandler(this.ntValue_ValueChanged);
            // 
            // ntOffset
            // 
            this.ntOffset.Enabled = false;
            this.ntOffset.Hexadecimal = true;
            this.ntOffset.Location = new System.Drawing.Point(113, 23);
            this.ntOffset.Name = "ntOffset";
            this.ntOffset.Size = new System.Drawing.Size(181, 27);
            this.ntOffset.TabIndex = 7;
            this.ntOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ntOffset.ValueChanged += new System.EventHandler(this.ntOffset_ValueChanged);
            // 
            // FrmAddrConvert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 133);
            this.Controls.Add(this.ntValue);
            this.Controls.Add(label2);
            this.Controls.Add(this.ntOffset);
            this.Controls.Add(label1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmAddrConvert";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "文件地址和虚拟地址转换器";
            this.VisibleChanged += new System.EventHandler(this.FrmAddrConvert_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.ntValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ntOffset)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown ntValue;
        private System.Windows.Forms.NumericUpDown ntOffset;
    }
}