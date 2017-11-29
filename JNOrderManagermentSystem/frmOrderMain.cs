using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DCTS.CustomComponents;
using Order.Buiness;
using Order.Common;
using Order.DB;

namespace JNOrderManagermentSystem
{
    public partial class frmOrderMain : Form
    {
        DateTime startAt;
        DateTime endAt;
        List<clsOrderinfo> Orderinfolist_Server;

        List<clsOrderinfo> deletedorderList;
        List<clsOrderinfo> FilterOrderResults;
        int rowcount;
        string txfind;
        private SortableBindingList<clsOrderinfo> sortableOrderList;
        List<int> changeindex;
        int RowRemark = 0;
        int cloumn = 0;
        private Hashtable dataGridChanges = null;
        DateTimePicker dtp = new DateTimePicker();  //这里实例化一个DateTimePicker控件  
        Rectangle _Rectangle;  

        public frmOrderMain(string user)
        {
            InitializeComponent();
            this.dataGridChanges = new Hashtable();
            changeindex = new List<int>();
            Orderinfolist_Server = new List<clsOrderinfo>();
            deletedorderList = new List<clsOrderinfo>();
            this.WindowState = FormWindowState.Maximized;



            binddav_combox();



            this.BindDataGridView();

            dataGridView1.Controls.Add(dtp);
            dtp.Visible = false;  //先不让它显示  
            dtp.ShowUpDown = true;
            dtp.Format = DateTimePickerFormat.Custom;  //设置日期格式为2010-08-05  
            dtp.CustomFormat = "yyyy/MM/dd";
            dtp.TextChanged += new EventHandler(dtp_TextChange); //为时间控件加入事件dtp_TextChange  


        }

        private void binddav_combox()
        {

            string strSelect = "select * from JNOrder_customer";
            strSelect += " order by customer_id desc";
            clsAllnew BusinessHelp = new clsAllnew();
            List<clscustomerinfo> customerinfolist_Server = new List<clscustomerinfo>();
            customerinfolist_Server = BusinessHelp.findcustomer(strSelect);
            this.customer_name.DisplayMember = "customer_name";
            this.customer_name.ValueMember = "customer_name";
            this.customer_name.DataSource = customerinfolist_Server;

            strSelect = "select * from JNOrder_product";
            strSelect += " order by Product_id desc";
            List<clsProductinfo> Productinfolist_Server = new List<clsProductinfo>();
            Productinfolist_Server = BusinessHelp.findProductr(strSelect);
            this.Product_no.DisplayMember = "Product_no";
            this.Product_no.ValueMember = "Product_no";
            this.Product_no.DataSource = Productinfolist_Server;

            //
            this.Product_name.DisplayMember = "Product_name";
            this.Product_name.ValueMember = "Product_name";
            this.Product_name.DataSource = Productinfolist_Server;
            //
            this.Product_salse.DisplayMember = "Product_salse";
            this.Product_salse.ValueMember = "Product_salse";
            this.Product_salse.DataSource = Productinfolist_Server;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

            var form = new frmaddProcuct("");

            if (form.ShowDialog() == DialogResult.OK)
            {

            }

        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(" 确认删除这条信息 , 继续 ?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

            }
            else
                return;

            var oids = GetOrderIdsBySelectedGridCell();
            for (int j = 0; j < oids.Count; j++)
            {
                var filtered = Orderinfolist_Server.FindAll(s => s.order_id == oids[j]);
                clsAllnew BusinessHelp = new clsAllnew();
                //批量删 
                int istu = BusinessHelp.deleteOrder(filtered[0].order_id.ToString());

                for (int i = 0; i < filtered.Count; i++)
                {
                    //单个删除
                    if (filtered[i].order_id != 0)
                    {
                        Orderinfolist_Server.Remove(Orderinfolist_Server.Where(o => o.order_id == filtered[i].order_id).Single());
                    }
                    if (istu != 1)
                    {
                        MessageBox.Show("删除失败，请查看" + filtered[i].order_no + filtered[i].Product_name, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            BindDataGridView();

        }
        private List<long> GetOrderIdsBySelectedGridCell()
        {

            List<long> order_ids = new List<long>();
            var rows = GetSelectedRowsBySelectedCells(dataGridView1);
            foreach (DataGridViewRow row in rows)
            {
                var Diningorder = row.DataBoundItem as clsOrderinfo;
                order_ids.Add((long)Diningorder.order_id);
            }

            return order_ids;
        }
        private IEnumerable<DataGridViewRow> GetSelectedRowsBySelectedCells(DataGridView dgv)
        {
            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            foreach (DataGridViewCell cell in dgv.SelectedCells)
            {
                rows.Add(cell.OwningRow);

            }
            rowcount = dgv.SelectedCells.Count;

            return rows.Distinct();
        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            this.pbStatus.Value = 0;
            this.toolStripLabel1.Text = "";

            startAt = this.stockOutDateTimePicker.Value.AddDays(0).Date;
            endAt = this.stockInDateTimePicker1.Value.AddDays(0).Date;
            txfind = this.textBox8.Text;

            string strSelect = "select * from JNOrder_order where Input_Date>='" + startAt.ToString("yyyy/MM/dd") + "'" + "and " + "Input_Date<='" + endAt.ToString("yyyy/MM/dd") + "'";
            // strSelect = "select * from JNOrder_customer where Input_Date BETWEEN #" + startAt + "# AND #" + endAt + "#";//成功


            if (txfind.Length > 0)
            {
                strSelect += " And order_no like '%" + txfind + "%'";
                if (txfind == "所有")
                    strSelect = "select * from JNOrder_order";

            }

            strSelect += " order by order_id desc";

            clsAllnew BusinessHelp = new clsAllnew();
            Orderinfolist_Server = new List<clsOrderinfo>();
            Orderinfolist_Server = BusinessHelp.findOrder(strSelect);
            this.BindDataGridView();
        }

            private void BindDataGridView()
            {
                if (Orderinfolist_Server != null)
                {

                    sortableOrderList = new SortableBindingList<clsOrderinfo>(Orderinfolist_Server);
                    bindingSource1.DataSource = new SortableBindingList<clsOrderinfo>(Orderinfolist_Server);
                    dataGridView1.AutoGenerateColumns = false;

                    dataGridView1.DataSource = bindingSource1;
                    this.toolStripLabel1.Text = "条数：" + sortableOrderList.Count.ToString();
                }
            }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                int s = this.tabControl1.SelectedIndex;
                if (s == 0)
                {
                    dataGridView1.Enabled = false;
                    if (changeindex.Count < 1)
                    {
                        IEnumerable<int> orderIds = GetChangedOrderIds();
                        foreach (var id in orderIds.Distinct())
                        {
                            changeindex.Add(id);
                        }
                    }



                }

                if (backgroundWorker2.IsBusy != true)
                {
                    backgroundWorker2.RunWorkerAsync(new WorkerArgument { OrderCount = 0, CurrentIndex = 0 });

                }
                dataGridChanges.Clear();

            }
            catch (Exception ex)
            {
                dataGridChanges.Clear();
                return;
                throw;
            }
        }
        private IEnumerable<int> GetChangedOrderIds()
        {

            List<int> rows = new List<int>();
            foreach (DictionaryEntry entry in dataGridChanges)
            {
                var key = entry.Key as string;
                if (key.EndsWith("_changed"))
                {
                    int row = Int32.Parse(key.Split('_')[0]);
                    rows.Add(row);
                }

            }
            return rows.Distinct();
        }


        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridViewRow dgrSingle = dataGridView1.Rows[e.RowIndex];
            string cell_key = e.RowIndex.ToString() + "_" + e.ColumnIndex.ToString();

            if (!dataGridChanges.ContainsKey(cell_key))
            {
                dataGridChanges[cell_key] = dgrSingle.Cells[e.ColumnIndex].Value;
            }



        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                string cell_key = e.RowIndex.ToString() + "_" + e.ColumnIndex.ToString() + "_changed";

                if (dataGridChanges.ContainsKey(cell_key))
                {
                    e.CellStyle.BackColor = Color.Red;
                    e.CellStyle.SelectionBackColor = Color.DarkRed;

                }
            }
            catch (Exception ex)
            {


            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            string cell_key = e.RowIndex.ToString() + "_" + e.ColumnIndex.ToString();
            var new_cell_value = row.Cells[e.ColumnIndex].Value;
            var original_cell_value = dataGridChanges[cell_key];
            if (new_cell_value == null && original_cell_value == null)
            {
                dataGridChanges.Remove(cell_key + "_changed");
            }
            else if ((new_cell_value == null && original_cell_value != null) || (new_cell_value != null && original_cell_value == null) || !new_cell_value.Equals(original_cell_value))
            {
                dataGridChanges[cell_key + "_changed"] = new_cell_value;
            }
            else
            {
                dataGridChanges.Remove(cell_key + "_changed");
            }
            //查找联想功能

            if (e.ColumnIndex == 0)
            {
                //string strSelect = "select * from JNOrder_customer";
                //txfind = dataGridView1.Rows[e.RowIndex].Cells["customer_name"].EditedFormattedValue.ToString();
                //if (txfind.Length > 0)
                //{
                //    strSelect += " where  customer_name like '%" + txfind + "%'";
                //    if (txfind == "所有")
                //        strSelect = "select * from JNOrder_customer";

                //}

                //strSelect += " order by customer_id desc";

                //clsAllnew BusinessHelp = new clsAllnew();
                //List<clscustomerinfo> customerinfolist_Server = new List<clscustomerinfo>();
                //customerinfolist_Server = BusinessHelp.findcustomer(strSelect);
                //this.customer_name.DisplayMember = "customer_name";
                //this.customer_name.ValueMember = "customer_name";
                //this.customer_name.DataSource = customerinfolist_Server;

                //var form = new frmAlterShow("customer_name", customerinfolist_Server);

                //if (form.ShowDialog() == DialogResult.OK)
                //{

                //}

            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            bool success = dailysaveList(worker, e);
        }
        private bool dailysaveList(BackgroundWorker worker, DoWorkEventArgs e)
        {
            WorkerArgument arg = e.Argument as WorkerArgument;
            clsAllnew BusinessHelp = new clsAllnew();
            bool success = true;
            try
            {

                int rowCount = changeindex.Count;
                arg.OrderCount = rowCount;
                int j = 1;
                int progress = 0;
                #region MyRegion
                for (int ik = 0; ik < changeindex.Count; ik++)
                {
                    j = ik;

                    arg.CurrentIndex = j + 1;
                    progress = Convert.ToInt16(((j + 1) * 1.0 / rowCount) * 100);

                    int i = changeindex[ik];
                    var row = dataGridView1.Rows[i];

                    var model = row.DataBoundItem as clsOrderinfo;

                    clsOrderinfo item = new clsOrderinfo();

                    item.customer_name = Convert.ToString(dataGridView1.Rows[i].Cells["customer_name"].EditedFormattedValue.ToString());
                    if (dataGridView1.Rows[i].Cells["dinghuoshijian"].EditedFormattedValue.ToString()!="")
                    item.dinghuoshijian = Convert.ToDateTime(dataGridView1.Rows[i].Cells["dinghuoshijian"].EditedFormattedValue.ToString());

                    item.order_no = Convert.ToString(dataGridView1.Rows[i].Cells["order_no"].EditedFormattedValue.ToString());

                    item.Product_no = Convert.ToString(dataGridView1.Rows[i].Cells["Product_no"].EditedFormattedValue.ToString());

                    item.Product_name = Convert.ToString(dataGridView1.Rows[i].Cells["Product_name"].EditedFormattedValue.ToString());

                    item.shuliang = Convert.ToString(dataGridView1.Rows[i].Cells["shuliang"].EditedFormattedValue.ToString());

                    item.Product_salse = Convert.ToString(dataGridView1.Rows[i].Cells["Product_salse"].EditedFormattedValue.ToString());

                    item.jine = Convert.ToString(dataGridView1.Rows[i].Cells["jine"].EditedFormattedValue.ToString());

                    if (dataGridView1.Rows[i].Cells["yujijiaohuoshijian"].EditedFormattedValue.ToString() != null && dataGridView1.Rows[i].Cells["yujijiaohuoshijian"].EditedFormattedValue.ToString() != "")
                        item.yujijiaohuoshijian = Convert.ToDateTime(dataGridView1.Rows[i].Cells["yujijiaohuoshijian"].EditedFormattedValue.ToString());
                    if (dataGridView1.Rows[i].Cells["jianhuoshijian2"].EditedFormattedValue.ToString() != null && dataGridView1.Rows[i].Cells["jianhuoshijian2"].EditedFormattedValue.ToString() != "")
                        item.jianhuoshijian2 = Convert.ToDateTime(dataGridView1.Rows[i].Cells["jianhuoshijian2"].EditedFormattedValue.ToString());

                    item.dingdanguanliyuan = Convert.ToString(dataGridView1.Rows[i].Cells["dingdanguanliyuan"].EditedFormattedValue.ToString());

                    item.kaipiao = Convert.ToString(dataGridView1.Rows[i].Cells["kaipiao"].EditedFormattedValue.ToString());


                    item.shifoujiaohuo = Convert.ToString(dataGridView1.Rows[i].Cells["shifoujiaohuo"].EditedFormattedValue.ToString());
                    if (dataGridView1.Rows[i].Cells["fukuanriqi"].EditedFormattedValue.ToString() != null && dataGridView1.Rows[i].Cells["fukuanriqi"].EditedFormattedValue.ToString() != "")
                        item.fukuanriqi = Convert.ToDateTime(dataGridView1.Rows[i].Cells["fukuanriqi"].EditedFormattedValue.ToString());

                    item.beizhu = Convert.ToString(dataGridView1.Rows[i].Cells["beizhu"].EditedFormattedValue.ToString());

                    item.xinzeng = Convert.ToString(dataGridView1.Rows[i].Cells["xinzeng"].EditedFormattedValue.ToString());

                    item.Input_Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));
                    item.order_id = model.order_id;

                #endregion

                    #region MyRegion
                    var startAt = this.stockOutDateTimePicker.Value.AddDays(0).Date;
                    string conditions = "";

                    #region  构造查询条件
                    if (item.customer_name != null)
                    {
                        conditions += " customer_name ='" + item.customer_name + "'";
                    }
                    if (item.dinghuoshijian != null)
                    {
                        conditions += " ,dinghuoshijian ='" + item.dinghuoshijian.ToString("yyyy/MM/dd") + "'";
                    }
                    if (item.order_no != null)
                    {
                        conditions += " ,order_no ='" + item.order_no + "'";
                    }
                    if (item.Product_no != null)
                    {
                        conditions += " ,Product_no ='" + item.Product_no + "'";
                    }
                    if (item.Product_name != null)
                    {
                        conditions += " ,Product_name ='" + item.Product_name + "'";
                    }

                    if (item.shuliang != null)
                    {
                        conditions += " ,shuliang ='" + item.shuliang + "'";
                    }

                    if (item.Product_salse != null)
                    {
                        conditions += " ,Product_salse ='" + item.Product_salse + "'";
                    }

                    if (item.jine != null)
                    {
                        conditions += " ,jine ='" + item.jine + "'";
                    }

                    if (item.yujijiaohuoshijian != null && item.yujijiaohuoshijian != Convert.ToDateTime("01/01/0001 00:00:00"))
                    {
                        conditions += " ,yujijiaohuoshijian ='" + item.yujijiaohuoshijian.ToString("yyyy/MM/dd") + "'";
                    }

                    if (item.jianhuoshijian2 != null && item.jianhuoshijian2 != Convert.ToDateTime("01/01/0001 00:00:00"))
                    {
                        conditions += " ,jianhuoshijian2 ='" + item.jianhuoshijian2.ToString("yyyy/MM/dd") + "'";
                    }

                    if (item.dingdanguanliyuan != null)
                    {
                        conditions += " ,dingdanguanliyuan ='" + item.dingdanguanliyuan + "'";
                    }

                    if (item.kaipiao != null)
                    {
                        conditions += " ,kaipiao ='" + item.kaipiao + "'";
                    }

                    if (item.shifoujiaohuo != null)
                    {
                        conditions += " ,shifoujiaohuo ='" + item.shifoujiaohuo + "'";
                    }

                    if (item.fukuanriqi != null && item.fukuanriqi != Convert.ToDateTime("01/01/0001 00:00:00"))
                    {
                        conditions += " ,fukuanriqi ='" + item.fukuanriqi.ToString("yyyy/MM/dd") + "'";
                    }

                    if (item.beizhu != null)
                    {
                        conditions += " ,beizhu ='" + item.beizhu + "'";
                    }
                    if (item.Input_Date != null)
                    {
                        conditions += " ,Input_Date ='" + item.Input_Date.ToString("yyyy/MM/dd") + "'";
                    }
                    if (item.xinzeng == "true")
                        conditions = "insert into JNOrder_order(customer_name,dinghuoshijian,order_no,Product_no,Product_name,shuliang,Product_salse,jine,yujijiaohuoshijian,jianhuoshijian2,dingdanguanliyuan,kaipiao,shifoujiaohuo,fukuanriqi,beizhu,Input_Date) values ('" + item.customer_name + "','" + item.dinghuoshijian.ToString("yyyy/MM/dd") + "','" + item.order_no + "','" + item.Product_no + "','" + item.Product_name + "','" + item.shuliang + "','" + item.Product_salse + "','" + item.jine + "','" + item.yujijiaohuoshijian.ToString("yyyy/MM/dd") + "','" + item.jianhuoshijian2.ToString("yyyy/MM/dd") + "','" + item.dingdanguanliyuan + "','" + item.kaipiao + "','" + item.shifoujiaohuo + "','" + item.fukuanriqi.ToString("yyyy/MM/dd") + "','" + item.beizhu + "','" + item.Input_Date.ToString("yyyy/MM/dd") + "')";
                    else
                        conditions = "update JNOrder_order set  " + conditions + " where order_id = " + item.order_id + " ";

                    // conditions += " order by Id desc";
                    #endregion
                    #endregion

                    int isrun = BusinessHelp.updateProduct_Server(conditions);
                    if (item.xinzeng == "true" && isrun == 1)
                        item.xinzeng = "";


                    if (arg.CurrentIndex % 5 == 0)
                    {
                        backgroundWorker2.ReportProgress(progress, arg);
                    }
                }
                backgroundWorker2.ReportProgress(100, arg);
                e.Result = string.Format("{0} 已保存 ！", changeindex.Count);

            }
            catch (Exception ex)
            {
                if (!e.Cancel)
                {

                    e.Result = ex.Message + "";
                }
                success = false;
            }

            return success;
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                MessageBox.Show(string.Format("It is cancelled!"));
            }
            else
            {
                toolStripLabel1.Text = "" + "(" + e.Result + ")" + "--数据已成功保存 可以继续编辑无需刷新";
                changeindex = new List<int>();

                dataGridView1.Enabled = true;
            }
        }

        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            WorkerArgument arg = e.UserState as WorkerArgument;
            if (!arg.HasError)
            {
                this.toolStripLabel1.Text = String.Format("{0}/{1}", arg.CurrentIndex, arg.OrderCount);
                this.ProgressValue = e.ProgressPercentage;
            }
            else
            {
                this.toolStripLabel1.Text = arg.ErrorMessage;
            }

        }
        public int ProgressValue
        {
            get { return this.pbStatus.Value; }
            set { pbStatus.Value = value; }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Sorry , No Data Output !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = ".csv";
            saveFileDialog.Filter = "csv|*.csv";
            string strFileName = "订单 信息" + "_" + DateTime.Now.ToString("yyyyMMddHHmmss");
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
            MessageBox.Show("Dear User, Down File  Successful ！", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //bool handle;
            //if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.Equals(DBNull.Value))
            //{
            //    handle = true;
            //}
            //else
            //    handle = false;
            //e.Cancel = handle;
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int s = this.tabControl1.SelectedIndex;
                if (s == 0)
                {
                    dataGridView1.Enabled = false;
                    if (changeindex.Count < 1)
                    {
                        IEnumerable<int> orderIds = GetChangedOrderIds();
                        foreach (var id in orderIds.Distinct())
                        {
                            changeindex.Add(id);
                        }
                    }
                }

                if (backgroundWorker2.IsBusy != true)
                {
                    backgroundWorker2.RunWorkerAsync(new WorkerArgument { OrderCount = 0, CurrentIndex = 0 });

                }
                dataGridChanges.Clear();

            }
            catch (Exception ex)
            {
                dataGridChanges.Clear();
                return;
                throw;
            }
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            clsOrderinfo item = new clsOrderinfo();
            item.Input_Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));
            item.xinzeng = "true";

            this.bindingSource1.Add(item);
            this.dataGridView1.Refresh();
        }

        private void delScheduleButton_Click(object sender, EventArgs e)
        {
            var schedule = GetSelectedSchedule();

            if (schedule != null)
            {
                deletedorderList.Add(schedule);
                bindingSource1.Remove(schedule);
                this.dataGridView1.Refresh();
            }
        }
        private clsOrderinfo GetSelectedSchedule()
        {
            clsOrderinfo schedule = null;
            var row = this.dataGridView1.CurrentRow;
            if (row != null)
            {
                schedule = row.DataBoundItem as clsOrderinfo;
            }
            return schedule;
        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void 打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var oids = GetOrderIdsBySelectedGridCell();

            if (this.dataGridView1.RowCount == 0 || this.dataGridView1.RowCount < RowRemark)
            {
                MessageBox.Show("请选择要打印的单子，谢谢", "打印", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
            else
            {

                int ishaveprint = 0;


                if (oids.Count > 0)
                {
                    ishaveprint++;

                }
                if (ishaveprint == 0)
                {
                    MessageBox.Show("请选择要打印的单子，谢谢", "打印", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

            }
            clsAllnew BusinessHelp = new clsAllnew();

            FilterOrderResults = new List<clsOrderinfo>();

            for (int j = 0; j < oids.Count; j++)
            {
                var filtered = Orderinfolist_Server.FindAll(s => s.order_id == oids[j]);
                FilterOrderResults.Add(filtered[0]);

            }
            BusinessHelp.Run(FilterOrderResults);

            MessageBox.Show("打印完成，请核对打印信息，谢谢", "打印", MessageBoxButtons.OK, MessageBoxIcon.Information);

            return;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewColumn column = dataGridView1.Columns[e.ColumnIndex];

            if (column == customer_name)
            {


            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            RowRemark = e.RowIndex;
            cloumn = e.ColumnIndex;
            if (e.ColumnIndex == 1)
            {
                _Rectangle = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true); //得到所在单元格位置和大小  
                dtp.Size = new Size(_Rectangle.Width, _Rectangle.Height); //把单元格大小赋给时间控件  
                dtp.Location = new Point(_Rectangle.X, _Rectangle.Y); //把单元格位置赋给时间控件  
                if (dataGridView1.CurrentCell.Value.ToString()!="01/01/0001 00:00:00")
                dtp.Value = (DateTime)dataGridView1.CurrentCell.Value;
                dtp.Visible = true;  //可以显示控件了  
            }
            else if (e.ColumnIndex == 8)
            {
                _Rectangle = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true); //得到所在单元格位置和大小  
                dtp.Size = new Size(_Rectangle.Width, _Rectangle.Height); //把单元格大小赋给时间控件  
                dtp.Location = new Point(_Rectangle.X, _Rectangle.Y); //把单元格位置赋给时间控件 
                if (dataGridView1.CurrentCell.Value.ToString() != "01/01/0001 00:00:00")
                dtp.Value = (DateTime)dataGridView1.CurrentCell.Value;
                dtp.Visible = true;  //可以显示控件了  
            }
            else if (e.ColumnIndex == 9)
            {
                _Rectangle = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true); //得到所在单元格位置和大小  
                dtp.Size = new Size(_Rectangle.Width, _Rectangle.Height); //把单元格大小赋给时间控件  
                dtp.Location = new Point(_Rectangle.X, _Rectangle.Y); //把单元格位置赋给时间控件  
                if (dataGridView1.CurrentCell.Value.ToString() != "01/01/0001 00:00:00")
                dtp.Value = (DateTime)dataGridView1.CurrentCell.Value;
                dtp.Visible = true;  //可以显示控件了  
            }
            else if (e.ColumnIndex == 13)
            {
                _Rectangle = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true); //得到所在单元格位置和大小  
                dtp.Size = new Size(_Rectangle.Width, _Rectangle.Height); //把单元格大小赋给时间控件  
                dtp.Location = new Point(_Rectangle.X, _Rectangle.Y); //把单元格位置赋给时间控件  
                if (dataGridView1.CurrentCell.Value.ToString() != "01/01/0001 00:00:00")
                dtp.Value = (DateTime)dataGridView1.CurrentCell.Value;
                dtp.Visible = true;  //可以显示控件了  
            }
            else
                dtp.Visible = false;


        }
        /*************时间控件选择时间时****************/
        private void dtp_TextChange(object sender, EventArgs e)
        {
            dataGridView1.CurrentCell.Value = dtp.Value;  //时间控件选择时间时，就把时间赋给所在的单元格  
        }

        /***********当列的宽度变化时，时间控件先隐藏起来，不然单元格变大时间控件无法跟着变大哦***********/
        private void dataGridView1_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            dtp.Visible = false;

        }

        /***********滚动条滚动时，单元格位置发生变化，也得隐藏时间控件，不然时间控件位置不动就乱了********/
        private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            dtp.Visible = false;
        }  
        private void textBox8_Enter(object sender, EventArgs e)
        {
            this.textBox8.AutoCompleteCustomSource.AddRange(new string[] {
            "aaaaaaa",
            "aabbbbb",
            "cccccc",
            "dddddd"});
            this.textBox8.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBox8.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView1.CurrentCell.OwningColumn is DataGridViewComboBoxColumn)
            {
                ((ComboBox)e.Control).DropDownStyle = ComboBoxStyle.DropDown;
                ((ComboBox)e.Control).AutoCompleteMode = AutoCompleteMode.Append;
                ((ComboBox)e.Control).AutoCompleteSource = AutoCompleteSource.ListItems;
            }
        }
    }
}
