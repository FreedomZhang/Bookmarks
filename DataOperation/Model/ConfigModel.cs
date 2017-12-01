using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataOperation.Model
{
    public class ConfigModel
    {

        /// <summary>
        /// ID
        /// </summary>
        public string CId { get; set; }

        /// <summary>
        /// 书签文件地址
        /// </summary>
        public string FilePath { get; set; }
        /// <summary>
        /// 书签类型
        /// </summary>
        public string Type { get; set; }
    }
}
