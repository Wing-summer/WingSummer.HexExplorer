
namespace PEHexExplorer
{
    partial class FrmNewInsert
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
                newInsert = null;
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Button btnCancel;
            System.Windows.Forms.Button btnNew;
            System.Windows.Forms.Label label2;
            this.ntOffset = new System.Windows.Forms.NumericUpDown();
            this.cbHex = new System.Windows.Forms.CheckBox();
            this.ntValue = new System.Windows.Forms.NumericUpDown();
            label1 = new System.Windows.Forms.Label();
            btnCancel = new System.Windows.Forms.Button();
            btnNew = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ntOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ntValue)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(36, 29);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(82, 15);
            label1.TabIndex = 0;
            label1.Text = "文件偏移：";
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnCancel.Location = new System.Drawing.Point(228, 127);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(187, 43);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "取消";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnNew
            // 
            btnNew.Location = new System.Drawing.Point(26, 127);
            btnNew.Name = "btnNew";
            btnNew.Size = new System.Drawing.Size(187, 43);
            btnNew.TabIndex = 8;
            btnNew.Text = "新建";
            btnNew.UseVisualStyleBackColor = true;
            btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(51, 81);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(67, 15);
            label2.TabIndex = 0;
            label2.Text = "初始值：";
            // 
            // ntOffset
            // 
            this.ntOffset.Location = new System.Drawing.Point(124, 23);
            this.ntOffset.Name = "ntOffset";
            this.ntOffset.Size = new System.Drawing.Size(181, 25);
            this.ntOffset.TabIndex = 1;
            // 
            // cbHex
            // 
            this.cbHex.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbHex.Location = new System.Drawing.Point(329, 39);
            this.cbHex.Name = "cbHex";
            this.cbHex.Size = new System.Drawing.Size(75, 43);
            this.cbHex.TabIndex = 9;
            this.cbHex.Text = "Hex(&H)";
            this.cbHex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbHex.UseVisualStyleBackColor = true;
            this.cbHex.CheckedChanged += new System.EventHandler(this.cbHex_CheckedChanged);
            // 
            // ntValue
            // 
            this.ntValue.Location = new System.Drawing.Point(124, 78);
            this.ntValue.Name = "ntValue";
            this.ntValue.Size = new System.Drawing.Size(181, 25);
            this.ntValue.TabIndex = 1;
            // 
            // FrmNewInsert
            // 
            this.AcceptButton = btnNew;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = btnCancel;
            this.ClientSize = new System.Drawing.Size(447, 186);
            this.Controls.Add(this.cbHex);
            this.Controls.Add(btnCancel);
            this.Controls.Add(btnNew);
            this.Controls.Add(this.ntValue);
            this.Controls.Add(label2);
            this.Controls.Add(this.ntOffset);
            this.Controls.Add(label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmNewInsert";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "新建数据块";
            ((System.ComponentModel.ISupportInitialize)(this.ntOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ntValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown ntOffset;
        private System.Windows.Forms.CheckBox cbHex;
        private System.Windows.Forms.NumericUpDown ntValue;
    }
}