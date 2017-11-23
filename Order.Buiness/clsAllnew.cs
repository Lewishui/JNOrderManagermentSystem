using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using Order.Common;
using Order.DB;

namespace Order.Buiness
{
    public class clsAllnew
    {
        string connectionString = "mongodb://127.0.0.1";
        string DB_NAME = "FA_shop_PT";


        public clsAllnew()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "System\\IP.txt";

            string[] fileText = File.ReadAllLines(path);
            connectionString = "mongodb://" + fileText[0];



        }
        public void createUser_Server(List<clsuserinfo> AddMAPResult)
        {
            string sql = "insert into JNOrder_User(name,password,Createdate,Btype,denglushijian,jigoudaima,AdminIS) values ('" + AddMAPResult[0].name + "','" + AddMAPResult[0].password + "','" + AddMAPResult[0].Createdate + "','" + AddMAPResult[0].Btype + "','" + AddMAPResult[0].denglushijian + "','" + AddMAPResult[0].jigoudaima + "','" + AddMAPResult[0].AdminIS + "')";
            int isrun = MySqlHelper.ExecuteSql(sql);

            return;


            #region mongo

            //MongoServer server = MongoServer.Create(connectionString);
            //MongoDatabase db1 = server.GetDatabase(DB_NAME);
            //MongoCollection collection1 = db1.GetCollection("FA_shop_User");
            //MongoCollection<BsonDocument> employees1 = db1.GetCollection<BsonDocument>("FA_shop_User");

            ////  collection1.RemoveAll();
            //if (AddMAPResult == null)
            //{
            //    MessageBox.Show("No Data  input Sever", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //foreach (clsuserinfo item in AddMAPResult)
            //{

            //    QueryDocument query = new QueryDocument("name", item.name);
            //    collection1.Remove(query);
            //    BsonDocument fruit_1 = new BsonDocument
            //{ 
            //{ "name", item.name },
            //{ "password", item.password },
            //{ "Createdate", DateTime.Now.ToString("yyyy/MM/dd/HH")}, 
            //{ "Btype", item.Btype} ,
            // { "denglushijian", item.denglushijian} ,
            //  { "jigoudaima", item.jigoudaima} ,
            //{ "AdminIS", item.AdminIS} 
            //};
            //    collection1.Insert(fruit_1);
            //} 
            #endregion
        }
        public void lock_Userpassword_Server(List<clsuserinfo> AddMAPResult)
        {
            string sql = "update JNOrder_User set Btype ='" + AddMAPResult[0].Btype.Trim() + "' where name ='" + AddMAPResult[0].name + "'";
            int isrun = MySqlHelper.ExecuteSql(sql);

            return;
            #region monodb

            //MongoServer server = MongoServer.Create(connectionString);
            //MongoDatabase db1 = server.GetDatabase(DB_NAME);
            //MongoCollection collection1 = db1.GetCollection("FA_shop_User");
            //MongoCollection<BsonDocument> employees1 = db1.GetCollection<BsonDocument>("FA_shop_User");

            //if (AddMAPResult == null)
            //{
            //    MessageBox.Show("No Data  input Sever", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //foreach (clsuserinfo item in AddMAPResult)
            //{
            //    QueryDocument query = new QueryDocument("name", item.name);
            //    var update = Update.Set("Btype", item.Btype.Trim());
            //    collection1.Update(query, update);
            //} 
            #endregion
        }
        public List<clsuserinfo> ReadUserlistfromServer()
        {
            string conditions = "select * from JNOrder_User";//成功
            MySql.Data.MySqlClient.MySqlDataReader reader = MySqlHelper.ExecuteReader(conditions);
            List<clsuserinfo> ClaimReport_Server = new List<clsuserinfo>();

            while (reader.Read())
            {
                clsuserinfo item = new clsuserinfo();

                item.Order_id = reader.GetString(0);
                item.name = reader.GetString(1);
                item.password = reader.GetString(2);
                item.Createdate = reader.GetString(3);
                item.Btype = reader.GetString(4);
                item.denglushijian = reader.GetString(5);
                item.jigoudaima = reader.GetString(6);
                item.AdminIS = reader.GetString(7);



                ClaimReport_Server.Add(item);

                //这里做数据处理....
            }
            return ClaimReport_Server;
            #region  mongodb  Read  database info server
            //try
            //{
            //    List<clsuserinfo> ClaimReport_Server = new List<clsuserinfo>();

            //    MongoServer server = MongoServer.Create(connectionString);
            //    MongoDatabase db1 = server.GetDatabase(DB_NAME);
            //    MongoCollection collection1 = db1.GetCollection("FA_shop_User");
            //    MongoCollection<BsonDocument> employees = db1.GetCollection<BsonDocument>("FA_shop_User");

            //    foreach (BsonDocument emp in employees.FindAll())
            //    {
            //        clsuserinfo item = new clsuserinfo();

            //        #region 数据
            //        if (emp.Contains("_id"))
            //            item.Order_id = (emp["_id"].ToString());
            //        if (emp.Contains("name"))
            //            item.name = (emp["name"].AsString);
            //        if (emp.Contains("password"))
            //            item.password = (emp["password"].ToString());
            //        if (emp.Contains("Btype"))
            //            item.Btype = (emp["Btype"].AsString);
            //        if (emp.Contains("denglushijian"))
            //            item.denglushijian = (emp["denglushijian"].AsString);
            //        if (emp.Contains("Createdate"))
            //            item.Createdate = (emp["Createdate"].AsString);
            //        if (emp.Contains("AdminIS"))
            //            item.AdminIS = (emp["AdminIS"].AsString);

            //        if (emp.Contains("jigoudaima"))
            //            item.jigoudaima = (emp["jigoudaima"].AsString);

            //        #endregion
            //        ClaimReport_Server.Add(item);
            //    }
            //    return ClaimReport_Server;

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("" + ex);
            //    return null;
            //    throw ex;
            //}
            #endregion
        }

        public List<clsuserinfo> findUser(string findtext)
        {
            string strSelect = "select * from JNOrder_User where name='" + findtext + "'";
            MySql.Data.MySqlClient.MySqlDataReader reader = MySqlHelper.ExecuteReader(strSelect);
            List<clsuserinfo> ClaimReport_Server = new List<clsuserinfo>();

            while (reader.Read())
            {
                clsuserinfo item = new clsuserinfo();

                item.Order_id = reader.GetString(0);
                item.name = reader.GetString(1);
                item.password = reader.GetString(2);
                item.Createdate = reader.GetString(3);
                item.Btype = reader.GetString(4);
                item.denglushijian = reader.GetString(5);
                item.jigoudaima = reader.GetString(6);
                item.AdminIS = reader.GetString(7);



                ClaimReport_Server.Add(item);

                //这里做数据处理....
            }
            return ClaimReport_Server;
            #region Read  database info server
            //try
            //{
            //    List<clsuserinfo> ClaimReport_Server = new List<clsuserinfo>();

            //    MongoServer server = MongoServer.Create(connectionString);
            //    MongoDatabase db1 = server.GetDatabase(DB_NAME);
            //    MongoCollection collection1 = db1.GetCollection("FA_shop_User");
            //    MongoCollection<BsonDocument> employees = db1.GetCollection<BsonDocument>("FA_shop_User");

            //    var query = new QueryDocument("name", findtext);

            //    foreach (BsonDocument emp in employees.Find(query))
            //    {
            //        clsuserinfo item = new clsuserinfo();

            //        #region 数据
            //        if (emp.Contains("_id"))
            //            item.Order_id = (emp["_id"].ToString());
            //        if (emp.Contains("name"))
            //            item.name = (emp["name"].AsString);
            //        if (emp.Contains("password"))
            //            item.password = (emp["password"].ToString());
            //        if (emp.Contains("Btype"))
            //            item.Btype = (emp["Btype"].AsString);
            //        if (emp.Contains("denglushijian"))
            //            item.denglushijian = (emp["denglushijian"].AsString);
            //        if (emp.Contains("Createdate"))
            //            item.Createdate = (emp["Createdate"].AsString);
            //        if (emp.Contains("AdminIS"))
            //            item.AdminIS = (emp["AdminIS"].AsString);

            //        if (emp.Contains("jigoudaima"))
            //            item.jigoudaima = (emp["jigoudaima"].AsString);
            //        #endregion
            //        ClaimReport_Server.Add(item);
            //    }
            //    return ClaimReport_Server;

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("" + ex);
            //    return null;

            //    throw ex;
            //}
            #endregion
        }
        public void deleteUSER(string name)
        {
            string sql2 = "delete from JNOrder_User where  name='" + name + "'";
            int isrun = MySqlHelper.ExecuteSql(sql2);

            return;
            #region  monodb
            //MongoServer server = MongoServer.Create(connectionString);
            //MongoDatabase db1 = server.GetDatabase(DB_NAME);
            //MongoCollection collection1 = db1.GetCollection("FA_shop_User");
            //MongoCollection<BsonDocument> employees = db1.GetCollection<BsonDocument>("FA_shop_User");

            //if (name == null)
            //{
            //    MessageBox.Show("No Data  input Sever", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //QueryDocument query = new QueryDocument("name", name);

            //collection1.Remove(query); 
            #endregion
        }
        public void changeUserpassword_Server(List<clsuserinfo> AddMAPResult)
        {
            string sql = "update JNOrder_User set password ='" + AddMAPResult[0].password.Trim() + "' where name ='" + AddMAPResult[0].name + "'";
            int isrun = MySqlHelper.ExecuteSql(sql);

            return;
            #region mongodb

            //MongoServer server = MongoServer.Create(connectionString);
            //MongoDatabase db1 = server.GetDatabase(DB_NAME);
            //MongoCollection collection1 = db1.GetCollection("FA_shop_User");
            //MongoCollection<BsonDocument> employees1 = db1.GetCollection<BsonDocument>("FA_shop_User");

            //if (AddMAPResult == null)
            //{
            //    MessageBox.Show("No Data  input Sever", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //foreach (clsuserinfo item in AddMAPResult)
            //{
            //    QueryDocument query = new QueryDocument("name", item.name);
            //    var update = Update.Set("password", item.password.Trim());
            //    collection1.Update(query, update);
            //} 
            #endregion
        }
        public void updateLoginTime_Server(List<clsuserinfo> AddMAPResult)
        {
            string sql = "update JNOrder_User set denglushijian ='" + AddMAPResult[0].denglushijian.Trim() + "' where name ='" + AddMAPResult[0].name + "'";
            int isrun = MySqlHelper.ExecuteSql(sql);

            return;

            #region mongodb
            //MongoServer server = MongoServer.Create(connectionString);
            //MongoDatabase db1 = server.GetDatabase(DB_NAME);
            //MongoCollection collection1 = db1.GetCollection("FA_shop_User");
            //MongoCollection<BsonDocument> employees1 = db1.GetCollection<BsonDocument>("FA_shop_User");

            ////  collection1.RemoveAll();
            //if (AddMAPResult == null)
            //{
            //    MessageBox.Show("No Data  input Sever", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //foreach (clsuserinfo item in AddMAPResult)
            //{
            //    QueryDocument query = new QueryDocument("name", item.name);
            //    var update = Update.Set("denglushijian", item.denglushijian.Trim());
            //    collection1.Update(query, update);
            //} 
            #endregion
        }
        public int create_customer_Server(List<clscustomerinfo> AddMAPResult)
        {
            string sql = "insert into JNOrder_customer(customer_name,customer_adress,customer_shuihao,customer_bank,customer_account,customer_phone,Input_Date,customer_contact) values ('" + AddMAPResult[0].customer_name + "','" + AddMAPResult[0].customer_adress + "','" + AddMAPResult[0].customer_shuihao + "','" + AddMAPResult[0].customer_bank + "','" + AddMAPResult[0].customer_account + "','" + AddMAPResult[0].customer_phone + "','" + AddMAPResult[0].Input_Date.ToString("yyyy/MM/dd") + "','" + AddMAPResult[0].customer_contact + "')";
            int isrun = MySqlHelper.ExecuteSql(sql);

            return isrun;
        }
        public int deletecustomer(string name)
        {
            string sql2 = "delete from JNOrder_customer where  customer_id='" + name + "'";
            int isrun = MySqlHelper.ExecuteSql(sql2);

            return isrun;
          
        }
        public List<clscustomerinfo> findcustomer(string findtext)
        {
            MySql.Data.MySqlClient.MySqlDataReader reader = MySqlHelper.ExecuteReader(findtext);
            List<clscustomerinfo> ClaimReport_Server = new List<clscustomerinfo>();

            while (reader.Read())
            {
                clscustomerinfo item = new clscustomerinfo();

                item.customer_id = reader.GetInt32(0);
                item.customer_name = reader.GetString(1);
                item.customer_adress = reader.GetString(2);
                item.customer_shuihao = reader.GetString(3);
                item.customer_bank = reader.GetString(4);
                item.customer_account = reader.GetString(5);
                item.customer_phone = reader.GetString(6);
                item.customer_contact = reader.GetString(7);
                if (reader.GetString(8) != null && reader.GetString(8)!="")
                item.Input_Date = Convert.ToDateTime( reader.GetString(8));



                ClaimReport_Server.Add(item);

                //这里做数据处理....
            }
            return ClaimReport_Server;
        }
        public int updatecustomer_Server(string findtext)
        {
             int isrun = MySqlHelper.ExecuteSql(findtext);

            return isrun;
        }
        public int create_Product_Server(List<clsProductinfo> AddMAPResult)
        {
            string sql = "insert into JNOrder_product(Product_no,Product_name,Product_salse,Product_address,Input_Date) values ('" + AddMAPResult[0].Product_no + "','" + AddMAPResult[0].Product_name + "','" + AddMAPResult[0].Product_salse + "','" + AddMAPResult[0].Product_address + "','" + AddMAPResult[0].Input_Date.ToString("yyyy/MM/dd") + "')";
            int isrun = MySqlHelper.ExecuteSql(sql);

            return isrun;
        }
        public List<clsProductinfo> findProductr(string findtext)
        {
            MySql.Data.MySqlClient.MySqlDataReader reader = MySqlHelper.ExecuteReader(findtext);
            List<clsProductinfo> ClaimReport_Server = new List<clsProductinfo>();

            while (reader.Read())
            {
                clsProductinfo item = new clsProductinfo();

                item.Product_id = reader.GetInt32(0);
                item.Product_no = reader.GetString(1);
                item.Product_name = reader.GetString(2);
                item.Product_salse = reader.GetString(3);
                item.Product_address = reader.GetString(4);
             
                if (reader.GetString(5) != null && reader.GetString(5) != "")
                    item.Input_Date = Convert.ToDateTime(reader.GetString(5));



                ClaimReport_Server.Add(item);

                //这里做数据处理....
            }
            return ClaimReport_Server;
        }
        public int deleteProduct(string name)
        {
            string sql2 = "delete from JNOrder_product where  Product_id='" + name + "'";
            int isrun = MySqlHelper.ExecuteSql(sql2);

            return isrun;

        }
        public int updateProduct_Server(string findtext)
        {
            int isrun = MySqlHelper.ExecuteSql(findtext);

            return isrun;
        }
       
    }
}
