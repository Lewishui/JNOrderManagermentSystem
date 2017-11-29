using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;

namespace JNOrderManagermentSystem
{
    public partial class frmIPconfing : Form
    {
        string ipadress;
        string path = AppDomain.CurrentDomain.BaseDirectory + "System\\IP.txt";

        public frmIPconfing(string tys)
        {
            InitializeComponent();
          
            string[] fileText = File.ReadAllLines(path);
            ipadress = "" + fileText[0];
            this.textBox1.Text = ipadress;

        }

        private void frmIPconfing_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(path);

            sw.WriteLine(this.textBox1.Text);

            sw.Flush();
            sw.Close();
            MessageBox.Show("保存成功");
            this.Close();

           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //ipadress = "127.0.0.1";
            Ping pingSender = new Ping();
            PingReply reply = pingSender.Send(this.textBox1.Text, 120);//第一个参数为ip地址，第二个参数为ping的时间
            if (reply.Status == IPStatus.Success)
            {
                //ping的通
                button2.Text = "网络畅通";

            }
            else
            {
                //ping不通
                button2.Text = "网络不通";

            } 
        }
    }
}
