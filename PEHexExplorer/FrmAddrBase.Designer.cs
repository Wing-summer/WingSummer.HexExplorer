
namespace PEHexExplorer
{
    partial class FrmAddrBase
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
            this.nAddr = new System.Windows.Forms.NumericUpDown();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nAddr)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(28, 36);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(52, 15);
            label1.TabIndex = 0;
            label1.Text = "基址：";
            // 
            // nAddr
            // 
            this.nAddr.Hexadecimal = true;
            this.nAddr.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.nAddr.Location = new System.Drawing.Point(95, 31);
            this.nAddr.Name = "nAddr";
            this.nAddr.Size = new System.Drawing.Size(127, 25);
            this.nAddr.TabIndex = 1;
            this.toolTip1.SetToolTip(this.nAddr, "注意输入十六进制");
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(31, 86);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(78, 33);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "√";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(144, 86);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(78, 33);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "×";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // FrmAddrBase
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(261, 149);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(label1);
            this.Controls.Add(this.nAddr);
            this.Name = "FrmAddrBase";
            this.Text = "文件基址重定位";
            ((System.ComponentModel.ISupportInitialize)(this.nAddr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nAddr;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}