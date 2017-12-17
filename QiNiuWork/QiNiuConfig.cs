using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Qiniu.Http;
using Qiniu.Storage;

namespace QiNiuWork
{
    public delegate void DoUpload();
   public class QiNiuConfig
    {
        public string AK { get; set; }
        public  string SK { get; set; }
        /// <summary>
        /// 目标空间名
        /// </summary>
        public string Bucket { get; set; }
        /// <summary>
        /// 目标文件名
        /// </summary>
        public string SaveKey {
            get { return System.IO.Path.GetFileName(LocalFile); }
        }
        /// <summary>
        /// 本地文件
        /// </summary>
        public string LocalFile { get; set; }
        public DoUpload UploadH { get; set; }
        public UpCompletionHandler UpHandler
        {
            get { return OnUploadCompleted; }
        }


        private  void OnUploadCompleted(string key, ResponseInfo respInfo, string respJson)
        {
            string str = respJson;
            // respJson是返回的json消息，示例: { "key":"FILE","hash":"HASH","fsize":FILE_SIZE }
            DoUpload load = UploadH;
            if (load == null) return;
            load();
        }
    }
}
