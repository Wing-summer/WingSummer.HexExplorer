
namespace PEHexExplorer
{
    partial class FrmSetting
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbSetting = new System.Windows.Forms.ListBox();
            this.plGeneral = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lbSetting, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.plGeneral, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(773, 491);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lbSetting
            // 
            this.lbSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSetting.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.lbSetting.Items.AddRange(new object[] {
            "常规",
            "PE结构",
            "插件"});
            this.lbSetting.Location = new System.Drawing.Point(3, 3);
            this.lbSetting.Name = "lbSetting";
            this.lbSetting.Size = new System.Drawing.Size(294, 485);
            this.lbSetting.TabIndex = 0;
            this.lbSetting.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lbSetting_DrawItem);
            this.lbSetting.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.lbSetting_MeasureItem);
            // 
            // plGeneral
            // 
            this.plGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plGeneral.Location = new System.Drawing.Point(303, 3);
            this.plGeneral.Name = "plGeneral";
            this.plGeneral.Size = new System.Drawing.Size(467, 485);
            this.plGeneral.TabIndex = 1;
            // 
            // FrmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 491);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmSetting";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox lbSetting;
        private System.Windows.Forms.Panel plGeneral;
    }
}