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
    public partial class UCSpecialList : UserControl
    {
        public UCSpecialList()
        {
            InitializeComponent();
        }
        private UCSpeVod myuc;
        private void tsbutref_Click(object sender, EventArgs e)
        {
            getData();
        }
        public void getData()
        {
            string errmsg;
            DataTable mydt1 = DAL.DALCMS.GetSpecialList("50", "0", out errmsg);
            if (string.IsNullOrEmpty(errmsg))
            {
                bindingSource1.DataSource = mydt1;
                dataGridView1.DataSource = bindingSource1;
              //  dataGridView1.Columns["news_id"].Visible = false;
                dataGridView1.RowHeadersWidth = 4;//  RowsHeaderWidth
            }
            else
            {
                MessageBox.Show(this.FindForm(), errmsg, "获取失败");
            }
        }

        private void UCSpecialList_Load(object sender, EventArgs e)
        {
            getData();
        }
  
        private void tsbutset_Click(object sender, EventArgs e)
        {
            if(this.dataGridView1.CurrentCell ==null)
            {
                return ;
            }
            if (myuc == null)
            {
                myuc = new UCSpeVod();
                myuc.Dock = DockStyle.Fill;
                myuc.SpeID = this.dataGridView1.CurrentRow.Cells["special_id"].Value.ToString();
                this.Controls.Add(myuc);
                myuc.BringToFront();
            }
            else
            {
                myuc.SpeID = this.dataGridView1.CurrentRow.Cells["special_id"].Value.ToString();
                myuc.Visible = true;
                myuc.BringToFront();
            }

        }

    }
}
