using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DCTS.CustomComponents;
using Order.Buiness;
using Order.DB;

namespace JNOrderManagermentSystem
{
    public partial class frmInfoCenter : Form
    {
        DateTime startAt;
        DateTime endAt;
        string txfind;
        List<clsOrderinfo> Orderinfolist_Server;
        private SortableBindingList<clsOrderinfo> sortableOrderList;
        List<clscustomerinfo> customerinfolist_Server;


        public frmInfoCenter(string type)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;



        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            //this.pbStatus.Value = 0;
            this.toolStripLabel1.Text = "";

            txfind = this.textBox8.Text;
            if (txfind.Length <= 0)
            {
                MessageBox.Show("请输入要查找的相关信息 ！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;

            }
            if (radioButton1.Checked == true)
            {
                customerinfolist_Server = new List<clscustomerinfo>();

                Read_order();

                List<string> customer_nameList = (from v in Orderinfolist_Server select v.customer_name).Distinct().ToList();
                string conditions_new = "";


                for (int i = 0; i < customer_nameList.Count; i++)
                {
                    if (i == 0)
                        conditions_new += "'" + customer_nameList[i] + "'";
                    else
                        conditions_new += "," + "'" + customer_nameList[i] + "'";
                }
                if (conditions_new != "")
                {
                    string strSelect = "select * from JNOrder_customer where customer_name in ( " + conditions_new + " )";

                    strSelect += " order by customer_id desc";

                    clsAllnew BusinessHelp = new clsAllnew();
                    customerinfolist_Server = new List<clscustomerinfo>();
                    customerinfolist_Server = BusinessHelp.findcustomer(strSelect);
                }
            }
            else
            {
                // Read_customer();

                string strSelect = "select * from JNOrder_order where ";


                strSelect += "   customer_name like '%" + txfind + "%'";
                if (txfind == "所有")
                    strSelect = "select * from JNOrder_order";
                clsAllnew BusinessHelp = new clsAllnew();
                Orderinfolist_Server = new List<clsOrderinfo>();
                Orderinfolist_Server = BusinessHelp.findOrder(strSelect);



            }


            this.BindDataGridView();
        }

        private void Read_customer()
        {
            //string strSelect = "select * from JNOrder_customer where Input_Date>='" + startAt.ToString("yyyy/MM/dd") + "'" + "and " + "Input_Date<='" + endAt.ToString("yyyy/MM/dd") + "'";
            string strSelect = "select * from JNOrder_customer where ";

            if (txfind.Length > 0)
            {
                //strSelect += " And customer_name like '%" + txfind + "%'";
                strSelect += "  customer_name like '%" + txfind + "%'";

                if (txfind == "所有")
                    strSelect = "select * from JNOrder_customer";
            }

            strSelect += " order by customer_id desc";

            clsAllnew BusinessHelp = new clsAllnew();
            customerinfolist_Server = new List<clscustomerinfo>();
            customerinfolist_Server = BusinessHelp.findcustomer(strSelect);
        }

        private void Read_order()
        {
            //string strSelect = "select * from JNOrder_order where Input_Date>='" + startAt.ToString("yyyy/MM/dd") + "'" + "and " + "Input_Date<='" + endAt.ToString("yyyy/MM/dd") + "'";
            string strSelect = "select * from JNOrder_order where ";


            if (txfind.Length > 0)
            {
                //strSelect += " And order_no like '%" + txfind + "%'";
                strSelect += "   order_no like '%" + txfind + "%'";
                if (txfind == "所有")
                    strSelect = "select * from JNOrder_order";

            }

            strSelect += " order by order_id desc";

            clsAllnew BusinessHelp = new clsAllnew();
            Orderinfolist_Server = new List<clsOrderinfo>();
            Orderinfolist_Server = BusinessHelp.findOrder(strSelect);
        }
        private void BindDataGridView()
        {

            var qtyTable = new DataTable();

            if (radioButton1.Checked == false)
            {
                qtyTable.Columns.Add("客户", System.Type.GetType("System.String"));//0
                qtyTable.Columns.Add("订货时间", System.Type.GetType("System.String"));//0
                qtyTable.Columns.Add("订单号", System.Type.GetType("System.String"));//0
                qtyTable.Columns.Add("产品型号", System.Type.GetType("System.String"));//0
                qtyTable.Columns.Add("名称", System.Type.GetType("System.String"));//0
                qtyTable.Columns.Add("数量", System.Type.GetType("System.String"));//0
                qtyTable.Columns.Add("单价", System.Type.GetType("System.String"));//0
                qtyTable.Columns.Add("金额", System.Type.GetType("System.String"));//0
                qtyTable.Columns.Add("预计交货时间 ", System.Type.GetType("System.String"));//0
                qtyTable.Columns.Add("交货时间2", System.Type.GetType("System.String"));//0
                qtyTable.Columns.Add("订单管理员", System.Type.GetType("System.String"));//0
                qtyTable.Columns.Add("开票", System.Type.GetType("System.String"));//0
                qtyTable.Columns.Add("是否交货", System.Type.GetType("System.String"));//0
                qtyTable.Columns.Add("付款日期", System.Type.GetType("System.String"));//0
                qtyTable.Columns.Add("备注", System.Type.GetType("System.String"));//0
                qtyTable.Columns.Add("录入时间", System.Type.GetType("System.String"));//0
                foreach (clsOrderinfo k in Orderinfolist_Server)//new  替换 
                {
                    qtyTable.Rows.Add(qtyTable.NewRow());
                }
                int jk = 0;
                foreach (clsOrderinfo k in Orderinfolist_Server)//new  替换 
                {
                    #region MyRegion
                    qtyTable.Rows[jk][0] = k.customer_name;
                    qtyTable.Rows[jk][1] = k.dinghuoshijian;
                    qtyTable.Rows[jk][2] = k.order_no;
                    qtyTable.Rows[jk][3] = k.Product_no;
                    qtyTable.Rows[jk][4] = k.Product_name;
                    qtyTable.Rows[jk][5] = k.shuliang;
                    qtyTable.Rows[jk][6] = k.Product_salse;
                    qtyTable.Rows[jk][7] = k.jine;
                    qtyTable.Rows[jk][8] = k.yujijiaohuoshijian;
                    qtyTable.Rows[jk][9] = k.jianhuoshijian2;
                    qtyTable.Rows[jk][10] = k.dingdanguanliyuan;
                    qtyTable.Rows[jk][11] = k.kaipiao;
                    qtyTable.Rows[jk][12] = k.shifoujiaohuo;
                    qtyTable.Rows[jk][13] = k.fukuanriqi;
                    qtyTable.Rows[jk][14] = k.beizhu;
                    qtyTable.Rows[jk][15] = k.Input_Date;
                    jk++;

                    #endregion

                }
                if (Orderinfolist_Server != null)
                {
                    this.bindingSource1.DataSource = qtyTable;
                    this.dataGridView1.DataSource = this.bindingSource1;

                    //sortableOrderList = new SortableBindingList<clsOrderinfo>(Orderinfolist_Server);
                    //bindingSource1.DataSource = new SortableBindingList<clsOrderinfo>(Orderinfolist_Server);
                    //dataGridView1.AutoGenerateColumns = false;

                    //dataGridView1.DataSource = bindingSource1;
                    //this.toolStripLabel1.Text = "条数：" + sortableOrderList.Count.ToString();
                }

            }
            else if (radioButton2.Checked == false)
            {

                qtyTable.Columns.Add("客户名称", System.Type.GetType("System.String"));//0
                qtyTable.Columns.Add("地址", System.Type.GetType("System.String"));//0
                qtyTable.Columns.Add("税号", System.Type.GetType("System.String"));//0
                qtyTable.Columns.Add("开户行", System.Type.GetType("System.String"));//0
                qtyTable.Columns.Add("账号", System.Type.GetType("System.String"));//0
                qtyTable.Columns.Add("电话", System.Type.GetType("System.String"));//0
                qtyTable.Columns.Add("联系人", System.Type.GetType("System.String"));//0
                qtyTable.Columns.Add("录入时间", System.Type.GetType("System.String"));//0
                foreach (clscustomerinfo k in customerinfolist_Server)//new  替换 
                {
                    qtyTable.Rows.Add(qtyTable.NewRow());
                }
                int jk = 0;
                foreach (clscustomerinfo k in customerinfolist_Server)//new  替换 
                {
                    #region MyRegion
                    qtyTable.Rows[jk][0] = k.customer_name;
                    qtyTable.Rows[jk][1] = k.customer_adress;
                    qtyTable.Rows[jk][2] = k.customer_shuihao;
                    qtyTable.Rows[jk][3] = k.customer_bank;
                    qtyTable.Rows[jk][4] = k.customer_account;
                    qtyTable.Rows[jk][5] = k.customer_phone;
                    qtyTable.Rows[jk][6] = k.customer_contact;

                    qtyTable.Rows[jk][7] = k.Input_Date;
                    jk++;
                    #endregion

                }

                this.bindingSource1.DataSource = qtyTable;
                this.dataGridView1.DataSource = this.bindingSource1;

            }
            if (dataGridView1 != null)
                this.toolStripLabel1.Text = "条目 " + this.dataGridView1.RowCount.ToString();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
        {
            if (this.dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Sorry , No Data Output !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = ".csv";
            saveFileDialog.Filter = "csv|*.csv";
            string strFileName = "信   息   中    心" + "_" + DateTime.Now.ToString("yyyyMMddHHmmss");
            saveFileDialog.FileName = strFileName;
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                strFileName = saveFileDialog.FileName.ToString();
            }
            else
            {
                return;
            }
            FileStream fa = new FileStream(strFileName, FileMode.Create);
            StreamWriter sw = new StreamWriter(fa, Encoding.Unicode);
            string delimiter = "\t";
            string strHeader = "";
            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                strHeader += this.dataGridView1.Columns[i].HeaderText + delimiter;
            }
            sw.WriteLine(strHeader);

            //output rows data
            for (int j = 0; j < this.dataGridView1.Rows.Count; j++)
            {
                string strRowValue = "";

                for (int k = 0; k < this.dataGridView1.Columns.Count; k++)
                {
                    if (this.dataGridView1.Rows[j].Cells[k].Value != null)
                    {
                        strRowValue += this.dataGridView1.Rows[j].Cells[k].Value.ToString().Replace("\r\n", " ").Replace("\n", "") + delimiter;
                        if (this.dataGridView1.Rows[j].Cells[k].Value.ToString() == "LIP201507-35")
                        {

                        }

                    }
                    else
                    {
                        strRowValue += this.dataGridView1.Rows[j].Cells[k].Value + delimiter;
                    }
                }
                sw.WriteLine(strRowValue);
            }
            sw.Close();
            fa.Close();
            MessageBox.Show("下载完成 ！", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

    }
}
