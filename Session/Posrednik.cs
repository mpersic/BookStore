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
                string cmdText = "INSERT INTO dbo.Autor(ID,Ime,AutorUrl,Adresa) VALUES(@id,@ime,@url,@adresa)";
                SqlCommand cmd = new SqlCommand(cmdText, connection);
                cmd.Parameters.AddWithValue("@id", autor.IdAutora);
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
                string cmdText = "INSERT INTO dbo.Izdavac(Ime,IzdavacUrl,Adresa,ID) VALUES(@ime,@url,@adresa,@id)";
                SqlCommand cmd = new SqlCommand(cmdText, connection);
                cmd.Parameters.AddWithValue("@ime", izdavac.Ime);
                cmd.Parameters.AddWithValue("@url", izdavac.Url);
                cmd.Parameters.AddWithValue("@adresa", izdavac.Adresa);
                cmd.Parameters.AddWithValue("@id", izdavac.IdIzdavaca);
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

        public void InsertSkladiste(Skladiste skladiste)
        {
            try
            {
                string cmdText = "INSERT INTO dbo.Skladiste(IDSkladiste,Adresa) VALUES(@id,@adresa)";
                SqlCommand cmd = new SqlCommand(cmdText, connection);
                cmd.Parameters.AddWithValue("@id", skladiste.IDSkladiste);
                cmd.Parameters.AddWithValue("@adresa", skladiste.Adresa);
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

        public void InsertSeNalazi(SeNalazi seNalazi)
        {
            try
            {
                string cmdText = "INSERT INTO dbo.SeNalazi(IDKosarice,ISBN) VALUES(@id,@isbn)";
                SqlCommand cmd = new SqlCommand(cmdText, connection);
                cmd.Parameters.AddWithValue("@id", seNalazi.IdKosarice);
                cmd.Parameters.AddWithValue("@isbn", seNalazi.Isbn);
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

        public void InsertKosarica(Kosarica kosarica)
        {
            try
            {
                string cmdText = "INSERT INTO dbo.Kosarica(IDKosarice,IDKupca) VALUES(@idKosarice,@idKupca)";
                SqlCommand cmd = new SqlCommand(cmdText, connection);
                cmd.Parameters.AddWithValue("@idKosarice", kosarica.IdKosarice);
                cmd.Parameters.AddWithValue("@idKupca", kosarica.IdKupca);
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

        public void InsertKupac(Kupac kupac)
        {
            try
            {
                string cmdText = "INSERT INTO dbo.Kupac(IDKupca,Adresa,BrojMobitela,Email,Ime) VALUES(@id,@adresa,@brojMobitela,email,ime)";
                SqlCommand cmd = new SqlCommand(cmdText, connection);
                cmd.Parameters.AddWithValue("@id", kupac.IdKupca);
                cmd.Parameters.AddWithValue("@adresa", kupac.Adresa);
                cmd.Parameters.AddWithValue("@brojMobitela", kupac.BrojMobitela);
                cmd.Parameters.AddWithValue("@email", kupac.Email);
                cmd.Parameters.AddWithValue("@ime", kupac.Ime);
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

        public void InsertKnjiga(Knjiga knjiga)
        {
            try
            {
                string cmdText = "INSERT INTO dbo.Knjiga(ISBN, Ime, BrojDostupnih, Godina, IDSkladista, IDIzdavaca, IDAutora) " +
                    "VALUES(@isbn, @ime, @brojDostupnih, @godina, @idSkladista, @idIzdavaca, @idAutora)";
                SqlCommand cmd = new SqlCommand(cmdText, connection);
                cmd.Parameters.AddWithValue("@isbn", knjiga.Isbn);
                cmd.Parameters.AddWithValue("@ime", knjiga.Ime);
                cmd.Parameters.AddWithValue("@brojDostupnih", knjiga.BrojDostupnih);
                cmd.Parameters.AddWithValue("@godina", knjiga.Godina);
                cmd.Parameters.AddWithValue("@idSkladista", knjiga.IdSkladista);
                cmd.Parameters.AddWithValue("@idIzdavaca", knjiga.IdIzdavaca);
                cmd.Parameters.AddWithValue("@idAutora",knjiga.IdAutora);
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

        public List<Autor> SelectAutor(Autor autor, int autorDataSelector)
        {
            List<Autor> listaAutora = new List<Autor>();
            try
            {
                string text = "SELECT * FROM dbo.Autor";

                bool addAND = false;
                if ((autorDataSelector & 1) > 0)
                {
                    text += "WHERE Autor.Ime = '" + autor.Ime + "'";
                    addAND = true;
                }
                if ((autorDataSelector & 2) > 0)
                {
                    text += (addAND ? " AND " : " ") + "WHERE Autor.AutorUrl = '" + autor.Url + "'";
                    addAND = true;
                }
                if ((autorDataSelector & 4) > 0)
                {
                    text += (addAND ? " AND " : " ") + "WHERE Autor.Adresa = '" + autor.Adresa + "'";
                    addAND = true;
                }
                if ((autorDataSelector & 8) > 0)
                {
                    text += (addAND ? " AND " : " ") + "WHERE Autor.ID = '" + autor.IdAutora + "'";
                }

                SqlCommand cmd = new SqlCommand(text, connection);
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Autor a = new Autor();
                    a.Ime = reader["Ime"].ToString();
                    a.Url = reader["AutorUrl"].ToString();
                    a.Adresa = reader["Adresa"].ToString();
                    a.IdAutora = Int32.Parse(reader["ID"].ToString());
                    listaAutora.Add(a);
                }
                return listaAutora;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public void DeleteAutor(Autor autor)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("DELETE FROM Autor WHERE Autor.ID = '" + autor.IdAutora + "'", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void DeleteIzdavac(Izdavac izdavac)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("DELETE FROM Izdavac WHERE Izdavac.ID = '" + izdavac.IdIzdavaca + "'", connection);
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
            SqlCommand command = new SqlCommand("DELETE FROM Kosarica WHERE Kosarica.IDKosarice = '" + kosarica.IdKosarice + "'", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void DeleteKupac(Kupac kupac)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("DELETE FROM Kupac WHERE Kupac.IDKupca = '" + kupac.IdKupca + "'", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void DeleteSkladiste(Skladiste skladiste)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("DELETE FROM Skladiste WHERE Skladiste.IDSkladiste = '" + skladiste.IDSkladiste + "'", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void DeleteSeNalazi(SeNalazi seNalazi)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("DELETE FROM SeNalazi WHERE SeNalazi.IDKosarice = '" + seNalazi.IdKosarice + "' AND SeNalazi.ISBN = '" + seNalazi.Isbn + "'", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
