using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Qiniu.Http;
using Qiniu.Storage;
using Qiniu.Util;

namespace QiNiuWork
{
    public class QiNiuWorkUtil
    {

        public void UploadFile(QiNiuConfig qiNiuConfig)
        {
            //string AK = "DhR0aOgYjluVsdplOW_A7heVOfKW7PSIoR9aU08_";
            //string SK = "T4W_D6urXqUKutAm3G0aHLE9NEF3RvGhepcXqfqJ";
            //// 目标空间名
            //string bucket = "myfreet";
            //// 目标文件名
            //string saveKey = "谷歌浏览器书签保存位置2.txt";
            //// 本地文件
            //string localFile = @"C:\Users\z8489\Documents\GitHub\Bookmarks\谷歌浏览器书签保存位置.txt";
            // 上传策略
            PutPolicy putPolicy = new PutPolicy();
            // 设置要上传的目标空间
            putPolicy.Scope = qiNiuConfig.Bucket;
            // 上传策略的过期时间(单位:秒)
            putPolicy.SetExpires(3600);
            // 文件上传完毕后，在多少天后自动被删除
            //putPolicy.DeleteAfterDays = 1;
            // 请注意这里的Zone设置(如果不设置，就默认为华东机房)
            // var zoneId = Qiniu.Common.AutoZone.Query(AK,BUCKET);
            // Qiniu.Common.Config.ConfigZone(zoneId);
            Mac mac = new Mac(qiNiuConfig.AK, qiNiuConfig.SK); // Use AK & SK here
            // 生成上传凭证
            string uploadToken = Auth.createUploadToken(putPolicy, mac);
            UploadOptions uploadOptions = null;
            // 上传完毕事件处理
            UpCompletionHandler uploadCompleted = new UpCompletionHandler(OnUploadCompleted);
            // 方式1：使用UploadManager
            //默认设置 Qiniu.Common.Config.PUT_THRESHOLD = 512*1024;
            //可以适当修改,UploadManager会根据这个阈值自动选择是否使用分片(Resumable)上传    
            UploadManager um = new UploadManager();
            um.uploadFile(qiNiuConfig.LocalFile, qiNiuConfig.SaveKey, uploadToken, uploadOptions, qiNiuConfig.UpHandler);
            // 方式2：使用FormManager
            //FormUploader fm = new FormUploader();
            //fm.uploadFile(localFile, saveKey, token, uploadOptions, uploadCompleted);
        }
        private static void OnUploadCompleted(string key, ResponseInfo respInfo, string respJson)
        {
            // respInfo.StatusCode
            // respJson是返回的json消息，示例: { "key":"FILE","hash":"HASH","fsize":FILE_SIZE }
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="url"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static  bool HttpDownload(string url,string fileName)
        {
            string path = System.Environment.CurrentDirectory+@"\"+ fileName;
            string tempPath = System.IO.Path.GetDirectoryName(path) + @"\temp";
            System.IO.Directory.CreateDirectory(tempPath);  //创建临时文件目录
            string tempFile = tempPath + @"\" + System.IO.Path.GetFileName(path) + ".temp"; //临时文件
            if (System.IO.File.Exists(tempFile))
            {
                System.IO.File.Delete(tempFile);    //存在则删除
            }
            try
            {
                FileStream fs = new FileStream(tempFile, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                // 设置参数
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                //发送请求并获取相应回应数据
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                //直到request.GetResponse()程序才开始向目标网页发送Post请求
                Stream responseStream = response.GetResponseStream();
                //创建本地文件写入流
                //Stream stream = new FileStream(tempFile, FileMode.Create);
                byte[] bArr = new byte[1024];
                int size = responseStream.Read(bArr, 0, (int)bArr.Length);
                while (size > 0)
                {
                    //stream.Write(bArr, 0, size);
                    fs.Write(bArr, 0, size);
                    size = responseStream.Read(bArr, 0, (int)bArr.Length);
                }
                //stream.Close();
                fs.Close();
                responseStream.Close();
                System.IO.File.Move(tempFile, path);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
