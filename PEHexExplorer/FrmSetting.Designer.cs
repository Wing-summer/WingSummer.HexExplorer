﻿
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TabPage tabGeneral;
            System.Windows.Forms.TabPage tabPE;
            System.Windows.Forms.TabPage tabBookMark;
            System.Windows.Forms.TabPage tabPlugin;
            System.Windows.Forms.GroupBox groupBox1;
            System.Windows.Forms.GroupBox groupBox2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            this.tabSetting = new System.Windows.Forms.TabControl();
            this.cD = new System.Windows.Forms.ColorDialog();
            this.cbEnablePlugin = new System.Windows.Forms.CheckBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.fD = new System.Windows.Forms.FontDialog();
            this.btnFont = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbEncoding = new System.Windows.Forms.ComboBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.button4 = new System.Windows.Forms.Button();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.propertyGrid2 = new System.Windows.Forms.PropertyGrid();
            this.checkedListBox2 = new System.Windows.Forms.CheckedListBox();
            tabGeneral = new System.Windows.Forms.TabPage();
            tabPE = new System.Windows.Forms.TabPage();
            tabBookMark = new System.Windows.Forms.TabPage();
            tabPlugin = new System.Windows.Forms.TabPage();
            groupBox1 = new System.Windows.Forms.GroupBox();
            groupBox2 = new System.Windows.Forms.GroupBox();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            tabGeneral.SuspendLayout();
            tabPE.SuspendLayout();
            tabBookMark.SuspendLayout();
            tabPlugin.SuspendLayout();
            this.tabSetting.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabGeneral
            // 
            tabGeneral.Controls.Add(groupBox2);
            tabGeneral.Controls.Add(groupBox1);
            tabGeneral.Location = new System.Drawing.Point(4, 29);
            tabGeneral.Name = "tabGeneral";
            tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            tabGeneral.Size = new System.Drawing.Size(690, 458);
            tabGeneral.TabIndex = 0;
            tabGeneral.Text = "常规";
            tabGeneral.UseVisualStyleBackColor = true;
            // 
            // tabPE
            // 
            tabPE.Controls.Add(this.button16);
            tabPE.Controls.Add(this.button15);
            tabPE.Controls.Add(this.button14);
            tabPE.Controls.Add(this.button13);
            tabPE.Controls.Add(this.button12);
            tabPE.Controls.Add(this.button11);
            tabPE.Controls.Add(this.button10);
            tabPE.Controls.Add(this.button9);
            tabPE.Controls.Add(this.button8);
            tabPE.Controls.Add(this.button5);
            tabPE.Location = new System.Drawing.Point(4, 29);
            tabPE.Name = "tabPE";
            tabPE.Padding = new System.Windows.Forms.Padding(3);
            tabPE.Size = new System.Drawing.Size(690, 458);
            tabPE.TabIndex = 1;
            tabPE.Text = "PE结构";
            tabPE.UseVisualStyleBackColor = true;
            // 
            // tabBookMark
            // 
            tabBookMark.Controls.Add(this.propertyGrid2);
            tabBookMark.Controls.Add(this.checkedListBox2);
            tabBookMark.Controls.Add(this.checkBox6);
            tabBookMark.Location = new System.Drawing.Point(4, 29);
            tabBookMark.Name = "tabBookMark";
            tabBookMark.Padding = new System.Windows.Forms.Padding(3);
            tabBookMark.Size = new System.Drawing.Size(690, 458);
            tabBookMark.TabIndex = 2;
            tabBookMark.Text = "书签";
            tabBookMark.UseVisualStyleBackColor = true;
            // 
            // tabPlugin
            // 
            tabPlugin.Controls.Add(this.propertyGrid1);
            tabPlugin.Controls.Add(this.checkedListBox1);
            tabPlugin.Controls.Add(this.cbEnablePlugin);
            tabPlugin.Location = new System.Drawing.Point(4, 29);
            tabPlugin.Name = "tabPlugin";
            tabPlugin.Padding = new System.Windows.Forms.Padding(3);
            tabPlugin.Size = new System.Drawing.Size(690, 458);
            tabPlugin.TabIndex = 3;
            tabPlugin.Text = "插件";
            tabPlugin.UseVisualStyleBackColor = true;
            // 
            // tabSetting
            // 
            this.tabSetting.Controls.Add(tabGeneral);
            this.tabSetting.Controls.Add(tabPE);
            this.tabSetting.Controls.Add(tabBookMark);
            this.tabSetting.Controls.Add(tabPlugin);
            this.tabSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSetting.Location = new System.Drawing.Point(0, 0);
            this.tabSetting.Multiline = true;
            this.tabSetting.Name = "tabSetting";
            this.tabSetting.SelectedIndex = 0;
            this.tabSetting.Size = new System.Drawing.Size(698, 491);
            this.tabSetting.TabIndex = 0;
            // 
            // cbEnablePlugin
            // 
            this.cbEnablePlugin.AutoSize = true;
            this.cbEnablePlugin.Checked = true;
            this.cbEnablePlugin.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbEnablePlugin.Location = new System.Drawing.Point(31, 28);
            this.cbEnablePlugin.Name = "cbEnablePlugin";
            this.cbEnablePlugin.Size = new System.Drawing.Size(256, 24);
            this.cbEnablePlugin.TabIndex = 0;
            this.cbEnablePlugin.Text = "启用插件支持（修改后重启有效）";
            this.cbEnablePlugin.UseVisualStyleBackColor = true;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(23, 71);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(313, 356);
            this.checkedListBox1.TabIndex = 1;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.HelpVisible = false;
            this.propertyGrid1.Location = new System.Drawing.Point(353, 69);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(316, 358);
            this.propertyGrid1.TabIndex = 2;
            // 
            // fD
            // 
            this.fD.AllowVectorFonts = false;
            this.fD.AllowVerticalFonts = false;
            this.fD.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fD.ScriptsOnly = true;
            this.fD.ShowEffects = false;
            // 
            // btnFont
            // 
            this.btnFont.Location = new System.Drawing.Point(85, 38);
            this.btnFont.Name = "btnFont";
            this.btnFont.Size = new System.Drawing.Size(133, 40);
            this.btnFont.TabIndex = 0;
            this.btnFont.Text = "微软雅黑";
            this.btnFont.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "字体：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "字符表编码：";
            // 
            // cbEncoding
            // 
            this.cbEncoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEncoding.FormattingEnabled = true;
            this.cbEncoding.Items.AddRange(new object[] {
            "ASCII",
            "EBCDIC",
            "Unicode"});
            this.cbEncoding.Location = new System.Drawing.Point(29, 139);
            this.cbEncoding.Name = "cbEncoding";
            this.cbEncoding.Size = new System.Drawing.Size(189, 28);
            this.cbEncoding.TabIndex = 2;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(this.checkBox4);
            groupBox1.Controls.Add(this.checkBox3);
            groupBox1.Controls.Add(this.button4);
            groupBox1.Controls.Add(this.checkBox2);
            groupBox1.Controls.Add(this.button3);
            groupBox1.Controls.Add(this.checkBox5);
            groupBox1.Controls.Add(this.checkBox1);
            groupBox1.Controls.Add(this.button2);
            groupBox1.Controls.Add(this.button7);
            groupBox1.Controls.Add(this.button6);
            groupBox1.Controls.Add(this.button1);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(this.numericUpDown1);
            groupBox1.Controls.Add(label3);
            groupBox1.Location = new System.Drawing.Point(20, 222);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(649, 221);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "十六进制编辑区相关";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(this.label1);
            groupBox2.Controls.Add(this.btnFont);
            groupBox2.Controls.Add(this.cbEncoding);
            groupBox2.Controls.Add(this.label2);
            groupBox2.Location = new System.Drawing.Point(20, 13);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(649, 203);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "外观";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DecimalPlaces = 1;
            this.numericUpDown1.Location = new System.Drawing.Point(106, 45);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(89, 27);
            this.numericUpDown1.TabIndex = 4;
            this.numericUpDown1.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(25, 47);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(84, 20);
            label3.TabIndex = 1;
            label3.Text = "默认缩放：";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(201, 47);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(22, 20);
            label4.TabIndex = 1;
            label4.Text = "%";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(262, 50);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(91, 24);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "文件地址";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(359, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(48, 33);
            this.button1.TabIndex = 0;
            this.button1.Text = "☻";
            this.toolTip.SetToolTip(this.button1, "更改颜色");
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(359, 84);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(48, 33);
            this.button2.TabIndex = 0;
            this.button2.Text = "☻";
            this.toolTip.SetToolTip(this.button2, "更改颜色");
            this.button2.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(262, 89);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(91, 24);
            this.checkBox2.TabIndex = 5;
            this.checkBox2.Text = "列标索引";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(359, 124);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(48, 33);
            this.button3.TabIndex = 0;
            this.button3.Text = "☻";
            this.toolTip.SetToolTip(this.button3, "更改颜色");
            this.button3.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.Location = new System.Drawing.Point(262, 129);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(91, 24);
            this.checkBox3.TabIndex = 5;
            this.checkBox3.Text = "组分割线";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(359, 163);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(48, 33);
            this.button4.TabIndex = 0;
            this.button4.Text = "☻";
            this.toolTip.SetToolTip(this.button4, "更改颜色");
            this.button4.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Checked = true;
            this.checkBox4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox4.Location = new System.Drawing.Point(262, 168);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(91, 24);
            this.checkBox4.TabIndex = 5;
            this.checkBox4.Text = "字分割线";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Checked = true;
            this.checkBox5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox5.Location = new System.Drawing.Point(29, 85);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(76, 24);
            this.checkBox5.TabIndex = 5;
            this.checkBox5.Text = "字符表";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(83, 34);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(241, 40);
            this.button5.TabIndex = 1;
            this.button5.Text = "IMAGE_DOS_HEADER";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(29, 117);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(194, 37);
            this.button6.TabIndex = 0;
            this.button6.Text = "选区颜色";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(29, 161);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(194, 37);
            this.button7.TabIndex = 0;
            this.button7.Text = "选中颜色";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(83, 92);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(241, 40);
            this.button8.TabIndex = 1;
            this.button8.Text = "IMAGE_NT_HEADERS";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(83, 150);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(241, 40);
            this.button9.TabIndex = 1;
            this.button9.Text = "IMAGE_FILE_HEADER";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(83, 208);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(241, 40);
            this.button10.TabIndex = 1;
            this.button10.Text = " IMAGE_OPTIONAL_HEADER";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(83, 266);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(241, 40);
            this.button11.TabIndex = 1;
            this.button11.Text = "IMAGE_DATA_DIRECTORY";
            this.button11.UseVisualStyleBackColor = true;
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(83, 324);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(241, 40);
            this.button12.TabIndex = 1;
            this.button12.Text = "IMAGE_SECTION_HEADER";
            this.button12.UseVisualStyleBackColor = true;
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(83, 382);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(241, 40);
            this.button13.TabIndex = 1;
            this.button13.Text = "IMAGE_EXPORT_DIRECTORY";
            this.button13.UseVisualStyleBackColor = true;
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(358, 34);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(241, 40);
            this.button14.TabIndex = 1;
            this.button14.Text = "IMAGE_IMPORT_DESCRIPTOR";
            this.button14.UseVisualStyleBackColor = true;
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(358, 92);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(241, 40);
            this.button15.TabIndex = 1;
            this.button15.Text = "IMAGE_BASE_RELOCATION ";
            this.button15.UseVisualStyleBackColor = true;
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(358, 150);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(241, 40);
            this.button16.TabIndex = 1;
            this.button16.Text = "其他";
            this.button16.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Checked = true;
            this.checkBox6.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox6.Location = new System.Drawing.Point(26, 29);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(151, 24);
            this.checkBox6.TabIndex = 11;
            this.checkBox6.Text = "启用高级书签支持";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // propertyGrid2
            // 
            this.propertyGrid2.HelpVisible = false;
            this.propertyGrid2.Location = new System.Drawing.Point(354, 76);
            this.propertyGrid2.Name = "propertyGrid2";
            this.propertyGrid2.Size = new System.Drawing.Size(316, 358);
            this.propertyGrid2.TabIndex = 13;
            // 
            // checkedListBox2
            // 
            this.checkedListBox2.FormattingEnabled = true;
            this.checkedListBox2.Location = new System.Drawing.Point(24, 78);
            this.checkedListBox2.Name = "checkedListBox2";
            this.checkedListBox2.Size = new System.Drawing.Size(313, 356);
            this.checkedListBox2.TabIndex = 12;
            // 
            // FrmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 491);
            this.Controls.Add(this.tabSetting);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmSetting";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置";
            this.VisibleChanged += new System.EventHandler(this.FrmSetting_VisibleChanged);
            tabGeneral.ResumeLayout(false);
            tabPE.ResumeLayout(false);
            tabBookMark.ResumeLayout(false);
            tabBookMark.PerformLayout();
            tabPlugin.ResumeLayout(false);
            tabPlugin.PerformLayout();
            this.tabSetting.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabSetting;
        private System.Windows.Forms.ColorDialog cD;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.CheckBox cbEnablePlugin;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.FontDialog fD;
        private System.Windows.Forms.Button btnFont;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbEncoding;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.PropertyGrid propertyGrid2;
        private System.Windows.Forms.CheckedListBox checkedListBox2;
    }
}