using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SwiftLaunch.Properties;

namespace SwiftLaunch.View
{
    public partial class InputTabNameForm : Form
    {
        public String mTabName { get; set; }
        public InputTabNameForm()
        {
            InitializeComponent();
        }

        private void mOKButton_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(this.mTabNameTextBox.Text))
            {
                MessageBox.Show(Resources.String_TabNameCanNotBeEmpty, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.mTabName = this.mTabNameTextBox.Text;
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }

        private void mCancelButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void InputTabNameForm_Load(object sender, EventArgs e)
        {
            this.mTabNameTextBox.Text = this.mTabName;
        }
    }
}
