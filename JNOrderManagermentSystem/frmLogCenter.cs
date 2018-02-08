using System;
using System.Collections;
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
using Order.Common;
using Order.DB;

namespace JNOrderManagermentSystem
{
    public partial class frmLogCenter : Form
    {
        DateTime startAt;
        DateTime endAt;
        string txfind;
        List<clsLog_info> Loglist_Server;
        private SortableBindingList<clsLog_info> sortableLogList;
        List<int> changeindex;
        int RowRemark = 0;
        int cloumn = 0;
        private Hashtable dataGridChanges = null;
        DateTimePicker dtp = new DateTimePicker();  //这里实例化一个DateTimePicker控件  
        Rectangle _Rectangle;
        int rowcount;
        List<clsLog_info> deletedorderList;

        public frmLogCenter(string type)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            changeindex = new List<int>();
            this.dataGridChanges = new Hashtable();
            Loglist_Server = new List<clsLog_info>();
            changeindex = new List<int>();
            deletedorderList = new List<clsLog_info>();


            this.BindDataGridView();


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

        private List<long> GetOrderIdsBySelectedGridCell()
        {

            List<long> order_ids = new List<long>();
            var rows = GetSelectedRowsBySelectedCells(dataGridView1);
            foreach (DataGridViewRow row in rows)
            {
                var Diningorder = row.DataBoundItem as clsLog_info;
                order_ids.Add((long)Diningorder.Log_id);
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
            //this.pbStatus.Value = 0;
            this.toolStripLabel1.Text = "";
            var startAt = this.stockOutDateTimePicker.Value.AddDays(0).Date;
            endAt = this.stockInDateTimePicker1.Value.AddDays(0).Date;
            txfind = this.textBox8.Text;
            if (txfind.Length <= 0 && checkBox1.Checked == false)
            {
                MessageBox.Show("请输入要查找的相关信息 ！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;

            }
            //if (checkBox1.Checked == true)
            {
                if (checkBox1.Checked == true)
                    txfind = "";

                Read_order();
            }
            //else
            //{
            //    string conditions_new = "";


            //    {
            //        if (txfind != "所有")
            //            conditions_new += "'" + txfind + "'";
            //        if (txfind == "所有")
            //            conditions_new += "," + "'" + txfind + "'";
            //    }

            //    //string strSelect = "select * from JNOrder_log where product_no in ( " + conditions_new + " )";
            //    string strSelect = "select * from JNOrder_log where product_no like ( " + conditions_new + " )";
            //    if (txfind == "所有")
            //        strSelect = "select * from JNOrder_log ";

            //    strSelect += " order by Log_id desc";

            //    clsAllnew BusinessHelp = new clsAllnew();
            //    Loglist_Server = new List<clsLog_info>();

            //    Loglist_Server = BusinessHelp.findLog(strSelect);

            //}

            this.BindDataGridView();
        }



        private void Read_order()
        {
            string strSelect = "select * from JNOrder_log where Input_Date>='" + startAt.ToString("yyyy/MM/dd") + "'" + "and " + "Input_Date<='" + endAt.ToString("yyyy/MM/dd") + "'";

            if (txfind.Length > 0)
            {
                strSelect += " And product_no like '%" + txfind + "%'";//4、工作日志的内容查找，现在是按供应商查找，（查找供应商改为查找型号）
                if (txfind == "所有")
                    strSelect = "select * from JNOrder_log";

            }
            else
                strSelect = "select * from JNOrder_log";


            strSelect += " order by Log_id desc";

            clsAllnew BusinessHelp = new clsAllnew();
            Loglist_Server = new List<clsLog_info>();

            Loglist_Server = BusinessHelp.findLog(strSelect);
        }
        private void BindDataGridView()
        {

            if (Loglist_Server != null)
            {

                sortableLogList = new SortableBindingList<clsLog_info>(Loglist_Server);
                bindingSource1.DataSource = new SortableBindingList<clsLog_info>(Loglist_Server);
                dataGridView1.AutoGenerateColumns = false;

                dataGridView1.DataSource = bindingSource1;
                this.toolStripLabel1.Text = "条数：" + sortableLogList.Count.ToString();
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
                string strFileName = "工作日志" + "_" + DateTime.Now.ToString("yyyyMMddHHmmss");
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.groupBox2.Visible = false;
            this.toolStrip2.Visible = false;
            this.FormBorderStyle = FormBorderStyle.None;

        }

        private void frmLogCenter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.WindowState = FormWindowState.Minimized;
                this.groupBox2.Visible = true;
                this.toolStrip2.Visible = true;
                this.FormBorderStyle = FormBorderStyle.Sizable;

            }
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLogCenter_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            clsLog_info item = new clsLog_info();
            item.Input_Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));
            item.xinzeng = "true";

            this.bindingSource1.Add(item);
            this.dataGridView1.Refresh();

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

                    var model = row.DataBoundItem as clsLog_info;

                    clsLog_info item = new clsLog_info();

                    item.product_no = Convert.ToString(dataGridView1.Rows[i].Cells["product_no"].EditedFormattedValue.ToString());

                    item.indent = Convert.ToString(dataGridView1.Rows[i].Cells["indent"].EditedFormattedValue.ToString());

                    item.indent_date = Convert.ToString(dataGridView1.Rows[i].Cells["indent_date"].EditedFormattedValue.ToString());

                    item.end_user = Convert.ToString(dataGridView1.Rows[i].Cells["end_user"].EditedFormattedValue.ToString());

                    item.vendor = Convert.ToString(dataGridView1.Rows[i].Cells["vendor"].EditedFormattedValue.ToString());

                    item.daohuoshijian = Convert.ToString(dataGridView1.Rows[i].Cells["daohuoshijian"].EditedFormattedValue.ToString());
                    item.xinzeng = Convert.ToString(dataGridView1.Rows[i].Cells["xinzeng"].EditedFormattedValue.ToString());

                    item.Input_Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));
                    item.Log_id = model.Log_id;

                #endregion

                    #region MyRegion
                    var startAt = this.stockOutDateTimePicker.Value.AddDays(0).Date;
                    string conditions = "";

                    #region  构造查询条件
                    if (item.product_no != null)
                    {
                        conditions += " product_no ='" + item.product_no + "'";
                    }
                    if (item.indent != null)
                    {
                        conditions += " ,indent ='" + item.indent + "'";
                    }
                    if (item.indent_date != null)
                    {
                        conditions += " ,indent_date ='" + item.indent_date + "'";
                    }
                    if (item.end_user != null)
                    {
                        conditions += " ,end_user ='" + item.end_user + "'";
                    }
                    if (item.vendor != null)
                    {
                        conditions += " ,vendor ='" + item.vendor + "'";
                    }
                    if (item.daohuoshijian != null)
                    {
                        conditions += " ,daohuoshijian ='" + item.daohuoshijian + "'";
                    }

                    if (item.Input_Date != null)
                    {
                        conditions += " ,Input_Date ='" + item.Input_Date.ToString("yyyy/MM/dd") + "'";
                    }
                    if (item.xinzeng == "true")
                        conditions = "insert into JNOrder_log(product_no,indent,indent_date,end_user,vendor,Input_Date) values ('" + item.product_no + "','" + item.indent + "','" + item.indent_date + "','" + item.end_user + "','" + item.vendor + "','" + item.Input_Date.ToString("yyyy/MM/dd") + "')";
                    else
                        conditions = "update JNOrder_log set  " + conditions + " where Log_id = " + item.Log_id + " ";

                    #endregion
                    #endregion

                    int isrun = BusinessHelp.updateLog_Server(conditions);
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

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            bool success = dailysaveList(worker, e);
        }
        public int ProgressValue
        {
            get { return this.pbStatus.Value; }
            set { pbStatus.Value = value; }
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
        private clsLog_info GetSelectedSchedule()
        {
            clsLog_info schedule = null;
            var row = this.dataGridView1.CurrentRow;
            if (row != null)
            {
                schedule = row.DataBoundItem as clsLog_info;
            }
            return schedule;
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RowRemark = e.RowIndex;
            cloumn = e.ColumnIndex;

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
                var filtered = Loglist_Server.FindAll(s => s.Log_id == oids[j]);
                clsAllnew BusinessHelp = new clsAllnew();
                //批量删 
                int istu = BusinessHelp.deletelog(filtered[0].Log_id.ToString());

                for (int i = 0; i < filtered.Count; i++)
                {
                    //单个删除
                    if (filtered[i].Log_id != 0)
                    {
                        Loglist_Server.Remove(Loglist_Server.Where(o => o.Log_id == filtered[i].Log_id).Single());
                    }
                    if (istu != 1)
                    {
                        MessageBox.Show("删除失败，请查看" + filtered[i].vendor + filtered[i].product_no, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            BindDataGridView();


        }


    }
}
