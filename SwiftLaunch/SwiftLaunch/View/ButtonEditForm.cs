using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SwiftLaunch.DataModule;
using SwiftLaunch.Properties;

namespace SwiftLaunch.View
{
    public partial class ButtonEditForm : Form
    {
        #region Attributes

        private ButtonCell mButtonCell = null;

        private String mIconPath { get; set; }

        #endregion


        #region Constructors

        public ButtonEditForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        private void ButtonEditForm_Load(object sender, EventArgs e)
        {
            this.mButtonCell = ((MainForm)this.Owner).mEditingButtonCell;
            this.ReloadForm();
        }

        private void ReloadForm()
        {
            this.mIconButton.Image = this.mButtonCell.GetBitmap();
            this.mNameTextBox.Text = this.mButtonCell.mName;
            this.mTargetTextBox.Text = this.mButtonCell.mLaunchLink;
            this.mArgumentsTextBox.Text = this.mButtonCell.mLaunchArgs;
            this.mDescriptionRichTextBox.Text = this.mButtonCell.mDescription;
            this.mIconPath = this.mButtonCell.mIconPath;

            switch (this.mButtonCell.mLaunchType)
            {
                case ConstsAndEnums.LaunchType.Folder:
                    this.mTargetTypeComboBox.SelectedIndex = 1;
                    break;
                case ConstsAndEnums.LaunchType.Lnk:
                case ConstsAndEnums.LaunchType.Url:
                case ConstsAndEnums.LaunchType.File:
                    this.mTargetTypeComboBox.SelectedIndex = 0;
                    break;
                default:
                    break;
            }
        }

        private void ReloadForm(ButtonCell aButtonCell)
        {
            this.mIconButton.Image = aButtonCell.GetBitmap();
            this.mNameTextBox.Text = aButtonCell.mName;
            this.mTargetTextBox.Text = aButtonCell.mLaunchLink;
            this.mArgumentsTextBox.Text = aButtonCell.mLaunchArgs;
            this.mDescriptionRichTextBox.Text = aButtonCell.mDescription;
            this.mIconPath = aButtonCell.mIconPath;

            switch (aButtonCell.mLaunchType)
            {
                case ConstsAndEnums.LaunchType.Folder:
                    this.mTargetTypeComboBox.SelectedIndex = 1;
                    break;
                case ConstsAndEnums.LaunchType.Lnk:
                case ConstsAndEnums.LaunchType.Url:
                case ConstsAndEnums.LaunchType.File:
                    this.mTargetTypeComboBox.SelectedIndex = 0;
                    break;
                default:
                    break;
            }
        }

        private void mOKButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.ValidateInputData();

                this.mButtonCell.mName = this.mNameTextBox.Text;
                this.mButtonCell.mLaunchLink = this.mTargetTextBox.Text;
                this.mButtonCell.mLaunchArgs = this.mArgumentsTextBox.Text;
                this.mButtonCell.mDescription = this.mDescriptionRichTextBox.Text;
                this.mButtonCell.mIconPath = this.mIconPath;

                switch (this.mTargetTypeComboBox.SelectedIndex)
                {
                    case 1:
                        this.mButtonCell.mLaunchType = ConstsAndEnums.LaunchType.Folder;
                        break;
                    case -1:
                        this.mButtonCell.mLaunchType = ConstsAndEnums.LaunchType.Invalid;
                        break;
                    default:
                        this.mButtonCell.mLaunchType = ConstsAndEnums.LaunchType.File;
                        break;
                }

                this.DialogResult = DialogResult.OK;
                this.Dispose();
            }
            catch
            {

            }
        }

        private void mCancelButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void ValidateInputData()
        {

        }

        #endregion

        private void ButtonEditForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void ButtonEditForm_DragDrop(object sender, DragEventArgs e)
        {
            String[] lFiles = (String[])e.Data.GetData(DataFormats.FileDrop);

            if (lFiles.Count() > 1)
            {
                MessageBox.Show(Resources.String_TooManyFilesOnce, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ButtonCell lButtonCell = new ButtonCell();
            try
            {
                lButtonCell.SetButtonCellData(lFiles.First());
                this.ReloadForm(lButtonCell);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mSelectTargetButton_Click(object sender, EventArgs e)
        {
            switch (this.mTargetTypeComboBox.SelectedIndex)
            {
                case 0:
                    {
                        OpenFileDialog lOpenFileDialog = new OpenFileDialog();

                        lOpenFileDialog.Multiselect = false;
                        lOpenFileDialog.ShowDialog();
                        if (!string.IsNullOrEmpty(lOpenFileDialog.FileName))
                        {
                            try
                            {
                                this.mButtonCell.SetButtonCellData(lOpenFileDialog.FileName);
                                this.ReloadForm(this.mButtonCell);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    break;
                case 1:
                    {
                        FolderBrowserDialog lFolderBrowserDialog = new FolderBrowserDialog();

                        lFolderBrowserDialog.ShowDialog();
                        if (!string.IsNullOrEmpty(lFolderBrowserDialog.SelectedPath))
                        {
                            try
                            {
                                this.mButtonCell.SetButtonCellData(lFolderBrowserDialog.SelectedPath);
                                this.ReloadForm(this.mButtonCell);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    break;
                default:
                    MessageBox.Show(Resources.String_SelectTargetTypeFirst, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
            }




        }

        private void mIconButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog lOpenFileDialog = new OpenFileDialog();

            lOpenFileDialog.Multiselect = false;
            lOpenFileDialog.Filter = "Icon File(*.ico;*.icl;*.exe;*.dll)|*.ico;*.icl;*.exe;*.dll";
            lOpenFileDialog.ShowDialog();
            if (!string.IsNullOrEmpty(lOpenFileDialog.FileName))
            {
                this.mIconPath = lOpenFileDialog.FileName;
                this.mIconButton.Image = SystemIcon.GetFileIcon(lOpenFileDialog.FileName, false).ToBitmap();
            }
        }
    }
}
