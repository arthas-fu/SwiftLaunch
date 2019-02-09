using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftLaunch.Properties;
using System.Xml;
using System.IO;

namespace SwiftLaunch.DataModule
{
    public class GlobalConfig
    {
        #region Attributes

        private int mTabCount { get; set; }
        private XmlDocument mXmlDocument { get; set; }
        private bool mIsXmlFileValid { get; set; }
        public int mButtonSize { get; set; }
        public int mButtonRowCount { get; set; }
        public int mButtonColumnCount { get; set; }
        public List<ButtonCell> mButtonCellList { get; set; }
        public List<String> mTabNameList { get; set; }

        #endregion

        #region Constructors

        public GlobalConfig()
        {
            this.Initialize();

            this.LoadAllData();
        }

        #endregion

        #region Methods

        public void Initialize()
        {
            mTabCount = ConstsAndEnums.DEFAULT_TAB_COUNT;
            mButtonSize = ConstsAndEnums.DEFAULT_BUTTON_SIZE;
            mButtonRowCount = ConstsAndEnums.DEFAULT_BUTTON_ROW_COUNT;
            mButtonColumnCount = ConstsAndEnums.DEFAULT_BUTTON_COLUMN_COUNT;
            mButtonCellList = new List<ButtonCell>();
            mTabNameList = new List<String>();

            this.mIsXmlFileValid = true;
            this.mXmlDocument = new XmlDocument();

        }

        private void LoadAllData()
        {
            this.LoadXml();
            this.CheckXml();

            if (this.mIsXmlFileValid == false)
            {
                this.LoadDefaultTabNames();
                this.InitButtonCellsData();
            }
            else
            {
                this.LoadConfigurations();
                this.LoadTabNames();
                this.InitButtonCellsData();
                this.LoadButtonCellsData();
            }
        }

        private void LoadXml()
        {
            try
            {
	            Stream lStream = new FileStream(ConstsAndEnums.DEFAULT_CONFIG_PATH, FileMode.Open, FileAccess.Read);
	        
	            this.mXmlDocument.Load(lStream);
                lStream.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                this.mIsXmlFileValid = false;
            }
        }

        private void CheckXml()
        {
            XmlElement lRootNode = this.mXmlDocument.DocumentElement;
            if (lRootNode == null)
            {
                this.mIsXmlFileValid = false;
                return;
            }

            XmlElement lGlobalConfigurationNode = lRootNode.FirstChild as XmlElement;
            if (lGlobalConfigurationNode == null)
            {
                this.mIsXmlFileValid = false;
                return;
            }

            if (String.IsNullOrEmpty(lGlobalConfigurationNode.GetAttribute("ButtonSize")))
            {
                this.mIsXmlFileValid = false;
                return;
            }
            if (String.IsNullOrEmpty(lGlobalConfigurationNode.GetAttribute("RowCount")))
            {
                this.mIsXmlFileValid = false;
                return;
            }
            if (String.IsNullOrEmpty(lGlobalConfigurationNode.GetAttribute("ColumnCount")))
            {
                this.mIsXmlFileValid = false;
                return;
            }

            XmlElement lTabsXml = lGlobalConfigurationNode.NextSibling as XmlElement;
            if (lGlobalConfigurationNode == null)
            {
                this.mIsXmlFileValid = false;
                return;
            }

            if (Convert.ToInt32(lTabsXml.GetAttribute("Count")) == 0)
            {
                this.mIsXmlFileValid = false;
                return;
            }

        }

        private void SaveXml()
        {
            XmlDocument lXmlDocument = new XmlDocument();
            XmlDeclaration lXmlDeclaration = lXmlDocument.CreateXmlDeclaration("1.0", "UTF-8", null);

            lXmlDocument.AppendChild(lXmlDeclaration);

            XmlElement lRootXml = lXmlDocument.CreateElement("", "SwiftLaunch", "");
            lXmlDocument.AppendChild(lRootXml);

            XmlElement lGlobalConfigXml = lXmlDocument.CreateElement("", "GlobalConfigurations", "");
            lGlobalConfigXml.SetAttribute("ButtonSize", this.mButtonSize.ToString());
            //lGlobalConfigXml.SetAttribute("TabCount", this.mTabNameList.Count.ToString());
            lGlobalConfigXml.SetAttribute("RowCount", this.mButtonRowCount.ToString());
            lGlobalConfigXml.SetAttribute("ColumnCount", this.mButtonColumnCount.ToString());
            lRootXml.AppendChild(lGlobalConfigXml);

            XmlElement lTabsXml = lXmlDocument.CreateElement("", "Tabs", "");
            lTabsXml.SetAttribute("Count", this.mTabCount.ToString());
            lRootXml.AppendChild(lTabsXml);

            foreach (String lTabName in this.mTabNameList)
            {
                XmlElement lTabXml = lXmlDocument.CreateElement("", "Tab", "");
                lTabXml.SetAttribute("Name", lTabName);
                lTabsXml.AppendChild(lTabXml);
            }

            XmlElement lButtonsXml = lXmlDocument.CreateElement("", "Buttons", "");
            lButtonsXml.SetAttribute("Count", this.mButtonCellList.Count.ToString());
            lRootXml.AppendChild(lButtonsXml);

            foreach (ButtonCell lButtonCell in this.mButtonCellList)
            {
                XmlElement lButtonXml = lXmlDocument.CreateElement("", "Button", "");
                lButtonXml.SetAttribute("TabIndex", lButtonCell.mTabIndex.ToString());
                lButtonXml.SetAttribute("RowIndex", lButtonCell.mRowIndex.ToString());
                lButtonXml.SetAttribute("ColumnIndex", lButtonCell.mColumnIndex.ToString());
                lButtonXml.SetAttribute("Name", lButtonCell.mName);
                lButtonXml.SetAttribute("Description", lButtonCell.mDescription);
                lButtonXml.SetAttribute("IconPath", lButtonCell.mIconPath);
                lButtonXml.SetAttribute("TargetPath", lButtonCell.mLaunchLink);
                lButtonXml.SetAttribute("LaunchArgs", lButtonCell.mLaunchArgs);
                lButtonXml.SetAttribute("TargetType", lButtonCell.mLaunchType.ToString());
                lButtonsXml.AppendChild(lButtonXml);
            }

            lXmlDocument.Save(ConstsAndEnums.DEFAULT_CONFIG_PATH);
        }

        private void LoadConfigurations()
        {
            XmlElement lRootNode = this.mXmlDocument.DocumentElement;
            XmlElement lGlobalConfigurationNode = lRootNode.FirstChild as XmlElement;

            this.mButtonSize = Convert.ToInt32(lGlobalConfigurationNode.GetAttribute("ButtonSize"));
            this.mButtonRowCount = Convert.ToInt32(lGlobalConfigurationNode.GetAttribute("RowCount"));
            this.mButtonColumnCount = Convert.ToInt32(lGlobalConfigurationNode.GetAttribute("ColumnCount"));
        }

        private void LoadDefaultTabNames()
        {
            this.AddNewTab("Tools");
            this.AddNewTab("Documents");
        }

        private void LoadTabNames()
        {
            XmlElement lRootNode = this.mXmlDocument.DocumentElement;
            XmlElement lTabsNode = lRootNode.FirstChild.NextSibling as XmlElement;

            this.mTabCount = Convert.ToInt32(lTabsNode.GetAttribute("Count"));

            XmlElement lTabNode = lTabsNode.FirstChild as XmlElement;

            for (int i = 0; i < this.mTabCount; i++)
            {
                this.mTabNameList.Add(lTabNode.GetAttribute("Name"));
                lTabNode = lTabNode.NextSibling as XmlElement;
            }
        }

        private void InitButtonCellsData()
        {
            for (int i = 0; i < this.mTabCount; i++)
            {
                this.CreateTabPage(i);
            }
        }

        private void LoadButtonCellsData()
        {
            XmlElement lRootNode = this.mXmlDocument.DocumentElement;
            XmlElement lButtonsNode = lRootNode.FirstChild.NextSibling.NextSibling as XmlElement;
            String lTabIndex = null, lRowIndex = null, lColumnIndex = null;
            ButtonCell lButtonCell = null;

            foreach (XmlElement lButtonNode in lButtonsNode.ChildNodes)
            {
                lTabIndex = lButtonNode.GetAttribute("TabIndex");
                if (String.IsNullOrEmpty(lTabIndex))
                {
                    continue;
                }

                lRowIndex = lButtonNode.GetAttribute("RowIndex");
                if (String.IsNullOrEmpty(lRowIndex))
                {
                    continue;
                }

                lColumnIndex = lButtonNode.GetAttribute("ColumnIndex");
                if (String.IsNullOrEmpty(lColumnIndex))
                {
                    continue;
                }

                String lString = null;

                lButtonCell = this.mButtonCellList.Find(
                    delegate(ButtonCell aButtonCell)
                    {
                        return aButtonCell.mTabIndex == Convert.ToInt32(lTabIndex) && 
                            aButtonCell.mRowIndex == Convert.ToInt32(lRowIndex) && 
                            aButtonCell.mColumnIndex == Convert.ToInt32(lColumnIndex);
                    });
                if (lButtonCell != null)
                {
                    lButtonCell.mTabIndex = Convert.ToInt32(lTabIndex);
                    lButtonCell.mRowIndex = Convert.ToInt32(lRowIndex);
                    lButtonCell.mColumnIndex = Convert.ToInt32(lColumnIndex);
                    lButtonCell.mName = lButtonNode.GetAttribute("Name");
                    lButtonCell.mDescription = lButtonNode.GetAttribute("Description");
                    lButtonCell.mIconPath = lButtonNode.GetAttribute("IconPath");
                    lButtonCell.mLaunchLink = lButtonNode.GetAttribute("TargetPath");
                    lButtonCell.mLaunchArgs = lButtonNode.GetAttribute("LaunchArgs");
                    lButtonCell.mDescription = lButtonNode.GetAttribute("Description");
                    lString = lButtonNode.GetAttribute("TargetType").ToLower();

                    switch (lString)
                    {
                        case "url":
                            lButtonCell.mLaunchType = ConstsAndEnums.LaunchType.Url;
                            break;
                        case "lnk":
                            lButtonCell.mLaunchType = ConstsAndEnums.LaunchType.Lnk;
                            break;
                        case "file":
                            lButtonCell.mLaunchType = ConstsAndEnums.LaunchType.File;
                            break;
                        case "folder":
                            lButtonCell.mLaunchType = ConstsAndEnums.LaunchType.Folder;
                            break;
                        default:
                            lButtonCell.mLaunchType = ConstsAndEnums.LaunchType.Invalid;
                            break;
                    }
                }
            }
        }

        public void AddNewTab(String aTabName)
        {
            if (String.IsNullOrEmpty(aTabName))
            {
                throw new Exception(Resources.String_TabNameCanNotBeEmpty);
            }

            this.CreateTabPage(this.mTabNameList.Count);
            this.mTabNameList.Add(aTabName);
        }

        private void CreateTabPage(int aTabIndex)
        {
            for (int i = 0; i < this.mButtonRowCount; i++)
            {
                for (int j = 0; j < this.mButtonColumnCount; j++)
                {
                    this.mButtonCellList.Add(new ButtonCell(aTabIndex, i, j));
                }
            }
        }

        public void RemoveTab(int aTabIndex)
        {
            if (aTabIndex >= this.mTabNameList.Count)
            {
                throw new Exception(Resources.String_IndexBeyondRange);
            }

            this.mTabNameList.RemoveAt(aTabIndex);
            this.RemoveTabPage(this.mTabNameList.Count);
        }

        private void RemoveTabPage(int aTabIndex)
        {
            for (int i = 0; i < this.mButtonCellList.Count; )
            {
                if (this.mButtonCellList[i].mTabIndex == aTabIndex)
                {
                    this.mButtonCellList.RemoveAt(i);
                    continue;
                }
                else if (this.mButtonCellList[i].mTabIndex == aTabIndex)
                {
                    this.mButtonCellList[i].mTabIndex--;
                }
                i++;
            }
        }

        public void SwitchTabPage(int aFromIndex, int aToIndex)
        {
            if (aFromIndex >= this.mTabNameList.Count || aToIndex >= this.mTabNameList.Count)
            {
                throw new Exception(Resources.String_IndexBeyondRange);
            }

            String lTmpString = this.mTabNameList[aToIndex];
            this.mTabNameList[aToIndex] = this.mTabNameList[aFromIndex];
            this.mTabNameList[aFromIndex] = lTmpString;

            foreach (ButtonCell lButtonCell in this.mButtonCellList)
            {
                if (lButtonCell.mTabIndex == aFromIndex)
                {
                    lButtonCell.mTabIndex = aToIndex;
                }
                else if (lButtonCell.mTabIndex == aToIndex)
                {
                    lButtonCell.mTabIndex = aFromIndex;
                }
            }
        }

        public void SaveAll()
        {
            this.SaveXml();
        }
        #endregion
    }
}
