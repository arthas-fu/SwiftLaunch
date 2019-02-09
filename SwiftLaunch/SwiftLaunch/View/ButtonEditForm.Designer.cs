namespace SwiftLaunch.View
{
    partial class ButtonEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ButtonEditForm));
            this.mOKButton = new System.Windows.Forms.Button();
            this.mCancelButton = new System.Windows.Forms.Button();
            this.mNameTextBox = new System.Windows.Forms.TextBox();
            this.mTargetTextBox = new System.Windows.Forms.TextBox();
            this.mTargetLable = new System.Windows.Forms.Label();
            this.mArgumentsTextBox = new System.Windows.Forms.TextBox();
            this.mArgsLabel = new System.Windows.Forms.Label();
            this.mDescriptionLable = new System.Windows.Forms.Label();
            this.mIconButton = new System.Windows.Forms.Button();
            this.mTargetTypeLabel = new System.Windows.Forms.Label();
            this.mTargetTypeComboBox = new System.Windows.Forms.ComboBox();
            this.mSelectTargetButton = new System.Windows.Forms.Button();
            this.mDescriptionRichTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // mOKButton
            // 
            this.mOKButton.Location = new System.Drawing.Point(224, 381);
            this.mOKButton.Name = "mOKButton";
            this.mOKButton.Size = new System.Drawing.Size(75, 23);
            this.mOKButton.TabIndex = 6;
            this.mOKButton.Text = "OK";
            this.mOKButton.UseVisualStyleBackColor = true;
            this.mOKButton.Click += new System.EventHandler(this.mOKButton_Click);
            // 
            // mCancelButton
            // 
            this.mCancelButton.Location = new System.Drawing.Point(305, 381);
            this.mCancelButton.Name = "mCancelButton";
            this.mCancelButton.Size = new System.Drawing.Size(75, 23);
            this.mCancelButton.TabIndex = 7;
            this.mCancelButton.Text = "Cancel";
            this.mCancelButton.UseVisualStyleBackColor = true;
            this.mCancelButton.Click += new System.EventHandler(this.mCancelButton_Click);
            // 
            // mNameTextBox
            // 
            this.mNameTextBox.Location = new System.Drawing.Point(120, 33);
            this.mNameTextBox.Name = "mNameTextBox";
            this.mNameTextBox.Size = new System.Drawing.Size(260, 21);
            this.mNameTextBox.TabIndex = 1;
            // 
            // mTargetTextBox
            // 
            this.mTargetTextBox.Location = new System.Drawing.Point(120, 156);
            this.mTargetTextBox.Name = "mTargetTextBox";
            this.mTargetTextBox.Size = new System.Drawing.Size(212, 21);
            this.mTargetTextBox.TabIndex = 3;
            // 
            // mTargetLable
            // 
            this.mTargetLable.AutoSize = true;
            this.mTargetLable.Location = new System.Drawing.Point(33, 159);
            this.mTargetLable.Name = "mTargetLable";
            this.mTargetLable.Size = new System.Drawing.Size(41, 12);
            this.mTargetLable.TabIndex = 0;
            this.mTargetLable.Text = "Target";
            // 
            // mArgumentsTextBox
            // 
            this.mArgumentsTextBox.Location = new System.Drawing.Point(120, 208);
            this.mArgumentsTextBox.Name = "mArgumentsTextBox";
            this.mArgumentsTextBox.Size = new System.Drawing.Size(260, 21);
            this.mArgumentsTextBox.TabIndex = 5;
            // 
            // mArgsLabel
            // 
            this.mArgsLabel.AutoSize = true;
            this.mArgsLabel.Location = new System.Drawing.Point(33, 211);
            this.mArgsLabel.Name = "mArgsLabel";
            this.mArgsLabel.Size = new System.Drawing.Size(59, 12);
            this.mArgsLabel.TabIndex = 0;
            this.mArgsLabel.Text = "Arguments";
            // 
            // mDescriptionLable
            // 
            this.mDescriptionLable.AutoSize = true;
            this.mDescriptionLable.Location = new System.Drawing.Point(33, 263);
            this.mDescriptionLable.Name = "mDescriptionLable";
            this.mDescriptionLable.Size = new System.Drawing.Size(71, 12);
            this.mDescriptionLable.TabIndex = 0;
            this.mDescriptionLable.Text = "Description";
            // 
            // mIconButton
            // 
            this.mIconButton.Location = new System.Drawing.Point(35, 12);
            this.mIconButton.Name = "mIconButton";
            this.mIconButton.Size = new System.Drawing.Size(60, 60);
            this.mIconButton.TabIndex = 0;
            this.mIconButton.UseVisualStyleBackColor = true;
            this.mIconButton.Click += new System.EventHandler(this.mIconButton_Click);
            // 
            // mTargetTypeLabel
            // 
            this.mTargetTypeLabel.AutoSize = true;
            this.mTargetTypeLabel.Location = new System.Drawing.Point(33, 108);
            this.mTargetTypeLabel.Name = "mTargetTypeLabel";
            this.mTargetTypeLabel.Size = new System.Drawing.Size(71, 12);
            this.mTargetTypeLabel.TabIndex = 0;
            this.mTargetTypeLabel.Text = "Target Type";
            // 
            // mTargetTypeComboBox
            // 
            this.mTargetTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mTargetTypeComboBox.FormattingEnabled = true;
            this.mTargetTypeComboBox.Items.AddRange(new object[] {
            "File",
            "Folder"});
            this.mTargetTypeComboBox.Location = new System.Drawing.Point(120, 105);
            this.mTargetTypeComboBox.Name = "mTargetTypeComboBox";
            this.mTargetTypeComboBox.Size = new System.Drawing.Size(121, 20);
            this.mTargetTypeComboBox.TabIndex = 2;
            // 
            // mSelectTargetButton
            // 
            this.mSelectTargetButton.Location = new System.Drawing.Point(338, 154);
            this.mSelectTargetButton.Name = "mSelectTargetButton";
            this.mSelectTargetButton.Size = new System.Drawing.Size(42, 23);
            this.mSelectTargetButton.TabIndex = 4;
            this.mSelectTargetButton.Text = "...";
            this.mSelectTargetButton.UseVisualStyleBackColor = true;
            this.mSelectTargetButton.Click += new System.EventHandler(this.mSelectTargetButton_Click);
            // 
            // mDescriptionRichTextBox
            // 
            this.mDescriptionRichTextBox.DetectUrls = false;
            this.mDescriptionRichTextBox.Location = new System.Drawing.Point(120, 260);
            this.mDescriptionRichTextBox.Name = "mDescriptionRichTextBox";
            this.mDescriptionRichTextBox.ShortcutsEnabled = false;
            this.mDescriptionRichTextBox.Size = new System.Drawing.Size(260, 96);
            this.mDescriptionRichTextBox.TabIndex = 6;
            this.mDescriptionRichTextBox.Text = "";
            // 
            // ButtonEditForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(412, 426);
            this.Controls.Add(this.mDescriptionRichTextBox);
            this.Controls.Add(this.mSelectTargetButton);
            this.Controls.Add(this.mTargetTypeComboBox);
            this.Controls.Add(this.mTargetTypeLabel);
            this.Controls.Add(this.mIconButton);
            this.Controls.Add(this.mDescriptionLable);
            this.Controls.Add(this.mArgumentsTextBox);
            this.Controls.Add(this.mArgsLabel);
            this.Controls.Add(this.mTargetTextBox);
            this.Controls.Add(this.mTargetLable);
            this.Controls.Add(this.mNameTextBox);
            this.Controls.Add(this.mCancelButton);
            this.Controls.Add(this.mOKButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ButtonEditForm";
            this.ShowInTaskbar = false;
            this.Text = "Edit Button";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ButtonEditForm_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.ButtonEditForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.ButtonEditForm_DragEnter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button mOKButton;
        private System.Windows.Forms.Button mCancelButton;
        private System.Windows.Forms.TextBox mNameTextBox;
        private System.Windows.Forms.TextBox mTargetTextBox;
        private System.Windows.Forms.Label mTargetLable;
        private System.Windows.Forms.TextBox mArgumentsTextBox;
        private System.Windows.Forms.Label mArgsLabel;
        private System.Windows.Forms.Label mDescriptionLable;
        private System.Windows.Forms.Button mIconButton;
        private System.Windows.Forms.Label mTargetTypeLabel;
        private System.Windows.Forms.ComboBox mTargetTypeComboBox;
        private System.Windows.Forms.Button mSelectTargetButton;
        private System.Windows.Forms.RichTextBox mDescriptionRichTextBox;
    }
}