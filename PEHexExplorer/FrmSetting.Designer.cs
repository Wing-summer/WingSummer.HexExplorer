
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
            System.Windows.Forms.GroupBox groupBox2;
            System.Windows.Forms.GroupBox groupBox1;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.TabPage tabPE;
            System.Windows.Forms.TabPage tabBookMark;
            System.Windows.Forms.TabPage tabPlugin;
            this.label1 = new System.Windows.Forms.Label();
            this.btnFont = new System.Windows.Forms.Button();
            this.cbEncoding = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStringLine = new System.Windows.Forms.Button();
            this.btnGroupLine = new System.Windows.Forms.Button();
            this.btnColInfo = new System.Windows.Forms.Button();
            this.btnLineInfo = new System.Windows.Forms.Button();
            this.cbStringLine = new System.Windows.Forms.CheckBox();
            this.cbGroupLine = new System.Windows.Forms.CheckBox();
            this.cbColInfo = new System.Windows.Forms.CheckBox();
            this.cbEnableString = new System.Windows.Forms.CheckBox();
            this.cbLineInfo = new System.Windows.Forms.CheckBox();
            this.btnSelTextColor = new System.Windows.Forms.Button();
            this.btnSelBackColor = new System.Windows.Forms.Button();
            this.ntScaling = new System.Windows.Forms.NumericUpDown();
            this.cbEnablePE = new System.Windows.Forms.CheckBox();
            this.btnOther = new System.Windows.Forms.Button();
            this.btnIMAGE_BASE_RELOCATION = new System.Windows.Forms.Button();
            this.btnIMAGE_IMPORT_DESCRIPTOR = new System.Windows.Forms.Button();
            this.btnIMAGE_EXPORT_DIRECTORY = new System.Windows.Forms.Button();
            this.btnIMAGE_SECTION_HEADER = new System.Windows.Forms.Button();
            this.btnIMAGE_DATA_DIRECTORY = new System.Windows.Forms.Button();
            this.btnIMAGE_OPTIONAL_HEADER = new System.Windows.Forms.Button();
            this.btnIMAGE_FILE_HEADER = new System.Windows.Forms.Button();
            this.btnIMAGE_NT_HEADERS = new System.Windows.Forms.Button();
            this.btnIMAGE_DOS_HEADER = new System.Windows.Forms.Button();
            this.pgBookMark = new System.Windows.Forms.PropertyGrid();
            this.clbBookMark = new System.Windows.Forms.CheckedListBox();
            this.cbEnableBookMark = new System.Windows.Forms.CheckBox();
            this.pgPlugin = new System.Windows.Forms.PropertyGrid();
            this.clbPlugin = new System.Windows.Forms.ListBox();
            this.cbEnablePlugin = new System.Windows.Forms.CheckBox();
            this.tabSetting = new System.Windows.Forms.TabControl();
            this.cD = new System.Windows.Forms.ColorDialog();
            this.fD = new System.Windows.Forms.FontDialog();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            tabGeneral = new System.Windows.Forms.TabPage();
            groupBox2 = new System.Windows.Forms.GroupBox();
            groupBox1 = new System.Windows.Forms.GroupBox();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            tabPE = new System.Windows.Forms.TabPage();
            tabBookMark = new System.Windows.Forms.TabPage();
            tabPlugin = new System.Windows.Forms.TabPage();
            tabGeneral.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ntScaling)).BeginInit();
            tabPE.SuspendLayout();
            tabBookMark.SuspendLayout();
            tabPlugin.SuspendLayout();
            this.tabSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabGeneral
            // 
            tabGeneral.Controls.Add(groupBox2);
            tabGeneral.Controls.Add(groupBox1);
            tabGeneral.Location = new System.Drawing.Point(4, 25);
            tabGeneral.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            tabGeneral.Name = "tabGeneral";
            tabGeneral.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            tabGeneral.Size = new System.Drawing.Size(612, 339);
            tabGeneral.TabIndex = 0;
            tabGeneral.Text = "常规";
            tabGeneral.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(this.label1);
            groupBox2.Controls.Add(this.btnFont);
            groupBox2.Controls.Add(this.cbEncoding);
            groupBox2.Controls.Add(this.label2);
            groupBox2.Location = new System.Drawing.Point(18, 10);
            groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            groupBox2.Size = new System.Drawing.Size(577, 152);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "外观";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "字体：";
            // 
            // btnFont
            // 
            this.btnFont.Location = new System.Drawing.Point(76, 28);
            this.btnFont.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFont.Name = "btnFont";
            this.btnFont.Size = new System.Drawing.Size(118, 30);
            this.btnFont.TabIndex = 0;
            this.btnFont.Text = "微软雅黑";
            this.btnFont.UseVisualStyleBackColor = true;
            // 
            // cbEncoding
            // 
            this.cbEncoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEncoding.FormattingEnabled = true;
            this.cbEncoding.Items.AddRange(new object[] {
            "ASCII",
            "EBCDIC",
            "Unicode"});
            this.cbEncoding.Location = new System.Drawing.Point(26, 104);
            this.cbEncoding.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbEncoding.Name = "cbEncoding";
            this.cbEncoding.Size = new System.Drawing.Size(168, 23);
            this.cbEncoding.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "字符表编码：";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(this.btnStringLine);
            groupBox1.Controls.Add(this.btnGroupLine);
            groupBox1.Controls.Add(this.btnColInfo);
            groupBox1.Controls.Add(this.btnLineInfo);
            groupBox1.Controls.Add(this.cbStringLine);
            groupBox1.Controls.Add(this.cbGroupLine);
            groupBox1.Controls.Add(this.cbColInfo);
            groupBox1.Controls.Add(this.cbEnableString);
            groupBox1.Controls.Add(this.cbLineInfo);
            groupBox1.Controls.Add(this.btnSelTextColor);
            groupBox1.Controls.Add(this.btnSelBackColor);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(this.ntScaling);
            groupBox1.Controls.Add(label3);
            groupBox1.Location = new System.Drawing.Point(18, 166);
            groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            groupBox1.Size = new System.Drawing.Size(577, 166);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "十六进制编辑区相关";
            // 
            // btnStringLine
            // 
            this.btnStringLine.Location = new System.Drawing.Point(319, 122);
            this.btnStringLine.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStringLine.Name = "btnStringLine";
            this.btnStringLine.Size = new System.Drawing.Size(43, 25);
            this.btnStringLine.TabIndex = 0;
            this.btnStringLine.Text = "🖊";
            this.toolTip.SetToolTip(this.btnStringLine, "更改颜色");
            this.btnStringLine.UseVisualStyleBackColor = true;
            this.btnStringLine.Click += new System.EventHandler(this.BtnPenFEdit_Click);
            // 
            // btnGroupLine
            // 
            this.btnGroupLine.Location = new System.Drawing.Point(319, 93);
            this.btnGroupLine.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGroupLine.Name = "btnGroupLine";
            this.btnGroupLine.Size = new System.Drawing.Size(43, 25);
            this.btnGroupLine.TabIndex = 0;
            this.btnGroupLine.Text = "🖊";
            this.toolTip.SetToolTip(this.btnGroupLine, "更改颜色");
            this.btnGroupLine.UseVisualStyleBackColor = true;
            this.btnGroupLine.Click += new System.EventHandler(this.BtnPenFEdit_Click);
            // 
            // btnColInfo
            // 
            this.btnColInfo.BackColor = System.Drawing.Color.Black;
            this.btnColInfo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnColInfo.ForeColor = System.Drawing.Color.White;
            this.btnColInfo.Location = new System.Drawing.Point(319, 63);
            this.btnColInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnColInfo.Name = "btnColInfo";
            this.btnColInfo.Size = new System.Drawing.Size(43, 25);
            this.btnColInfo.TabIndex = 0;
            this.btnColInfo.Text = "☻";
            this.toolTip.SetToolTip(this.btnColInfo, "更改颜色");
            this.btnColInfo.UseVisualStyleBackColor = false;
            this.btnColInfo.Click += new System.EventHandler(this.BtnSelectColor_Click);
            // 
            // btnLineInfo
            // 
            this.btnLineInfo.BackColor = System.Drawing.Color.Black;
            this.btnLineInfo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLineInfo.ForeColor = System.Drawing.Color.White;
            this.btnLineInfo.Location = new System.Drawing.Point(319, 34);
            this.btnLineInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLineInfo.Name = "btnLineInfo";
            this.btnLineInfo.Size = new System.Drawing.Size(43, 25);
            this.btnLineInfo.TabIndex = 0;
            this.btnLineInfo.Text = "☻";
            this.toolTip.SetToolTip(this.btnLineInfo, "更改颜色");
            this.btnLineInfo.UseVisualStyleBackColor = false;
            this.btnLineInfo.Click += new System.EventHandler(this.BtnSelectColor_Click);
            // 
            // cbStringLine
            // 
            this.cbStringLine.AutoSize = true;
            this.cbStringLine.Checked = true;
            this.cbStringLine.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbStringLine.Location = new System.Drawing.Point(233, 126);
            this.cbStringLine.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbStringLine.Name = "cbStringLine";
            this.cbStringLine.Size = new System.Drawing.Size(89, 19);
            this.cbStringLine.TabIndex = 5;
            this.cbStringLine.Text = "字分割线";
            this.cbStringLine.UseVisualStyleBackColor = true;
            // 
            // cbGroupLine
            // 
            this.cbGroupLine.AutoSize = true;
            this.cbGroupLine.Checked = true;
            this.cbGroupLine.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbGroupLine.Location = new System.Drawing.Point(233, 97);
            this.cbGroupLine.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbGroupLine.Name = "cbGroupLine";
            this.cbGroupLine.Size = new System.Drawing.Size(89, 19);
            this.cbGroupLine.TabIndex = 5;
            this.cbGroupLine.Text = "组分割线";
            this.cbGroupLine.UseVisualStyleBackColor = true;
            // 
            // cbColInfo
            // 
            this.cbColInfo.AutoSize = true;
            this.cbColInfo.Checked = true;
            this.cbColInfo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbColInfo.Location = new System.Drawing.Point(233, 67);
            this.cbColInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbColInfo.Name = "cbColInfo";
            this.cbColInfo.Size = new System.Drawing.Size(89, 19);
            this.cbColInfo.TabIndex = 5;
            this.cbColInfo.Text = "列标索引";
            this.cbColInfo.UseVisualStyleBackColor = true;
            // 
            // cbEnableString
            // 
            this.cbEnableString.AutoSize = true;
            this.cbEnableString.Checked = true;
            this.cbEnableString.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbEnableString.Location = new System.Drawing.Point(26, 64);
            this.cbEnableString.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbEnableString.Name = "cbEnableString";
            this.cbEnableString.Size = new System.Drawing.Size(74, 19);
            this.cbEnableString.TabIndex = 5;
            this.cbEnableString.Text = "字符表";
            this.cbEnableString.UseVisualStyleBackColor = true;
            // 
            // cbLineInfo
            // 
            this.cbLineInfo.AutoSize = true;
            this.cbLineInfo.Checked = true;
            this.cbLineInfo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbLineInfo.Location = new System.Drawing.Point(233, 38);
            this.cbLineInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbLineInfo.Name = "cbLineInfo";
            this.cbLineInfo.Size = new System.Drawing.Size(89, 19);
            this.cbLineInfo.TabIndex = 5;
            this.cbLineInfo.Text = "行号信息";
            this.cbLineInfo.UseVisualStyleBackColor = true;
            // 
            // btnSelTextColor
            // 
            this.btnSelTextColor.BackColor = System.Drawing.Color.Black;
            this.btnSelTextColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSelTextColor.ForeColor = System.Drawing.Color.White;
            this.btnSelTextColor.Location = new System.Drawing.Point(26, 121);
            this.btnSelTextColor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSelTextColor.Name = "btnSelTextColor";
            this.btnSelTextColor.Size = new System.Drawing.Size(172, 28);
            this.btnSelTextColor.TabIndex = 0;
            this.btnSelTextColor.Text = "选中颜色";
            this.btnSelTextColor.UseVisualStyleBackColor = false;
            this.btnSelTextColor.Click += new System.EventHandler(this.BtnSelectColor_Click);
            // 
            // btnSelBackColor
            // 
            this.btnSelBackColor.BackColor = System.Drawing.Color.Black;
            this.btnSelBackColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSelBackColor.ForeColor = System.Drawing.Color.White;
            this.btnSelBackColor.Location = new System.Drawing.Point(26, 88);
            this.btnSelBackColor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSelBackColor.Name = "btnSelBackColor";
            this.btnSelBackColor.Size = new System.Drawing.Size(172, 28);
            this.btnSelBackColor.TabIndex = 0;
            this.btnSelBackColor.Text = "选区颜色";
            this.btnSelBackColor.UseVisualStyleBackColor = false;
            this.btnSelBackColor.Click += new System.EventHandler(this.BtnSelectColor_Click);
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(179, 32);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(15, 15);
            label4.TabIndex = 1;
            label4.Text = "%";
            // 
            // ntScaling
            // 
            this.ntScaling.DecimalPlaces = 1;
            this.ntScaling.Location = new System.Drawing.Point(97, 28);
            this.ntScaling.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ntScaling.Name = "ntScaling";
            this.ntScaling.Size = new System.Drawing.Size(79, 25);
            this.ntScaling.TabIndex = 4;
            this.ntScaling.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(22, 32);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(82, 15);
            label3.TabIndex = 1;
            label3.Text = "默认缩放：";
            // 
            // tabPE
            // 
            tabPE.Controls.Add(this.cbEnablePE);
            tabPE.Controls.Add(this.btnOther);
            tabPE.Controls.Add(this.btnIMAGE_BASE_RELOCATION);
            tabPE.Controls.Add(this.btnIMAGE_IMPORT_DESCRIPTOR);
            tabPE.Controls.Add(this.btnIMAGE_EXPORT_DIRECTORY);
            tabPE.Controls.Add(this.btnIMAGE_SECTION_HEADER);
            tabPE.Controls.Add(this.btnIMAGE_DATA_DIRECTORY);
            tabPE.Controls.Add(this.btnIMAGE_OPTIONAL_HEADER);
            tabPE.Controls.Add(this.btnIMAGE_FILE_HEADER);
            tabPE.Controls.Add(this.btnIMAGE_NT_HEADERS);
            tabPE.Controls.Add(this.btnIMAGE_DOS_HEADER);
            tabPE.Location = new System.Drawing.Point(4, 25);
            tabPE.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            tabPE.Name = "tabPE";
            tabPE.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            tabPE.Size = new System.Drawing.Size(612, 339);
            tabPE.TabIndex = 1;
            tabPE.Text = "PE结构";
            tabPE.UseVisualStyleBackColor = true;
            // 
            // cbEnablePE
            // 
            this.cbEnablePE.AutoSize = true;
            this.cbEnablePE.Checked = true;
            this.cbEnablePE.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbEnablePE.Location = new System.Drawing.Point(361, 224);
            this.cbEnablePE.Name = "cbEnablePE";
            this.cbEnablePE.Size = new System.Drawing.Size(135, 19);
            this.cbEnablePE.TabIndex = 2;
            this.cbEnablePE.Text = "PE结构分析支持";
            this.cbEnablePE.UseVisualStyleBackColor = true;
            // 
            // btnOther
            // 
            this.btnOther.BackColor = System.Drawing.Color.Black;
            this.btnOther.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOther.ForeColor = System.Drawing.Color.White;
            this.btnOther.Location = new System.Drawing.Point(318, 112);
            this.btnOther.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOther.Name = "btnOther";
            this.btnOther.Size = new System.Drawing.Size(214, 30);
            this.btnOther.TabIndex = 1;
            this.btnOther.Text = "其他";
            this.btnOther.UseVisualStyleBackColor = false;
            this.btnOther.Click += new System.EventHandler(this.BtnSelectColor_Click);
            // 
            // btnIMAGE_BASE_RELOCATION
            // 
            this.btnIMAGE_BASE_RELOCATION.BackColor = System.Drawing.Color.Black;
            this.btnIMAGE_BASE_RELOCATION.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnIMAGE_BASE_RELOCATION.ForeColor = System.Drawing.Color.White;
            this.btnIMAGE_BASE_RELOCATION.Location = new System.Drawing.Point(318, 69);
            this.btnIMAGE_BASE_RELOCATION.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnIMAGE_BASE_RELOCATION.Name = "btnIMAGE_BASE_RELOCATION";
            this.btnIMAGE_BASE_RELOCATION.Size = new System.Drawing.Size(214, 30);
            this.btnIMAGE_BASE_RELOCATION.TabIndex = 1;
            this.btnIMAGE_BASE_RELOCATION.Text = "IMAGE_BASE_RELOCATION ";
            this.btnIMAGE_BASE_RELOCATION.UseVisualStyleBackColor = false;
            this.btnIMAGE_BASE_RELOCATION.Click += new System.EventHandler(this.BtnSelectColor_Click);
            // 
            // btnIMAGE_IMPORT_DESCRIPTOR
            // 
            this.btnIMAGE_IMPORT_DESCRIPTOR.BackColor = System.Drawing.Color.Black;
            this.btnIMAGE_IMPORT_DESCRIPTOR.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnIMAGE_IMPORT_DESCRIPTOR.ForeColor = System.Drawing.Color.White;
            this.btnIMAGE_IMPORT_DESCRIPTOR.Location = new System.Drawing.Point(318, 26);
            this.btnIMAGE_IMPORT_DESCRIPTOR.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnIMAGE_IMPORT_DESCRIPTOR.Name = "btnIMAGE_IMPORT_DESCRIPTOR";
            this.btnIMAGE_IMPORT_DESCRIPTOR.Size = new System.Drawing.Size(214, 30);
            this.btnIMAGE_IMPORT_DESCRIPTOR.TabIndex = 1;
            this.btnIMAGE_IMPORT_DESCRIPTOR.Text = "IMAGE_IMPORT_DESCRIPTOR";
            this.btnIMAGE_IMPORT_DESCRIPTOR.UseVisualStyleBackColor = false;
            this.btnIMAGE_IMPORT_DESCRIPTOR.Click += new System.EventHandler(this.BtnSelectColor_Click);
            // 
            // btnIMAGE_EXPORT_DIRECTORY
            // 
            this.btnIMAGE_EXPORT_DIRECTORY.BackColor = System.Drawing.Color.Black;
            this.btnIMAGE_EXPORT_DIRECTORY.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnIMAGE_EXPORT_DIRECTORY.ForeColor = System.Drawing.Color.White;
            this.btnIMAGE_EXPORT_DIRECTORY.Location = new System.Drawing.Point(74, 286);
            this.btnIMAGE_EXPORT_DIRECTORY.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnIMAGE_EXPORT_DIRECTORY.Name = "btnIMAGE_EXPORT_DIRECTORY";
            this.btnIMAGE_EXPORT_DIRECTORY.Size = new System.Drawing.Size(214, 30);
            this.btnIMAGE_EXPORT_DIRECTORY.TabIndex = 1;
            this.btnIMAGE_EXPORT_DIRECTORY.Text = "IMAGE_EXPORT_DIRECTORY";
            this.btnIMAGE_EXPORT_DIRECTORY.UseVisualStyleBackColor = false;
            this.btnIMAGE_EXPORT_DIRECTORY.Click += new System.EventHandler(this.BtnSelectColor_Click);
            // 
            // btnIMAGE_SECTION_HEADER
            // 
            this.btnIMAGE_SECTION_HEADER.BackColor = System.Drawing.Color.Black;
            this.btnIMAGE_SECTION_HEADER.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnIMAGE_SECTION_HEADER.ForeColor = System.Drawing.Color.White;
            this.btnIMAGE_SECTION_HEADER.Location = new System.Drawing.Point(74, 243);
            this.btnIMAGE_SECTION_HEADER.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnIMAGE_SECTION_HEADER.Name = "btnIMAGE_SECTION_HEADER";
            this.btnIMAGE_SECTION_HEADER.Size = new System.Drawing.Size(214, 30);
            this.btnIMAGE_SECTION_HEADER.TabIndex = 1;
            this.btnIMAGE_SECTION_HEADER.Text = "IMAGE_SECTION_HEADER";
            this.btnIMAGE_SECTION_HEADER.UseVisualStyleBackColor = false;
            this.btnIMAGE_SECTION_HEADER.Click += new System.EventHandler(this.BtnSelectColor_Click);
            // 
            // btnIMAGE_DATA_DIRECTORY
            // 
            this.btnIMAGE_DATA_DIRECTORY.BackColor = System.Drawing.Color.Black;
            this.btnIMAGE_DATA_DIRECTORY.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnIMAGE_DATA_DIRECTORY.ForeColor = System.Drawing.Color.White;
            this.btnIMAGE_DATA_DIRECTORY.Location = new System.Drawing.Point(74, 200);
            this.btnIMAGE_DATA_DIRECTORY.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnIMAGE_DATA_DIRECTORY.Name = "btnIMAGE_DATA_DIRECTORY";
            this.btnIMAGE_DATA_DIRECTORY.Size = new System.Drawing.Size(214, 30);
            this.btnIMAGE_DATA_DIRECTORY.TabIndex = 1;
            this.btnIMAGE_DATA_DIRECTORY.Text = "IMAGE_DATA_DIRECTORY";
            this.btnIMAGE_DATA_DIRECTORY.UseVisualStyleBackColor = false;
            this.btnIMAGE_DATA_DIRECTORY.Click += new System.EventHandler(this.BtnSelectColor_Click);
            // 
            // btnIMAGE_OPTIONAL_HEADER
            // 
            this.btnIMAGE_OPTIONAL_HEADER.BackColor = System.Drawing.Color.Black;
            this.btnIMAGE_OPTIONAL_HEADER.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnIMAGE_OPTIONAL_HEADER.ForeColor = System.Drawing.Color.White;
            this.btnIMAGE_OPTIONAL_HEADER.Location = new System.Drawing.Point(74, 156);
            this.btnIMAGE_OPTIONAL_HEADER.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnIMAGE_OPTIONAL_HEADER.Name = "btnIMAGE_OPTIONAL_HEADER";
            this.btnIMAGE_OPTIONAL_HEADER.Size = new System.Drawing.Size(214, 30);
            this.btnIMAGE_OPTIONAL_HEADER.TabIndex = 1;
            this.btnIMAGE_OPTIONAL_HEADER.Text = " IMAGE_OPTIONAL_HEADER";
            this.btnIMAGE_OPTIONAL_HEADER.UseVisualStyleBackColor = false;
            this.btnIMAGE_OPTIONAL_HEADER.Click += new System.EventHandler(this.BtnSelectColor_Click);
            // 
            // btnIMAGE_FILE_HEADER
            // 
            this.btnIMAGE_FILE_HEADER.BackColor = System.Drawing.Color.Black;
            this.btnIMAGE_FILE_HEADER.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnIMAGE_FILE_HEADER.ForeColor = System.Drawing.Color.White;
            this.btnIMAGE_FILE_HEADER.Location = new System.Drawing.Point(74, 112);
            this.btnIMAGE_FILE_HEADER.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnIMAGE_FILE_HEADER.Name = "btnIMAGE_FILE_HEADER";
            this.btnIMAGE_FILE_HEADER.Size = new System.Drawing.Size(214, 30);
            this.btnIMAGE_FILE_HEADER.TabIndex = 1;
            this.btnIMAGE_FILE_HEADER.Text = "IMAGE_FILE_HEADER";
            this.btnIMAGE_FILE_HEADER.UseVisualStyleBackColor = false;
            this.btnIMAGE_FILE_HEADER.Click += new System.EventHandler(this.BtnSelectColor_Click);
            // 
            // btnIMAGE_NT_HEADERS
            // 
            this.btnIMAGE_NT_HEADERS.BackColor = System.Drawing.Color.Black;
            this.btnIMAGE_NT_HEADERS.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnIMAGE_NT_HEADERS.ForeColor = System.Drawing.Color.White;
            this.btnIMAGE_NT_HEADERS.Location = new System.Drawing.Point(74, 69);
            this.btnIMAGE_NT_HEADERS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnIMAGE_NT_HEADERS.Name = "btnIMAGE_NT_HEADERS";
            this.btnIMAGE_NT_HEADERS.Size = new System.Drawing.Size(214, 30);
            this.btnIMAGE_NT_HEADERS.TabIndex = 1;
            this.btnIMAGE_NT_HEADERS.Text = "IMAGE_NT_HEADERS";
            this.btnIMAGE_NT_HEADERS.UseVisualStyleBackColor = false;
            this.btnIMAGE_NT_HEADERS.Click += new System.EventHandler(this.BtnSelectColor_Click);
            // 
            // btnIMAGE_DOS_HEADER
            // 
            this.btnIMAGE_DOS_HEADER.BackColor = System.Drawing.Color.Black;
            this.btnIMAGE_DOS_HEADER.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnIMAGE_DOS_HEADER.ForeColor = System.Drawing.Color.White;
            this.btnIMAGE_DOS_HEADER.Location = new System.Drawing.Point(74, 26);
            this.btnIMAGE_DOS_HEADER.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnIMAGE_DOS_HEADER.Name = "btnIMAGE_DOS_HEADER";
            this.btnIMAGE_DOS_HEADER.Size = new System.Drawing.Size(214, 30);
            this.btnIMAGE_DOS_HEADER.TabIndex = 1;
            this.btnIMAGE_DOS_HEADER.Text = "IMAGE_DOS_HEADER";
            this.btnIMAGE_DOS_HEADER.UseVisualStyleBackColor = false;
            this.btnIMAGE_DOS_HEADER.Click += new System.EventHandler(this.BtnSelectColor_Click);
            // 
            // tabBookMark
            // 
            tabBookMark.Controls.Add(this.pgBookMark);
            tabBookMark.Controls.Add(this.clbBookMark);
            tabBookMark.Controls.Add(this.cbEnableBookMark);
            tabBookMark.Location = new System.Drawing.Point(4, 25);
            tabBookMark.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            tabBookMark.Name = "tabBookMark";
            tabBookMark.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            tabBookMark.Size = new System.Drawing.Size(612, 339);
            tabBookMark.TabIndex = 2;
            tabBookMark.Text = "书签";
            tabBookMark.UseVisualStyleBackColor = true;
            // 
            // pgBookMark
            // 
            this.pgBookMark.HelpVisible = false;
            this.pgBookMark.Location = new System.Drawing.Point(314, 55);
            this.pgBookMark.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pgBookMark.Name = "pgBookMark";
            this.pgBookMark.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
            this.pgBookMark.Size = new System.Drawing.Size(281, 265);
            this.pgBookMark.TabIndex = 13;
            this.pgBookMark.ToolbarVisible = false;
            // 
            // clbBookMark
            // 
            this.clbBookMark.FormattingEnabled = true;
            this.clbBookMark.Location = new System.Drawing.Point(20, 55);
            this.clbBookMark.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.clbBookMark.Name = "clbBookMark";
            this.clbBookMark.Size = new System.Drawing.Size(279, 264);
            this.clbBookMark.TabIndex = 12;
            // 
            // cbEnableBookMark
            // 
            this.cbEnableBookMark.AutoSize = true;
            this.cbEnableBookMark.Checked = true;
            this.cbEnableBookMark.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbEnableBookMark.Location = new System.Drawing.Point(20, 20);
            this.cbEnableBookMark.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbEnableBookMark.Name = "cbEnableBookMark";
            this.cbEnableBookMark.Size = new System.Drawing.Size(149, 19);
            this.cbEnableBookMark.TabIndex = 11;
            this.cbEnableBookMark.Text = "启用高级书签支持";
            this.cbEnableBookMark.UseVisualStyleBackColor = true;
            // 
            // tabPlugin
            // 
            tabPlugin.Controls.Add(this.pgPlugin);
            tabPlugin.Controls.Add(this.clbPlugin);
            tabPlugin.Controls.Add(this.cbEnablePlugin);
            tabPlugin.Location = new System.Drawing.Point(4, 25);
            tabPlugin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            tabPlugin.Name = "tabPlugin";
            tabPlugin.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            tabPlugin.Size = new System.Drawing.Size(612, 339);
            tabPlugin.TabIndex = 3;
            tabPlugin.Text = "插件";
            tabPlugin.UseVisualStyleBackColor = true;
            // 
            // pgPlugin
            // 
            this.pgPlugin.HelpVisible = false;
            this.pgPlugin.Location = new System.Drawing.Point(314, 55);
            this.pgPlugin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pgPlugin.Name = "pgPlugin";
            this.pgPlugin.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
            this.pgPlugin.Size = new System.Drawing.Size(281, 264);
            this.pgPlugin.TabIndex = 2;
            this.pgPlugin.ToolbarVisible = false;
            // 
            // clbPlugin
            // 
            this.clbPlugin.FormattingEnabled = true;
            this.clbPlugin.ItemHeight = 15;
            this.clbPlugin.Location = new System.Drawing.Point(20, 55);
            this.clbPlugin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.clbPlugin.Name = "clbPlugin";
            this.clbPlugin.Size = new System.Drawing.Size(279, 259);
            this.clbPlugin.TabIndex = 1;
            this.clbPlugin.SelectedIndexChanged += new System.EventHandler(this.ClbPlugin_SelectedIndexChanged);
            // 
            // cbEnablePlugin
            // 
            this.cbEnablePlugin.AutoSize = true;
            this.cbEnablePlugin.Checked = true;
            this.cbEnablePlugin.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbEnablePlugin.Location = new System.Drawing.Point(20, 20);
            this.cbEnablePlugin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbEnablePlugin.Name = "cbEnablePlugin";
            this.cbEnablePlugin.Size = new System.Drawing.Size(254, 19);
            this.cbEnablePlugin.TabIndex = 0;
            this.cbEnablePlugin.Text = "启用插件支持（修改后重启有效）";
            this.cbEnablePlugin.UseVisualStyleBackColor = true;
            // 
            // tabSetting
            // 
            this.tabSetting.Controls.Add(tabGeneral);
            this.tabSetting.Controls.Add(tabPE);
            this.tabSetting.Controls.Add(tabBookMark);
            this.tabSetting.Controls.Add(tabPlugin);
            this.tabSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSetting.Location = new System.Drawing.Point(0, 0);
            this.tabSetting.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabSetting.Multiline = true;
            this.tabSetting.Name = "tabSetting";
            this.tabSetting.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabSetting.SelectedIndex = 0;
            this.tabSetting.Size = new System.Drawing.Size(620, 368);
            this.tabSetting.TabIndex = 0;
            // 
            // fD
            // 
            this.fD.AllowVectorFonts = false;
            this.fD.AllowVerticalFonts = false;
            this.fD.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fD.ScriptsOnly = true;
            this.fD.ShowEffects = false;
            // 
            // FrmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 368);
            this.Controls.Add(this.tabSetting);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "FrmSetting";
            this.Text = "设置";
            this.VisibleChanged += new System.EventHandler(this.FrmSetting_VisibleChanged);
            tabGeneral.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ntScaling)).EndInit();
            tabPE.ResumeLayout(false);
            tabPE.PerformLayout();
            tabBookMark.ResumeLayout(false);
            tabBookMark.PerformLayout();
            tabPlugin.ResumeLayout(false);
            tabPlugin.PerformLayout();
            this.tabSetting.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabSetting;
        private System.Windows.Forms.ColorDialog cD;
        private System.Windows.Forms.ListBox clbPlugin;
        private System.Windows.Forms.CheckBox cbEnablePlugin;
        private System.Windows.Forms.PropertyGrid pgPlugin;
        private System.Windows.Forms.FontDialog fD;
        private System.Windows.Forms.Button btnFont;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbEncoding;
        private System.Windows.Forms.NumericUpDown ntScaling;
        private System.Windows.Forms.CheckBox cbLineInfo;
        private System.Windows.Forms.Button btnLineInfo;
        private System.Windows.Forms.CheckBox cbColInfo;
        private System.Windows.Forms.Button btnColInfo;
        private System.Windows.Forms.CheckBox cbStringLine;
        private System.Windows.Forms.CheckBox cbGroupLine;
        private System.Windows.Forms.Button btnStringLine;
        private System.Windows.Forms.Button btnGroupLine;
        private System.Windows.Forms.CheckBox cbEnableString;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button btnIMAGE_DOS_HEADER;
        private System.Windows.Forms.Button btnSelBackColor;
        private System.Windows.Forms.Button btnSelTextColor;
        private System.Windows.Forms.Button btnIMAGE_NT_HEADERS;
        private System.Windows.Forms.Button btnIMAGE_OPTIONAL_HEADER;
        private System.Windows.Forms.Button btnIMAGE_FILE_HEADER;
        private System.Windows.Forms.Button btnIMAGE_DATA_DIRECTORY;
        private System.Windows.Forms.Button btnIMAGE_BASE_RELOCATION;
        private System.Windows.Forms.Button btnIMAGE_IMPORT_DESCRIPTOR;
        private System.Windows.Forms.Button btnIMAGE_EXPORT_DIRECTORY;
        private System.Windows.Forms.Button btnIMAGE_SECTION_HEADER;
        private System.Windows.Forms.Button btnOther;
        private System.Windows.Forms.CheckBox cbEnableBookMark;
        private System.Windows.Forms.PropertyGrid pgBookMark;
        private System.Windows.Forms.CheckedListBox clbBookMark;
        private System.Windows.Forms.CheckBox cbEnablePE;
    }
}