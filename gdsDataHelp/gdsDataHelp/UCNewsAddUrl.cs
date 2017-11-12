using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cwfDataHelp
{
    public partial class UCNewsAddUrl : UserControl
    {
        public UCNewsAddUrl()
        {
            InitializeComponent();
        }
        DataTable mydtconfig = new DataTable("wzconfig");
        private void tsbutanalyse_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                return;
            }
            string errmsg;
            string[] mystr = getstring(textBox1.Text,out errmsg);
            if (!string.IsNullOrEmpty(errmsg))
            {
                textBox2.Text = errmsg;
            }
            textBox2.Text = string.Format("{0}\r\n{1}", mystr[0], mystr[1]);

        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                return;
            }
            string errmsg;
            string url=textBox1.Text;
            string[] mystr = getstring(textBox1.Text, out errmsg);
            if (!string.IsNullOrEmpty(errmsg))
            {
                textBox2.Text =string.Format("获取页面内容失败:{0}", errmsg);
            }
            errmsg = DAL.DALCMS.AddNews1(url, mystr[0], mystr[1]);
            if (string.IsNullOrEmpty(errmsg))
            {
                textBox2.Text = "添加成功！";
            }
            else
            {
                textBox2.Text = errmsg;
            }
        }

        private string[] getstring(string url,out string errmsg)
        {
            errmsg = "";
            string htmlc=phpCSBase.General.GetWebClient(url);
           //标题的配置信息
            DataRow[] drs = findconfig(url);
            if (drs.Length < 2)
            {
                errmsg =string.Format( "找不到配置信息:{0}",url);
                return null;
            }
            string bt="";
            string zt = "";
            string yc = "";
            for (int i = 0; i < drs.Length; i++)
            {
                yc = drs[i]["annul"].ToString();
                if (string.Compare(drs[i]["ctype"].ToString(), "title") == 0)
                {
                    bt = phpCSBase.General.GetContent(htmlc, drs[i]["seat"].ToString(), drs[i]["topstr"].ToString(), drs[i]["endstr"].ToString());
                    if (!string.IsNullOrEmpty(yc))
                    {
                        bt = bt.Replace(yc, "");
                    }
                }
                else if (string.Compare(drs[i]["ctype"].ToString(), "subject") == 0)
                {
                    zt = phpCSBase.General.GetContent(htmlc, drs[i]["seat"].ToString(), drs[i]["topstr"].ToString(), drs[i]["endstr"].ToString());
                    if (!string.IsNullOrEmpty(yc))
                    {
                        zt = zt.Replace(yc, "");
                    }
                }
            }
            return new String[] {bt,zt };
        }
        private DataRow[] findconfig(string url)
        {
            DataRow[] drs = mydtconfig.Select(string.Format("'{0}' like '%'+name+'%'", url.Trim().Replace("'", "")));
            return drs;
          
        }
        private void UCNewsAddUrl_Load(object sender, EventArgs e)
        {
            mydtconfig.Columns.Add("name");
            mydtconfig.Columns.Add("ctype");
            mydtconfig.Columns.Add("seat");
            mydtconfig.Columns.Add("topstr");
            mydtconfig.Columns.Add("endstr");
            mydtconfig.Columns.Add("annul");
            string cfile = System.IO.Path.Combine(Application.StartupPath, @"config/decodeRules.xml");
            if (System.IO.File.Exists(cfile))
            {
                mydtconfig.ReadXml(cfile);
            }
            //name,ctype,seat,topstr,endstr ,名称,类型,前置位置符号,开始符号，结束符号
        }

        private void tsbutclose_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

      
    }
}
