namespace SwiftLaunch.View
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mTabControl = new System.Windows.Forms.TabControl();
            this.mTabContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RenameTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MoveTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GlobalConfigurationsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.mNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.mIconContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mButtonContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MoveButtonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditButtonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClearButtonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GlobalConfigurationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mTabControl.SuspendLayout();
            this.mTabContextMenuStrip.SuspendLayout();
            this.mIconContextMenuStrip.SuspendLayout();
            this.mButtonContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mTabControl
            // 
            this.mTabControl.ContextMenuStrip = this.mTabContextMenuStrip;
            this.mTabControl.Controls.Add(this.tabPage1);
            this.mTabControl.Location = new System.Drawing.Point(0, 0);
            this.mTabControl.Margin = new System.Windows.Forms.Padding(0);
            this.mTabControl.Name = "mTabControl";
            this.mTabControl.SelectedIndex = 0;
            this.mTabControl.Size = new System.Drawing.Size(288, 267);
            this.mTabControl.TabIndex = 0;
            this.mTabControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mTabControl_MouseDown);
            // 
            // mTabContextMenuStrip
            // 
            this.mTabContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RenameTabToolStripMenuItem,
            this.MoveTabToolStripMenuItem,
            this.NewTabToolStripMenuItem,
            this.DeleteTabToolStripMenuItem,
            this.GlobalConfigurationsToolStripMenuItem1});
            this.mTabContextMenuStrip.Name = "mTabContextMenuStrip";
            this.mTabContextMenuStrip.Size = new System.Drawing.Size(204, 114);
            // 
            // RenameTabToolStripMenuItem
            // 
            this.RenameTabToolStripMenuItem.Name = "RenameTabToolStripMenuItem";
            this.RenameTabToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.RenameTabToolStripMenuItem.Text = "Rename Tab";
            this.RenameTabToolStripMenuItem.Click += new System.EventHandler(this.RenameTabToolStripMenuItem_Click);
            // 
            // MoveTabToolStripMenuItem
            // 
            this.MoveTabToolStripMenuItem.Name = "MoveTabToolStripMenuItem";
            this.MoveTabToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.MoveTabToolStripMenuItem.Text = "Move Tab";
            this.MoveTabToolStripMenuItem.Click += new System.EventHandler(this.MoveTabToolStripMenuItem_Click);
            // 
            // NewTabToolStripMenuItem
            // 
            this.NewTabToolStripMenuItem.Name = "NewTabToolStripMenuItem";
            this.NewTabToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.NewTabToolStripMenuItem.Text = "New Tab";
            this.NewTabToolStripMenuItem.Click += new System.EventHandler(this.NewTabToolStripMenuItem_Click);
            // 
            // DeleteTabToolStripMenuItem
            // 
            this.DeleteTabToolStripMenuItem.Name = "DeleteTabToolStripMenuItem";
            this.DeleteTabToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.DeleteTabToolStripMenuItem.Text = "Delete Tab";
            this.DeleteTabToolStripMenuItem.Click += new System.EventHandler(this.DeleteTabToolStripMenuItem_Click);
            // 
            // GlobalConfigurationsToolStripMenuItem1
            // 
            this.GlobalConfigurationsToolStripMenuItem1.Name = "GlobalConfigurationsToolStripMenuItem1";
            this.GlobalConfigurationsToolStripMenuItem1.Size = new System.Drawing.Size(203, 22);
            this.GlobalConfigurationsToolStripMenuItem1.Text = "Global Configurations";
            this.GlobalConfigurationsToolStripMenuItem1.Click += new System.EventHandler(this.GlobalConfigurationsToolStripMenuItem_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabPage1.Size = new System.Drawing.Size(280, 241);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            // 
            // mNotifyIcon
            // 
            this.mNotifyIcon.ContextMenuStrip = this.mIconContextMenuStrip;
            this.mNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("mNotifyIcon.Icon")));
            this.mNotifyIcon.Text = "SwiftLaunch";
            this.mNotifyIcon.Visible = true;
            this.mNotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseDoubleClick);
            // 
            // mIconContextMenuStrip
            // 
            this.mIconContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExitToolStripMenuItem});
            this.mIconContextMenuStrip.Name = "IconContextMenuStrip";
            this.mIconContextMenuStrip.Size = new System.Drawing.Size(97, 26);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.ExitToolStripMenuItem.Text = "Exit";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // mButtonContextMenuStrip
            // 
            this.mButtonContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MoveButtonToolStripMenuItem,
            this.EditButtonToolStripMenuItem,
            this.ClearButtonToolStripMenuItem,
            this.GlobalConfigurationsToolStripMenuItem});
            this.mButtonContextMenuStrip.Name = "mButtonContextMenuStrip";
            this.mButtonContextMenuStrip.Size = new System.Drawing.Size(204, 92);
            // 
            // MoveButtonToolStripMenuItem
            // 
            this.MoveButtonToolStripMenuItem.Name = "MoveButtonToolStripMenuItem";
            this.MoveButtonToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.MoveButtonToolStripMenuItem.Text = "Move Button";
            this.MoveButtonToolStripMenuItem.Click += new System.EventHandler(this.MoveButtonToolStripMenuItem_Click);
            // 
            // EditButtonToolStripMenuItem
            // 
            this.EditButtonToolStripMenuItem.Name = "EditButtonToolStripMenuItem";
            this.EditButtonToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.EditButtonToolStripMenuItem.Text = "Edit Button";
            this.EditButtonToolStripMenuItem.Click += new System.EventHandler(this.EditButtonToolStripMenuItem_Click);
            // 
            // ClearButtonToolStripMenuItem
            // 
            this.ClearButtonToolStripMenuItem.Name = "ClearButtonToolStripMenuItem";
            this.ClearButtonToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.ClearButtonToolStripMenuItem.Text = "Clear Button";
            this.ClearButtonToolStripMenuItem.Click += new System.EventHandler(this.ClearButtonToolStripMenuItem_Click);
            // 
            // GlobalConfigurationsToolStripMenuItem
            // 
            this.GlobalConfigurationsToolStripMenuItem.Name = "GlobalConfigurationsToolStripMenuItem";
            this.GlobalConfigurationsToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.GlobalConfigurationsToolStripMenuItem.Text = "Global Configurations";
            this.GlobalConfigurationsToolStripMenuItem.Click += new System.EventHandler(this.GlobalConfigurationsToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.mTabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.Text = "Swift Launch";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mTabControl.ResumeLayout(false);
            this.mTabContextMenuStrip.ResumeLayout(false);
            this.mIconContextMenuStrip.ResumeLayout(false);
            this.mButtonContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl mTabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.NotifyIcon mNotifyIcon;
        private System.Windows.Forms.ContextMenuStrip mIconContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip mButtonContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem MoveButtonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditButtonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GlobalConfigurationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ClearButtonToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip mTabContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem RenameTabToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MoveTabToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewTabToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteTabToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GlobalConfigurationsToolStripMenuItem1;
    }
}