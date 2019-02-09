using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using SwiftLaunch.DataModule;
using SwiftLaunch.Properties;

namespace SwiftLaunch.View
{
    public partial class MainForm : Form
    {
        #region Attributes

        public GlobalConfig mGlobalConfig { get; set; }
        public ButtonCell mEditingButtonCell = null;

        private List<LaunchButton> mButtonList = new List<LaunchButton>();
        private List<TabPage> mTabPageList = new List<TabPage>();
        private LaunchButton mLaunchButtonSwitchedFrom { get; set; }
        private int mSelectedTabIndex { get; set; }
        private int mTabSwitdhedFrom { get; set; }
        private int mTargetTabIndex { get; set; }


        #endregion

        #region Constructors

        public MainForm()
        {
            this.mGlobalConfig = new GlobalConfig();
            this.mTabSwitdhedFrom = -1;
            this.mTargetTabIndex = -1;
            InitializeComponent();
        }

        #endregion

        #region Methods

        [DllImport("user32.dll")]
        static extern bool RegisterHotKey(IntPtr hWnd, int id, int modifiers, Keys vk);

        private void MainForm_Load(object sender, EventArgs e)
        {
            RegisterHotKey(this.Handle, ConstsAndEnums.HOT_KEY_ID, (int)ConstsAndEnums.HotKeyModifiers.Control, Keys.F12);
            this.ReloadForm();
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case ConstsAndEnums.WM_SYSCOMMAND:
                    if (m.WParam.ToInt32() == ConstsAndEnums.SC_MINIMIZE || m.WParam.ToInt32() == ConstsAndEnums.SC_CLOSE)
                    {
                        this.Hide();
                        return;
                    }
                    break;
                case ConstsAndEnums.WM_HOTKEY:
                    this.Visible = !this.Visible;
                    this.Refresh();
                    break;
                default:
                    break;
            }

            base.WndProc(ref m);
        }

        private void ReloadForm()
        {
            int lTotalButtonWidth = this.mGlobalConfig.mButtonColumnCount * this.mGlobalConfig.mButtonSize;
            int lTotalButtonHight = this.mGlobalConfig.mButtonRowCount * this.mGlobalConfig.mButtonSize;
            int lTabControlWidth = lTotalButtonWidth + 8;
            int lTabControlHight = lTotalButtonHight + 22 + 8;
            Size lButtonSize = new Size(this.mGlobalConfig.mButtonSize, this.mGlobalConfig.mButtonSize);
            ButtonCell lButtonCell = null;

            this.ClientSize = new Size(lTabControlWidth, lTabControlHight);
            this.AllowDrop = true;

            this.mTabPageList.Clear();
            this.mButtonList.Clear();
            this.mTabControl.Controls.Clear();
            this.mLaunchButtonSwitchedFrom = null;
            this.MoveButtonToolStripMenuItem.Text = Resources.String_MoveButton;
            this.MoveTabToolStripMenuItem.Text = Resources.String_MoveTab;
            this.mTabControl.Size = new Size(lTabControlWidth, lTabControlHight);
            this.mTabControl.TabStop = false;

            for (int i = 0; i < this.mGlobalConfig.mTabNameList.Count; i++)
            {
                this.mTabPageList.Add (new TabPage());
                this.mTabPageList[i].Location = new Point(0, 0);
                this.mTabPageList[i].Name = this.mGlobalConfig.mTabNameList[i];
                this.mTabPageList[i].Size = new Size(lTotalButtonWidth, lTotalButtonHight);
                this.mTabPageList[i].TabIndex = 0;
                this.mTabPageList[i].Text = this.mGlobalConfig.mTabNameList[i];
                this.mTabPageList[i].UseVisualStyleBackColor = true;
                this.mTabPageList[i].Margin = new Padding(0);
                this.mTabPageList[i].Padding = new Padding(0);
                this.mTabPageList[i].TabStop = false;
                this.mTabPageList[i].AllowDrop = true;
                //this.mTabPageList[i].ContextMenuStrip = this.mTabContextMenuStrip;

                this.mTabControl.Controls.Add(this.mTabPageList[i]);

                for (int j = 0; j < this.mGlobalConfig.mButtonRowCount; j++)
                {
                    for (int k = 0; k < this.mGlobalConfig.mButtonColumnCount; k++)
                    {
                        Point lStartPoint = new Point(0, 0);
                        lButtonCell = this.mGlobalConfig.mButtonCellList.Find(
                            delegate(ButtonCell aButtonCell)
                            {
                                return aButtonCell.mTabIndex == i && aButtonCell.mRowIndex == j && aButtonCell.mColumnIndex == k;
                            });

                        if (lButtonCell == null)
                        {
                            lButtonCell = new ButtonCell(i, j, k);
                            this.mGlobalConfig.mButtonCellList.Add(lButtonCell);
                        }

                        lStartPoint.Offset(k * this.mGlobalConfig.mButtonSize, j * this.mGlobalConfig.mButtonSize);
                        this.mButtonList.Add (new LaunchButton(k, j, i, lStartPoint, lButtonSize, ref lButtonCell));
                        this.mButtonList.Last().ContextMenuStrip = this.mButtonContextMenuStrip;
                        this.mButtonList.Last().ButtonCellChanged += new LaunchButton.ButtonCellChangedEventHandler(this.ButtonCellChanged);

                        this.mTabPageList[i].Controls.Add(this.mButtonList.Last());
                    }
                }
            }
        }

        #endregion

        private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.Visible == false)
            {
                this.WindowState = FormWindowState.Normal;
                this.Show();
                this.Activate();
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
            	this.mGlobalConfig.SaveAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Dispose();
            Application.Exit();
        }

        private void MoveButtonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LaunchButton lLaunchButton = (LaunchButton)this.mButtonContextMenuStrip.SourceControl;

            if (this.mLaunchButtonSwitchedFrom == null)
            {
                lLaunchButton.FlatStyle = FlatStyle.Popup;

                this.mLaunchButtonSwitchedFrom = lLaunchButton;
                this.MoveButtonToolStripMenuItem.Text = Resources.String_MoveButtonHere;
            }
            else
            {
                try
                {
	                ButtonCell lButtonCell = this.mLaunchButtonSwitchedFrom.mButtonCell;
	
	                this.mLaunchButtonSwitchedFrom.ReloadButtonCell(ref lLaunchButton.mButtonCell);
	                lLaunchButton.ReloadButtonCell(ref lButtonCell);
	
	                this.mLaunchButtonSwitchedFrom.FlatStyle = FlatStyle.Standard;
	                this.mLaunchButtonSwitchedFrom = null;
	
	                this.MoveButtonToolStripMenuItem.Text = Resources.String_MoveButton;
	                this.mGlobalConfig.SaveAll();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void EditButtonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ButtonEditForm lButtonEditForm = new ButtonEditForm();
            LaunchButton lLaunchButton = (LaunchButton)this.mButtonContextMenuStrip.SourceControl;

            this.mEditingButtonCell = lLaunchButton.mButtonCell;

            if (lButtonEditForm.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
	                lLaunchButton.ReloadButtonCell(ref this.mEditingButtonCell);
	                this.mGlobalConfig.SaveAll();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            this.mEditingButtonCell = null;
        }

        private void GlobalConfigurationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlobalConfigurationsForm lGlobalConfigurationsForm = new GlobalConfigurationsForm();

            if (lGlobalConfigurationsForm.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
	                this.ReloadForm();
	                this.mGlobalConfig.SaveAll();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClearButtonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Resources.String_ConfirmToClearButton, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LaunchButton lLaunchButton = (LaunchButton)this.mButtonContextMenuStrip.SourceControl;

                try
                {
                    lLaunchButton.mButtonCell.InitButtonCellData();
                    lLaunchButton.ReloadButtonCell(ref lLaunchButton.mButtonCell);
                    this.mGlobalConfig.SaveAll();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void RenameTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputTabNameForm lInputTabNameForm = new InputTabNameForm();

            lInputTabNameForm.mTabName = this.mTabPageList[this.mSelectedTabIndex].Text;
            if (lInputTabNameForm.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    this.mTabPageList[this.mSelectedTabIndex].Text = lInputTabNameForm.mTabName;
                    this.mGlobalConfig.mTabNameList[this.mSelectedTabIndex] = lInputTabNameForm.mTabName;
                    this.mGlobalConfig.SaveAll();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void mTabControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point pt = new Point(e.X, e.Y);
                for (int i = 0; i < this.mTabControl.TabCount; i++)
                {
                    Rectangle rect = this.mTabControl.GetTabRect(i);
                    if (rect.Contains(pt))
                    {
                        this.mSelectedTabIndex = i;
                    }
                }
            }
        }

        private void NewTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputTabNameForm lInputTabNameForm = new InputTabNameForm();

            if (lInputTabNameForm.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
	                this.AddNewTab(lInputTabNameForm.mTabName);
	                this.ReloadForm();
	                this.mGlobalConfig.SaveAll();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AddNewTab(String aTabName)
        {
            if (String.IsNullOrEmpty(aTabName))
            {
                MessageBox.Show(Resources.String_TabNameCanNotBeEmpty, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            this.mGlobalConfig.AddNewTab(aTabName);
        }

        private void DeleteTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.mGlobalConfig.mTabNameList.Count == 1)
            {
                MessageBox.Show(Resources.String_CanNotRemoveLastTabPage, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show(Resources.String_ConfirmToRemoveTabPage, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                try
                {
	                this.DeleteTab(this.mSelectedTabIndex);
	                this.ReloadForm();
	                this.mGlobalConfig.SaveAll();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DeleteTab(int aTabIndex)
        {
            this.mGlobalConfig.RemoveTab(aTabIndex);
        }

        private void MoveTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.mTabSwitdhedFrom < 0)
            {
                this.mTabSwitdhedFrom = this.mSelectedTabIndex;
                this.mTabPageList[this.mTabSwitdhedFrom].Text += "*";
                this.MoveTabToolStripMenuItem.Text = Resources.String_MoveTabHere;
            }
            else
            {
                try
                {
	                this.mTargetTabIndex = this.mSelectedTabIndex;
	                this.mTabPageList[this.mTabSwitdhedFrom].Text.TrimEnd('*');
	                this.MoveTabToolStripMenuItem.Text = Resources.String_MoveTab;
	
	                this.SwitchTab();
	
	                this.mTabSwitdhedFrom = -1;
	                this.mTargetTabIndex = -1;
	                this.mGlobalConfig.SaveAll();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SwitchTab()
        {
            if (this.mTabSwitdhedFrom == this.mTargetTabIndex)
            {
                return;
            }

            this.mGlobalConfig.SwitchTabPage(this.mTabSwitdhedFrom, this.mTargetTabIndex);
            this.ReloadForm();
        }

        protected void ButtonCellChanged(object sender, EventArgs e)
        {
            try
            {
                this.mGlobalConfig.SaveAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
