using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SwiftLaunch.DataModule;
using System.Drawing;
using SwiftLaunch.Properties;

namespace SwiftLaunch.View
{
    class LaunchButton : Button
    {
        #region Attributes

        public ButtonCell mButtonCell;
        private int mTabIndex { get; set; }
        private int mRowIndex { get; set; }
        private int mColumnIndex { get; set;}

        private ToolTip mToolTip = new ToolTip();

        #endregion

        #region delegates & events

        public delegate void ButtonCellChangedEventHandler(object sender, EventArgs e);
        public event ButtonCellChangedEventHandler ButtonCellChanged;

        #endregion

        #region Constructors

        public LaunchButton(int aColumnIndex, int aRowIndex, int aTabIndex, Point aPosition, Size aSize)
            : base()
        {
            this.mButtonCell = new ButtonCell();
            this.mTabIndex = aTabIndex;
            this.mRowIndex = aRowIndex;
            this.mColumnIndex = aColumnIndex;

            this.Location = aPosition;
            this.Size = aSize;
            this.TabIndex = 0;
            this.UseVisualStyleBackColor = true;
            this.Margin = new Padding(0);
            this.FlatAppearance.BorderSize = 0;

            this.TabStop = false;
            this.AllowDrop = true;

            this.DragDrop += new DragEventHandler(this.LaunchButtonDragDrop);
            this.DragEnter += new DragEventHandler(this.LaunchButtonDragEnter);
            this.Click += new EventHandler(this.LaunchButtonClick);
            this.MouseHover += new EventHandler(this.LaunchButtonMouseHover);

        }

        public LaunchButton(int aColumnIndex, int aRowIndex, int aTabIndex, Point aPosition, Size aSize, ref ButtonCell aButtonCell)
            : this(aColumnIndex, aRowIndex, aTabIndex, aPosition, aSize)
        {
            this.ReloadButtonCell(ref aButtonCell);
        }

        #endregion

        #region Methods

        public void ReloadButtonCell(ref ButtonCell aButtonCell)
        {
            this.mButtonCell = aButtonCell;
            this.mButtonCell.mTabIndex = this.mTabIndex;
            this.mButtonCell.mRowIndex = this.mRowIndex;
            this.mButtonCell.mColumnIndex = this.mColumnIndex;
            this.RefreshLaunchButton();
        }

        private void RefreshLaunchButton()
        {
            this.Name = this.mButtonCell.mName;
            this.Image = this.mButtonCell.GetBitmap();

            this.Refresh();
        }

        private void LaunchButtonClick(object sender, EventArgs e)
        {
            try
            {
                this.mButtonCell.LaunchButtonCell();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LaunchButtonMouseHover(object sender, EventArgs e)
        {
            this.mToolTip.ShowAlways = true;
            this.mToolTip.IsBalloon = false;
            this.mToolTip.UseAnimation = false;
            this.mToolTip.UseFading = false;
            this.mToolTip.SetToolTip(this, this.mButtonCell.mName);
        }

        protected virtual void LaunchButtonDragDrop(object sender, DragEventArgs e)
        {
            String[] lFiles = (String[])e.Data.GetData(DataFormats.FileDrop);

            if (lFiles.Count() > 1)
            {
                MessageBox.Show(Resources.String_TooManyFilesOnce, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                this.mButtonCell.SetButtonCellData(lFiles.First());
                this.RefreshLaunchButton();
                if (this.ButtonCellChanged != null)
                {
                    this.ButtonCellChanged(this, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected virtual void LaunchButtonDragEnter(object sender, DragEventArgs e)
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

        #endregion

    }
}
