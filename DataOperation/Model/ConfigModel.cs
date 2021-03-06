﻿using System;
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
        /// <summary>
        /// 保存文件地址
        /// </summary>
        public string SaveJsonPath { get; set; }
        /// <summary>
        /// 是否自动同步
        /// </summary>
        public bool Synchronization { get; set; }

        public string QiNiuAccessKey { get; set; }

        public string QiNiuSecretKey { get; set; }
        /// <summary>
        /// 七牛存储文件空间
        /// </summary>
        public string QiNiuSpace { get; set; }

        public string DownloadUrl { get; set; }
    }
}
