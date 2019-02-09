namespace SwiftLaunch.View
{
    partial class InputTabNameForm
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
            this.mTabNameTextBox = new System.Windows.Forms.TextBox();
            this.mOKButton = new System.Windows.Forms.Button();
            this.mCancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mTabNameTextBox
            // 
            this.mTabNameTextBox.Location = new System.Drawing.Point(28, 37);
            this.mTabNameTextBox.Name = "mTabNameTextBox";
            this.mTabNameTextBox.Size = new System.Drawing.Size(187, 21);
            this.mTabNameTextBox.TabIndex = 0;
            // 
            // mOKButton
            // 
            this.mOKButton.Location = new System.Drawing.Point(28, 88);
            this.mOKButton.Name = "mOKButton";
            this.mOKButton.Size = new System.Drawing.Size(75, 23);
            this.mOKButton.TabIndex = 1;
            this.mOKButton.Text = "OK";
            this.mOKButton.UseVisualStyleBackColor = true;
            this.mOKButton.Click += new System.EventHandler(this.mOKButton_Click);
            // 
            // mCancelButton
            // 
            this.mCancelButton.Location = new System.Drawing.Point(140, 88);
            this.mCancelButton.Name = "mCancelButton";
            this.mCancelButton.Size = new System.Drawing.Size(75, 23);
            this.mCancelButton.TabIndex = 2;
            this.mCancelButton.Text = "Cancel";
            this.mCancelButton.UseVisualStyleBackColor = true;
            this.mCancelButton.Click += new System.EventHandler(this.mCancelButton_Click);
            // 
            // InputTabNameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(240, 132);
            this.Controls.Add(this.mCancelButton);
            this.Controls.Add(this.mOKButton);
            this.Controls.Add(this.mTabNameTextBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InputTabNameForm";
            this.Text = "Input Tab Name";
            this.Load += new System.EventHandler(this.InputTabNameForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox mTabNameTextBox;
        private System.Windows.Forms.Button mOKButton;
        private System.Windows.Forms.Button mCancelButton;
    }
}