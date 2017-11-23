using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Order.DB
{
    public class clsuserinfo
    {
        public string Order_id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string Btype { get; set; }
        public string denglushijian { get; set; }
        public string Createdate { get; set; }
        public string AdminIS { get; set; }
        public string jigoudaima { get; set; }
    }
    public class clscustomerinfo
    {
        public int customer_id { get; set; }
        public string customer_name { get; set; }
        public string customer_adress { get; set; }
        public string customer_shuihao { get; set; }
        public string customer_bank { get; set; }
        public string customer_account { get; set; }
        public string customer_phone { get; set; }
        public string customer_contact { get; set; }
        public DateTime Input_Date { get; set; }
    }
    public class clsProductinfo
    {
        public int Product_id { get; set; }
        public string Product_no { get; set; }
        public string Product_name { get; set; }
        public string Product_salse { get; set; }
        public string Product_address { get; set; }
 
        public DateTime Input_Date { get; set; }
    }
}
