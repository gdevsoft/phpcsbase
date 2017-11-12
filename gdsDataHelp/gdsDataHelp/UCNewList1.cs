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
    public partial class UCNewList1 : UserControl
    {
        public UCNewList1()
        {
            InitializeComponent();
        }
        public void getData()
        {
            string errmsg;
            DataTable mydt1 = DAL.DALCMS.GetNewsList("50", "0", out errmsg);
            if (string.IsNullOrEmpty(errmsg))
            {
                bindingSource1.DataSource = mydt1;
                dataGridView1.DataSource = bindingSource1;
                dataGridView1.Columns["news_id"].Visible = false;
               dataGridView1.RowHeadersWidth=4;//  RowsHeaderWidth
            }
            else
            {
                MessageBox.Show(this.FindForm(), errmsg,"获取失败");
            }
        }

        private void tsbutref_Click(object sender, EventArgs e)
        {
            getData();
        }

        private void UCNewList1_Load(object sender, EventArgs e)
        {
            getData();
        } 
    }
}
