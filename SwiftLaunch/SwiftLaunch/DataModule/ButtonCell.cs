using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using SwiftLaunch.Properties;
using System.Drawing;

namespace SwiftLaunch.DataModule
{
    public class ButtonCell
    {
        #region Attributes

        //private int mID { get; set; }
        public int mTabIndex { get; set; }
        public int mColumnIndex { get; set; }
        public int mRowIndex { get; set; }
        public String mName { get; set; }
        public String mDescription { get; set; }
        public String mIconPath { get; set; }
        public String mLaunchLink { get; set; }
        public String mLaunchArgs { get; set; }
        public ConstsAndEnums.LaunchType mLaunchType { get; set; }

        #endregion

        #region Constructors

        public ButtonCell()
        {

        }

        public ButtonCell(int aTabIndex, int aRowIndex, int aColumnIndex)
        {
            this.mTabIndex = aTabIndex;
            this.mRowIndex = aRowIndex;
            this.mColumnIndex = aColumnIndex;
        }
        
        #endregion

        #region Methods

        public void SetButtonCellData(String aFilePath)
        {
            if (File.Exists(aFilePath))
            {
                String lExtension = Path.GetExtension(aFilePath).ToLower();

                switch (lExtension)
                {
                    case ".lnk":
                        {
                            IWshRuntimeLibrary.WshShell lShell = new IWshRuntimeLibrary.WshShell();
                            IWshRuntimeLibrary.IWshShortcut lShortCut = (IWshRuntimeLibrary.IWshShortcut)lShell.CreateShortcut(aFilePath);

                            this.mName = Path.GetFileNameWithoutExtension(aFilePath);
                            this.mLaunchLink = lShortCut.TargetPath;
                            this.mLaunchArgs = lShortCut.Arguments;
                            this.mDescription = lShortCut.Description;

                            if (File.Exists(lShortCut.IconLocation))
                            {
                                this.mIconPath = lShortCut.IconLocation;
                            }
                            else if (File.Exists(lShortCut.TargetPath))
                            {
                                this.mIconPath = lShortCut.TargetPath;
                            }
                            else
                            {
                                this.mIconPath = aFilePath;
                            }

                            this.mLaunchType = ConstsAndEnums.LaunchType.Lnk;
                        }
                        break;
                    case ".url":
                    default:
                        this.mLaunchLink = aFilePath;
                        this.mName = Path.GetFileNameWithoutExtension(aFilePath);
                        this.mIconPath = aFilePath;
                        this.mLaunchType = ConstsAndEnums.LaunchType.File;
                        break;
                }
            }
            else if (Directory.Exists(aFilePath))
            {
                this.mLaunchLink = aFilePath;
                this.mName = aFilePath;// Path.GetFileNameWithoutExtension(aFilePath);
                this.mIconPath = aFilePath;
                this.mLaunchType = ConstsAndEnums.LaunchType.Folder;
            }
            else
            {
                throw new Exception(Resources.String_TargetNotExist);
            }
        }

        public void InitButtonCellData()
        {
            this.mTabIndex = 0;
            this.mRowIndex = 0;
            this.mColumnIndex = 0;
            this.mName = null;
            this.mDescription = null;
            this.mIconPath = null;
            this.mLaunchLink = null;
            this.mLaunchArgs = null;
            this.mLaunchType = ConstsAndEnums.LaunchType.Invalid;
        }

        public void LaunchButtonCell()
        {
            if (String.IsNullOrEmpty(this.mLaunchLink) || this.mLaunchType == ConstsAndEnums.LaunchType.Invalid)
            {
                return;
            }

            try
            {
                String lString = String.Format(@"{0}{1}", this.mLaunchLink, this.mLaunchArgs);
                //if (File.Exists(this.mLaunchLink) || Directory.Exists(this.mLaunchLink))
                {
                    Process.Start(lString);
                }

                //string targetPath = string.Format("C:\\Windows\\Installer\\{{90140000-0011-0000-0000-0000000FF1CE}}");
                //    // Process:提供对本地和远程进程的访问并使你能够启动和停止本地系统进程
                //Process process = new Process();

                //// 初始化可执行文件的一些基础信息
                //process.StartInfo.WorkingDirectory = @targetPath; // 初始化可执行文件的文件夹信息
                //process.StartInfo.FileName = "xlicons.exe"; // 初始化可执行文件名

                //// 当我们需要给可执行文件传入参数时候可以设置这个参数
                //// "para1 para2 para3" 参数为字符串形式，每一个参数用空格隔开
                //process.StartInfo.Arguments = this.mLaunchArgs;
                //process.StartInfo.UseShellExecute = true;        // 使用操作系统shell启动进程

                //// 启动可执行文件
                //process.Start();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw new Exception(Resources.String_TargetNotExist);
            }
        }

        public Bitmap GetBitmap()
        {
            Bitmap lBitmap = null;

            if (!String.IsNullOrEmpty(this.mIconPath))
            {
                if (this.mLaunchType == ConstsAndEnums.LaunchType.Folder && this.mIconPath.Count() > 3)
                {
                    lBitmap = SystemIcon.GetFolderIcon(false).ToBitmap();
                }
                else
                {
                    lBitmap = SystemIcon.GetFileIcon(this.mIconPath, false).ToBitmap();
                }
            }

            return lBitmap;
        }
        #endregion
    }
}
