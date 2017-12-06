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
    public partial class frmaddProcuct : Form
    {
        List<clsProductinfo> userlist_Server;
        public frmaddProcuct(string TYPE)
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                read();

                clsAllnew BusinessHelp = new clsAllnew();

                int ISURN = BusinessHelp.create_Product_Server(userlist_Server);
                if (ISURN == 1)
                {
            
                    if (MessageBox.Show(" 产品创建成功 , 是否继续添加 ?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        clear();
                    }
                    else
                        this.Close();
                }
                if (ISURN == 0)
                {
                    MessageBox.Show("产品创建失败,请检查是否录入有误！");

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
            userlist_Server = new List<clsProductinfo>();

            clsProductinfo item = new clsProductinfo();
            item.Product_no = txproductno.Text;
            item.Product_name = txproductname.Text;
            item.Product_salse = txsales.Text;
            item.Product_address = txaddress.Text;
    
            item.Input_Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));
            userlist_Server.Add(item);
        }

        private void clear()
        {
            txproductno.Text = "";
            txproductname.Text = "";
            txsales.Text = "";
            txaddress.Text = "";
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clear();
          
        }
    }
}
