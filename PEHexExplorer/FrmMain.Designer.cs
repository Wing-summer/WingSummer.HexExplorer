namespace PEHexExplorer
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
            System.Windows.Forms.StatusStrip statusStrip2;
            System.Windows.Forms.ToolStripStatusLabel Slbl1;
            System.Windows.Forms.ToolStripStatusLabel Slbl2;
            System.Windows.Forms.ToolStripStatusLabel Slbl4;
            System.Windows.Forms.ToolStripStatusLabel Slbl6;
            System.Windows.Forms.MenuStrip MainMenu;
            System.Windows.Forms.ToolStripMenuItem MenuItemFile;
            System.Windows.Forms.ToolStripSeparator MIS0;
            System.Windows.Forms.ToolStripSeparator MIS1;
            System.Windows.Forms.ToolStripMenuItem MenuItemEdit;
            System.Windows.Forms.ToolStripSeparator MIS2;
            System.Windows.Forms.ToolStripSeparator MIS3;
            System.Windows.Forms.ToolStripSeparator MIS7;
            System.Windows.Forms.ToolStripSeparator MIS4;
            System.Windows.Forms.ToolStripSeparator MIS8;
            System.Windows.Forms.ToolStripMenuItem MenuItemSetting;
            System.Windows.Forms.ToolStripMenuItem MenuItemAbout;
            System.Windows.Forms.ToolStripSeparator ts9;
            System.Windows.Forms.ToolStripSeparator ts1;
            System.Windows.Forms.ToolStripSeparator ts2;
            System.Windows.Forms.ToolStripSeparator ts3;
            System.Windows.Forms.ToolStripSeparator ts4;
            System.Windows.Forms.ToolStripSeparator ts5;
            System.Windows.Forms.TabPage tabPage2;
            System.Windows.Forms.SplitContainer splitContainer3;
            System.Windows.Forms.SplitContainer splitContainer4;
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("IMAGE_DOS_HEADER", 1, 1);
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("IMAGE_NT_HEADERS", 1, 1);
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("IMAGE_FILE_HEADER", 1, 1);
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("IMAGE_OPTIONAL_HEADER", 1, 1);
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("IMAGE_DATA_DIRECTORY", 1, 1);
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("IMAGE_EXPORT_DIRECTORY", 1, 1);
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("IMAGE_IMPORT_DESCRIPTOR", 1, 1);
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("IMAGE_BASE_RELOCATION", 1, 1);
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("IMAGE_SECTION_HEADER", 1, 1);
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("IMAGE_COR20_HEADER\n", 1, 1);
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode(".NET", 3, 3, new System.Windows.Forms.TreeNode[] {
            treeNode22});
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("PE 文件", new System.Windows.Forms.TreeNode[] {
            treeNode13,
            treeNode14,
            treeNode15,
            treeNode16,
            treeNode17,
            treeNode18,
            treeNode19,
            treeNode20,
            treeNode21,
            treeNode23});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            System.Windows.Forms.TabPage tabPage3;
            System.Windows.Forms.SplitContainer splitContainer2;
            System.Windows.Forms.ToolStripSeparator ts11;
            System.Windows.Forms.ToolStripSeparator ts12;
            this.LblScale = new System.Windows.Forms.ToolStripStatusLabel();
            this.LblLocation = new System.Windows.Forms.ToolStripStatusLabel();
            this.Slbl3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.LblLen = new System.Windows.Forms.ToolStripStatusLabel();
            this.MINew = new System.Windows.Forms.ToolStripMenuItem();
            this.MIOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.MIOpenProcess = new System.Windows.Forms.ToolStripMenuItem();
            this.MISave = new System.Windows.Forms.ToolStripMenuItem();
            this.MISaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.MIExport = new System.Windows.Forms.ToolStripMenuItem();
            this.MIClose = new System.Windows.Forms.ToolStripMenuItem();
            this.MIExit = new System.Windows.Forms.ToolStripMenuItem();
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
            this.MIGeneral = new System.Windows.Forms.ToolStripMenuItem();
            this.MIPlugin = new System.Windows.Forms.ToolStripMenuItem();
            this.MIInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemTool = new System.Windows.Forms.ToolStripMenuItem();
            this.MICalculator = new System.Windows.Forms.ToolStripMenuItem();
            this.MIAddrConverter = new System.Windows.Forms.ToolStripMenuItem();
            this.MIS = new System.Windows.Forms.ToolStripSeparator();
            this.MenuPlugin = new System.Windows.Forms.ToolStripMenuItem();
            this.tvPEStruct = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.pgConst = new System.Windows.Forms.PropertyGrid();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.propertyGridB = new System.Windows.Forms.PropertyGrid();
            this.scEdit = new System.Windows.Forms.SplitContainer();
            this.hexBox = new Be.Windows.Forms.HexBox();
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
            statusStrip2 = new System.Windows.Forms.StatusStrip();
            Slbl1 = new System.Windows.Forms.ToolStripStatusLabel();
            Slbl2 = new System.Windows.Forms.ToolStripStatusLabel();
            Slbl4 = new System.Windows.Forms.ToolStripStatusLabel();
            Slbl6 = new System.Windows.Forms.ToolStripStatusLabel();
            MainMenu = new System.Windows.Forms.MenuStrip();
            MenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            MIS0 = new System.Windows.Forms.ToolStripSeparator();
            MIS1 = new System.Windows.Forms.ToolStripSeparator();
            MenuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            MIS2 = new System.Windows.Forms.ToolStripSeparator();
            MIS3 = new System.Windows.Forms.ToolStripSeparator();
            MIS7 = new System.Windows.Forms.ToolStripSeparator();
            MIS4 = new System.Windows.Forms.ToolStripSeparator();
            MIS8 = new System.Windows.Forms.ToolStripSeparator();
            MenuItemSetting = new System.Windows.Forms.ToolStripMenuItem();
            MenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
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
            statusStrip2.SuspendLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.scEdit)).BeginInit();
            this.scEdit.Panel1.SuspendLayout();
            this.scEdit.Panel2.SuspendLayout();
            this.scEdit.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip2
            // 
            statusStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            Slbl1,
            this.LblScale,
            Slbl2,
            this.LblLocation,
            this.Slbl3,
            this.LblLen});
            statusStrip2.Location = new System.Drawing.Point(0, 663);
            statusStrip2.Name = "statusStrip2";
            statusStrip2.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            statusStrip2.ShowItemToolTips = true;
            statusStrip2.Size = new System.Drawing.Size(1130, 30);
            statusStrip2.TabIndex = 1;
            // 
            // Slbl1
            // 
            Slbl1.Name = "Slbl1";
            Slbl1.Size = new System.Drawing.Size(54, 24);
            Slbl1.Text = "缩放：";
            // 
            // LblScale
            // 
            this.LblScale.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.LblScale.DoubleClickEnabled = true;
            this.LblScale.Name = "LblScale";
            this.LblScale.Size = new System.Drawing.Size(53, 24);
            this.LblScale.Text = "100%";
            this.LblScale.ToolTipText = "双击重置视图";
            this.LblScale.DoubleClick += new System.EventHandler(this.LblScale_DoubleClick);
            // 
            // Slbl2
            // 
            Slbl2.Name = "Slbl2";
            Slbl2.Size = new System.Drawing.Size(54, 24);
            Slbl2.Text = "位置：";
            // 
            // LblLocation
            // 
            this.LblLocation.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.LblLocation.Name = "LblLocation";
            this.LblLocation.Size = new System.Drawing.Size(45, 24);
            this.LblLocation.Text = "(0,0)";
            // 
            // Slbl3
            // 
            this.Slbl3.Name = "Slbl3";
            this.Slbl3.Size = new System.Drawing.Size(84, 24);
            this.Slbl3.Text = "选中长度：";
            // 
            // LblLen
            // 
            this.LblLen.Name = "LblLen";
            this.LblLen.Size = new System.Drawing.Size(16, 24);
            this.LblLen.Text = "*";
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
            MainMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            MainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            MenuItemFile,
            MenuItemEdit,
            MenuItemSetting,
            this.MenuItemTool,
            this.MenuPlugin,
            MenuItemAbout});
            MainMenu.Location = new System.Drawing.Point(0, 0);
            MainMenu.Name = "MainMenu";
            MainMenu.Padding = new System.Windows.Forms.Padding(4, 3, 0, 3);
            MainMenu.ShowItemToolTips = true;
            MainMenu.Size = new System.Drawing.Size(1782, 30);
            MainMenu.TabIndex = 3;
            // 
            // MenuItemFile
            // 
            MenuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MINew,
            this.MIOpen,
            this.MIOpenProcess,
            MIS0,
            this.MISave,
            this.MISaveAs,
            this.MIExport,
            MIS1,
            this.MIClose,
            this.MIExit});
            MenuItemFile.Image = global::PEHexExplorer.Properties.Resources.file;
            MenuItemFile.Name = "MenuItemFile";
            MenuItemFile.Size = new System.Drawing.Size(91, 24);
            MenuItemFile.Text = "文件(&F)";
            // 
            // MINew
            // 
            this.MINew.Image = global::PEHexExplorer.Properties.Resources._new;
            this.MINew.Name = "MINew";
            this.MINew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.MINew.Size = new System.Drawing.Size(254, 26);
            this.MINew.Text = "新建";
            this.MINew.Click += new System.EventHandler(this.MINew_Click);
            // 
            // MIOpen
            // 
            this.MIOpen.Image = global::PEHexExplorer.Properties.Resources.open;
            this.MIOpen.Name = "MIOpen";
            this.MIOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.MIOpen.Size = new System.Drawing.Size(254, 26);
            this.MIOpen.Text = "打开";
            this.MIOpen.Click += new System.EventHandler(this.MIOpen_Click);
            // 
            // MIOpenProcess
            // 
            this.MIOpenProcess.Name = "MIOpenProcess";
            this.MIOpenProcess.Size = new System.Drawing.Size(254, 26);
            this.MIOpenProcess.Text = "从进程读取";
            this.MIOpenProcess.Click += new System.EventHandler(this.MIOpenProcess_Click);
            // 
            // MIS0
            // 
            MIS0.Name = "MIS0";
            MIS0.Size = new System.Drawing.Size(251, 6);
            // 
            // MISave
            // 
            this.MISave.Image = global::PEHexExplorer.Properties.Resources.save;
            this.MISave.Name = "MISave";
            this.MISave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.MISave.Size = new System.Drawing.Size(254, 26);
            this.MISave.Text = "保存";
            this.MISave.Click += new System.EventHandler(this.MISave_Click);
            // 
            // MISaveAs
            // 
            this.MISaveAs.Image = global::PEHexExplorer.Properties.Resources.saveas;
            this.MISaveAs.Name = "MISaveAs";
            this.MISaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.MISaveAs.Size = new System.Drawing.Size(254, 26);
            this.MISaveAs.Text = "另存为";
            this.MISaveAs.Click += new System.EventHandler(this.MISaveAs_Click);
            // 
            // MIExport
            // 
            this.MIExport.Image = global::PEHexExplorer.Properties.Resources.export;
            this.MIExport.Name = "MIExport";
            this.MIExport.ShortcutKeys = ((System.Windows.Forms.Keys)((((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.MIExport.Size = new System.Drawing.Size(254, 26);
            this.MIExport.Text = "导出";
            this.MIExport.Click += new System.EventHandler(this.MIExport_Click);
            // 
            // MIS1
            // 
            MIS1.Name = "MIS1";
            MIS1.Size = new System.Drawing.Size(251, 6);
            // 
            // MIClose
            // 
            this.MIClose.Image = global::PEHexExplorer.Properties.Resources.closefile;
            this.MIClose.Name = "MIClose";
            this.MIClose.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Q)));
            this.MIClose.Size = new System.Drawing.Size(254, 26);
            this.MIClose.Text = "关闭文件";
            this.MIClose.Click += new System.EventHandler(this.MIClose_Click);
            // 
            // MIExit
            // 
            this.MIExit.Image = global::PEHexExplorer.Properties.Resources.exit;
            this.MIExit.Name = "MIExit";
            this.MIExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.MIExit.Size = new System.Drawing.Size(254, 26);
            this.MIExit.Text = "退出";
            this.MIExit.Click += new System.EventHandler(this.MIExit_Click);
            // 
            // MenuItemEdit
            // 
            MenuItemEdit.DropDown = this.hexMenuStrip;
            MenuItemEdit.Image = global::PEHexExplorer.Properties.Resources.edit;
            MenuItemEdit.Name = "MenuItemEdit";
            MenuItemEdit.Size = new System.Drawing.Size(91, 24);
            MenuItemEdit.Text = "编辑(&E)";
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
            this.hexMenuStrip.OwnerItem = MenuItemEdit;
            this.hexMenuStrip.Size = new System.Drawing.Size(262, 424);
            // 
            // MISelectAll
            // 
            this.MISelectAll.Enabled = false;
            this.MISelectAll.Image = global::PEHexExplorer.Properties.Resources.selectAll;
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
            this.MICut.Image = global::PEHexExplorer.Properties.Resources.cut;
            this.MICut.Name = "MICut";
            this.MICut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.MICut.Size = new System.Drawing.Size(261, 26);
            this.MICut.Text = "剪切";
            this.MICut.Click += new System.EventHandler(this.MICut_Click);
            // 
            // MICopy
            // 
            this.MICopy.Enabled = false;
            this.MICopy.Image = global::PEHexExplorer.Properties.Resources.copy;
            this.MICopy.Name = "MICopy";
            this.MICopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.MICopy.Size = new System.Drawing.Size(261, 26);
            this.MICopy.Text = "复制";
            this.MICopy.Click += new System.EventHandler(this.MICopy_Click);
            // 
            // MICopyHex
            // 
            this.MICopyHex.Enabled = false;
            this.MICopyHex.Image = global::PEHexExplorer.Properties.Resources.copy;
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
            this.MIPaste.Image = global::PEHexExplorer.Properties.Resources.paste;
            this.MIPaste.Name = "MIPaste";
            this.MIPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.MIPaste.Size = new System.Drawing.Size(261, 26);
            this.MIPaste.Text = "粘贴";
            this.MIPaste.Click += new System.EventHandler(this.MIPaste_Click);
            // 
            // MIPasteHex
            // 
            this.MIPasteHex.Enabled = false;
            this.MIPasteHex.Image = global::PEHexExplorer.Properties.Resources.paste;
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
            this.MIDel.Image = global::PEHexExplorer.Properties.Resources.del;
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
            this.MIInsert.Image = global::PEHexExplorer.Properties.Resources.insert;
            this.MIInsert.Name = "MIInsert";
            this.MIInsert.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.MIInsert.Size = new System.Drawing.Size(261, 26);
            this.MIInsert.Text = "插入数据";
            this.MIInsert.Click += new System.EventHandler(this.MIInsert_Click);
            // 
            // MINewInsert
            // 
            this.MINewInsert.Enabled = false;
            this.MINewInsert.Image = global::PEHexExplorer.Properties.Resources.newinsert;
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
            this.MIFind.Image = global::PEHexExplorer.Properties.Resources.find;
            this.MIFind.Name = "MIFind";
            this.MIFind.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.MIFind.Size = new System.Drawing.Size(261, 26);
            this.MIFind.Text = "查找";
            this.MIFind.Click += new System.EventHandler(this.MIFind_Click);
            // 
            // MIJmp
            // 
            this.MIJmp.Enabled = false;
            this.MIJmp.Image = global::PEHexExplorer.Properties.Resources.jmp;
            this.MIJmp.Name = "MIJmp";
            this.MIJmp.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.MIJmp.Size = new System.Drawing.Size(261, 26);
            this.MIJmp.Text = "定位";
            this.MIJmp.Click += new System.EventHandler(this.MIJmp_Click);
            // 
            // MIS4
            // 
            MIS4.Name = "MIS4";
            MIS4.Size = new System.Drawing.Size(258, 6);
            // 
            // MIFill
            // 
            this.MIFill.Enabled = false;
            this.MIFill.Image = global::PEHexExplorer.Properties.Resources.fill;
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
            this.MIFillZero.Image = global::PEHexExplorer.Properties.Resources.fillZero;
            this.MIFillZero.Name = "MIFillZero";
            this.MIFillZero.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D0)));
            this.MIFillZero.Size = new System.Drawing.Size(261, 26);
            this.MIFillZero.Text = "选区置零";
            this.MIFillZero.Click += new System.EventHandler(this.MIFillZero_Click);
            // 
            // MIFillNop
            // 
            this.MIFillNop.Enabled = false;
            this.MIFillNop.Image = global::PEHexExplorer.Properties.Resources.fillNop;
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
            this.MIBookMark.Image = global::PEHexExplorer.Properties.Resources.bookmark;
            this.MIBookMark.Name = "MIBookMark";
            this.MIBookMark.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.MIBookMark.Size = new System.Drawing.Size(261, 26);
            this.MIBookMark.Text = "书签添加/删除";
            this.MIBookMark.Click += new System.EventHandler(this.MIBookMark_Click);
            // 
            // MenuItemSetting
            // 
            MenuItemSetting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MIGeneral,
            this.MIPlugin,
            this.MIInfo});
            MenuItemSetting.Image = global::PEHexExplorer.Properties.Resources.setting;
            MenuItemSetting.Name = "MenuItemSetting";
            MenuItemSetting.Size = new System.Drawing.Size(92, 24);
            MenuItemSetting.Text = "设置(&S)";
            // 
            // MIGeneral
            // 
            this.MIGeneral.Image = global::PEHexExplorer.Properties.Resources.general;
            this.MIGeneral.Name = "MIGeneral";
            this.MIGeneral.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.K)));
            this.MIGeneral.Size = new System.Drawing.Size(268, 26);
            this.MIGeneral.Text = "常规";
            this.MIGeneral.Click += new System.EventHandler(this.MIGeneral_Click);
            // 
            // MIPlugin
            // 
            this.MIPlugin.Image = global::PEHexExplorer.Properties.Resources.settingplugin;
            this.MIPlugin.Name = "MIPlugin";
            this.MIPlugin.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.K)));
            this.MIPlugin.Size = new System.Drawing.Size(268, 26);
            this.MIPlugin.Text = "插件设置";
            this.MIPlugin.Click += new System.EventHandler(this.MIPlugin_Click);
            // 
            // MIInfo
            // 
            this.MIInfo.Image = global::PEHexExplorer.Properties.Resources.info;
            this.MIInfo.Name = "MIInfo";
            this.MIInfo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.MIInfo.Size = new System.Drawing.Size(268, 26);
            this.MIInfo.Text = "显示/隐藏侧栏信息";
            this.MIInfo.Click += new System.EventHandler(this.MIInfo_Click);
            // 
            // MenuItemTool
            // 
            this.MenuItemTool.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MICalculator,
            this.MIAddrConverter,
            this.MIS});
            this.MenuItemTool.Image = global::PEHexExplorer.Properties.Resources.tools;
            this.MenuItemTool.Name = "MenuItemTool";
            this.MenuItemTool.Size = new System.Drawing.Size(107, 24);
            this.MenuItemTool.Text = "小工具(&T)";
            // 
            // MICalculator
            // 
            this.MICalculator.Image = global::PEHexExplorer.Properties.Resources.calc;
            this.MICalculator.Name = "MICalculator";
            this.MICalculator.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.NumPad0)));
            this.MICalculator.Size = new System.Drawing.Size(284, 26);
            this.MICalculator.Text = "计算器";
            this.MICalculator.Click += new System.EventHandler(this.MICalculator_Click);
            // 
            // MIAddrConverter
            // 
            this.MIAddrConverter.Image = global::PEHexExplorer.Properties.Resources.AddrConv;
            this.MIAddrConverter.Name = "MIAddrConverter";
            this.MIAddrConverter.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.NumPad1)));
            this.MIAddrConverter.Size = new System.Drawing.Size(284, 26);
            this.MIAddrConverter.Text = "地址转化器";
            this.MIAddrConverter.Click += new System.EventHandler(this.MIAddrConverter_Click);
            // 
            // MIS
            // 
            this.MIS.Name = "MIS";
            this.MIS.Size = new System.Drawing.Size(281, 6);
            this.MIS.Visible = false;
            // 
            // MenuPlugin
            // 
            this.MenuPlugin.Image = global::PEHexExplorer.Properties.Resources.plugin;
            this.MenuPlugin.Name = "MenuPlugin";
            this.MenuPlugin.Size = new System.Drawing.Size(92, 24);
            this.MenuPlugin.Text = "插件(&P)";
            // 
            // MenuItemAbout
            // 
            MenuItemAbout.Image = global::PEHexExplorer.Properties.Resources.aboutthis;
            MenuItemAbout.Name = "MenuItemAbout";
            MenuItemAbout.Size = new System.Drawing.Size(73, 24);
            MenuItemAbout.Text = "关于";
            MenuItemAbout.Click += new System.EventHandler(this.MIAboutThis_Click);
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
            treeNode13.ImageIndex = 1;
            treeNode13.Name = "tDOS_HEADER";
            treeNode13.SelectedImageIndex = 1;
            treeNode13.Text = "IMAGE_DOS_HEADER";
            treeNode14.ImageIndex = 1;
            treeNode14.Name = "tNT_HEADERS";
            treeNode14.SelectedImageIndex = 1;
            treeNode14.Text = "IMAGE_NT_HEADERS";
            treeNode15.ImageIndex = 1;
            treeNode15.Name = "tFILE_HEADER";
            treeNode15.SelectedImageIndex = 1;
            treeNode15.Text = "IMAGE_FILE_HEADER";
            treeNode16.ImageIndex = 1;
            treeNode16.Name = "tOPTIONAL_HEADER";
            treeNode16.SelectedImageIndex = 1;
            treeNode16.Text = "IMAGE_OPTIONAL_HEADER";
            treeNode17.ImageIndex = 1;
            treeNode17.Name = "tDATA_DIRECTORY";
            treeNode17.SelectedImageIndex = 1;
            treeNode17.Text = "IMAGE_DATA_DIRECTORY";
            treeNode18.ImageIndex = 1;
            treeNode18.Name = "tEXPORT_DIRECTORY";
            treeNode18.SelectedImageIndex = 1;
            treeNode18.Text = "IMAGE_EXPORT_DIRECTORY";
            treeNode19.ImageIndex = 1;
            treeNode19.Name = "tIMPORT_DESCRIPTOR";
            treeNode19.SelectedImageIndex = 1;
            treeNode19.Text = "IMAGE_IMPORT_DESCRIPTOR";
            treeNode20.ImageIndex = 1;
            treeNode20.Name = "tBASE_RELOCATION";
            treeNode20.SelectedImageIndex = 1;
            treeNode20.Text = "IMAGE_BASE_RELOCATION";
            treeNode21.ImageIndex = 1;
            treeNode21.Name = "tSECTION_HEADER";
            treeNode21.SelectedImageIndex = 1;
            treeNode21.Text = "IMAGE_SECTION_HEADER";
            treeNode22.ImageIndex = 1;
            treeNode22.Name = "tCOR20_HEADER\n";
            treeNode22.SelectedImageIndex = 1;
            treeNode22.Text = "IMAGE_COR20_HEADER\n";
            treeNode23.ImageIndex = 3;
            treeNode23.Name = "tNET";
            treeNode23.SelectedImageIndex = 3;
            treeNode23.Text = ".NET";
            treeNode24.Name = "nodeRoot";
            treeNode24.Text = "PE 文件";
            this.tvPEStruct.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode24});
            this.tvPEStruct.SelectedImageIndex = 0;
            this.tvPEStruct.Size = new System.Drawing.Size(300, 347);
            this.tvPEStruct.TabIndex = 0;
            this.tvPEStruct.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TvPEStruct_AfterSelect);
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
            splitContainer2.SplitterDistance = 243;
            splitContainer2.TabIndex = 3;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(0, 0);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(634, 243);
            this.checkedListBox1.TabIndex = 3;
            // 
            // propertyGridB
            // 
            this.propertyGridB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridB.Location = new System.Drawing.Point(0, 0);
            this.propertyGridB.Name = "propertyGridB";
            this.propertyGridB.Size = new System.Drawing.Size(634, 411);
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
            // scEdit
            // 
            this.scEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scEdit.Location = new System.Drawing.Point(0, 30);
            this.scEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.scEdit.Name = "scEdit";
            // 
            // scEdit.Panel1
            // 
            this.scEdit.Panel1.Controls.Add(this.hexBox);
            this.scEdit.Panel1.Controls.Add(this.toolStrip);
            this.scEdit.Panel1.Controls.Add(statusStrip2);
            // 
            // scEdit.Panel2
            // 
            this.scEdit.Panel2.Controls.Add(this.tabControl1);
            this.scEdit.Size = new System.Drawing.Size(1782, 693);
            this.scEdit.SplitterDistance = 1130;
            this.scEdit.TabIndex = 5;
            // 
            // hexBox
            // 
            this.hexBox.BaseAddr = ((long)(0));
            this.hexBox.ColumnInfoBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.hexBox.ColumnInfoVisible = true;
            this.hexBox.ContextMenuStrip = this.hexMenuStrip;
            this.hexBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hexBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.hexBox.GroupLinePen.Alignment = System.Drawing.Drawing2D.PenAlignment.Center;
            this.hexBox.GroupLinePen.Color = System.Drawing.Color.Lime;
            this.hexBox.GroupLinePen.DashCap = System.Drawing.Drawing2D.DashCap.Flat;
            this.hexBox.GroupLinePen.DashOffset = 0F;
            this.hexBox.GroupLinePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.hexBox.GroupLinePen.EndCap = System.Drawing.Drawing2D.LineCap.Flat;
            this.hexBox.GroupLinePen.StartCap = System.Drawing.Drawing2D.LineCap.Flat;
            this.hexBox.GroupLinePen.Width = 1F;
            this.hexBox.GroupSeparatorVisible = true;
            this.hexBox.HexStringLinePen = ((Be.Windows.Forms.PenF)(resources.GetObject("hexBox.HexStringLinePen")));
            this.hexBox.HScrollBarVisible = true;
            this.hexBox.LineInfoBackColor = System.Drawing.Color.Cyan;
            this.hexBox.LineInfoVisible = true;
            this.hexBox.Location = new System.Drawing.Point(0, 27);
            this.hexBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.hexBox.Name = "hexBox";
            this.hexBox.Scaling = 1F;
            this.hexBox.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.hexBox.ShowColumnInfoBackColor = true;
            this.hexBox.ShowLineInfoBackColor = true;
            this.hexBox.Size = new System.Drawing.Size(1130, 636);
            this.hexBox.StringViewVisible = true;
            this.hexBox.TabIndex = 0;
            this.hexBox.UseFixedBytesPerLine = true;
            this.hexBox.VScrollBarVisible = true;
            this.hexBox.InsertActiveChanged += new System.EventHandler(this.HexBox_InsertActiveChanged);
            this.hexBox.ByteProviderChanged += new System.EventHandler(this.HexBox_ByteProviderChanged);
            this.hexBox.SelectionLengthChanged += new System.EventHandler(this.HexBox_SelectionLengthChanged);
            this.hexBox.CurrentLineChanged += new System.EventHandler(this.HexBox_CurrentLineChanged);
            this.hexBox.CurrentPositionInLineChanged += new System.EventHandler(this.HexBox_CurrentPositionInLineChanged);
            this.hexBox.CurrentPositionChanged += new System.EventHandler(this.HexBox_CurrentPositionChanged);
            this.hexBox.ScalingChanged += new System.EventHandler(this.HexBox_ScalingChanged);
            this.hexBox.SavedStatusChanged += new System.EventHandler(this.HexBox_ContentChanged);
            this.hexBox.LockedBufferChanged += new System.EventHandler(this.HexBox_LockedBufferChanged);
            // 
            // toolStrip
            // 
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
            this.tbAboutthis});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.ShowItemToolTips = false;
            this.toolStrip.Size = new System.Drawing.Size(1130, 27);
            this.toolStrip.TabIndex = 2;
            // 
            // tbNew
            // 
            this.tbNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbNew.Image = global::PEHexExplorer.Properties.Resources._new;
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
            this.tbOpen.Image = global::PEHexExplorer.Properties.Resources.open;
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
            this.tbExport.Image = global::PEHexExplorer.Properties.Resources.export;
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
            this.tbSave.Image = global::PEHexExplorer.Properties.Resources.save;
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
            this.tbSaveAs.Image = global::PEHexExplorer.Properties.Resources.saveas;
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
            this.tbCut.Image = global::PEHexExplorer.Properties.Resources.cut;
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
            this.tbCopy.Image = global::PEHexExplorer.Properties.Resources.copy;
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
            this.SMICopy.Image = global::PEHexExplorer.Properties.Resources.copy;
            this.SMICopy.Name = "SMICopy";
            this.SMICopy.Size = new System.Drawing.Size(181, 26);
            this.SMICopy.Text = "复制";
            this.SMICopy.Click += new System.EventHandler(this.MICopy_Click);
            // 
            // SMICopyHex
            // 
            this.SMICopyHex.Image = global::PEHexExplorer.Properties.Resources.copy;
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
            this.tbPaste.Image = global::PEHexExplorer.Properties.Resources.paste;
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
            this.SMIPaste.Image = global::PEHexExplorer.Properties.Resources.paste;
            this.SMIPaste.Name = "SMIPaste";
            this.SMIPaste.Size = new System.Drawing.Size(181, 26);
            this.SMIPaste.Text = "粘贴";
            this.SMIPaste.Click += new System.EventHandler(this.MIPaste_Click);
            // 
            // SMIPasteHex
            // 
            this.SMIPasteHex.Image = global::PEHexExplorer.Properties.Resources.paste;
            this.SMIPasteHex.Name = "SMIPasteHex";
            this.SMIPasteHex.Size = new System.Drawing.Size(181, 26);
            this.SMIPasteHex.Text = "粘贴（Hex）";
            this.SMIPasteHex.Click += new System.EventHandler(this.MIPasteHex_Click);
            // 
            // tbDel
            // 
            this.tbDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbDel.Enabled = false;
            this.tbDel.Image = global::PEHexExplorer.Properties.Resources.del;
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
            this.tbFill.Image = global::PEHexExplorer.Properties.Resources.fill;
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
            this.tbFillZero.Image = global::PEHexExplorer.Properties.Resources.fillZero;
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
            this.tbFillNop.Image = global::PEHexExplorer.Properties.Resources.fillNop;
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
            this.tbBookMark.Image = global::PEHexExplorer.Properties.Resources.bookmark;
            this.tbBookMark.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tbBookMark.Name = "tbBookMark";
            this.tbBookMark.Size = new System.Drawing.Size(29, 24);
            this.tbBookMark.Tag = "2";
            this.tbBookMark.Text = "书签";
            this.tbBookMark.Click += new System.EventHandler(this.MIBookMark_Click);
            this.tbBookMark.MouseLeave += new System.EventHandler(this.HideToolTipGroup_MouseLeave);
            this.tbBookMark.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ShowToolTipGroup_MouseMove);
            // 
            // tbInfo
            // 
            this.tbInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbInfo.Image = global::PEHexExplorer.Properties.Resources.info;
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
            this.tbSetting.Image = global::PEHexExplorer.Properties.Resources.setting;
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
            this.tbSettingPlugin.Image = global::PEHexExplorer.Properties.Resources.settingplugin;
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
            this.tbCalc.Image = global::PEHexExplorer.Properties.Resources.calc;
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
            this.tbClose.Image = global::PEHexExplorer.Properties.Resources.closefile;
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
            this.tbAboutthis.Image = global::PEHexExplorer.Properties.Resources.aboutthis;
            this.tbAboutthis.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tbAboutthis.Name = "tbAboutthis";
            this.tbAboutthis.Size = new System.Drawing.Size(29, 24);
            this.tbAboutthis.Tag = "2";
            this.tbAboutthis.Text = "关于此软件";
            this.tbAboutthis.Click += new System.EventHandler(this.MIAboutThis_Click);
            this.tbAboutthis.MouseLeave += new System.EventHandler(this.HideToolTipGroup_MouseLeave);
            this.tbAboutthis.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ShowToolTipGroup_MouseMove);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(tabPage2);
            this.tabControl1.Controls.Add(tabPage3);
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
            this.statusStrip.TabIndex = 4;
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
            this.oD.Filter = "PE文件|*.exe;*.dll;*.ocx|所有文件|*.*";
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
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = MainMenu;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "羽云PE浏览器 —— By. 寂静的羽夏(wingsummer)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            statusStrip2.ResumeLayout(false);
            statusStrip2.PerformLayout();
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
            this.scEdit.Panel1.ResumeLayout(false);
            this.scEdit.Panel1.PerformLayout();
            this.scEdit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scEdit)).EndInit();
            this.scEdit.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem MINew;
        private System.Windows.Forms.ToolStripMenuItem MIOpen;
        private System.Windows.Forms.ToolStripMenuItem MISave;
        private System.Windows.Forms.ToolStripMenuItem MIExport;
        private System.Windows.Forms.ToolStripMenuItem MIExit;
        private System.Windows.Forms.ToolStripMenuItem MICopy;
        private System.Windows.Forms.ToolStripMenuItem MIPaste;
        private System.Windows.Forms.ToolStripMenuItem MICut;
        private System.Windows.Forms.ToolStripMenuItem MISelectAll;
        private System.Windows.Forms.ToolStripMenuItem MenuPlugin;
        private Be.Windows.Forms.HexBox hexBox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.PropertyGrid pgConst;
        private System.Windows.Forms.OpenFileDialog oD;
        private System.Windows.Forms.SaveFileDialog sD;
        private System.Windows.Forms.ToolStripMenuItem MIGeneral;
        private System.Windows.Forms.ToolStripStatusLabel LblScale;
        private System.Windows.Forms.ToolStripStatusLabel LblLocation;
        private System.Windows.Forms.ToolStripStatusLabel LblStatus;
        private System.Windows.Forms.ToolStripStatusLabel Slbl5;
        private System.Windows.Forms.ToolStripStatusLabel LblSaved;
        private System.Windows.Forms.ToolStripStatusLabel LblWritable;
        private System.Windows.Forms.ToolStripStatusLabel LblFilename;
        private System.Windows.Forms.ToolStripMenuItem MIPlugin;
        private System.Windows.Forms.ToolStripMenuItem MIInsert;
        private System.Windows.Forms.ToolStripMenuItem MINewInsert;
        private System.Windows.Forms.ToolStripMenuItem MIFill;
        private System.Windows.Forms.ToolStripMenuItem MIFillZero;
        private System.Windows.Forms.ToolStripMenuItem MIFillNop;
        private System.Windows.Forms.ToolStripMenuItem MenuItemTool;
        private System.Windows.Forms.ToolStripMenuItem MICalculator;
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
        private System.Windows.Forms.ToolStrip toolStrip;
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
        private System.Windows.Forms.ToolStripMenuItem MIAddrConverter;
        private System.Windows.Forms.SplitContainer scEdit;
        private System.Windows.Forms.ToolStripButton tbInfo;
        private System.Windows.Forms.ToolStripMenuItem MIInfo;
        private System.Windows.Forms.ToolStripMenuItem MIOpenProcess;
    }
}

