using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataOperation.Model
{
    /// <summary>
    /// 转换后书签格式对象
    /// </summary>
    public class MyBookmarks
    {
        public string Type { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public  string Source { get; set; }
    }

    public class BookmarksType
    {
        /// <summary>
        /// 分类集合
        /// </summary>
        public List<string> Type { get; set; }
        /// <summary>
        /// 详细内容
        /// </summary>
        public List<MyBookmarks> Info { get; set; }
    }

}
