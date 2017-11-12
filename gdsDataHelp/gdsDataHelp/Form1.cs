using phpCSBase;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace cwfDataHelp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            phpCSBase.phpapi myphpapi = new phpCSBase.phpapi();
           //textBox1.Text = myphpapi.data_entry(textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, "");
            textBox1.Text = myphpapi.GetCwfDataText(textBox2.Text, textBox3.Text, "admin","aaaassfg");
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            string result = "QeXUvemla5nQbJFluDWXsSx28jYPsuGtlLCh3tO9ChkJXm56C5aQZ4fwq6dGCdKN";
            string v1 = General.Decrypt3DES(result, "cwfresul");
            textBox1.Text = v1;
            textBox1.Text += "\r\n解压\r\n";
            try
            {
                 
                textBox1.Text += General.Decompress(v1);
            }
            catch(Exception cw)
            {
                textBox1.Text += "解压失败"+cw.Message;
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            string json = textBox1.Text;//Jsonstr函数读取json数据的文本txt     
            DataTable mydt1 = ToDataTable(json, "abcd");
        }
        /// <summary>
        /// 解析PHP json_encode fetchAll() 后的数据
        /// 格式 指标 数据 指标序号 数据
        /// </summary>
        /// <param name="json"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static DataTable ToDataTable(string json, string tableName)
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

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            string json = textBox1.Text;//Jsonstr函数读取json数据的文本txt     
            DataTable mydt1 =phpCSBase.General.ToDataTable1(json, "abcd");
        }
        //中文json函数方法  
 
    }
}
