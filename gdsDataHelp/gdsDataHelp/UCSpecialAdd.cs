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
    public partial class UCSpecialAdd : UserControl
    {
        public UCSpecialAdd()
        {
            InitializeComponent();
        }

        private void tsbutsave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                errorProvider1.SetError(textBox1, "必须填写标题名称");
                return;
            }
            string mystr = DAL.DALCMS.AddSpecial(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text);
            if (string.IsNullOrEmpty(mystr))
            {
                DialogResult mydrg = MessageBox.Show("添加成功，是否继续添加?", "提示确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (mydrg == DialogResult.Yes)
                {
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox1.SelectAll();
                    textBox1.Focus();
                }
                else
                {
                    this.Visible = false;
                }
            }
            else if (mystr.Equals("名称重复"))
            {
                // MessageBox.Show("标题名称重复", "添加失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                errorProvider1.SetError(textBox1, "标题名称重复");
            }
            else
            {
                MessageBox.Show(mystr, "添加失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

    }
}
