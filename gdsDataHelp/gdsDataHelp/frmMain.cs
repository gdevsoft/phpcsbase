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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        UCNewsAddUrl myurcnew ;
        UCNewList1 mynewlist;
        UCSpecialAdd myspadd;
        UCSpecialList myspelist;
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (myurcnew == null)
            {
                myurcnew = new UCNewsAddUrl();
                myurcnew.Dock = DockStyle.Fill;
                this.Controls.Add(myurcnew);
                myurcnew.BringToFront();
            }
            else
            {
                myurcnew.Visible = true;
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
           // name,ctype,seat,topstr,endstr
            DataTable mydt1 = new DataTable("wzconfig");
            mydt1.Columns.Add("name");
            mydt1.Columns.Add("ctype");
            mydt1.Columns.Add("seat");
            mydt1.Columns.Add("topstr");
            mydt1.Columns.Add("endstr");
            mydt1.Rows.Add(new object[] { "www.yidianzixun.com", "title", "", "<h2>", "</h2>" });
            mydt1.Rows.Add(new object[] { "www.yidianzixun.com", "subject", "<body>", "<body>", "</body>" });
            mydt1.AcceptChanges();
            mydt1.WriteXml(Application.StartupPath + @"\forwz.xml",  XmlWriteMode.WriteSchema);
        }

        private void tsmenunews_Click(object sender, EventArgs e)
        {
            if (mynewlist == null)
            {
                mynewlist = new UCNewList1();
                mynewlist.Dock = DockStyle.Fill;
                this.Controls.Add(mynewlist);
                mynewlist.BringToFront();
            }
            else
            {
                mynewlist.Visible = true;
                mynewlist.BringToFront();
            }
        }

        private void tsbutaddsp_Click(object sender, EventArgs e)
        { 
            if (myspadd == null)
            {
                myspadd = new  UCSpecialAdd();
                myspadd.Dock = DockStyle.Fill;
                this.Controls.Add(myspadd);
                myspadd.BringToFront();
            }
            else
            {
                myspadd.Visible = true;
                myspadd.BringToFront();
            }
        }

        private void TSMenspe_Click(object sender, EventArgs e)
        {
            if (myspelist == null)
            {
                myspelist = new UCSpecialList();
                myspelist.Dock = DockStyle.Fill;
                this.Controls.Add(myspelist);
                myspelist.BringToFront();
            }
            else
            {
                myspelist.Visible = true;
                myspelist.BringToFront();
            }
        }
    }
}
