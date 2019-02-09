using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftLaunch.DataModule
{
    public class ConstsAndEnums
    {
        public enum LaunchType : int
        {
            Invalid = 0,
            Url = 1,
            Lnk = 2,
            File = 3,
            Folder = 4
        }

        public enum HotKeyModifiers
        {
            Alt = 1,
            Control = 2,
            Shift = 4,
            Win = 8,
        }

        public const int DEFAULT_TAB_COUNT = 2;
        public const int DEFAULT_BUTTON_SIZE = 40;
        public const int DEFAULT_BUTTON_ROW_COUNT = 4;
        public const int DEFAULT_BUTTON_COLUMN_COUNT = 8;
        public const int HINT_LABLE_HIGHT = 20;
        public const int HOT_KEY_ID = 0x1BCDDBCA;
        public const String DEFAULT_CONFIG_PATH = "./cfg.xml";

        public const int WM_SYSCOMMAND = 0x112;
        public const int WM_HOTKEY = 0x312;

        public const int SC_CLOSE = 0xF060;
        public const int SC_MINIMIZE = 0xF020;
        public const int SC_MAXIMIZE = 0xF030;
    }
}
