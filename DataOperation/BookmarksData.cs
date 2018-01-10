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
        public static bool SaveMyBookmarksToJsonFile(List<MyBookmarks> myBookmarkses, string filePath)
        {
            BookmarksType bookmarksType = new BookmarksType();
            bookmarksType.Info = myBookmarkses;
            List<string> types = new List<string>();
            foreach (var item in myBookmarkses.GroupBy(a => a.Type).ToList())
            {
                types.Add(item.Key);
            }
            bookmarksType.Type = types;
            return StringConvert.FileWrite(filePath, StringConvert.ListToJson(bookmarksType));
        }

        /// <summary>
        /// 对比线上书签内容和本地书签内容是否一致
        /// </summary>
        /// <param name="localBookmarks">本地书签内容</param>
        /// <param name="onlineBookmarks">线上书签内容</param>
        /// <returns></returns>
        public static bool ContrastBookmarks(List<MyBookmarks> localBookmarks, List<MyBookmarks> onlineBookmarks)
        {
            bool rel = false;
            foreach (MyBookmarks item in localBookmarks)
            {
                if (!onlineBookmarks.Contains(item))
                {
                    onlineBookmarks.Add(item);
                    rel = true;
                }
            }
            return rel;
        }

        /// <summary>
        /// 将文件保存成data.js文件
        /// </summary>
        /// <param name="localBookmarks">本地书签文件数据</param>
        public static void SaveDataJs(List<MyBookmarks> localBookmarks)
        {
            string dataPath = System.Environment.CurrentDirectory + @"\data.json";
            string datajsPath = System.Environment.CurrentDirectory + @"\data.js";
            if (BookmarksData.SaveMyBookmarksToJsonFile(localBookmarks, dataPath))
            {
                string cont = "var InfoData =" + StringConvert.FileRead(dataPath);
                StringConvert.FileWrite(datajsPath, cont);
            }

        }

        /// <summary>
        /// 对比文件
        /// </summary>
        /// <param name="localBookmarks"></param>
        public static bool ContrastBookmarks(List<MyBookmarks> localBookmarks)
        {
            if (localBookmarks == null) return false;
            string datajsPath = System.Environment.CurrentDirectory + @"\old_data.js";
            string datajs = StringConvert.FileRead(datajsPath);
            datajs = datajs.Substring((datajs.IndexOf("=") + 1));
            BookmarksType bookmarksType = (BookmarksType)StringConvert.JsonToList<BookmarksType>(datajs);
            //List<MyBookmarks> onlineBookmarks = bookmarksType.Info;
            bool rel = false;
            foreach (MyBookmarks item in localBookmarks)
            {
                if (!bookmarksType.Info.Any(a=>a.Url==item.Url))
                {
                    bookmarksType.Info.Add(item);
                    rel = true;
                }
            }
            if (rel)
            {
                SaveDataJs(localBookmarks);
            }
            return rel;
        }
    }
}
