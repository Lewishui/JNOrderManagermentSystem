using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Order.DB;

namespace JNOrderManagermentSystem
{
    public partial class frmAlterShow : Form
    {
        public frmAlterShow(string type, List<clscustomerinfo> customerinfolist_Server)
        {
            InitializeComponent();
            if (type == "customer_name")
            {
                this.listView1.BeginUpdate();
                foreach (clscustomerinfo itenm in customerinfolist_Server)
                {

                    this.listView1.Items.Add(itenm.customer_name);

                }
                this.listView1.EndUpdate();

            }

        }
    }
}
