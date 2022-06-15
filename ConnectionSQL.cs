using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace KTYP
{
    public partial class ConnectionSQL
    {
        public ConnectionSQL()
        {

        }
        public static SqlConnectionStringBuilder SQLCONN()
        {
            
            XDocument xd = XDocument.Load("C:\\KTYP\\config.xml");
            SqlConnectionStringBuilder conn = new SqlConnectionStringBuilder();
#pragma warning disable CS8602 // Olası bir null başvurunun başvurma işlemi.
            conn.DataSource = xd.Element("sql").Element("DataSource").Value.ToString();

            conn.UserID = xd.Element("sql").Element("UserID").Value.ToString();
            conn.Password = xd.Element("sql").Element("Password").Value.ToString();
            conn.ConnectTimeout = Convert.ToInt32(xd.Element("sql").Element("ConnectTimeout").Value);
            conn.Encrypt = Convert.ToBoolean(xd.Element("sql").Element("Encrypt").Value);
            conn.TrustServerCertificate= Convert.ToBoolean(xd.Element("sql").Element("TrustServerCertificate").Value);
            conn.ApplicationIntent = (System.Data.SqlClient.ApplicationIntent.ReadWrite);
            conn.MultiSubnetFailover = Convert.ToBoolean(xd.Element("sql").Element("MultiSubnetFailover").Value);
#pragma warning restore CS8602 // Olası bir null başvurunun başvurma işlemi.
            return conn;
            
        }
        public static SqlConnection SqlConnection ()
        {
            SqlConnectionStringBuilder sqlConnection = ConnectionSQL.SQLCONN();
            string CS = sqlConnection.ConnectionString;
            SqlConnection Conn = new SqlConnection(CS.ToString());
            return Conn;
        }
    }
}
