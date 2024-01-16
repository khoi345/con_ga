using System;
using System.Data.SqlClient;
using System.Xml;

namespace Dao
{
    public static class Conection
    {
        public static SqlConnection conn;
        public static SqlCommand comm;
        public static SqlConnectionStringBuilder connStringBuilder;
        public static SqlConnectionStringBuilder connStringBuilder2;
        public static string _SERVER_REDIS = "data source=127.0.0.1:6379;initial catalog=0";
          static Conection()
        {
#if DEBUG

            connStringBuilder = new SqlConnectionStringBuilder();
            connStringBuilder.MultipleActiveResultSets = true;
            connStringBuilder.DataSource = "KHOI-PC\\SQLEXPRESS";
            connStringBuilder.UserID = "sa";
            connStringBuilder.Password = "";
            connStringBuilder.InitialCatalog = "ConGa";

            connStringBuilder2 = new SqlConnectionStringBuilder();
            connStringBuilder2.MultipleActiveResultSets = true;
            connStringBuilder2.DataSource = "KHOI-PC\\SQLEXPRESS";
            connStringBuilder2.UserID = "sa";
            connStringBuilder2.Password = "";
            connStringBuilder2.InitialCatalog = "ConGa";
                          
#else

            connStringBuilder = new SqlConnectionStringBuilder();
            connStringBuilder.MultipleActiveResultSets = true;
            connStringBuilder.DataSource = "KHOI-PC\\SQLEXPRESS";
            connStringBuilder.UserID = "sa";
            connStringBuilder.Password = "";
            connStringBuilder.InitialCatalog = "ConGa";

            connStringBuilder2 = new SqlConnectionStringBuilder();
            connStringBuilder2.MultipleActiveResultSets = true;
            connStringBuilder2.DataSource = "KHOI-PC\\SQLEXPRESS";
            connStringBuilder2.UserID = "sa";
            connStringBuilder2.Password = "";
            connStringBuilder2.InitialCatalog = "ConGa";
#endif

        }
        public static string Maincode(string item)
        {
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(".\\maincode.xml");
            }
            catch (Exception)
            {
            }
            XmlNodeList nodeLst = doc.GetElementsByTagName(item);
            return nodeLst.Item(0).InnerText;
        }
        public static string Pass(string item)
        {
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(".\\pass.xml");
            }
            catch (Exception)
            {
            }
            XmlNodeList nodeLst = doc.GetElementsByTagName(item);
            return nodeLst.Item(0).InnerText;
        }
    }

}
