using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SwiftLaunch.View;
using SwiftLaunch.DataModule;
using System.Threading;

namespace SwiftLaunch
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool lRunOne = true;
            Mutex lRun = new Mutex(true, "SwiftLaunch", out lRunOne);
            if (lRunOne)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
            else
            {

            }
        }
    }
}
