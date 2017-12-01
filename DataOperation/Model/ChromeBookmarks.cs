using System.Collections.Generic;

namespace DataOperation.Model
{
    /// <summary>
    /// Chorme书签保存文件结构
    /// </summary>
    public class ChromeBookmarks
    {
        public string checksum { get; set; }
        public bookmark roots { get; set; }
        //public  string sync_transaction_version { get; set; }
        public string version { get; set; }
        //public  string synced { get; set; }
    }

    public class bookmark
    {
        public datameta bookmark_bar { get; set; }
        public datameta other { get; set; }
    }



    public class datameta
    {
        public List<datameta> children { get; set; }
        public  string date_added { get; set; }
        public  string date_modified { get; set; }
        public  string id { get; set; }
        public meta_info meta_info { get; set; }
        public  string name { get; set; }
        public  string sync_transaction_version { get; set; }
        public  string type { get; set; }
        public  string url { get; set; }
    }

    public class meta_info
    {
        public string last_visited_desktop { get; set; }
    }
}