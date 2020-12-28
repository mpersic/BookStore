using System;
using System.Data.SqlClient;
using Objekti;
using System.Collections.Generic;

namespace Session
{
    public class Posrednik
    {
        SqlConnection connection;
        SqlConnectionStringBuilder connStringBuilder;

        void ConnectToDatabase()
        {
            //Data Source=DESKTOP-11SDEU5\SQLEXPRESS;Initial Catalog=master;Integrated Security=True
            connStringBuilder = new SqlConnectionStringBuilder();
            connStringBuilder.DataSource = "DESKTOP-11SDEU5";
            connStringBuilder.InitialCatalog = "master";
            connStringBuilder.IntegratedSecurity = true;

            connection = new SqlConnection(connStringBuilder.ToString());
        }
        public Posrednik()
        {
            ConnectToDatabase();
        }
        public void InsertAutor(Autor autor)
        {
            try
            {
                string cmdText = "INSERT INTO dbo.Autor(Ime,AutorUrl,Adresa) VALUES(@ime,@url,@adresa)";
                SqlCommand cmd = new SqlCommand(cmdText, connection);
                cmd.Parameters.AddWithValue("@ime", autor.Ime);
                cmd.Parameters.AddWithValue("@url", autor.Url);
                cmd.Parameters.AddWithValue("@adresa", autor.Adresa);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

        public void InsertIzdavac(Izdavac izdavac)
        {
            try
            {
                string cmdText = "INSERT INTO dbo.Izdavac(Ime,IzdavacUrl,Adresa) VALUES(@ime,@url,@adresa)";
                SqlCommand cmd = new SqlCommand(cmdText, connection);
                cmd.Parameters.AddWithValue("@ime", izdavac.Ime);
                cmd.Parameters.AddWithValue("@url", izdavac.Url);
                cmd.Parameters.AddWithValue("@adresa", izdavac.Adresa);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }
        //public void InsertKnjiga(Knjiga knjiga)
        //{
        //    try
        //    {
        //        string cmdText = "INSERT INTO dbo.Knjiga(ISBN,Ime,Godina) VALUES(@ime,@url,@adresa)";
        //        SqlCommand cmd = new SqlCommand(cmdText, connection);
        //        cmd.Parameters.AddWithValue("@ime", izdavac.Ime);
        //        connection.Open();
        //        cmd.ExecuteNonQuery();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        if (connection != null)
        //            connection.Close();
        //    }
        //}

        //public List<Autor> SelectAutor(Autor autor)
        //{
        //    List<Autor> listaAutora = new List<Autor>();
        //    try
        //    {
        //        string text = "SELECT * FROM dbo.Autors";
        //        SqlCommand cmd = new SqlCommand(text, conn);
        //        conn.Open();

        //        SqlDataReader reader = cmd.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            Autor a = new Autor();
        //            a.Ime = reader["ime"].ToString();
        //            a.Url = reader["url"].ToString();
        //            a.Adresa = reader["adresa"].ToString();

        //            listaAutora.Add(a);
        //        }
        //        return listaAutora;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        if (conn != null)
        //        {
        //            conn.Close();
        //        }
        //    }
        //}

        public void DeleteAutor(Autor autor)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("DELETE FROM Autor WHERE Autor.Ime = '" + autor.Ime + "'", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void DeleteIzdavac(Izdavac izdavac)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("DELETE FROM Izdavac WHERE Izdavac.Ime = '" + izdavac.Ime + "'", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void DeleteKnjiga(Knjiga knjiga)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("DELETE FROM knjiga WHERE Knjiga.ISBN = '" + knjiga.Isbn + "'", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void DeleteKosarica(Kosarica kosarica)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("DELETE FROM Kosarica WHERE Kosarica.Ime = '" + kosarica.IdKosarice + "'", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void DeleteKupac(Kupac kupac)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("DELETE FROM Kupac WHERE Kupac.Ime = '" + kupac.IdKupca + "'", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void DeleteSkladiste(Skladiste skladiste)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("DELETE FROM Skladiste WHERE Skladiste.Ime = '" + skladiste.IDSkladiste + "'", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void DeleteSkladiste(Skladiste skladiste)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("DELETE FROM Skladiste WHERE Skladiste.Ime = '" + skladiste.IDSkladiste + "'", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
