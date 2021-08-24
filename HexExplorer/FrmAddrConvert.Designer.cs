
namespace HexExplorer
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
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            this.ntRVA = new System.Windows.Forms.NumericUpDown();
            this.ntFOA = new System.Windows.Forms.NumericUpDown();
            this.ntVA = new System.Windows.Forms.NumericUpDown();
            this.ntBase = new System.Windows.Forms.NumericUpDown();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ntRVA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ntFOA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ntVA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ntBase)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(24, 100);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(46, 15);
            label2.TabIndex = 13;
            label2.Text = "RVA：";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(24, 61);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(46, 15);
            label1.TabIndex = 12;
            label1.Text = "FOA：";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(24, 25);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(38, 15);
            label3.TabIndex = 12;
            label3.Text = "VA：";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(24, 140);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(54, 15);
            label4.TabIndex = 13;
            label4.Text = "Base：";
            // 
            // ntRVA
            // 
            this.ntRVA.Hexadecimal = true;
            this.ntRVA.Location = new System.Drawing.Point(68, 95);
            this.ntRVA.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ntRVA.Name = "ntRVA";
            this.ntRVA.Size = new System.Drawing.Size(161, 25);
            this.ntRVA.TabIndex = 8;
            this.ntRVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ntRVA.ValueChanged += new System.EventHandler(this.NtValue_ValueChanged);
            // 
            // ntFOA
            // 
            this.ntFOA.Hexadecimal = true;
            this.ntFOA.Location = new System.Drawing.Point(68, 56);
            this.ntFOA.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ntFOA.Name = "ntFOA";
            this.ntFOA.Size = new System.Drawing.Size(161, 25);
            this.ntFOA.TabIndex = 7;
            this.ntFOA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ntFOA.ValueChanged += new System.EventHandler(this.NtOffset_ValueChanged);
            // 
            // ntVA
            // 
            this.ntVA.Hexadecimal = true;
            this.ntVA.Location = new System.Drawing.Point(68, 20);
            this.ntVA.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ntVA.Name = "ntVA";
            this.ntVA.Size = new System.Drawing.Size(161, 25);
            this.ntVA.TabIndex = 7;
            this.ntVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ntVA.ValueChanged += new System.EventHandler(this.NtOffset_ValueChanged);
            // 
            // ntBase
            // 
            this.ntBase.Hexadecimal = true;
            this.ntBase.Location = new System.Drawing.Point(84, 133);
            this.ntBase.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ntBase.Name = "ntBase";
            this.ntBase.Size = new System.Drawing.Size(145, 25);
            this.ntBase.TabIndex = 8;
            this.ntBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ntBase.ValueChanged += new System.EventHandler(this.NtValue_ValueChanged);
            // 
            // FrmAddrConvert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 176);
            this.Controls.Add(this.ntBase);
            this.Controls.Add(this.ntRVA);
            this.Controls.Add(label4);
            this.Controls.Add(label2);
            this.Controls.Add(this.ntVA);
            this.Controls.Add(label3);
            this.Controls.Add(this.ntFOA);
            this.Controls.Add(label1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "FrmAddrConvert";
            this.Text = "文件地址和虚拟地址转换器";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmAddrConvert_FormClosed);
            this.VisibleChanged += new System.EventHandler(this.FrmAddrConvert_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.ntRVA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ntFOA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ntVA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ntBase)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown ntRVA;
        private System.Windows.Forms.NumericUpDown ntFOA;
        private System.Windows.Forms.NumericUpDown ntVA;
        private System.Windows.Forms.NumericUpDown ntBase;
    }
}