using System;
using System.Data.SqlClient;
using Objekti;

namespace Session
{
    public class Posrednik
    {
        SqlConnection conn;
        SqlConnectionStringBuilder connStringBuilder;

        void ConnectTo()
        {
            //Data Source=DESKTOP-11SDEU5\SQLEXPRESS;Initial Catalog=master;Integrated Security=True
            connStringBuilder = new SqlConnectionStringBuilder();
            connStringBuilder.DataSource = "DESKTOP-11SDEU5\SQLEXPRESS";
            connStringBuilder.InitialCatalog = "master";
            connStringBuilder.IntegratedSecurity = true;

            conn = new SqlConnection(connStringBuilder.ToString());
        }
        public Posrednik()
        {
            ConnectTo();
        }
        public void InsertAutor(Autor autor)
        {

        }
    }
}
