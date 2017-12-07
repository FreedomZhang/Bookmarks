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

        /// <summary>
        /// 将Chrome书签对象数据转为MyBookmarks数据
        /// </summary>
        /// <param name="chromeBookmarks"></param>
        /// <returns></returns>
        public List<MyBookmarks> GetBookmarkses(ChromeBookmarks chromeBookmarks)
        {
            List<MyBookmarks> list = new List<MyBookmarks>();
            if (chromeBookmarks != null)
            {
                //添加分组书签
                foreach (var datameta in chromeBookmarks.roots.bookmark_bar.children)
                {
                    if (datameta.children == null) continue;
                    foreach (var datametaChild in datameta.children)
                    {
                        if (datametaChild.type == "url")
                        {
                            list.Add(new MyBookmarks()
                            {
                                Name = datametaChild.name,
                                Url = datametaChild.url,
                                Type = datameta.name,
                                Source = EnumClass.SourceEnum.Chrome.ToString(),
                            });
                        }
                    }
                }
                //添加其他书签
                foreach (var datameta in chromeBookmarks.roots.other.children)
                {
                    list.Add(new MyBookmarks()
                    {
                        Name = datameta.name,
                        Url = datameta.url,
                        Type = chromeBookmarks.roots.other.name,
                        Source = EnumClass.SourceEnum.Chrome.ToString(),
                    });

                }
            }
            return list;
        }

        /// <summary>
        /// 保存成json文件
        /// </summary>
        /// <param name="myBookmarkses"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool SaveMyBookmarksToJsonFile(List<MyBookmarks> myBookmarkses,string filePath)
        {
            return StringConvert.FileWrite(filePath,StringConvert.ListToJson(myBookmarkses));
        }
    }
}
