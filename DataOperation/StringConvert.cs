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
    }
}
