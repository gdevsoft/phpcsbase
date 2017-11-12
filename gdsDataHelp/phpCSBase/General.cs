using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web.Script.Serialization;

namespace phpCSBase
{
   public  class General
    {
       /// <summary>
       /// 对字符串进行压缩处理
       /// </summary>
       /// <param name="text"></param>
       /// <returns></returns>
        public static string Compress(string text)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(text);
            using (MemoryStream ms = new MemoryStream())
            {
                GZipStream Compress = new GZipStream(ms, CompressionMode.Compress);

                Compress.Write(buffer, 0, buffer.Length);

                Compress.Close();

                return Convert.ToBase64String(ms.ToArray()).TrimEnd('\0');

            }
        }

       /// <summary>
       /// 对字符串进行解压处理
       /// </summary>
       /// <param name="text"></param>
       /// <returns></returns>
        public static string Decompress(string text)
        {
            text = text.TrimEnd('\0');
            byte[] buffer = Convert.FromBase64String(text);
            using (MemoryStream tempMs = new MemoryStream())
            {
                using (MemoryStream ms = new MemoryStream(buffer))
                {
                    GZipStream Decompress = new GZipStream(ms, CompressionMode.Decompress);

                    Decompress.CopyTo(tempMs);

                    Decompress.Close();

                    return Encoding.UTF8.GetString(tempMs.ToArray());
                }
            }
        }
       /// <summary>
        /// 加密
       /// </summary>
       /// <param name="strString"></param>
       /// <returns></returns>
        public static string Encrypt3DES(string strString)
        {
            return Encrypt3DES(strString, "xxxxxxxx");
        }
     /// <summary>
     /// 加密
     /// </summary>
     /// <param name="strString"></param>
     /// <param name="Key">必须是8位的字符</param>
     /// <returns></returns>
        public static string Encrypt3DES(string strString, string Key)
        {
            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();

            DES.Key = System.Text.Encoding.UTF8.GetBytes(Key);
            DES.Mode = CipherMode.ECB;
            DES.Padding = PaddingMode.Zeros;

            ICryptoTransform DESEncrypt = DES.CreateEncryptor();

            byte[] Buffer = System.Text.Encoding.UTF8.GetBytes(strString);

            return Convert.ToBase64String(DESEncrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
        }
       /// <summary>
        /// 字符串解密
       /// </summary>
       /// <returns></returns>
        public static string Decrypt3DES(string strString)
        {
            return Decrypt3DES(strString, "xxxxxxxx");
        }
       /// <summary>
       /// 字符串解密
       /// </summary>
       /// <param name="strString"></param>
        /// <param name="Key">必须是8位的字符</param>
       /// <returns></returns>
        public static string Decrypt3DES(string strString, string Key)
        {
            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();

            DES.Key = Encoding.UTF8.GetBytes(Key);
            DES.Mode = CipherMode.ECB;
            DES.Padding = PaddingMode.Zeros;
            ICryptoTransform DESDecrypt = DES.CreateDecryptor();

            byte[] Buffer = Convert.FromBase64String(strString);
            return UTF8Encoding.UTF8.GetString(DESDecrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
        }
        /// <summary>
        /// 解析PHP json_encode fetchAll(PDO::FETCH_ASSOC) 后的数据 只包括列的数据
        /// 格式 指标 数据 指标序号 数据
        /// </summary>
        /// <param name="json"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static DataTable ToDataTable1(string json, string tableName)
        {
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            javaScriptSerializer.MaxJsonLength = Int32.MaxValue; //取得最大数值
            ArrayList arrayList = javaScriptSerializer.Deserialize<ArrayList>(json);
            DataTable dataTable = new DataTable(tableName);  //实例化
            DataTable result;
            if (arrayList.Count > 0)
            { 
                foreach (Dictionary<string, object> dictionary in arrayList)
                {
                    if (dictionary.Keys.Count == 0)
                    {
                        result = dataTable;
                        return result;
                    }
                    if (dataTable.Columns.Count == 0)
                    {
                      
                        foreach (string current in dictionary.Keys)
                        {
                            
                                Type type = Type.GetType("System.String");
                                if (dictionary[current] != null)
                                    type = dictionary[current].GetType();
                                dataTable.Columns.Add(current, type);
                            
                        }
                    }
                
                    DataRow dataRow = dataTable.NewRow();
                    foreach (string current in dictionary.Keys)
                    {
                       
                            dataRow[current] = dictionary[current];
                        
                    }

                    dataTable.Rows.Add(dataRow); //循环添加行到DataTable中
                }
            }
            return dataTable;
        }
        /// <summary>
        /// 解析PHP json_encode fetchAll() 后的数据 包括列和列索引的数据
        /// 格式 指标 数据 指标序号 数据
        /// </summary>
        /// <param name="json"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static DataTable ToDataTable2(string json, string tableName)
        {
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            javaScriptSerializer.MaxJsonLength = Int32.MaxValue; //取得最大数值
            ArrayList arrayList = javaScriptSerializer.Deserialize<ArrayList>(json);
            DataTable dataTable = new DataTable(tableName);  //实例化
            DataTable result;
            if (arrayList.Count > 0)
            {

                int xh;
                foreach (Dictionary<string, object> dictionary in arrayList)
                {
                    if (dictionary.Keys.Count == 0)
                    {
                        result = dataTable;
                        return result;
                    }
                    if (dataTable.Columns.Count == 0)
                    {
                        xh = 0;
                        foreach (string current in dictionary.Keys)
                        {
                            if ((xh % 2 == 0) ? true : false)
                            {
                                Type type = Type.GetType("System.String");
                                if (dictionary[current] != null)
                                    type = dictionary[current].GetType();
                                dataTable.Columns.Add(current, type);
                            }
                            xh++;
                        }
                    }
                    xh = 0;
                    DataRow dataRow = dataTable.NewRow();
                    foreach (string current in dictionary.Keys)
                    {
                        if ((xh % 2 == 0) ? true : false)
                        {
                            dataRow[current] = dictionary[current];
                        }
                        xh++;
                    }

                    dataTable.Rows.Add(dataRow); //循环添加行到DataTable中
                }
            }
            return dataTable;
        }

       /// <summary>
       /// 获取网页源码信息
       /// </summary>
       /// <param name="url"></param>
       /// <returns></returns>
        public static string GetWebClient(string url)
        {
            string strHTML = "";
            WebClient myWebClient = new WebClient();
            Stream myStream = myWebClient.OpenRead(url);
            StreamReader sr = new StreamReader(myStream, System.Text.Encoding.GetEncoding("utf-8"));
            strHTML = sr.ReadToEnd();
            myStream.Close();
            return strHTML;
        }
       /// <summary>
       /// 分析页面获取数据内容
       /// </summary>
       /// <param name="htmlcode"></param>
       /// <param name="seat"></param>
       /// <param name="topstr"></param>
       /// <param name="endstr"></param>
       /// <returns></returns>
        public static string GetContent(string htmlcode, string seat, string topstr, string endstr)
        {
            int tgwz;
            if (string.IsNullOrEmpty(seat))
            {
                tgwz = 0;
            }
            else
            {
                tgwz = htmlcode.IndexOf(seat) + seat.Length;
            }
            int start = htmlcode.IndexOf(topstr, tgwz) + topstr.Length;
            int endwz = htmlcode.IndexOf(endstr, start) - start;

            return htmlcode.Substring(start, endwz);
        }
    }
}
