using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DataOperation.Model;

namespace DataOperation
{
    public class ConfigDataService
    {
        private static ConfigModel _configData;

        public static ConfigModel ConfigData
        {
            get
            {
                if (_configData == null)
                {
                    LoadConfig();
                }
                return _configData;
            }
        }

        public static string FilePath => System.Environment.CurrentDirectory + @"\config.json";

        public static void LoadConfig()
        {
            //string path = System.Environment.CurrentDirectory + @"\config.json"; 
            if (File.Exists(FilePath))
            {
                _configData = (ConfigModel)StringConvert.JsonToList<ConfigModel>(StringConvert.FileRead(FilePath));
            }
            else
            {
                _configData = new ConfigModel();
            }
        }
        /// <summary>
        /// 保存配置文件
        /// </summary>
        public static bool SaveConfigData()
        {
            if (ConfigDataService.ConfigData!=null)
            {
                //string path = System.Environment.CurrentDirectory + @"\config.json";
                StringConvert.FileWrite(FilePath, StringConvert.ListToJson(ConfigDataService.ConfigData));
                return true;
            }
            return false;
        }


    }
}
