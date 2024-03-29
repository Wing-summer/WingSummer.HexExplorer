﻿namespace HexExplorer
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ToolStripStatusLabel Slbl1;
            System.Windows.Forms.ToolStripStatusLabel Slbl2;
            System.Windows.Forms.ToolStripStatusLabel Slbl4;
            System.Windows.Forms.ToolStripStatusLabel Slbl6;
            System.Windows.Forms.MenuStrip MainMenu;
            System.Windows.Forms.ToolStripMenuItem MINew;
            System.Windows.Forms.ToolStripMenuItem MIOpen;
            System.Windows.Forms.ToolStripMenuItem MIOpenProcess;
            System.Windows.Forms.ToolStripSeparator MIS0;
            System.Windows.Forms.ToolStripSeparator MIS1;
            System.Windows.Forms.ToolStripMenuItem MIExit;
            System.Windows.Forms.ToolStripSeparator MIS2;
            System.Windows.Forms.ToolStripSeparator MIS3;
            System.Windows.Forms.ToolStripSeparator MIS7;
            System.Windows.Forms.ToolStripSeparator MIS4;
            System.Windows.Forms.ToolStripSeparator MIS8;
            System.Windows.Forms.ToolStripMenuItem MenuItemSetting;
            System.Windows.Forms.ToolStripMenuItem MIGeneral;
            System.Windows.Forms.ToolStripMenuItem MIPlugin;
            System.Windows.Forms.ToolStripMenuItem MIInfo;
            System.Windows.Forms.ToolStripMenuItem MICalculator;
            System.Windows.Forms.ToolStripMenuItem MIAddrConverter;
            System.Windows.Forms.ToolStripMenuItem MenuItemAbout;
            System.Windows.Forms.ToolStripMenuItem MIAbout;
            System.Windows.Forms.ToolStripMenuItem MISponsor;
            System.Windows.Forms.ToolStripSeparator ts9;
            System.Windows.Forms.ToolStripSeparator ts1;
            System.Windows.Forms.ToolStripSeparator ts2;
            System.Windows.Forms.ToolStripSeparator ts3;
            System.Windows.Forms.ToolStripSeparator ts4;
            System.Windows.Forms.ToolStripSeparator ts5;
            System.Windows.Forms.TabPage tabPage2;
            System.Windows.Forms.SplitContainer splitContainer3;
            System.Windows.Forms.SplitContainer splitContainer4;
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("IMAGE_DOS_HEADER", 1, 1);
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("IMAGE_NT_HEADERS", 1, 1);
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("IMAGE_FILE_HEADER", 1, 1);
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("IMAGE_OPTIONAL_HEADER", 1, 1);
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("IMAGE_DATA_DIRECTORY", 1, 1);
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("IMAGE_SECTION_HEADER", 1, 1);
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("IMAGE_IMPORT_DESCRIPTOR", 1, 1);
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("IMAGE_EXPORT_DIRECTORY", 1, 1);
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("IMAGE_BASE_RELOCATION", 1, 1);
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("IMAGE_RESOURCE_DIRECTORY", 1, 1);
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("IMAGE_COR20_HEADER\n", 1, 1);
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode(".NET", 3, 3, new System.Windows.Forms.TreeNode[] {
            treeNode24});
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("PE 文件", new System.Windows.Forms.TreeNode[] {
            treeNode14,
            treeNode15,
            treeNode16,
            treeNode17,
            treeNode18,
            treeNode19,
            treeNode20,
            treeNode21,
            treeNode22,
            treeNode23,
            treeNode25});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            System.Windows.Forms.TabPage tabPage3;
            System.Windows.Forms.SplitContainer splitContainer2;
            System.Windows.Forms.ToolStripSeparator ts11;
            System.Windows.Forms.ToolStripSeparator ts12;
            System.Windows.Forms.ToolStripSeparator ts14;
            System.Windows.Forms.ToolStripSeparator ts15;
            System.Windows.Forms.ToolStripSeparator ts16;
            System.Windows.Forms.ToolStripSeparator ts17;
            System.Windows.Forms.ToolStripSeparator ts18;
            System.Windows.Forms.TabPage tabPage1;
            this.MenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MISave = new System.Windows.Forms.ToolStripMenuItem();
            this.MISaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.MIExport = new System.Windows.Forms.ToolStripMenuItem();
            this.MIAdmin = new System.Windows.Forms.ToolStripMenuItem();
            this.ts13 = new System.Windows.Forms.ToolStripSeparator();
            this.MIClose = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.hexMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MISelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.MICut = new System.Windows.Forms.ToolStripMenuItem();
            this.MICopy = new System.Windows.Forms.ToolStripMenuItem();
            this.MICopyHex = new System.Windows.Forms.ToolStripMenuItem();
            this.MIPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.MIPasteHex = new System.Windows.Forms.ToolStripMenuItem();
            this.MIDel = new System.Windows.Forms.ToolStripMenuItem();
            this.MIInsert = new System.Windows.Forms.ToolStripMenuItem();
            this.MINewInsert = new System.Windows.Forms.ToolStripMenuItem();
            this.MIFind = new System.Windows.Forms.ToolStripMenuItem();
            this.MIJmp = new System.Windows.Forms.ToolStripMenuItem();
            this.MIFill = new System.Windows.Forms.ToolStripMenuItem();
            this.MIFillZero = new System.Windows.Forms.ToolStripMenuItem();
            this.MIFillNop = new System.Windows.Forms.ToolStripMenuItem();
            this.MIBookMark = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemTool = new System.Windows.Forms.ToolStripMenuItem();
            this.MIS = new System.Windows.Forms.ToolStripSeparator();
            this.MenuPlugin = new System.Windows.Forms.ToolStripMenuItem();
            this.MIUpgrade = new System.Windows.Forms.ToolStripMenuItem();
            this.tvPEStruct = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.pgConst = new System.Windows.Forms.PropertyGrid();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.propertyGridB = new System.Windows.Forms.PropertyGrid();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.LblScale = new System.Windows.Forms.ToolStripStatusLabel();
            this.LblLocation = new System.Windows.Forms.ToolStripStatusLabel();
            this.Slbl3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.LblLen = new System.Windows.Forms.ToolStripStatusLabel();
            this.scEdit = new System.Windows.Forms.SplitContainer();
            this.tabEditArea = new HexExplorer.TabControlEx();
            this.toolStripHexEdit = new System.Windows.Forms.ToolStrip();
            this.tscbEncoding = new System.Windows.Forms.ToolStripComboBox();
            this.tbString = new System.Windows.Forms.ToolStripButton();
            this.tbPEInfo = new System.Windows.Forms.ToolStripButton();
            this.tbGroupSep = new System.Windows.Forms.ToolStripButton();
            this.tbColBg = new System.Windows.Forms.ToolStripButton();
            this.tbColInfo = new System.Windows.Forms.ToolStripButton();
            this.tbLineBg = new System.Windows.Forms.ToolStripButton();
            this.tbLineInfo = new System.Windows.Forms.ToolStripButton();
            this.tbAddr = new System.Windows.Forms.ToolStripButton();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tbNew = new System.Windows.Forms.ToolStripButton();
            this.tbOpen = new System.Windows.Forms.ToolStripButton();
            this.tbExport = new System.Windows.Forms.ToolStripButton();
            this.tbSave = new System.Windows.Forms.ToolStripButton();
            this.tbSaveAs = new System.Windows.Forms.ToolStripButton();
            this.tbCut = new System.Windows.Forms.ToolStripButton();
            this.tbCopy = new System.Windows.Forms.ToolStripSplitButton();
            this.SMICopy = new System.Windows.Forms.ToolStripMenuItem();
            this.SMICopyHex = new System.Windows.Forms.ToolStripMenuItem();
            this.tbPaste = new System.Windows.Forms.ToolStripSplitButton();
            this.SMIPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.SMIPasteHex = new System.Windows.Forms.ToolStripMenuItem();
            this.tbDel = new System.Windows.Forms.ToolStripButton();
            this.tbFill = new System.Windows.Forms.ToolStripButton();
            this.tbFillZero = new System.Windows.Forms.ToolStripButton();
            this.tbFillNop = new System.Windows.Forms.ToolStripButton();
            this.tbBookMark = new System.Windows.Forms.ToolStripButton();
            this.tbInfo = new System.Windows.Forms.ToolStripButton();
            this.tbSetting = new System.Windows.Forms.ToolStripButton();
            this.tbSettingPlugin = new System.Windows.Forms.ToolStripButton();
            this.tbCalc = new System.Windows.Forms.ToolStripButton();
            this.tbClose = new System.Windows.Forms.ToolStripButton();
            this.ts10 = new System.Windows.Forms.ToolStripSeparator();
            this.tbAboutthis = new System.Windows.Forms.ToolStripButton();
            this.tbSponsor = new System.Windows.Forms.ToolStripButton();
            this.tbUpgrade = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.LblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.Slbl5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.LblSaved = new System.Windows.Forms.ToolStripStatusLabel();
            this.LblWritable = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblLocked = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblInsert = new System.Windows.Forms.ToolStripStatusLabel();
            this.LblFilename = new System.Windows.Forms.ToolStripStatusLabel();
            this.TMISelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.oD = new System.Windows.Forms.OpenFileDialog();
            this.sD = new System.Windows.Forms.SaveFileDialog();
            this.TMICut = new System.Windows.Forms.ToolStripMenuItem();
            this.TMICopy = new System.Windows.Forms.ToolStripMenuItem();
            this.TMIPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.TMIFind = new System.Windows.Forms.ToolStripMenuItem();
            this.TMIJmp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            Slbl1 = new System.Windows.Forms.ToolStripStatusLabel();
            Slbl2 = new System.Windows.Forms.ToolStripStatusLabel();
            Slbl4 = new System.Windows.Forms.ToolStripStatusLabel();
            Slbl6 = new System.Windows.Forms.ToolStripStatusLabel();
            MainMenu = new System.Windows.Forms.MenuStrip();
            MINew = new System.Windows.Forms.ToolStripMenuItem();
            MIOpen = new System.Windows.Forms.ToolStripMenuItem();
            MIOpenProcess = new System.Windows.Forms.ToolStripMenuItem();
            MIS0 = new System.Windows.Forms.ToolStripSeparator();
            MIS1 = new System.Windows.Forms.ToolStripSeparator();
            MIExit = new System.Windows.Forms.ToolStripMenuItem();
            MIS2 = new System.Windows.Forms.ToolStripSeparator();
            MIS3 = new System.Windows.Forms.ToolStripSeparator();
            MIS7 = new System.Windows.Forms.ToolStripSeparator();
            MIS4 = new System.Windows.Forms.ToolStripSeparator();
            MIS8 = new System.Windows.Forms.ToolStripSeparator();
            MenuItemSetting = new System.Windows.Forms.ToolStripMenuItem();
            MIGeneral = new System.Windows.Forms.ToolStripMenuItem();
            MIPlugin = new System.Windows.Forms.ToolStripMenuItem();
            MIInfo = new System.Windows.Forms.ToolStripMenuItem();
            MICalculator = new System.Windows.Forms.ToolStripMenuItem();
            MIAddrConverter = new System.Windows.Forms.ToolStripMenuItem();
            MenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            MIAbout = new System.Windows.Forms.ToolStripMenuItem();
            MISponsor = new System.Windows.Forms.ToolStripMenuItem();
            ts9 = new System.Windows.Forms.ToolStripSeparator();
            ts1 = new System.Windows.Forms.ToolStripSeparator();
            ts2 = new System.Windows.Forms.ToolStripSeparator();
            ts3 = new System.Windows.Forms.ToolStripSeparator();
            ts4 = new System.Windows.Forms.ToolStripSeparator();
            ts5 = new System.Windows.Forms.ToolStripSeparator();
            tabPage2 = new System.Windows.Forms.TabPage();
            splitContainer3 = new System.Windows.Forms.SplitContainer();
            splitContainer4 = new System.Windows.Forms.SplitContainer();
            tabPage3 = new System.Windows.Forms.TabPage();
            splitContainer2 = new System.Windows.Forms.SplitContainer();
            ts11 = new System.Windows.Forms.ToolStripSeparator();
            ts12 = new System.Windows.Forms.ToolStripSeparator();
            ts14 = new System.Windows.Forms.ToolStripSeparator();
            ts15 = new System.Windows.Forms.ToolStripSeparator();
            ts16 = new System.Windows.Forms.ToolStripSeparator();
            ts17 = new System.Windows.Forms.ToolStripSeparator();
            ts18 = new System.Windows.Forms.ToolStripSeparator();
            tabPage1 = new System.Windows.Forms.TabPage();
            MainMenu.SuspendLayout();
            this.hexMenuStrip.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(splitContainer3)).BeginInit();
            splitContainer3.Panel1.SuspendLayout();
            splitContainer3.Panel2.SuspendLayout();
            splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(splitContainer4)).BeginInit();
            splitContainer4.Panel1.SuspendLayout();
            splitContainer4.Panel2.SuspendLayout();
            splitContainer4.SuspendLayout();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(splitContainer2)).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scEdit)).BeginInit();
            this.scEdit.Panel1.SuspendLayout();
            this.scEdit.Panel2.SuspendLayout();
            this.scEdit.SuspendLayout();
            this.toolStripHexEdit.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // Slbl1
            // 
            Slbl1.Name = "Slbl1";
            Slbl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            Slbl1.Size = new System.Drawing.Size(54, 26);
            Slbl1.Text = "缩放：";
            // 
            // Slbl2
            // 
            Slbl2.Name = "Slbl2";
            Slbl2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            Slbl2.Size = new System.Drawing.Size(54, 26);
            Slbl2.Text = "位置：";
            // 
            // Slbl4
            // 
            Slbl4.Name = "Slbl4";
            Slbl4.Size = new System.Drawing.Size(54, 24);
            Slbl4.Text = "状态：";
            // 
            // Slbl6
            // 
            Slbl6.Name = "Slbl6";
            Slbl6.Size = new System.Drawing.Size(69, 24);
            Slbl6.Text = "文件名：";
            // 
            // MainMenu
            // 
            MainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemFile,
            this.MenuItemEdit,
            MenuItemSetting,
            this.MenuItemTool,
            this.MenuPlugin,
            MenuItemAbout});
            MainMenu.Location = new System.Drawing.Point(0, 0);
            MainMenu.Name = "MainMenu";
            MainMenu.Padding = new System.Windows.Forms.Padding(4, 3, 0, 3);
            MainMenu.ShowItemToolTips = true;
            MainMenu.Size = new System.Drawing.Size(1782, 30);
            MainMenu.TabIndex = 0;
            // 
            // MenuItemFile
            // 
            this.MenuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            MINew,
            MIOpen,
            MIOpenProcess,
            MIS0,
            this.MISave,
            this.MISaveAs,
            this.MIExport,
            MIS1,
            this.MIAdmin,
            this.ts13,
            this.MIClose,
            MIExit});
            this.MenuItemFile.Image = global::HexExplorer.Properties.Resources.file;
            this.MenuItemFile.Name = "MenuItemFile";
            this.MenuItemFile.Size = new System.Drawing.Size(91, 24);
            this.MenuItemFile.Text = "文件(&F)";
            // 
            // MINew
            // 
            MINew.Image = global::HexExplorer.Properties.Resources._new;
            MINew.Name = "MINew";
            MINew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            MINew.Size = new System.Drawing.Size(287, 26);
            MINew.Text = "新建";
            MINew.Click += new System.EventHandler(this.MINew_Click);
            // 
            // MIOpen
            // 
            MIOpen.Image = global::HexExplorer.Properties.Resources.open;
            MIOpen.Name = "MIOpen";
            MIOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            MIOpen.Size = new System.Drawing.Size(287, 26);
            MIOpen.Text = "打开";
            MIOpen.Click += new System.EventHandler(this.MIOpen_Click);
            // 
            // MIOpenProcess
            // 
            MIOpenProcess.Name = "MIOpenProcess";
            MIOpenProcess.Size = new System.Drawing.Size(287, 26);
            MIOpenProcess.Text = "从进程读取";
            MIOpenProcess.Click += new System.EventHandler(this.MIOpenProcess_Click);
            // 
            // MIS0
            // 
            MIS0.Name = "MIS0";
            MIS0.Size = new System.Drawing.Size(284, 6);
            // 
            // MISave
            // 
            this.MISave.Enabled = false;
            this.MISave.Image = global::HexExplorer.Properties.Resources.save;
            this.MISave.Name = "MISave";
            this.MISave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.MISave.Size = new System.Drawing.Size(287, 26);
            this.MISave.Text = "保存";
            this.MISave.Click += new System.EventHandler(this.MISave_Click);
            // 
            // MISaveAs
            // 
            this.MISaveAs.Enabled = false;
            this.MISaveAs.Image = global::HexExplorer.Properties.Resources.saveas;
            this.MISaveAs.Name = "MISaveAs";
            this.MISaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.MISaveAs.Size = new System.Drawing.Size(287, 26);
            this.MISaveAs.Text = "另存为";
            this.MISaveAs.Click += new System.EventHandler(this.MISaveAs_Click);
            // 
            // MIExport
            // 
            this.MIExport.Enabled = false;
            this.MIExport.Image = global::HexExplorer.Properties.Resources.export;
            this.MIExport.Name = "MIExport";
            this.MIExport.ShortcutKeys = ((System.Windows.Forms.Keys)((((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.MIExport.Size = new System.Drawing.Size(287, 26);
            this.MIExport.Text = "导出";
            this.MIExport.Click += new System.EventHandler(this.MIExport_Click);
            // 
            // MIS1
            // 
            MIS1.Name = "MIS1";
            MIS1.Size = new System.Drawing.Size(284, 6);
            // 
            // MIAdmin
            // 
            this.MIAdmin.Name = "MIAdmin";
            this.MIAdmin.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.Q)));
            this.MIAdmin.Size = new System.Drawing.Size(287, 26);
            this.MIAdmin.Text = "管理员权限重启";
            this.MIAdmin.Click += new System.EventHandler(this.MIAdmin_Click);
            // 
            // ts13
            // 
            this.ts13.Name = "ts13";
            this.ts13.Size = new System.Drawing.Size(284, 6);
            // 
            // MIClose
            // 
            this.MIClose.Enabled = false;
            this.MIClose.Image = global::HexExplorer.Properties.Resources.closefile;
            this.MIClose.Name = "MIClose";
            this.MIClose.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Q)));
            this.MIClose.Size = new System.Drawing.Size(287, 26);
            this.MIClose.Text = "关闭文件";
            this.MIClose.Click += new System.EventHandler(this.MIClose_Click);
            // 
            // MIExit
            // 
            MIExit.Image = global::HexExplorer.Properties.Resources.exit;
            MIExit.Name = "MIExit";
            MIExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            MIExit.Size = new System.Drawing.Size(287, 26);
            MIExit.Text = "退出";
            MIExit.Click += new System.EventHandler(this.MIExit_Click);
            // 
            // MenuItemEdit
            // 
            this.MenuItemEdit.DropDown = this.hexMenuStrip;
            this.MenuItemEdit.Image = global::HexExplorer.Properties.Resources.edit;
            this.MenuItemEdit.Name = "MenuItemEdit";
            this.MenuItemEdit.Size = new System.Drawing.Size(91, 24);
            this.MenuItemEdit.Text = "编辑(&E)";
            // 
            // hexMenuStrip
            // 
            this.hexMenuStrip.Enabled = false;
            this.hexMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.hexMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MISelectAll,
            MIS2,
            this.MICut,
            this.MICopy,
            this.MICopyHex,
            this.MIPaste,
            this.MIPasteHex,
            this.MIDel,
            MIS3,
            this.MIInsert,
            this.MINewInsert,
            MIS7,
            this.MIFind,
            this.MIJmp,
            MIS4,
            this.MIFill,
            this.MIFillZero,
            this.MIFillNop,
            MIS8,
            this.MIBookMark});
            this.hexMenuStrip.Name = "hexMenuStrip";
            this.hexMenuStrip.OwnerItem = this.MenuItemEdit;
            this.hexMenuStrip.Size = new System.Drawing.Size(262, 424);
            // 
            // MISelectAll
            // 
            this.MISelectAll.Enabled = false;
            this.MISelectAll.Image = global::HexExplorer.Properties.Resources.selectAll;
            this.MISelectAll.Name = "MISelectAll";
            this.MISelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.MISelectAll.Size = new System.Drawing.Size(261, 26);
            this.MISelectAll.Text = "全选";
            this.MISelectAll.Click += new System.EventHandler(this.MISelectAll_Click);
            // 
            // MIS2
            // 
            MIS2.Name = "MIS2";
            MIS2.Size = new System.Drawing.Size(258, 6);
            // 
            // MICut
            // 
            this.MICut.Enabled = false;
            this.MICut.Image = global::HexExplorer.Properties.Resources.cut;
            this.MICut.Name = "MICut";
            this.MICut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.MICut.Size = new System.Drawing.Size(261, 26);
            this.MICut.Text = "剪切";
            this.MICut.Click += new System.EventHandler(this.MICut_Click);
            // 
            // MICopy
            // 
            this.MICopy.Enabled = false;
            this.MICopy.Image = global::HexExplorer.Properties.Resources.copy;
            this.MICopy.Name = "MICopy";
            this.MICopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.MICopy.Size = new System.Drawing.Size(261, 26);
            this.MICopy.Text = "复制";
            this.MICopy.Click += new System.EventHandler(this.MICopy_Click);
            // 
            // MICopyHex
            // 
            this.MICopyHex.Enabled = false;
            this.MICopyHex.Image = global::HexExplorer.Properties.Resources.copy;
            this.MICopyHex.Name = "MICopyHex";
            this.MICopyHex.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.C)));
            this.MICopyHex.Size = new System.Drawing.Size(261, 26);
            this.MICopyHex.Text = "复制（Hex）";
            this.MICopyHex.Click += new System.EventHandler(this.MICopyHex_Click);
            // 
            // MIPaste
            // 
            this.MIPaste.Enabled = false;
            this.MIPaste.Image = global::HexExplorer.Properties.Resources.paste;
            this.MIPaste.Name = "MIPaste";
            this.MIPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.MIPaste.Size = new System.Drawing.Size(261, 26);
            this.MIPaste.Text = "粘贴";
            this.MIPaste.Click += new System.EventHandler(this.MIPaste_Click);
            // 
            // MIPasteHex
            // 
            this.MIPasteHex.Enabled = false;
            this.MIPasteHex.Image = global::HexExplorer.Properties.Resources.paste;
            this.MIPasteHex.Name = "MIPasteHex";
            this.MIPasteHex.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.V)));
            this.MIPasteHex.Size = new System.Drawing.Size(261, 26);
            this.MIPasteHex.Text = "粘贴（Hex）";
            this.MIPasteHex.Click += new System.EventHandler(this.MIPasteHex_Click);
            // 
            // MIDel
            // 
            this.MIDel.Enabled = false;
            this.MIDel.Image = global::HexExplorer.Properties.Resources.del;
            this.MIDel.Name = "MIDel";
            this.MIDel.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.MIDel.Size = new System.Drawing.Size(261, 26);
            this.MIDel.Text = "删除";
            this.MIDel.Click += new System.EventHandler(this.MIDel_Click);
            // 
            // MIS3
            // 
            MIS3.Name = "MIS3";
            MIS3.Size = new System.Drawing.Size(258, 6);
            // 
            // MIInsert
            // 
            this.MIInsert.Enabled = false;
            this.MIInsert.Image = global::HexExplorer.Properties.Resources.insert;
            this.MIInsert.Name = "MIInsert";
            this.MIInsert.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.MIInsert.Size = new System.Drawing.Size(261, 26);
            this.MIInsert.Text = "插入数据";
            this.MIInsert.Click += new System.EventHandler(this.MIInsert_Click);
            // 
            // MINewInsert
            // 
            this.MINewInsert.Enabled = false;
            this.MINewInsert.Image = global::HexExplorer.Properties.Resources.newinsert;
            this.MINewInsert.Name = "MINewInsert";
            this.MINewInsert.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.N)));
            this.MINewInsert.Size = new System.Drawing.Size(261, 26);
            this.MINewInsert.Text = "新建数据块";
            this.MINewInsert.Click += new System.EventHandler(this.MINewInsert_Click);
            // 
            // MIS7
            // 
            MIS7.Name = "MIS7";
            MIS7.Size = new System.Drawing.Size(258, 6);
            // 
            // MIFind
            // 
            this.MIFind.Enabled = false;
            this.MIFind.Image = global::HexExplorer.Properties.Resources.find;
            this.MIFind.Name = "MIFind";
            this.MIFind.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.MIFind.Size = new System.Drawing.Size(261, 26);
            this.MIFind.Text = "查找";
            this.MIFind.Click += new System.EventHandler(this.MIFind_Click);
            // 
            // MIJmp
            // 
            this.MIJmp.Enabled = false;
            this.MIJmp.Image = global::HexExplorer.Properties.Resources.jmp;
            this.MIJmp.Name = "MIJmp";
            this.MIJmp.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.MIJmp.Size = new System.Drawing.Size(261, 26);
            this.MIJmp.Text = "定位";
            this.MIJmp.Click += new System.EventHandler(this.MIGoto_Click);
            // 
            // MIS4
            // 
            MIS4.Name = "MIS4";
            MIS4.Size = new System.Drawing.Size(258, 6);
            // 
            // MIFill
            // 
            this.MIFill.Enabled = false;
            this.MIFill.Image = global::HexExplorer.Properties.Resources.fill;
            this.MIFill.Name = "MIFill";
            this.MIFill.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.I)));
            this.MIFill.Size = new System.Drawing.Size(261, 26);
            this.MIFill.Text = "填充数据";
            this.MIFill.Click += new System.EventHandler(this.MIFill_Click);
            // 
            // MIFillZero
            // 
            this.MIFillZero.Enabled = false;
            this.MIFillZero.Image = global::HexExplorer.Properties.Resources.fillZero;
            this.MIFillZero.Name = "MIFillZero";
            this.MIFillZero.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D0)));
            this.MIFillZero.Size = new System.Drawing.Size(261, 26);
            this.MIFillZero.Text = "选区置零";
            this.MIFillZero.Click += new System.EventHandler(this.MIFillZero_Click);
            // 
            // MIFillNop
            // 
            this.MIFillNop.Enabled = false;
            this.MIFillNop.Image = global::HexExplorer.Properties.Resources.fillNop;
            this.MIFillNop.Name = "MIFillNop";
            this.MIFillNop.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.NumPad0)));
            this.MIFillNop.Size = new System.Drawing.Size(261, 26);
            this.MIFillNop.Text = "选区Nop";
            this.MIFillNop.Click += new System.EventHandler(this.MIFillNop_Click);
            // 
            // MIS8
            // 
            MIS8.Name = "MIS8";
            MIS8.Size = new System.Drawing.Size(258, 6);
            // 
            // MIBookMark
            // 
            this.MIBookMark.Enabled = false;
            this.MIBookMark.Image = global::HexExplorer.Properties.Resources.bookmark;
            this.MIBookMark.Name = "MIBookMark";
            this.MIBookMark.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.MIBookMark.Size = new System.Drawing.Size(261, 26);
            this.MIBookMark.Text = "书签添加/删除";
            this.MIBookMark.Click += new System.EventHandler(this.MIBookMark_Click);
            // 
            // MenuItemSetting
            // 
            MenuItemSetting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            MIGeneral,
            MIPlugin,
            MIInfo});
            MenuItemSetting.Image = global::HexExplorer.Properties.Resources.setting;
            MenuItemSetting.Name = "MenuItemSetting";
            MenuItemSetting.Size = new System.Drawing.Size(92, 24);
            MenuItemSetting.Text = "设置(&S)";
            // 
            // MIGeneral
            // 
            MIGeneral.Image = global::HexExplorer.Properties.Resources.general;
            MIGeneral.Name = "MIGeneral";
            MIGeneral.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.K)));
            MIGeneral.Size = new System.Drawing.Size(252, 26);
            MIGeneral.Text = "常规";
            MIGeneral.Click += new System.EventHandler(this.MIGeneral_Click);
            // 
            // MIPlugin
            // 
            MIPlugin.Image = global::HexExplorer.Properties.Resources.settingplugin;
            MIPlugin.Name = "MIPlugin";
            MIPlugin.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.K)));
            MIPlugin.Size = new System.Drawing.Size(252, 26);
            MIPlugin.Text = "插件设置";
            MIPlugin.Click += new System.EventHandler(this.MIPlugin_Click);
            // 
            // MIInfo
            // 
            MIInfo.Image = global::HexExplorer.Properties.Resources.info;
            MIInfo.Name = "MIInfo";
            MIInfo.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.I)));
            MIInfo.Size = new System.Drawing.Size(252, 26);
            MIInfo.Text = "侧栏信息";
            MIInfo.Click += new System.EventHandler(this.MIInfo_Click);
            // 
            // MenuItemTool
            // 
            this.MenuItemTool.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            MICalculator,
            MIAddrConverter,
            this.MIS});
            this.MenuItemTool.Image = global::HexExplorer.Properties.Resources.tools;
            this.MenuItemTool.Name = "MenuItemTool";
            this.MenuItemTool.Size = new System.Drawing.Size(107, 24);
            this.MenuItemTool.Text = "小工具(&T)";
            // 
            // MICalculator
            // 
            MICalculator.Image = global::HexExplorer.Properties.Resources.calc;
            MICalculator.Name = "MICalculator";
            MICalculator.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.NumPad0)));
            MICalculator.Size = new System.Drawing.Size(284, 26);
            MICalculator.Text = "计算器";
            MICalculator.Click += new System.EventHandler(this.MICalculator_Click);
            // 
            // MIAddrConverter
            // 
            MIAddrConverter.Image = global::HexExplorer.Properties.Resources.AddrConv;
            MIAddrConverter.Name = "MIAddrConverter";
            MIAddrConverter.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.NumPad1)));
            MIAddrConverter.Size = new System.Drawing.Size(284, 26);
            MIAddrConverter.Text = "地址转化器";
            MIAddrConverter.Click += new System.EventHandler(this.MIAddrConverter_Click);
            // 
            // MIS
            // 
            this.MIS.Name = "MIS";
            this.MIS.Size = new System.Drawing.Size(281, 6);
            this.MIS.Visible = false;
            // 
            // MenuPlugin
            // 
            this.MenuPlugin.Enabled = false;
            this.MenuPlugin.Image = global::HexExplorer.Properties.Resources.plugin;
            this.MenuPlugin.Name = "MenuPlugin";
            this.MenuPlugin.Size = new System.Drawing.Size(92, 24);
            this.MenuPlugin.Text = "插件(&P)";
            // 
            // MenuItemAbout
            // 
            MenuItemAbout.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            MIAbout,
            MISponsor,
            this.MIUpgrade});
            MenuItemAbout.Image = global::HexExplorer.Properties.Resources.soft;
            MenuItemAbout.Name = "MenuItemAbout";
            MenuItemAbout.Size = new System.Drawing.Size(73, 24);
            MenuItemAbout.Text = "关于";
            // 
            // MIAbout
            // 
            MIAbout.Image = global::HexExplorer.Properties.Resources.aboutthis;
            MIAbout.Name = "MIAbout";
            MIAbout.ShortcutKeys = System.Windows.Forms.Keys.F10;
            MIAbout.Size = new System.Drawing.Size(172, 26);
            MIAbout.Text = "此软件";
            MIAbout.Click += new System.EventHandler(this.MIAboutThis_Click);
            // 
            // MISponsor
            // 
            MISponsor.Image = global::HexExplorer.Properties.Resources.sponsor;
            MISponsor.Name = "MISponsor";
            MISponsor.Size = new System.Drawing.Size(172, 26);
            MISponsor.Text = "捐助";
            MISponsor.Click += new System.EventHandler(this.MISponsor_Click);
            // 
            // MIUpgrade
            // 
            this.MIUpgrade.Image = global::HexExplorer.Properties.Resources.upgrade;
            this.MIUpgrade.Name = "MIUpgrade";
            this.MIUpgrade.Size = new System.Drawing.Size(172, 26);
            this.MIUpgrade.Text = "软件升级";
            this.MIUpgrade.Click += new System.EventHandler(this.MIUpgrade_Click);
            // 
            // ts9
            // 
            ts9.Name = "ts9";
            ts9.Size = new System.Drawing.Size(6, 27);
            // 
            // ts1
            // 
            ts1.Name = "ts1";
            ts1.Size = new System.Drawing.Size(6, 27);
            // 
            // ts2
            // 
            ts2.Name = "ts2";
            ts2.Size = new System.Drawing.Size(6, 27);
            // 
            // ts3
            // 
            ts3.Name = "ts3";
            ts3.Size = new System.Drawing.Size(6, 27);
            // 
            // ts4
            // 
            ts4.Name = "ts4";
            ts4.Size = new System.Drawing.Size(6, 27);
            // 
            // ts5
            // 
            ts5.Name = "ts5";
            ts5.Size = new System.Drawing.Size(6, 27);
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(splitContainer3);
            tabPage2.Location = new System.Drawing.Point(4, 29);
            tabPage2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            tabPage2.Size = new System.Drawing.Size(640, 660);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "结构";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer3.Location = new System.Drawing.Point(3, 4);
            splitContainer3.Name = "splitContainer3";
            splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            splitContainer3.Panel1.Controls.Add(splitContainer4);
            // 
            // splitContainer3.Panel2
            // 
            splitContainer3.Panel2.Controls.Add(this.propertyGrid1);
            splitContainer3.Size = new System.Drawing.Size(634, 652);
            splitContainer3.SplitterDistance = 347;
            splitContainer3.TabIndex = 0;
            // 
            // splitContainer4
            // 
            splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer4.Location = new System.Drawing.Point(0, 0);
            splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            splitContainer4.Panel1.Controls.Add(this.tvPEStruct);
            splitContainer4.Panel1MinSize = 300;
            // 
            // splitContainer4.Panel2
            // 
            splitContainer4.Panel2.Controls.Add(this.pgConst);
            splitContainer4.Panel2MinSize = 250;
            splitContainer4.Size = new System.Drawing.Size(634, 347);
            splitContainer4.SplitterDistance = 300;
            splitContainer4.TabIndex = 0;
            // 
            // tvPEStruct
            // 
            this.tvPEStruct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvPEStruct.ImageIndex = 0;
            this.tvPEStruct.ImageList = this.imageList;
            this.tvPEStruct.Location = new System.Drawing.Point(0, 0);
            this.tvPEStruct.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tvPEStruct.Name = "tvPEStruct";
            treeNode14.ImageIndex = 1;
            treeNode14.Name = "tDOS_HEADER";
            treeNode14.SelectedImageIndex = 1;
            treeNode14.Text = "IMAGE_DOS_HEADER";
            treeNode15.ImageIndex = 1;
            treeNode15.Name = "tNT_HEADERS";
            treeNode15.SelectedImageIndex = 1;
            treeNode15.Text = "IMAGE_NT_HEADERS";
            treeNode16.ImageIndex = 1;
            treeNode16.Name = "tFILE_HEADER";
            treeNode16.SelectedImageIndex = 1;
            treeNode16.Text = "IMAGE_FILE_HEADER";
            treeNode17.ImageIndex = 1;
            treeNode17.Name = "tOPTIONAL_HEADER";
            treeNode17.SelectedImageIndex = 1;
            treeNode17.Text = "IMAGE_OPTIONAL_HEADER";
            treeNode18.ImageIndex = 1;
            treeNode18.Name = "tDATA_DIRECTORY";
            treeNode18.SelectedImageIndex = 1;
            treeNode18.Text = "IMAGE_DATA_DIRECTORY";
            treeNode19.ImageIndex = 1;
            treeNode19.Name = "tSECTION_HEADER";
            treeNode19.SelectedImageIndex = 1;
            treeNode19.Text = "IMAGE_SECTION_HEADER";
            treeNode20.ImageIndex = 1;
            treeNode20.Name = "tIMPORT_DESCRIPTOR";
            treeNode20.SelectedImageIndex = 1;
            treeNode20.Text = "IMAGE_IMPORT_DESCRIPTOR";
            treeNode21.ImageIndex = 1;
            treeNode21.Name = "tEXPORT_DIRECTORY";
            treeNode21.SelectedImageIndex = 1;
            treeNode21.Text = "IMAGE_EXPORT_DIRECTORY";
            treeNode22.ImageIndex = 1;
            treeNode22.Name = "tBASE_RELOCATION";
            treeNode22.SelectedImageIndex = 1;
            treeNode22.Text = "IMAGE_BASE_RELOCATION";
            treeNode23.ImageIndex = 1;
            treeNode23.Name = "tRESOURCE_DIRECTORY";
            treeNode23.SelectedImageIndex = 1;
            treeNode23.Text = "IMAGE_RESOURCE_DIRECTORY";
            treeNode24.ImageIndex = 1;
            treeNode24.Name = "tCOR20_HEADER\n";
            treeNode24.SelectedImageIndex = 1;
            treeNode24.Text = "IMAGE_COR20_HEADER\n";
            treeNode25.ImageIndex = 3;
            treeNode25.Name = "tNET";
            treeNode25.SelectedImageIndex = 3;
            treeNode25.Text = ".NET";
            treeNode26.Name = "nodeRoot";
            treeNode26.Text = "PE 文件";
            this.tvPEStruct.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode26});
            this.tvPEStruct.SelectedImageIndex = 0;
            this.tvPEStruct.Size = new System.Drawing.Size(300, 347);
            this.tvPEStruct.TabIndex = 0;
            this.tvPEStruct.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TvPEStruct_NodeMouseDoubleClick);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "0.png");
            this.imageList.Images.SetKeyName(1, "1.png");
            this.imageList.Images.SetKeyName(2, "2.png");
            this.imageList.Images.SetKeyName(3, "3.png");
            // 
            // pgConst
            // 
            this.pgConst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgConst.HelpVisible = false;
            this.pgConst.Location = new System.Drawing.Point(0, 0);
            this.pgConst.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pgConst.Name = "pgConst";
            this.pgConst.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.pgConst.Size = new System.Drawing.Size(330, 347);
            this.pgConst.TabIndex = 0;
            this.pgConst.ToolbarVisible = false;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(634, 301);
            this.propertyGrid1.TabIndex = 1;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(splitContainer2);
            tabPage3.Location = new System.Drawing.Point(4, 25);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new System.Windows.Forms.Padding(3);
            tabPage3.Size = new System.Drawing.Size(640, 664);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "书签";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer2.Location = new System.Drawing.Point(3, 3);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(this.checkedListBox1);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(this.propertyGridB);
            splitContainer2.Size = new System.Drawing.Size(634, 658);
            splitContainer2.SplitterDistance = 240;
            splitContainer2.TabIndex = 3;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(0, 0);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(634, 240);
            this.checkedListBox1.TabIndex = 3;
            // 
            // propertyGridB
            // 
            this.propertyGridB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridB.Location = new System.Drawing.Point(0, 0);
            this.propertyGridB.Name = "propertyGridB";
            this.propertyGridB.Size = new System.Drawing.Size(634, 414);
            this.propertyGridB.TabIndex = 0;
            // 
            // ts11
            // 
            ts11.Name = "ts11";
            ts11.Size = new System.Drawing.Size(105, 6);
            // 
            // ts12
            // 
            ts12.Name = "ts12";
            ts12.Size = new System.Drawing.Size(105, 6);
            // 
            // ts14
            // 
            ts14.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            ts14.Name = "ts14";
            ts14.Size = new System.Drawing.Size(6, 32);
            // 
            // ts15
            // 
            ts15.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            ts15.Name = "ts15";
            ts15.Size = new System.Drawing.Size(6, 32);
            // 
            // ts16
            // 
            ts16.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            ts16.Name = "ts16";
            ts16.Size = new System.Drawing.Size(6, 32);
            // 
            // ts17
            // 
            ts17.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            ts17.Name = "ts17";
            ts17.Size = new System.Drawing.Size(6, 32);
            // 
            // ts18
            // 
            ts18.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            ts18.Name = "ts18";
            ts18.Size = new System.Drawing.Size(6, 32);
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(this.tbLog);
            tabPage1.Location = new System.Drawing.Point(4, 25);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new System.Windows.Forms.Padding(3);
            tabPage1.Size = new System.Drawing.Size(640, 664);
            tabPage1.TabIndex = 3;
            tabPage1.Text = "日志";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tbLog
            // 
            this.tbLog.BackColor = System.Drawing.Color.Black;
            this.tbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLog.ForeColor = System.Drawing.SystemColors.Info;
            this.tbLog.Location = new System.Drawing.Point(3, 3);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ReadOnly = true;
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbLog.Size = new System.Drawing.Size(634, 658);
            this.tbLog.TabIndex = 0;
            // 
            // LblScale
            // 
            this.LblScale.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.LblScale.DoubleClickEnabled = true;
            this.LblScale.Name = "LblScale";
            this.LblScale.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblScale.Size = new System.Drawing.Size(53, 26);
            this.LblScale.Text = "100%";
            this.LblScale.ToolTipText = "双击重置视图";
            this.LblScale.DoubleClick += new System.EventHandler(this.LblScale_DoubleClick);
            // 
            // LblLocation
            // 
            this.LblLocation.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.LblLocation.Name = "LblLocation";
            this.LblLocation.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblLocation.Size = new System.Drawing.Size(45, 26);
            this.LblLocation.Text = "(0,0)";
            // 
            // Slbl3
            // 
            this.Slbl3.Name = "Slbl3";
            this.Slbl3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Slbl3.Size = new System.Drawing.Size(84, 26);
            this.Slbl3.Text = "选中长度：";
            // 
            // LblLen
            // 
            this.LblLen.Name = "LblLen";
            this.LblLen.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblLen.Size = new System.Drawing.Size(16, 26);
            this.LblLen.Text = "*";
            // 
            // scEdit
            // 
            this.scEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scEdit.Location = new System.Drawing.Point(0, 30);
            this.scEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.scEdit.Name = "scEdit";
            // 
            // scEdit.Panel1
            // 
            this.scEdit.Panel1.Controls.Add(this.tabEditArea);
            this.scEdit.Panel1.Controls.Add(this.toolStripHexEdit);
            this.scEdit.Panel1.Controls.Add(this.toolStrip);
            // 
            // scEdit.Panel2
            // 
            this.scEdit.Panel2.Controls.Add(this.tabControl1);
            this.scEdit.Size = new System.Drawing.Size(1782, 693);
            this.scEdit.SplitterDistance = 1130;
            this.scEdit.TabIndex = 5;
            // 
            // tabEditArea
            // 
            this.tabEditArea.AllowDrop = true;
            this.tabEditArea.CloseButtonSize = 12;
            this.tabEditArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabEditArea.Location = new System.Drawing.Point(0, 27);
            this.tabEditArea.Name = "tabEditArea";
            this.tabEditArea.Padding = new System.Drawing.Point(9, 3);
            this.tabEditArea.SelectedIndex = 0;
            this.tabEditArea.SelTextColor = System.Drawing.Color.White;
            this.tabEditArea.Size = new System.Drawing.Size(1130, 634);
            this.tabEditArea.TabIndex = 1;
            // 
            // toolStripHexEdit
            // 
            this.toolStripHexEdit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStripHexEdit.Enabled = false;
            this.toolStripHexEdit.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripHexEdit.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripHexEdit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tscbEncoding,
            ts18,
            this.tbString,
            this.tbPEInfo,
            ts17,
            this.tbGroupSep,
            ts16,
            this.tbColBg,
            this.tbColInfo,
            ts15,
            this.tbLineBg,
            this.tbLineInfo,
            ts14,
            this.tbAddr,
            Slbl1,
            this.LblScale,
            Slbl2,
            this.LblLocation,
            this.Slbl3,
            this.LblLen});
            this.toolStripHexEdit.Location = new System.Drawing.Point(0, 661);
            this.toolStripHexEdit.Name = "toolStripHexEdit";
            this.toolStripHexEdit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripHexEdit.Size = new System.Drawing.Size(1130, 32);
            this.toolStripHexEdit.TabIndex = 2;
            // 
            // tscbEncoding
            // 
            this.tscbEncoding.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tscbEncoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscbEncoding.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.tscbEncoding.Items.AddRange(new object[] {
            "ASCII",
            "EBCDIC",
            "Unicode"});
            this.tscbEncoding.Margin = new System.Windows.Forms.Padding(1, 2, 10, 2);
            this.tscbEncoding.Name = "tscbEncoding";
            this.tscbEncoding.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tscbEncoding.Size = new System.Drawing.Size(121, 28);
            this.tscbEncoding.SelectedIndexChanged += new System.EventHandler(this.TscbEncoding_SelectedIndexChanged);
            // 
            // tbString
            // 
            this.tbString.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tbString.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbString.Image = global::HexExplorer.Properties.Resources.mStr;
            this.tbString.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbString.Name = "tbString";
            this.tbString.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbString.Size = new System.Drawing.Size(29, 29);
            this.tbString.Text = "字符串解析表";
            this.tbString.Click += new System.EventHandler(this.TbString_Click);
            // 
            // tbPEInfo
            // 
            this.tbPEInfo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tbPEInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbPEInfo.Image = global::HexExplorer.Properties.Resources.mPEInfo;
            this.tbPEInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbPEInfo.Name = "tbPEInfo";
            this.tbPEInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbPEInfo.Size = new System.Drawing.Size(29, 29);
            this.tbPEInfo.Text = "PE底色显示";
            this.tbPEInfo.Click += new System.EventHandler(this.TbPEInfo_Click);
            // 
            // tbGroupSep
            // 
            this.tbGroupSep.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tbGroupSep.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbGroupSep.Image = global::HexExplorer.Properties.Resources.mHexStr;
            this.tbGroupSep.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbGroupSep.Name = "tbGroupSep";
            this.tbGroupSep.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbGroupSep.Size = new System.Drawing.Size(29, 29);
            this.tbGroupSep.Text = "字节字符串分割线";
            this.tbGroupSep.Click += new System.EventHandler(this.TbGroupSep_Click);
            // 
            // tbColBg
            // 
            this.tbColBg.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tbColBg.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbColBg.Image = global::HexExplorer.Properties.Resources.mLineBack;
            this.tbColBg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbColBg.Name = "tbColBg";
            this.tbColBg.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbColBg.Size = new System.Drawing.Size(29, 29);
            this.tbColBg.Text = "列信息背景";
            this.tbColBg.Click += new System.EventHandler(this.TbColBg_Click);
            // 
            // tbColInfo
            // 
            this.tbColInfo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tbColInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbColInfo.Image = global::HexExplorer.Properties.Resources.mLineInfo;
            this.tbColInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbColInfo.Name = "tbColInfo";
            this.tbColInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbColInfo.Size = new System.Drawing.Size(29, 29);
            this.tbColInfo.Text = "列信息";
            this.tbColInfo.Click += new System.EventHandler(this.TbColInfo_Click);
            // 
            // tbLineBg
            // 
            this.tbLineBg.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tbLineBg.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbLineBg.Image = global::HexExplorer.Properties.Resources.mColBack;
            this.tbLineBg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbLineBg.Name = "tbLineBg";
            this.tbLineBg.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbLineBg.Size = new System.Drawing.Size(29, 29);
            this.tbLineBg.Text = "行信息背景";
            this.tbLineBg.Click += new System.EventHandler(this.TbLineBg_Click);
            // 
            // tbLineInfo
            // 
            this.tbLineInfo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tbLineInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbLineInfo.Image = global::HexExplorer.Properties.Resources.mColInfo;
            this.tbLineInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbLineInfo.Name = "tbLineInfo";
            this.tbLineInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbLineInfo.Size = new System.Drawing.Size(29, 29);
            this.tbLineInfo.Text = "行信息";
            this.tbLineInfo.Click += new System.EventHandler(this.TbLineInfo_Click);
            // 
            // tbAddr
            // 
            this.tbAddr.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tbAddr.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbAddr.Image = global::HexExplorer.Properties.Resources.mAddr;
            this.tbAddr.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbAddr.Name = "tbAddr";
            this.tbAddr.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbAddr.Size = new System.Drawing.Size(29, 29);
            this.tbAddr.Text = "文件基址重定位";
            this.tbAddr.Click += new System.EventHandler(this.TbAddr_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.AllowDrop = true;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbNew,
            this.tbOpen,
            ts9,
            this.tbExport,
            this.tbSave,
            this.tbSaveAs,
            ts1,
            this.tbCut,
            this.tbCopy,
            this.tbPaste,
            this.tbDel,
            ts2,
            this.tbFill,
            this.tbFillZero,
            this.tbFillNop,
            ts3,
            this.tbBookMark,
            this.tbInfo,
            this.tbSetting,
            this.tbSettingPlugin,
            ts4,
            this.tbCalc,
            ts5,
            this.tbClose,
            this.ts10,
            this.tbAboutthis,
            this.tbSponsor,
            this.tbUpgrade});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.ShowItemToolTips = false;
            this.toolStrip.Size = new System.Drawing.Size(1130, 27);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.DragDrop += new System.Windows.Forms.DragEventHandler(this.ToolStrip_DragDrop);
            this.toolStrip.DragEnter += new System.Windows.Forms.DragEventHandler(this.ToolStrip_DragEnter);
            // 
            // tbNew
            // 
            this.tbNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbNew.Image = global::HexExplorer.Properties.Resources._new;
            this.tbNew.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tbNew.Name = "tbNew";
            this.tbNew.Size = new System.Drawing.Size(29, 24);
            this.tbNew.Tag = "2";
            this.tbNew.Text = "新建";
            this.tbNew.ToolTipText = "新建";
            this.tbNew.Click += new System.EventHandler(this.MINew_Click);
            this.tbNew.MouseLeave += new System.EventHandler(this.HideToolTipGroup_MouseLeave);
            this.tbNew.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ShowToolTipGroup_MouseMove);
            // 
            // tbOpen
            // 
            this.tbOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbOpen.Image = global::HexExplorer.Properties.Resources.open;
            this.tbOpen.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tbOpen.Name = "tbOpen";
            this.tbOpen.Size = new System.Drawing.Size(29, 24);
            this.tbOpen.Tag = "2";
            this.tbOpen.Text = "打开";
            this.tbOpen.Click += new System.EventHandler(this.MIOpen_Click);
            this.tbOpen.MouseLeave += new System.EventHandler(this.HideToolTipGroup_MouseLeave);
            this.tbOpen.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ShowToolTipGroup_MouseMove);
            // 
            // tbExport
            // 
            this.tbExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbExport.Enabled = false;
            this.tbExport.Image = global::HexExplorer.Properties.Resources.export;
            this.tbExport.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tbExport.Name = "tbExport";
            this.tbExport.Size = new System.Drawing.Size(29, 24);
            this.tbExport.Tag = "2";
            this.tbExport.Text = "导出";
            this.tbExport.Click += new System.EventHandler(this.MIExport_Click);
            this.tbExport.MouseLeave += new System.EventHandler(this.HideToolTipGroup_MouseLeave);
            this.tbExport.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ShowToolTipGroup_MouseMove);
            // 
            // tbSave
            // 
            this.tbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbSave.Enabled = false;
            this.tbSave.Image = global::HexExplorer.Properties.Resources.save;
            this.tbSave.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tbSave.Name = "tbSave";
            this.tbSave.Size = new System.Drawing.Size(29, 24);
            this.tbSave.Tag = "2";
            this.tbSave.Text = "保存";
            this.tbSave.Click += new System.EventHandler(this.MISave_Click);
            this.tbSave.MouseLeave += new System.EventHandler(this.HideToolTipGroup_MouseLeave);
            this.tbSave.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ShowToolTipGroup_MouseMove);
            // 
            // tbSaveAs
            // 
            this.tbSaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbSaveAs.Enabled = false;
            this.tbSaveAs.Image = global::HexExplorer.Properties.Resources.saveas;
            this.tbSaveAs.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tbSaveAs.Name = "tbSaveAs";
            this.tbSaveAs.Size = new System.Drawing.Size(29, 24);
            this.tbSaveAs.Tag = "2";
            this.tbSaveAs.Text = "另存为";
            this.tbSaveAs.Click += new System.EventHandler(this.MISaveAs_Click);
            this.tbSaveAs.MouseLeave += new System.EventHandler(this.HideToolTipGroup_MouseLeave);
            this.tbSaveAs.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ShowToolTipGroup_MouseMove);
            // 
            // tbCut
            // 
            this.tbCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbCut.Enabled = false;
            this.tbCut.Image = global::HexExplorer.Properties.Resources.cut;
            this.tbCut.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tbCut.Name = "tbCut";
            this.tbCut.Size = new System.Drawing.Size(29, 24);
            this.tbCut.Tag = "2";
            this.tbCut.Text = "剪切";
            this.tbCut.Click += new System.EventHandler(this.MICut_Click);
            this.tbCut.MouseLeave += new System.EventHandler(this.HideToolTipGroup_MouseLeave);
            this.tbCut.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ShowToolTipGroup_MouseMove);
            // 
            // tbCopy
            // 
            this.tbCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbCopy.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SMICopy,
            this.SMICopyHex});
            this.tbCopy.Enabled = false;
            this.tbCopy.Image = global::HexExplorer.Properties.Resources.copy;
            this.tbCopy.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tbCopy.Name = "tbCopy";
            this.tbCopy.Size = new System.Drawing.Size(39, 24);
            this.tbCopy.Tag = "2";
            this.tbCopy.Text = "复制";
            this.tbCopy.MouseLeave += new System.EventHandler(this.HideToolTipGroup_MouseLeave);
            this.tbCopy.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ShowToolTipGroup_MouseMove);
            // 
            // SMICopy
            // 
            this.SMICopy.Image = global::HexExplorer.Properties.Resources.copy;
            this.SMICopy.Name = "SMICopy";
            this.SMICopy.Size = new System.Drawing.Size(181, 26);
            this.SMICopy.Text = "复制";
            this.SMICopy.Click += new System.EventHandler(this.MICopy_Click);
            // 
            // SMICopyHex
            // 
            this.SMICopyHex.Image = global::HexExplorer.Properties.Resources.copy;
            this.SMICopyHex.Name = "SMICopyHex";
            this.SMICopyHex.Size = new System.Drawing.Size(181, 26);
            this.SMICopyHex.Text = "复制（Hex）";
            this.SMICopyHex.Click += new System.EventHandler(this.MICopyHex_Click);
            // 
            // tbPaste
            // 
            this.tbPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbPaste.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SMIPaste,
            this.SMIPasteHex});
            this.tbPaste.Enabled = false;
            this.tbPaste.Image = global::HexExplorer.Properties.Resources.paste;
            this.tbPaste.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tbPaste.Name = "tbPaste";
            this.tbPaste.Size = new System.Drawing.Size(39, 24);
            this.tbPaste.Tag = "2";
            this.tbPaste.Text = "粘贴";
            this.tbPaste.MouseLeave += new System.EventHandler(this.HideToolTipGroup_MouseLeave);
            this.tbPaste.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ShowToolTipGroup_MouseMove);
            // 
            // SMIPaste
            // 
            this.SMIPaste.Image = global::HexExplorer.Properties.Resources.paste;
            this.SMIPaste.Name = "SMIPaste";
            this.SMIPaste.Size = new System.Drawing.Size(181, 26);
            this.SMIPaste.Text = "粘贴";
            this.SMIPaste.Click += new System.EventHandler(this.MIPaste_Click);
            // 
            // SMIPasteHex
            // 
            this.SMIPasteHex.Image = global::HexExplorer.Properties.Resources.paste;
            this.SMIPasteHex.Name = "SMIPasteHex";
            this.SMIPasteHex.Size = new System.Drawing.Size(181, 26);
            this.SMIPasteHex.Text = "粘贴（Hex）";
            this.SMIPasteHex.Click += new System.EventHandler(this.MIPasteHex_Click);
            // 
            // tbDel
            // 
            this.tbDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbDel.Enabled = false;
            this.tbDel.Image = global::HexExplorer.Properties.Resources.del;
            this.tbDel.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tbDel.Name = "tbDel";
            this.tbDel.Size = new System.Drawing.Size(29, 24);
            this.tbDel.Tag = "2";
            this.tbDel.Text = "删除";
            this.tbDel.Click += new System.EventHandler(this.MIDel_Click);
            this.tbDel.MouseLeave += new System.EventHandler(this.HideToolTipGroup_MouseLeave);
            this.tbDel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ShowToolTipGroup_MouseMove);
            // 
            // tbFill
            // 
            this.tbFill.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbFill.Enabled = false;
            this.tbFill.Image = global::HexExplorer.Properties.Resources.fill;
            this.tbFill.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tbFill.Name = "tbFill";
            this.tbFill.Size = new System.Drawing.Size(29, 24);
            this.tbFill.Tag = "2";
            this.tbFill.Text = "填充数据";
            this.tbFill.Click += new System.EventHandler(this.MIFill_Click);
            this.tbFill.MouseLeave += new System.EventHandler(this.HideToolTipGroup_MouseLeave);
            this.tbFill.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ShowToolTipGroup_MouseMove);
            // 
            // tbFillZero
            // 
            this.tbFillZero.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbFillZero.Enabled = false;
            this.tbFillZero.Image = global::HexExplorer.Properties.Resources.fillZero;
            this.tbFillZero.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tbFillZero.Name = "tbFillZero";
            this.tbFillZero.Size = new System.Drawing.Size(29, 24);
            this.tbFillZero.Tag = "2";
            this.tbFillZero.Text = "二进制置零";
            this.tbFillZero.Click += new System.EventHandler(this.MIFillZero_Click);
            this.tbFillZero.MouseLeave += new System.EventHandler(this.HideToolTipGroup_MouseLeave);
            this.tbFillZero.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ShowToolTipGroup_MouseMove);
            // 
            // tbFillNop
            // 
            this.tbFillNop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbFillNop.Enabled = false;
            this.tbFillNop.Image = global::HexExplorer.Properties.Resources.fillNop;
            this.tbFillNop.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tbFillNop.Name = "tbFillNop";
            this.tbFillNop.Size = new System.Drawing.Size(29, 24);
            this.tbFillNop.Tag = "2";
            this.tbFillNop.Text = "汇编置零";
            this.tbFillNop.Click += new System.EventHandler(this.MIFillNop_Click);
            this.tbFillNop.MouseLeave += new System.EventHandler(this.HideToolTipGroup_MouseLeave);
            this.tbFillNop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ShowToolTipGroup_MouseMove);
            // 
            // tbBookMark
            // 
            this.tbBookMark.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbBookMark.Enabled = false;
            this.tbBookMark.Image = global::HexExplorer.Properties.Resources.bookmark;
            this.tbBookMark.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tbBookMark.Name = "tbBookMark";
            this.tbBookMark.Size = new System.Drawing.Size(29, 24);
            this.tbBookMark.Tag = "2";
            this.tbBookMark.Text = "书签";
            this.tbBookMark.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TbBookMark_MouseDown);
            this.tbBookMark.MouseLeave += new System.EventHandler(this.HideToolTipGroup_MouseLeave);
            this.tbBookMark.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ShowToolTipGroup_MouseMove);
            // 
            // tbInfo
            // 
            this.tbInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbInfo.Image = global::HexExplorer.Properties.Resources.info;
            this.tbInfo.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tbInfo.Name = "tbInfo";
            this.tbInfo.Size = new System.Drawing.Size(29, 24);
            this.tbInfo.Tag = "2";
            this.tbInfo.Text = "文件信息";
            this.tbInfo.Click += new System.EventHandler(this.MIInfo_Click);
            this.tbInfo.MouseLeave += new System.EventHandler(this.HideToolTipGroup_MouseLeave);
            this.tbInfo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ShowToolTipGroup_MouseMove);
            // 
            // tbSetting
            // 
            this.tbSetting.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbSetting.Image = global::HexExplorer.Properties.Resources.setting;
            this.tbSetting.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tbSetting.Name = "tbSetting";
            this.tbSetting.Size = new System.Drawing.Size(29, 24);
            this.tbSetting.Tag = "2";
            this.tbSetting.Text = "总体设置";
            this.tbSetting.ToolTipText = "常规设置";
            this.tbSetting.Click += new System.EventHandler(this.MIGeneral_Click);
            this.tbSetting.MouseLeave += new System.EventHandler(this.HideToolTipGroup_MouseLeave);
            this.tbSetting.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ShowToolTipGroup_MouseMove);
            // 
            // tbSettingPlugin
            // 
            this.tbSettingPlugin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbSettingPlugin.Image = global::HexExplorer.Properties.Resources.settingplugin;
            this.tbSettingPlugin.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tbSettingPlugin.Name = "tbSettingPlugin";
            this.tbSettingPlugin.Size = new System.Drawing.Size(29, 24);
            this.tbSettingPlugin.Tag = "2";
            this.tbSettingPlugin.Text = "插件设置";
            this.tbSettingPlugin.Click += new System.EventHandler(this.MIPlugin_Click);
            this.tbSettingPlugin.MouseLeave += new System.EventHandler(this.HideToolTipGroup_MouseLeave);
            this.tbSettingPlugin.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ShowToolTipGroup_MouseMove);
            // 
            // tbCalc
            // 
            this.tbCalc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbCalc.Image = global::HexExplorer.Properties.Resources.calc;
            this.tbCalc.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tbCalc.Name = "tbCalc";
            this.tbCalc.Size = new System.Drawing.Size(29, 24);
            this.tbCalc.Tag = "2";
            this.tbCalc.Text = "计算器";
            this.tbCalc.Click += new System.EventHandler(this.MICalculator_Click);
            this.tbCalc.MouseLeave += new System.EventHandler(this.HideToolTipGroup_MouseLeave);
            this.tbCalc.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ShowToolTipGroup_MouseMove);
            // 
            // tbClose
            // 
            this.tbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbClose.Enabled = false;
            this.tbClose.Image = global::HexExplorer.Properties.Resources.closefile;
            this.tbClose.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tbClose.Name = "tbClose";
            this.tbClose.Size = new System.Drawing.Size(29, 24);
            this.tbClose.Tag = "2";
            this.tbClose.Text = "关闭此文件";
            this.tbClose.Click += new System.EventHandler(this.MIClose_Click);
            this.tbClose.MouseLeave += new System.EventHandler(this.HideToolTipGroup_MouseLeave);
            this.tbClose.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ShowToolTipGroup_MouseMove);
            // 
            // ts10
            // 
            this.ts10.Name = "ts10";
            this.ts10.Size = new System.Drawing.Size(6, 27);
            // 
            // tbAboutthis
            // 
            this.tbAboutthis.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbAboutthis.Image = global::HexExplorer.Properties.Resources.aboutthis;
            this.tbAboutthis.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tbAboutthis.Name = "tbAboutthis";
            this.tbAboutthis.Size = new System.Drawing.Size(29, 24);
            this.tbAboutthis.Tag = "2";
            this.tbAboutthis.Text = "关于此软件";
            this.tbAboutthis.Click += new System.EventHandler(this.MIAboutThis_Click);
            this.tbAboutthis.MouseLeave += new System.EventHandler(this.HideToolTipGroup_MouseLeave);
            this.tbAboutthis.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ShowToolTipGroup_MouseMove);
            // 
            // tbSponsor
            // 
            this.tbSponsor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbSponsor.Image = global::HexExplorer.Properties.Resources.sponsor;
            this.tbSponsor.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tbSponsor.Name = "tbSponsor";
            this.tbSponsor.Size = new System.Drawing.Size(29, 24);
            this.tbSponsor.Tag = "2";
            this.tbSponsor.Text = "捐助";
            this.tbSponsor.Click += new System.EventHandler(this.MISponsor_Click);
            this.tbSponsor.MouseLeave += new System.EventHandler(this.HideToolTipGroup_MouseLeave);
            this.tbSponsor.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ShowToolTipGroup_MouseMove);
            // 
            // tbUpgrade
            // 
            this.tbUpgrade.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbUpgrade.Image = global::HexExplorer.Properties.Resources.upgrade;
            this.tbUpgrade.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tbUpgrade.Name = "tbUpgrade";
            this.tbUpgrade.Size = new System.Drawing.Size(29, 24);
            this.tbUpgrade.Tag = "2";
            this.tbUpgrade.Text = "软件升级";
            this.tbUpgrade.Click += new System.EventHandler(this.MIUpgrade_Click);
            this.tbUpgrade.MouseLeave += new System.EventHandler(this.HideToolTipGroup_MouseLeave);
            this.tbUpgrade.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ShowToolTipGroup_MouseMove);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(tabPage2);
            this.tabControl1.Controls.Add(tabPage3);
            this.tabControl1.Controls.Add(tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(648, 693);
            this.tabControl1.TabIndex = 0;
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            Slbl4,
            this.LblStatus,
            this.Slbl5,
            this.LblSaved,
            this.LblWritable,
            this.lblLocked,
            this.lblInsert,
            Slbl6,
            this.LblFilename});
            this.statusStrip.Location = new System.Drawing.Point(0, 723);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip.Size = new System.Drawing.Size(1782, 30);
            this.statusStrip.TabIndex = 1;
            // 
            // LblStatus
            // 
            this.LblStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.LblStatus.Name = "LblStatus";
            this.LblStatus.Size = new System.Drawing.Size(43, 24);
            this.LblStatus.Text = "就绪";
            // 
            // Slbl5
            // 
            this.Slbl5.Name = "Slbl5";
            this.Slbl5.Size = new System.Drawing.Size(84, 24);
            this.Slbl5.Text = "文件状态：";
            // 
            // LblSaved
            // 
            this.LblSaved.AutoToolTip = true;
            this.LblSaved.Enabled = false;
            this.LblSaved.ForeColor = System.Drawing.Color.Green;
            this.LblSaved.Name = "LblSaved";
            this.LblSaved.Size = new System.Drawing.Size(29, 24);
            this.LblSaved.Tag = "1";
            this.LblSaved.Text = "💾";
            this.LblSaved.ToolTipText = "是否保存";
            this.LblSaved.MouseLeave += new System.EventHandler(this.HideToolTipGroup_MouseLeave);
            this.LblSaved.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ShowToolTipGroup_MouseMove);
            // 
            // LblWritable
            // 
            this.LblWritable.AutoToolTip = true;
            this.LblWritable.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.LblWritable.Enabled = false;
            this.LblWritable.ForeColor = System.Drawing.Color.Green;
            this.LblWritable.Name = "LblWritable";
            this.LblWritable.Size = new System.Drawing.Size(34, 24);
            this.LblWritable.Tag = "1";
            this.LblWritable.Text = "🖊";
            this.LblWritable.ToolTipText = "是否可写";
            this.LblWritable.MouseLeave += new System.EventHandler(this.HideToolTipGroup_MouseLeave);
            this.LblWritable.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ShowToolTipGroup_MouseMove);
            // 
            // lblLocked
            // 
            this.lblLocked.AutoToolTip = true;
            this.lblLocked.Enabled = false;
            this.lblLocked.ForeColor = System.Drawing.Color.Red;
            this.lblLocked.Name = "lblLocked";
            this.lblLocked.Size = new System.Drawing.Size(26, 24);
            this.lblLocked.Tag = "1";
            this.lblLocked.Text = "🔒";
            this.lblLocked.ToolTipText = "越界锁";
            this.lblLocked.Click += new System.EventHandler(this.LblLocked_Click);
            this.lblLocked.MouseLeave += new System.EventHandler(this.HideToolTipGroup_MouseLeave);
            this.lblLocked.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ShowToolTipGroup_MouseMove);
            // 
            // lblInsert
            // 
            this.lblInsert.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lblInsert.Enabled = false;
            this.lblInsert.ForeColor = System.Drawing.Color.Red;
            this.lblInsert.Name = "lblInsert";
            this.lblInsert.Size = new System.Drawing.Size(34, 24);
            this.lblInsert.Tag = "1";
            this.lblInsert.Text = "✍";
            this.lblInsert.ToolTipText = "插入模式";
            this.lblInsert.Click += new System.EventHandler(this.LblInsert_Click);
            this.lblInsert.MouseLeave += new System.EventHandler(this.HideToolTipGroup_MouseLeave);
            this.lblInsert.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ShowToolTipGroup_MouseMove);
            // 
            // LblFilename
            // 
            this.LblFilename.IsLink = true;
            this.LblFilename.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
            this.LblFilename.Name = "LblFilename";
            this.LblFilename.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.LblFilename.Size = new System.Drawing.Size(61, 24);
            this.LblFilename.Tag = "1";
            this.LblFilename.Text = "<未知>";
            this.LblFilename.VisitedLinkColor = System.Drawing.Color.Blue;
            this.LblFilename.Click += new System.EventHandler(this.LblFilename_Click);
            this.LblFilename.MouseLeave += new System.EventHandler(this.HideToolTipGroup_MouseLeave);
            this.LblFilename.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ShowToolTipGroup_MouseMove);
            this.LblFilename.TextChanged += new System.EventHandler(this.LblFilename_TextChanged);
            // 
            // TMISelectAll
            // 
            this.TMISelectAll.Name = "TMISelectAll";
            this.TMISelectAll.Size = new System.Drawing.Size(108, 24);
            this.TMISelectAll.Text = "全选";
            // 
            // oD
            // 
            this.oD.Filter = "PE文件|*.exe;*.dll;*.ocx|普通二进制文件|*.bin;*.dat|所有文件|*.*";
            this.oD.ShowReadOnly = true;
            this.oD.Title = "请选择有效PE文件";
            // 
            // TMICut
            // 
            this.TMICut.Name = "TMICut";
            this.TMICut.Size = new System.Drawing.Size(108, 24);
            this.TMICut.Text = "剪切";
            // 
            // TMICopy
            // 
            this.TMICopy.Name = "TMICopy";
            this.TMICopy.Size = new System.Drawing.Size(108, 24);
            this.TMICopy.Text = "复制";
            // 
            // TMIPaste
            // 
            this.TMIPaste.Name = "TMIPaste";
            this.TMIPaste.Size = new System.Drawing.Size(108, 24);
            this.TMIPaste.Text = "粘贴";
            // 
            // TMIFind
            // 
            this.TMIFind.Name = "TMIFind";
            this.TMIFind.Size = new System.Drawing.Size(108, 24);
            this.TMIFind.Text = "查找";
            // 
            // TMIJmp
            // 
            this.TMIJmp.Name = "TMIJmp";
            this.TMIJmp.Size = new System.Drawing.Size(108, 24);
            this.TMIJmp.Text = "定位";
            // 
            // toolTip
            // 
            this.toolTip.ShowAlways = true;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1782, 753);
            this.Controls.Add(this.scEdit);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(MainMenu);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = MainMenu;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmMain";
            this.Text = "羽云十六进制浏览器";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmMain_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmMain_KeyUp);
            MainMenu.ResumeLayout(false);
            MainMenu.PerformLayout();
            this.hexMenuStrip.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            splitContainer3.Panel1.ResumeLayout(false);
            splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(splitContainer3)).EndInit();
            splitContainer3.ResumeLayout(false);
            splitContainer4.Panel1.ResumeLayout(false);
            splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(splitContainer4)).EndInit();
            splitContainer4.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(splitContainer2)).EndInit();
            splitContainer2.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            this.scEdit.Panel1.ResumeLayout(false);
            this.scEdit.Panel1.PerformLayout();
            this.scEdit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scEdit)).EndInit();
            this.scEdit.ResumeLayout(false);
            this.toolStripHexEdit.ResumeLayout(false);
            this.toolStripHexEdit.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem MISave;
        private System.Windows.Forms.ToolStripMenuItem MIExport;
        private System.Windows.Forms.ToolStripMenuItem MICopy;
        private System.Windows.Forms.ToolStripMenuItem MIPaste;
        private System.Windows.Forms.ToolStripMenuItem MICut;
        private System.Windows.Forms.ToolStripMenuItem MISelectAll;
        private System.Windows.Forms.ToolStripMenuItem MenuPlugin;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.PropertyGrid pgConst;
        private System.Windows.Forms.OpenFileDialog oD;
        private System.Windows.Forms.SaveFileDialog sD;
        private System.Windows.Forms.ToolStripStatusLabel LblScale;
        private System.Windows.Forms.ToolStripStatusLabel LblLocation;
        private System.Windows.Forms.ToolStripStatusLabel LblStatus;
        private System.Windows.Forms.ToolStripStatusLabel Slbl5;
        private System.Windows.Forms.ToolStripStatusLabel LblSaved;
        private System.Windows.Forms.ToolStripStatusLabel LblWritable;
        private System.Windows.Forms.ToolStripStatusLabel LblFilename;
        private System.Windows.Forms.ToolStripMenuItem MIInsert;
        private System.Windows.Forms.ToolStripMenuItem MINewInsert;
        private System.Windows.Forms.ToolStripMenuItem MIFill;
        private System.Windows.Forms.ToolStripMenuItem MIFillZero;
        private System.Windows.Forms.ToolStripMenuItem MIFillNop;
        private System.Windows.Forms.ToolStripMenuItem MenuItemTool;
        private System.Windows.Forms.ToolStripStatusLabel Slbl3;
        private System.Windows.Forms.ToolStripStatusLabel LblLen;
        private System.Windows.Forms.ToolStripMenuItem MIFind;
        private System.Windows.Forms.ToolStripMenuItem MIJmp;
        private System.Windows.Forms.ContextMenuStrip hexMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem TMISelectAll;
        private System.Windows.Forms.ToolStripMenuItem TMICut;
        private System.Windows.Forms.ToolStripMenuItem TMICopy;
        private System.Windows.Forms.ToolStripMenuItem TMIPaste;
        private System.Windows.Forms.ToolStripMenuItem TMIFind;
        private System.Windows.Forms.ToolStripMenuItem TMIJmp;
        private System.Windows.Forms.ToolStripMenuItem MIBookMark;
        private System.Windows.Forms.ToolStripMenuItem MIDel;
        private System.Windows.Forms.ToolStripSeparator MIS;
        private System.Windows.Forms.ToolStripButton tbNew;
        private System.Windows.Forms.ToolStripButton tbOpen;
        private System.Windows.Forms.ToolStripButton tbCut;
        private System.Windows.Forms.ToolStripSplitButton tbCopy;
        private System.Windows.Forms.ToolStripSplitButton tbPaste;
        private System.Windows.Forms.ToolStripButton tbFill;
        private System.Windows.Forms.ToolStripButton tbFillZero;
        private System.Windows.Forms.ToolStripButton tbFillNop;
        private System.Windows.Forms.ToolStripButton tbBookMark;
        private System.Windows.Forms.ToolStripButton tbSetting;
        private System.Windows.Forms.ToolStripButton tbSettingPlugin;
        private System.Windows.Forms.ToolStripButton tbCalc;
        private System.Windows.Forms.ToolStripButton tbAboutthis;
        private System.Windows.Forms.ToolStripButton tbExport;
        private System.Windows.Forms.ToolStripButton tbSave;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.PropertyGrid propertyGridB;
        private System.Windows.Forms.ToolStripButton tbDel;
        private System.Windows.Forms.ToolStripButton tbSaveAs;
        private System.Windows.Forms.ToolStripMenuItem MISaveAs;
        private System.Windows.Forms.ToolStripStatusLabel lblLocked;
        private System.Windows.Forms.ToolStripButton tbClose;
        private System.Windows.Forms.ToolStripSeparator ts10;
        private System.Windows.Forms.ToolStripMenuItem MIClose;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem SMICopyHex;
        private System.Windows.Forms.ToolStripMenuItem SMIPasteHex;
        private System.Windows.Forms.ToolStripMenuItem MICopyHex;
        private System.Windows.Forms.ToolStripMenuItem MIPasteHex;
        private System.Windows.Forms.ToolStripMenuItem SMICopy;
        private System.Windows.Forms.ToolStripMenuItem SMIPaste;
        private System.Windows.Forms.ToolStripStatusLabel lblInsert;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.TreeView tvPEStruct;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.SplitContainer scEdit;
        private System.Windows.Forms.ToolStripButton tbInfo;
        private System.Windows.Forms.ToolStripMenuItem MenuItemEdit;
        private System.Windows.Forms.ToolStripMenuItem MIAdmin;
        private System.Windows.Forms.ToolStripSeparator ts13;
        private System.Windows.Forms.ToolStripMenuItem MenuItemFile;
        private TabControlEx tabEditArea;
        private System.Windows.Forms.ToolStrip toolStripHexEdit;
        private System.Windows.Forms.ToolStripButton tbString;
        private System.Windows.Forms.ToolStripButton tbPEInfo;
        private System.Windows.Forms.ToolStripButton tbGroupSep;
        private System.Windows.Forms.ToolStripButton tbColBg;
        private System.Windows.Forms.ToolStripButton tbColInfo;
        private System.Windows.Forms.ToolStripButton tbLineBg;
        private System.Windows.Forms.ToolStripButton tbLineInfo;
        private System.Windows.Forms.ToolStripButton tbAddr;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripComboBox tscbEncoding;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.ToolStripButton tbSponsor;
        private System.Windows.Forms.ToolStripMenuItem MIUpgrade;
        private System.Windows.Forms.ToolStripButton tbUpgrade;
    }
}

