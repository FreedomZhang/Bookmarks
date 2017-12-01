using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataOperation.Model;

namespace DataOperation
{
    public class BookmarksData
    {
        /// <summary>
        /// 获取Chrome浏览器书签对象
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public ChromeBookmarks GetChromeBookmarksData(string filePath)
        {
            string str = StringConvert.FileRead(filePath);
            object chromeBookmarks = StringConvert.JsonToList<ChromeBookmarks>(str);
            if (chromeBookmarks != null)
            {
                return (ChromeBookmarks)chromeBookmarks;
            }
            return null;
        }

    }
}
