using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cwfDataHelp
{
    public partial class frmNews : Form
    {
        public frmNews()
        {
            InitializeComponent();
        }
        phpCSBase.phpapi myphpapi = new phpCSBase.phpapi();
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string errmsg;

            DataTable mydtreg = myphpapi.GetCwfDataTable("WT_CMS_Newslist", "[##]'abc','abc'", "admin", "", out errmsg);
            if (string.IsNullOrEmpty(errmsg))
            {
                bindingSource1.DataSource = mydtreg;
                dataGridView1.DataSource = bindingSource1;
            }
            else
            {
                MessageBox.Show(errmsg);
            }
        }
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            string errmsg;
            DataTable mydtreg = DAL.DALCMS.GetNewsList("200", "100", out errmsg);
            if (string.IsNullOrEmpty(errmsg))
            {
                bindingSource1.DataSource = mydtreg;
                dataGridView1.DataSource = bindingSource1;
            }
            else
            {
                MessageBox.Show(errmsg);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            string errmsg;
            //'#标题#','#来源#','#内容#'
            string args = "[##]'标题','测试的标题2'[##]'来源','测试的来源2'[##]'内容','测试的内容2'";
            DataTable mydtreg = myphpapi.GetCwfDataTable("WT_CMS_NewsAdd1", args, "admin", "", out errmsg);
            if (!string.IsNullOrEmpty(errmsg))
            {
                MessageBox.Show(errmsg);
            }
            MessageBox.Show(mydtreg.Rows[0][0].ToString());
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            DataTable mydt1 = new DataTable("wzconfig");
            mydt1.Columns.Add("name");
            mydt1.Columns.Add("ctype");
            mydt1.Columns.Add("seat");
            mydt1.Columns.Add("topstr");
            mydt1.Columns.Add("endstr");
            mydt1.Columns.Add("annul");
            mydt1.Rows.Add(new object[] { "www.yidianzixun.com", "title", "", "<h2>", "</h2>","" });
            mydt1.Rows.Add(new object[] { "www.yidianzixun.com", "subject", "<body>", "<body>", "</body>", "<!-- wemedia true -->" });
            mydt1.AcceptChanges();
            mydt1.WriteXml(Application.StartupPath + @"\forwz.xml", XmlWriteMode.WriteSchema);
        }

     
    }
}
