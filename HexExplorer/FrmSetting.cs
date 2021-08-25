using System.Windows.Forms;
using System.ComponentModel;
using Be.Windows.Forms;
using System.Drawing;
using Microsoft.Win32;
using System.Collections.Generic;
using System;

namespace HexExplorer
{
    public partial class FrmSetting : ToolWindowBase
    {

        private static FrmSetting frmSetting=null;
        public static bool UseShell = false;
        private readonly List<WSPlugin.PluginInfo> pluginInfos;
        private readonly WSPlugin plugin = WSPlugin.Instance;
        private static string app= Application.ExecutablePath;
        private string appp = $"\"{app}\" \"%1\"";

        public static FrmSetting Instance
        {
            get
            {
                if (frmSetting == null || frmSetting.IsDisposed)
                {
                    frmSetting = new FrmSetting();
                }
                return frmSetting;
            }
        }

        [DefaultValue(false)]
        public bool IsPluginShow { get; set; }

        private FrmSetting()
        {
            InitializeComponent();

            //创建绑定，少些重复性代码
            DataBindings.Add(BindingEnum.Setting.ProgramFont);
            btnFont.DataBindings.Add(BindingEnum.Setting.ProgramFontName);
            cbEncoding.DataBindings.Add(BindingEnum.Setting.StringViewEncoding);
            ntScaling.DataBindings.Add(BindingEnum.Setting.ScalingPercent);
            cbEnableString.DataBindings.Add(BindingEnum.Setting.EnableStringView);
            cbAdmin.DataBindings.Add(BindingEnum.Setting.AdminStart);

            btnSelBackColor.DataBindings.Add(BindingEnum.Setting.SelBackColor);
            btnSelTextColor.DataBindings.Add(BindingEnum.Setting.SelTextColor);
            cbLineInfo.DataBindings.Add(BindingEnum.Setting.EnableLineInfo);
            cbColInfo.DataBindings.Add(BindingEnum.Setting.EnableColInfo);
            cbGroupLine.DataBindings.Add(BindingEnum.Setting.EnableGroupLine);
            cbStringLine.DataBindings.Add(BindingEnum.Setting.EnableHexStringLine);

            btnIMAGE_DOS_HEADER.DataBindings.Add(BindingEnum.Setting.IMAGE_DOS_HEADER_Color);
            btnIMAGE_NT_HEADERS.DataBindings.Add(BindingEnum.Setting.IMAGE_NT_HEADERS_Color);
            btnIMAGE_FILE_HEADER.DataBindings.Add(BindingEnum.Setting.IMAGE_FILE_HEADER_Color);
            btnIMAGE_OPTIONAL_HEADER.DataBindings.Add(BindingEnum.Setting.IMAGE_OPTIONAL_HEADER_Color);
            btnIMAGE_IMPORT_DESCRIPTOR.DataBindings.Add(BindingEnum.Setting.IMAGE_IMPORT_DESCRIPTOR_Color);
            btnIMAGE_EXPORT_DIRECTORY.DataBindings.Add(BindingEnum.Setting.IMAGE_EXPORT_DIRECTORY_Color);
            btnIMAGE_DATA_DIRECTORY.DataBindings.Add(BindingEnum.Setting.IMAGE_DATA_DIRECTORY_Color);
            btnIMAGE_BASE_RELOCATION.DataBindings.Add(BindingEnum.Setting.IMAGE_BASE_RELOCATION_Color);
            btnIMAGE_SECTION_HEADER.DataBindings.Add(BindingEnum.Setting.IMAGE_SECTION_HEADER_Color);
            btnOther.DataBindings.Add(BindingEnum.Setting.Image_OtherColor);

            cbEnablePE.DataBindings.Add(BindingEnum.Setting.EnablePE);
            cbEnablePlugin.DataBindings.Add(BindingEnum.Setting.EnablePlugin);
            cbEnableBookMark.DataBindings.Add(BindingEnum.Setting.EnableAdvBookMark);

            btnLineInfo.DataBindings.Add(BindingEnum.Setting.LineInfoBtnForeColor);
            btnColInfo.DataBindings.Add(BindingEnum.Setting.ColInfoBtnForeColor);
            btnGroupLine.DataBindings.Add(BindingEnum.Setting.GroupLinePen);
            btnGroupLine.DataBindings.Add(BindingEnum.Setting.GroupLinePenFore);
            btnStringLine.DataBindings.Add(BindingEnum.Setting.HexStringLinePen);
            btnStringLine.DataBindings.Add(BindingEnum.Setting.HexStringLinePenFore);

            cbShellRight.DataBindings.Add(BindingEnum.UseShell);

            if (AdminLib.Instance.IsAdmin)
            {
                cbShellRight.Enabled = true;
            }

            MUserProfile mUser = UserSetting.UserProfile;
            var dplugin = mUser.DisableGuid;
            if (mUser.EnablePlugin)
            {
                pluginInfos = new List<WSPlugin.PluginInfo>();
                foreach (var item in plugin.plugins.Value)
                {
                    clbPlugin.Items.Add(item.PluginName);
                    bool ebable = dplugin == null || !dplugin.Contains(item.Puid);
                    pluginInfos.Add(new WSPlugin.PluginInfo(item, ebable));
                }
            }

        }

        private void FrmSetting_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                if (IsPluginShow)
                {
                    tabSetting.SelectedIndex = 3;
                    IsPluginShow = false;
                }
                else
                {
                    tabSetting.SelectedIndex = 0;
                }
            }
        }

        private void BtnSelectColor_Click(object sender, EventArgs e)
        {
            if (cD.ShowDialog() == DialogResult.OK)
            {
                if (cD.Color == Color.Black)
                {
                    MessageBox.Show("所选颜色不能为黑色！", Program.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                (sender as Button).ForeColor = cD.Color;
            }
        }

        private void BtnPenFEdit_Click(object sender, EventArgs e)
        {
            using (FrmPenFEdit frmPenF = FrmPenFEdit.Instance)
            {
                frmPenF.PenF = (sender as Button).Tag as PenF;
                frmPenF.ShowDialog();
                frmPenF.Dispose();
            }
        }

        private void ClbPlugin_SelectedIndexChanged(object sender, EventArgs e)
        {
            var sel = clbPlugin.SelectedIndex;
            if (sel >= 0)
            {
                pgPlugin.SelectedObject = pluginInfos[sel];
            }
        }

        private void FrmSetting_Load(object sender, EventArgs e)
        {
            RegistryKey key = Registry.ClassesRoot.OpenSubKey(@"*\shell");
            if ((key = key.OpenSubKey("WCHexExplorer")) != null)
            {
                if (!key.GetValue("Icon", null).Equals(app))
                    goto endl;
                if ((key = key.OpenSubKey("command")) != null)
                {
                    if (key.GetValue("").Equals(appp))
                    {
                        UseShell = true;
                    }
                    else
                    {
                        goto endl;
                    }
                }
                else
                {
                    goto endl;
                }
                return;
            }
        endl:
            UseShell = false;
        }

        private void CbShellRight_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShellRight.Checked)
            {
                var app = Application.ExecutablePath;
                using (var key = Registry.ClassesRoot.OpenSubKey(@"*\shell", true))
                {
                    using (var key0 = key.CreateSubKey("WCHexExplorer"))
                    {
                        key0.SetValue("", "用羽云十六进制浏览器打开");
                        key0.SetValue("Icon", app);
                        using (var key1 = key0.CreateSubKey("command"))
                        {
                            key1.SetValue("", appp);
                        }
                    }
                }

            }
            else
            {
                using (var key = Registry.ClassesRoot.OpenSubKey(@"*\shell", true))
                {
                    key.DeleteSubKeyTree("WCHexExplorer");
                }
            }
        }
    }
}