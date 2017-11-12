using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace cwfDataHelp.DAL
{
   public class DALCMS
    {
       static phpCSBase.phpapi myphpapi = new phpCSBase.phpapi();
       /// <summary>
       /// 获取咨询列表
       /// </summary>
       /// <param name="rowcount"></param>
       /// <param name="pageindex"></param>
       /// <returns></returns>
       public static DataTable GetNewsList(string rowcount, string pageindex,out string errmsg)
       {
       
           //'#标题#','#来源#','#内容#'
           string args = string.Format("[##]'rowcount','{0}'[##]'pageindex','{1}'", rowcount, pageindex);//WT_CMS_Newslist
          
           DataTable mydtreg = myphpapi.GetCwfDataTable("WT_CMS_Newslist01", args, "admin", "", out errmsg);//WT_CMS_Newslist01
           return mydtreg;
       }
       /// <summary>
       /// 添加数据，异常时返回错误信息，否则返回空
       /// </summary>
       /// <param name="url"></param>
       /// <param name="title"></param>
       /// <param name="conent"></param>
       /// <returns></returns>
       public static string AddNews1(string url,string title,string conent)
       {
           string errmsg;
           //'#标题#','#来源#','#内容#'
           string args =string.Format( "[##]'标题','{0}'[##]'来源','{1}'[##]'内容','{2}'",title,url,conent);
           DataTable mydtreg = myphpapi.GetCwfDataTable("WT_CMS_NewsAdd1", args, "admin", "", out errmsg);
           if (!string.IsNullOrEmpty(errmsg))
           {
               return errmsg;
           }
           else if (string.IsNullOrEmpty(mydtreg.Rows[0][0].ToString()))
           {
               return "没有添加成功";
           }
           else if (mydtreg.Rows[0][0].ToString()=="1")
           {
               return "";     
           }
           else if (mydtreg.Rows[0][0].ToString() == "0")
           {
               return "名称重复";
           }
           return "未成功！";
       }
       /// <summary>
       /// 获取专题列表
       /// </summary>
       /// <param name="rowcount"></param>
       /// <param name="pageindex"></param>
       /// <param name="errmsg"></param>
       /// <returns></returns>
       public static DataTable GetSpecialList(string rowcount, string pageindex, out string errmsg)
       {
           string args = string.Format("[##]'rowcount','{0}'[##]'pageindex','{1}'", rowcount, pageindex);// 

           DataTable mydtreg = myphpapi.GetCwfDataTable("wt_cms_01002", args, "admin", "", out errmsg);// 
           return mydtreg;     
       }
       public static string GetSpecialVod(string speid, out string errmsg)
       {
           
           string args = string.Format("[##]'专题','{0}'",speid);
           DataTable mydtreg = myphpapi.GetCwfDataTable("wt_cms_01002", args, "admin", "", out errmsg);//
           if (mydtreg != null)
           {
               if (mydtreg.Rows.Count > 0)
               {
                   return mydtreg.Rows[0][0].ToString();
               }
           }
           return "";  
       }
       public static DataTable GetVodList(string keyword, string rowcount, string pageindex, out string errmsg)
       {
           string args = string.Format("[##]'关键字','{2}'[##]'rowcount','{0}'[##]'pageindex','{1}'", rowcount, pageindex,keyword);// 

           DataTable mydtreg = myphpapi.GetCwfDataTable("wt_cms_01003", args, "admin", "", out errmsg);// 
           return mydtreg;   
       }

       public static string SetSpeVod(string Speid,string Vodid)
       {
           string errmsg;
           string args = string.Format("[##]'专题','{0}'[##]'电影列表','{1}'", Speid, Vodid);
           DataTable mydtreg = myphpapi.GetCwfDataTable("wt_cms_01004", args, "admin", "", out errmsg);
           if (!string.IsNullOrEmpty(errmsg))
           {
               return errmsg;
           }
           else if (string.IsNullOrEmpty(mydtreg.Rows[0][0].ToString()))
           {
               return "没有设置成功";
           }
           else if (mydtreg.Rows[0][0].ToString() == "1")
           {
               return "";
           }
           else if (mydtreg.Rows[0][0].ToString() == "0")
           {
               return "名称重复";
           }
           return "未成功！";
       }
       public static string AddSpecial(string title,string seotitle,string seokeyword,string seoinfo,string content)
       {
           string errmsg;
           // '#专题名称#','#专题名称#','#seo标题#','#seo关键字#','#seo描述信息#','#专题描述#'
           string args = string.Format("[##]'专题名称','{0}'[##]'专题别名','{1}'[##]'seo标题','{2}'[##]'seo关键字','{3}'[##]'seo描述信息','{4}'[##]'专题描述','{5}'"
               , title, title, string.IsNullOrEmpty(seotitle) ? title : string.IsNullOrEmpty(seotitle) ? title : seotitle, string.IsNullOrEmpty(seokeyword) ? title : seokeyword, string.IsNullOrEmpty(seoinfo) ? title : seoinfo, string.IsNullOrEmpty(content) ? title : content);
           DataTable mydtreg = myphpapi.GetCwfDataTable("wt_cms_01001", args, "admin", "", out errmsg);
           if (!string.IsNullOrEmpty(errmsg))
           {
               return errmsg;
           }
           else if (string.IsNullOrEmpty(mydtreg.Rows[0][0].ToString()))
           {
               return "没有添加成功";
           }
           else if (mydtreg.Rows[0][0].ToString() == "1")
           {
               return "";
           }
           else if (mydtreg.Rows[0][0].ToString() == "0")
           {
               return "名称重复";
           }
           return "未成功！";
       }
    }
}
