using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace DataOperation
{
    public class StringConvert
    {
        /// <summary>
        /// json序列化
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public static string ListToJson<T>(T data)
        {
            string str = string.Empty;
            try
            {
                if (null != data)
                    str = JsonConvert.SerializeObject(data);
            }
            catch (Exception e)
            {

            }
            return str;
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="jsonstr">数据</param>
        /// <returns></returns>
        public static Object JsonToList<T>(string jsonstr)
        {
            Object obj = null;
            try
            {
                if (null != jsonstr)
                    obj = JsonConvert.DeserializeObject<T>(jsonstr);//反序列化
            }
            catch (Exception e)
            {

            }
            return obj;
        }


        public static string FileRead(string filePath)
        {
            string rel = File.ReadAllText(filePath);
            return rel;
        }

        /// <summary>
        /// 写入文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="conte"></param>
        /// <returns></returns>
        public static bool FileWrite(string filePath, string conte)
        {
            try
            {
                FileStream fs = new FileStream(filePath, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);
                //开始写入
                sw.Write(conte);
                //清空缓冲区
                sw.Flush();
                //关闭流
                sw.Close();
                fs.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

    }
}
