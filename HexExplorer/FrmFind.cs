﻿using Be.Windows.Forms;
using System;
using System.Windows.Forms;

namespace HexExplorer
{
    public partial class FrmFind : ToolWindowBase
    {
        private FrmFind()
        {
            InitializeComponent();
            hexFind.CreateBuffer();
            UpDateUI = new Action(() =>
              {
                  if (lblFinding.Text.Length == 13)
                      lblFinding.Text = "";

                  lblFinding.Text += ".";

                  //===========================

                  long pos = HexBox.CurrentFindingPosition;
                  long length = HexBox.ByteProvider.Length;
                  double percent = pos / (double)length * 100;

                  string text = percent.ToString("0.00") + " %";
                  lblPercent.Text = text;
              });
        }

        private FindOptions _findOptions = new FindOptions();
        private bool _finding;
        private static FrmFind frmFind = null;
        private readonly Action UpDateUI;

        public HexBox HexBox
        {
            get;set;
        }

        public static FrmFind Instance
        {
            get
            {
                if (frmFind == null || frmFind.IsDisposed)
                {
                    frmFind = new FrmFind();
                }
                return frmFind;
            }
        }

        public FindOptions FindOptions
        {
            get
            {
                return _findOptions;
            }
            set
            {
                _findOptions = value;
                Reinitialize();
            }
        }

        private void Reinitialize()
        {
            if (_findOptions==null)
            {
                _findOptions = new FindOptions();
            }
            rbString.Checked = _findOptions.Type == FindType.Text;
            txtFind.Text = _findOptions.Text;
            chkMatchCase.Checked = _findOptions.MatchCase;

            rbHex.Checked = _findOptions.Type == FindType.Hex;

            if (hexFind.ByteProvider != null)
                hexFind.ByteProvider.Changed -= new EventHandler(ByteProvider_Changed);

            var hex = _findOptions.Hex ?? (new byte[0]);
            hexFind.ByteProvider = new DynamicByteProvider(hex);
            hexFind.ByteProvider.Changed += new EventHandler(ByteProvider_Changed);
            hexFind.Enabled = false;
        }

        private void ByteProvider_Changed(object sender, EventArgs e)
        {
            ValidateFind();
        }

        private void ValidateFind()
        {
            var isValid = false;
            if (rbString.Checked && txtFind.Text.Length > 0)
                isValid = true;
            if (rbHex.Checked && hexFind.ByteProvider.Length > 0)
                isValid = true;
            btnOK.Enabled = isValid;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (_finding)
                HexBox.AbortFind();
            else
                Close();
        }

        public void FindNext()
        {
            if (!_findOptions.IsValid)
                return;

            UpdateUIToFindingState();

            // start find process
            long res = HexBox.Find(_findOptions);

            UpdateUIToNormalState();

            Application.DoEvents();

            if (res == -1) // -1 = no match
            {
                MessageBox.Show("查找已越过文件末尾。", Program.AppName,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (res == -2) // -2 = find was aborted
            {
                return;
            }
            else // something was found
            {

                Application.DoEvents();

                if (!HexBox.Focused)
                    HexBox.Focus();
            }
        }

        private void UpdateUIToNormalState()
        {
            UpDateUI.Invoke();
            _finding = false;
            txtFind.Enabled = chkMatchCase.Enabled = rbHex.Enabled = rbString.Enabled
                = hexFind.Enabled = btnOK.Enabled = true;
        }

        private void UpdateUIToFindingState()
        {
            _finding = true;
            UpDateUI.Invoke();
            txtFind.Enabled = chkMatchCase.Enabled = rbHex.Enabled = rbString.Enabled
                = hexFind.Enabled = btnOK.Enabled = false;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (rbString.Checked)
            {
                _findOptions.Type = FindType.Text;
                _findOptions.Text = txtFind.Text;
                _findOptions.MatchCase = chkMatchCase.Checked;
            }
            else
            {
                _findOptions.Type = FindType.Hex;
                var provider = hexFind.ByteProvider as DynamicByteProvider;
                _findOptions.Hex = provider.Bytes.ToArray();

            }
            _findOptions.IsValid = true;
            FindNext();
        }

        private void FrmFind_Activated(object sender, EventArgs e)
        {
            if (rbString.Checked)
                txtFind.Focus();
            else
                hexFind.Focus();
        }

        private void TimerPercent_Tick(object sender, EventArgs e)
        {
         
        }

        private void TxtString_TextChanged(object sender, EventArgs e)
        {
            ValidateFind();
        }

        private void Rb_CheckedChanged(object sender, System.EventArgs e)
        {
            txtFind.Enabled = rbString.Checked;
            hexFind.Enabled = !txtFind.Enabled;

            if (txtFind.Enabled)
                txtFind.Focus();
            else
                hexFind.Focus();
        }

        private void FrmFind_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dispose();
        }

        private void HexFind_EnabledChanged(object sender, EventArgs e)
        {

        }
    }
}