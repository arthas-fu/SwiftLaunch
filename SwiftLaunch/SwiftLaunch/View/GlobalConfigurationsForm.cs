using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SwiftLaunch.DataModule;

namespace SwiftLaunch.View
{
    public partial class GlobalConfigurationsForm : Form
    {
        private GlobalConfig mGlobalConfig { get; set; }

        public GlobalConfigurationsForm()
        {
            InitializeComponent();
        }

        private void GlobalConfigurationsForm_Load(object sender, EventArgs e)
        {
            this.mGlobalConfig = ((MainForm)this.Owner).mGlobalConfig;
            this.ReloadForm();
        }

        private void ReloadForm()
        {
            this.mButtonSizeNumericUpDown.Value = this.mGlobalConfig.mButtonSize;
            this.mRowCountNumericUpDown.Value = this.mGlobalConfig.mButtonRowCount;
            this.mColumnCountNumericUpDown.Value = this.mGlobalConfig.mButtonColumnCount;

            //for (int i = 0; i < this.mGlobalConfig.mTabCount; i++)
            //{
            //    this.mTabNameListBox.Items.Add(this.mGlobalConfig.mTabNameList[i]);
            //}
        }

        private void mOKButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.ValidateInputData();

                this.mGlobalConfig.mButtonSize = Convert.ToInt32(this.mButtonSizeNumericUpDown.Value);
                this.mGlobalConfig.mButtonRowCount = Convert.ToInt32(this.mRowCountNumericUpDown.Value);
                this.mGlobalConfig.mButtonColumnCount = Convert.ToInt32(this.mColumnCountNumericUpDown.Value);

                //this.mGlobalConfig.mTabCount = this.mTabNameListBox.Items.Count;
                //this.mGlobalConfig.mTabNameList.Clear();

                //foreach (String lTabName in this.mTabNameListBox.Items)
                //{
                //    this.mGlobalConfig.mTabNameList.Add(lTabName);
                //}

                this.DialogResult = DialogResult.OK;
                this.Dispose();
            }
            catch
            {

            }
        }

        private void ValidateInputData()
        {

        }

        private void mCancelButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
