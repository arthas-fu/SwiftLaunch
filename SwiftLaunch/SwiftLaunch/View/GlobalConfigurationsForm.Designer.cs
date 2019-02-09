namespace SwiftLaunch.View
{
    partial class GlobalConfigurationsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GlobalConfigurationsForm));
            this.mButtonSizeLable = new System.Windows.Forms.Label();
            this.mButtonSizeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.mRowCountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.mRowCountLable = new System.Windows.Forms.Label();
            this.mColumnCountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.mColumnCountLable = new System.Windows.Forms.Label();
            this.mOKButton = new System.Windows.Forms.Button();
            this.mCancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mButtonSizeNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mRowCountNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mColumnCountNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // mButtonSizeLable
            // 
            this.mButtonSizeLable.AutoSize = true;
            this.mButtonSizeLable.Location = new System.Drawing.Point(27, 22);
            this.mButtonSizeLable.Name = "mButtonSizeLable";
            this.mButtonSizeLable.Size = new System.Drawing.Size(71, 12);
            this.mButtonSizeLable.TabIndex = 0;
            this.mButtonSizeLable.Text = "Button Size";
            // 
            // mButtonSizeNumericUpDown
            // 
            this.mButtonSizeNumericUpDown.Location = new System.Drawing.Point(104, 20);
            this.mButtonSizeNumericUpDown.Maximum = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.mButtonSizeNumericUpDown.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.mButtonSizeNumericUpDown.Name = "mButtonSizeNumericUpDown";
            this.mButtonSizeNumericUpDown.Size = new System.Drawing.Size(38, 21);
            this.mButtonSizeNumericUpDown.TabIndex = 1;
            this.mButtonSizeNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mButtonSizeNumericUpDown.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // mRowCountNumericUpDown
            // 
            this.mRowCountNumericUpDown.Location = new System.Drawing.Point(104, 62);
            this.mRowCountNumericUpDown.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.mRowCountNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mRowCountNumericUpDown.Name = "mRowCountNumericUpDown";
            this.mRowCountNumericUpDown.Size = new System.Drawing.Size(38, 21);
            this.mRowCountNumericUpDown.TabIndex = 2;
            this.mRowCountNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mRowCountNumericUpDown.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // mRowCountLable
            // 
            this.mRowCountLable.AutoSize = true;
            this.mRowCountLable.Location = new System.Drawing.Point(27, 64);
            this.mRowCountLable.Name = "mRowCountLable";
            this.mRowCountLable.Size = new System.Drawing.Size(59, 12);
            this.mRowCountLable.TabIndex = 0;
            this.mRowCountLable.Text = "Row Count";
            // 
            // mColumnCountNumericUpDown
            // 
            this.mColumnCountNumericUpDown.Location = new System.Drawing.Point(104, 105);
            this.mColumnCountNumericUpDown.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.mColumnCountNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mColumnCountNumericUpDown.Name = "mColumnCountNumericUpDown";
            this.mColumnCountNumericUpDown.Size = new System.Drawing.Size(38, 21);
            this.mColumnCountNumericUpDown.TabIndex = 3;
            this.mColumnCountNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mColumnCountNumericUpDown.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // mColumnCountLable
            // 
            this.mColumnCountLable.AutoSize = true;
            this.mColumnCountLable.Location = new System.Drawing.Point(27, 107);
            this.mColumnCountLable.Name = "mColumnCountLable";
            this.mColumnCountLable.Size = new System.Drawing.Size(77, 12);
            this.mColumnCountLable.TabIndex = 0;
            this.mColumnCountLable.Text = "Column Count";
            // 
            // mOKButton
            // 
            this.mOKButton.Location = new System.Drawing.Point(231, 391);
            this.mOKButton.Name = "mOKButton";
            this.mOKButton.Size = new System.Drawing.Size(75, 23);
            this.mOKButton.TabIndex = 4;
            this.mOKButton.Text = "OK";
            this.mOKButton.UseVisualStyleBackColor = true;
            this.mOKButton.Click += new System.EventHandler(this.mOKButton_Click);
            // 
            // mCancelButton
            // 
            this.mCancelButton.Location = new System.Drawing.Point(312, 391);
            this.mCancelButton.Name = "mCancelButton";
            this.mCancelButton.Size = new System.Drawing.Size(75, 23);
            this.mCancelButton.TabIndex = 5;
            this.mCancelButton.Text = "Cancel";
            this.mCancelButton.UseVisualStyleBackColor = true;
            this.mCancelButton.Click += new System.EventHandler(this.mCancelButton_Click);
            // 
            // GlobalConfigurationsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(413, 434);
            this.Controls.Add(this.mCancelButton);
            this.Controls.Add(this.mOKButton);
            this.Controls.Add(this.mColumnCountNumericUpDown);
            this.Controls.Add(this.mColumnCountLable);
            this.Controls.Add(this.mRowCountNumericUpDown);
            this.Controls.Add(this.mRowCountLable);
            this.Controls.Add(this.mButtonSizeNumericUpDown);
            this.Controls.Add(this.mButtonSizeLable);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GlobalConfigurationsForm";
            this.ShowInTaskbar = false;
            this.Text = "GlobalConfigurationsForm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.GlobalConfigurationsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mButtonSizeNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mRowCountNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mColumnCountNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label mButtonSizeLable;
        private System.Windows.Forms.NumericUpDown mButtonSizeNumericUpDown;
        private System.Windows.Forms.NumericUpDown mRowCountNumericUpDown;
        private System.Windows.Forms.Label mRowCountLable;
        private System.Windows.Forms.NumericUpDown mColumnCountNumericUpDown;
        private System.Windows.Forms.Label mColumnCountLable;
        private System.Windows.Forms.Button mOKButton;
        private System.Windows.Forms.Button mCancelButton;
    }
}