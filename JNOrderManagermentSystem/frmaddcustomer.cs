using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Order.Buiness;
using Order.DB;

namespace JNOrderManagermentSystem
{
    public partial class frmaddcustomer : Form
    {
        List<clscustomerinfo> userlist_Server;
        public frmaddcustomer(string TYPE)
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                read();

                clsAllnew BusinessHelp = new clsAllnew();

                int ISURN = BusinessHelp.create_customer_Server(userlist_Server);
                if (ISURN == 1)
                {

                    if (MessageBox.Show(" 客户创建成功 , 是否继续添加 ?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        clear();
                    }
                    else
                        this.Close();
                }
                if (ISURN == 0)
                {
                    MessageBox.Show("客户创建失败,请检查是否录入有误！");

                }
            }
            catch (Exception ex)
            {
                return;

                throw;
            }
        }

        private void read()
        {
            userlist_Server = new List<clscustomerinfo>();

            clscustomerinfo item = new clscustomerinfo();
            if (item.customer_name == null || item.customer_name == "")
            {
                errorProvider1.SetError(txname, "不能为空");
                return;
            }
            else
                errorProvider1.SetError(txname, String.Empty);

            item.customer_name = this.txname.Text;
            item.customer_adress = this.txadress.Text;
            item.customer_shuihao = this.tshuihao.Text;
            item.customer_bank = this.txbank.Text;
            item.customer_account = txaccount.Text;
            item.customer_phone = txphone.Text;
            item.customer_contact = txcontact.Text;
            item.Input_Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));
            userlist_Server.Add(item);
        }

        private void clear()
        {
            txname.Text = "";
            txadress.Text = "";
            txshuihao.Text = "";
            txbank.Text = "";
            txaccount.Text = "";
            txphone.Text = "";
            txcontact.Text = "";
        }

        private void txname_TextChanged(object sender, EventArgs e)
        {
            if (txname.Text !=
                "")
                errorProvider1.SetError(txname, String.Empty);
        }
    }
}
