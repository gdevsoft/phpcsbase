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
    public partial class UCSpeVod : UserControl
    {
        public UCSpeVod()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 专题编号
        /// </summary>
        public string SpeID
        {
            get
            {
               return toolStripLabel1.Text;
            }
            set
            {
                toolStripLabel1.Text = value;
                string errmsg;
                string vd = DAL.DALCMS.GetSpecialVod(value, out errmsg);
                if (!string.IsNullOrEmpty(vd))
                {
                    Vodids = string.Format("{0},", DAL.DALCMS.GetSpecialVod(value, out errmsg));
                }
                else
                {
                    Vodids = "";
                }
            }
        }
        /// <summary>
        /// 相关影视编号
        /// </summary>
        private string Vodids;
        public void getData(string keyword)
        {
            string errmsg;
            DataTable mydt1 = DAL.DALCMS.GetVodList(keyword,"50", "0", out errmsg); 
            if (string.IsNullOrEmpty(errmsg))
            {
                mydt1.Columns.Add("选择", typeof(bool));
                mydt1.Columns["选择"].SetOrdinal(0);
                 
                bindingSource1.DataSource = mydt1;
                dgvlist1.DataSource = bindingSource1;
                dgvlist1.Columns["vod_id"].Visible = false;
                dgvlist1.RowHeadersWidth = 4;//  RowsHeaderWidth
            }
            else
            {
                MessageBox.Show(this.FindForm(), errmsg, "获取失败");
            }
        }

        private void tsbutshow_Click(object sender, EventArgs e)
        {
            getData(txtword.Text);
        }

        private void txtword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                getData(txtword.Text);
            }
        }

        private void tsbutsave_Click(object sender, EventArgs e)
        {
            string vodbh = "";
            int rows = dgvlist1.Rows.Count;
            StringBuilder mysb = new StringBuilder();
            for (int i = 0; i < rows; i++)
            {
                if (dgvlist1.Rows[i].Cells["选择"].Value == null)
                {
                    continue;
                }
                if (dgvlist1.Rows[i].Cells["选择"].Value.GetType().Equals(System.DBNull.Value.GetType()))
                {
                    continue;
                }
                if (!(Boolean)dgvlist1.Rows[i].Cells["选择"].Value)
                {
                    continue;
                }
                vodbh = dgvlist1.Rows[i].Cells["vod_id"].Value.ToString();
                if (Vodids.Contains(string.Format("{0},", vodbh)))
                {
                    continue;
                }
                if (mysb.ToString() == "")
                {
                    mysb.Append(vodbh);
                }
                else
                {
                    mysb.Append(string.Format(",{0}", vodbh));
                }

            }
            if (string.IsNullOrEmpty(mysb.ToString()))
            {
                return;
            }
            string reg = DAL.DALCMS.SetSpeVod(SpeID, string.Format("{0}{1}", Vodids, mysb.ToString()));
            if (!string.IsNullOrEmpty(reg))
            {
                MessageBox.Show(reg, "保存失败!", MessageBoxButtons.OK);
            }
            else
            {
                this.Visible = false;
            }
        }

        private void tsbutback_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
