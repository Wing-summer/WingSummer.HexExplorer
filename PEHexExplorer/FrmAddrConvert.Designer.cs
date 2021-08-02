
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
            System.Windows.Forms.Button btnCancel;
            System.Windows.Forms.Button btnNew;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            this.cbHex = new System.Windows.Forms.CheckBox();
            this.ntValue = new System.Windows.Forms.NumericUpDown();
            this.ntOffset = new System.Windows.Forms.NumericUpDown();
            btnCancel = new System.Windows.Forms.Button();
            btnNew = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ntValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ntOffset)).BeginInit();
            this.SuspendLayout();
            // 
            // cbHex
            // 
            this.cbHex.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbHex.Location = new System.Drawing.Point(412, 51);
            this.cbHex.Name = "cbHex";
            this.cbHex.Size = new System.Drawing.Size(75, 43);
            this.cbHex.TabIndex = 9;
            this.cbHex.Text = "Hex(&H)";
            this.cbHex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbHex.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnCancel.Location = new System.Drawing.Point(311, 139);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(187, 43);
            btnCancel.TabIndex = 11;
            btnCancel.Text = "取消";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnNew
            // 
            btnNew.Location = new System.Drawing.Point(109, 139);
            btnNew.Name = "btnNew";
            btnNew.Size = new System.Drawing.Size(187, 43);
            btnNew.TabIndex = 10;
            btnNew.Text = "新建";
            btnNew.UseVisualStyleBackColor = true;
            // 
            // ntValue
            // 
            this.ntValue.Location = new System.Drawing.Point(207, 90);
            this.ntValue.Name = "ntValue";
            this.ntValue.Size = new System.Drawing.Size(181, 27);
            this.ntValue.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(134, 93);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(69, 20);
            label2.TabIndex = 13;
            label2.Text = "初始值：";
            // 
            // ntOffset
            // 
            this.ntOffset.Location = new System.Drawing.Point(207, 35);
            this.ntOffset.Name = "ntOffset";
            this.ntOffset.Size = new System.Drawing.Size(181, 27);
            this.ntOffset.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(119, 41);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(84, 20);
            label1.TabIndex = 12;
            label1.Text = "文件偏移：";
            // 
            // FrmAddrConvert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 217);
            this.Controls.Add(this.cbHex);
            this.Controls.Add(btnCancel);
            this.Controls.Add(btnNew);
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
            ((System.ComponentModel.ISupportInitialize)(this.ntValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ntOffset)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbHex;
        private System.Windows.Forms.NumericUpDown ntValue;
        private System.Windows.Forms.NumericUpDown ntOffset;
    }
}