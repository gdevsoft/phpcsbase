using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Data;
namespace phpCSBase
{
    public class phpapi
    {
        public string data_entry(string name, string args, string username, string appkey, string signed, string updata)
        {
            string result;
            cwfapiService.cwf_servicePortTypeClient myclient = new cwfapiService.cwf_servicePortTypeClient();
            myclient.Open();
            try
            {
                result = myclient.job_dataentry(name, args, username, appkey, signed, updata);
            }
            catch (Exception cw)
            {
                result = string.Format("err:发生异常{0}", cw.Message);
            }
            myclient.Abort();
            return result; 
        }
        /// <summary>
        /// 获取数据表格
        /// </summary>
        /// <param name="name"></param>
        /// <param name="args"></param>
        /// <param name="username"></param>
        /// <param name="updata"></param>
        /// <returns></returns>
        public DataTable GetCwfDataTable(string name, string args, string username, string updata,out string errmsg)
        {
            errmsg = null;
            string json = GetCwfDataText(name, args, username, updata);
            if (string.IsNullOrEmpty(json))
            {
                errmsg = "无数据返回";
                return null;
            }
            if (json.Length > 3)
            {
                if (json.Substring(0, 3).Equals("err"))
                {
                    errmsg = json;
                    return null;
                }
            }
            DataTable mydt1 = phpCSBase.General.ToDataTable1(json, "jtable");
            return mydt1;
        }
        /// <summary>
        /// 获取数据信息 json文本
        /// </summary>
        /// <param name="name"></param>
        /// <param name="args"></param>
        /// <param name="username"></param>
        /// <param name="updata"></param>
        /// <returns></returns>
        public string GetCwfDataText(string name, string args,string username,string updata)
        {
            /*
             *name    只加密
             *username 只加密
             *args    压缩后加密
             *appkey  只加密
             *update  压缩后加密
             *
             */
            if (string.IsNullOrEmpty(name))
            {
                return "err:name没有提供";
            }
            if (string.IsNullOrEmpty(args))
            {
                return "err:args没有提供";
            }
            string appkey = ConfigurationManager.AppSettings["appkey"];
            if (string.IsNullOrEmpty(appkey))
            {
                return "err:没有配置appkey信息";
            }
            string appserct = ConfigurationManager.AppSettings["appserct"];
            if (string.IsNullOrEmpty(appserct))
            {
                return "err:没有配置appserct信息";
            }
            string vname = General.Encrypt3DES(name, "cwfapp11");
            string vargs = General.Encrypt3DES(General.Compress(args), "cwfapp21");
            string vupdata;
            if (string.IsNullOrEmpty(updata))
            {
                vupdata = "";
            }
            else 
            {
                vupdata = General.Encrypt3DES(General.Compress(updata), "cwfapp31");
            }
            string vusername;
            if (string.IsNullOrEmpty(username))
            {
                vusername = "";
            }
            else
            {
                vusername = General.Encrypt3DES(username, "cwfuser1");
            }
            string vappkey = General.Encrypt3DES(appkey, "cwfappke");

            string sign = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(string.Format("{0}{1}{2}{3}#{4}",vname,vargs,vusername,vappkey,appserct), "MD5").ToLower();
            string result = data_entry(vname, vargs,vusername, vappkey, sign, vupdata);
            if (string.IsNullOrEmpty(result))
            {
                return result;
            }
            if (string.Compare(result.Substring(0, 3),"err")==0)
            {
                return result;
            }
            //解密后，解压处理
            string jresult = General.Decrypt3DES(result,"cwfresul");
            return General.Decompress(jresult);
        }

    }
}
