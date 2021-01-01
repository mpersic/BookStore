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
            connStringBuilder.DataSource = "DESKTOP-3ES45SE";
            connStringBuilder.InitialCatalog = "master";
            connStringBuilder.IntegratedSecurity = true;

            connection = new SqlConnection(connStringBuilder.ToString());
        }

        public Posrednik()
        {
            ConnectToDatabase();
        }

        public void IspisAutoraKnjigaSkladista(int ID)
        {
            string text1 = "'" + ID + "' = Knjiga.IDSkladista";
            string text2 = "Skladiste.IDSkladiste = '" + ID + "'";
            string text3 = "Knjiga.IDAutora = Autor.ID";

            using (SqlCommand command = new SqlCommand("SELECT DISTINCT Autor.Ime FROM Knjiga,Autor,Skladiste WHERE " + text1 + " AND " + text2 + " AND " + text3, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(reader["Ime"].ToString() + "\t");
                    }
                }
                connection.Close();
            }
        }

        public void IspisBrojaKnjigaNaSkladistu(int ID)
        {
            string text1 = "'" + ID + "' = Knjiga.IDSkladista";
            string text2 = "Skladiste.IDSkladiste = '" + ID + "'";

            using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Knjiga,Skladiste WHERE " + text1 + " AND " + text2, connection))
            {
                connection.Open();
                Console.WriteLine(command.ExecuteScalar().ToString() + " knjiga(e)");
                connection.Close();
            }
        }

        public void IspisBrojaKnjigaOdAutora(int ID)
        {
            string text1 = "'" + ID + "' = Autor.ID";
            string text2 = "Knjiga.IDAutora = '" + ID + "'";

            using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Autor,Knjiga WHERE " + text1 + " AND " + text2, connection))
            {
                connection.Open();
                Console.WriteLine(command.ExecuteScalar().ToString() + " knjiga(e)");
                connection.Close();
            }
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
                string cmdText = "INSERT INTO dbo.Kupac(IDKupca,Adresa,BrojMobitela,Email,Ime) VALUES(@id,@adresa,@brojMobitela,@email,@ime)";
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
                cmd.Parameters.AddWithValue("@idAutora", knjiga.IdAutora);
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



        public void PrintAutors()
        {
            using (SqlCommand command = new SqlCommand("select * from Autor", connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.Write(reader["ID"].ToString() + "\t");
                        Console.Write(reader["Ime"].ToString() + "\t");
                        Console.Write(reader["AutorUrl"].ToString() + "\t");
                        Console.Write(reader["Adresa"].ToString() + "\n");
                    }
                }
                connection.Close();
            }
        }

        public void PrintIzdavac()
        {
            using (SqlCommand command = new SqlCommand("select * from Izdavac", connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.Write(reader["ID"].ToString() + "\t");
                        Console.Write(reader["Ime"].ToString() + "\t");
                        Console.Write(reader["IzdavacUrl"].ToString() + "\t");
                        Console.Write(reader["Adresa"].ToString() + "\n");
                    }
                }
                connection.Close();
            }
        }

        public void PrintSkladiste()
        {
            using (SqlCommand command = new SqlCommand("select * from Skladiste", connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.Write(reader["IDSkladiste"].ToString() + "\t");
                        Console.Write(reader["Adresa"].ToString() + "\n");
                    }
                }
                connection.Close();
            }
        }

        public void PrintKupac()
        {
            using (SqlCommand command = new SqlCommand("select * from Kupac", connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.Write(reader["IDKupca"].ToString() + "\t");
                        Console.Write(reader["Adresa"].ToString() + "\t");
                        Console.Write(reader["BrojMobitela"].ToString() + "\t");
                        Console.Write(reader["Email"].ToString() + "\t");
                        Console.Write(reader["Ime"].ToString() + "\n");
                    }
                }
                connection.Close();
            }
        }

        public void PrintKosarica()
        {
            using (SqlCommand command = new SqlCommand("select * from Kosarica", connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.Write(reader["IDKosarica"].ToString() + "\t");
                        Console.Write(reader["IDKupca"].ToString() + "\n");
                    }
                }
                connection.Close();
            }
        }

        public void PrintKnjiga()
        {
            using (SqlCommand command = new SqlCommand("select * from Knjiga", connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.Write(reader["ISBN"].ToString() + "\t");
                        Console.Write(reader["Ime"].ToString() + "\t");
                        Console.Write(reader["BrojDostupnih"].ToString() + "\t");
                        Console.Write(reader["Godina"].ToString() + "\t");
                        Console.Write(reader["IDSkladista"].ToString() + "\t");
                        Console.Write(reader["IDIzdavaca"].ToString() + "\t");
                        Console.Write(reader["IDAutora"].ToString() + "\n");
                    }
                }
                connection.Close();
            }
        }

        public void PrintSeNalazi()
        {
            using (SqlCommand command = new SqlCommand("select * from SeNalazi", connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.Write(reader["IDKosarice"].ToString() + "\t");
                        Console.Write(reader["ISBN"].ToString() + "\n");
                    }
                }
                connection.Close();
            }
        }

        public void DeleteAutor(int ID)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("DELETE FROM Autor WHERE Autor.ID= '" + ID + "'", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void DeleteIzdavac(int ID)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("DELETE FROM Izdavac WHERE Izdavac.ID = '" + ID + "'", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void DeleteKnjiga(int ISBN)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("DELETE FROM knjiga WHERE Knjiga.ISBN = '" + ISBN + "'", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void DeleteKosarica(int ID)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("DELETE FROM Kosarica WHERE Kosarica.IDKosarice = '" + ID + "'", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void DeleteKupac(int ID)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("DELETE FROM Kupac WHERE Kupac.IDKupca = '" + ID + "'", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void DeleteSkladiste(int ID)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("DELETE FROM Skladiste WHERE Skladiste.IDSkladiste = '" + ID + "'", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void DeleteSeNalazi(int IDKosarice, int ISBN)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("DELETE FROM SeNalazi WHERE SeNalazi.IDKosarice = '" + IDKosarice + "' AND SeNalazi.ISBN = '" + ISBN + "'", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void IspisKnjigaAutora(int AutorID)
        {
            using (SqlCommand command = new SqlCommand("SELECT * from Knjiga WHERE IDAutora= '" + AutorID + "'", connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.Write(reader["ISBN"].ToString() + "\t");
                        Console.Write(reader["Ime"].ToString() + "\t");
                        Console.Write(reader["BrojDostupnih"].ToString() + "\t");
                        Console.Write(reader["Godina"].ToString() + "\t");
                        Console.Write(reader["IDSkladista"].ToString() + "\t");
                        Console.Write(reader["IDIzdavaca"].ToString() + "\t");
                        Console.Write(reader["IDAutora"].ToString() + "\n");
                    }
                }
                connection.Close();
            }
        }

        public void UpdateKnjiga(int ISBN)
        {
            bool isAvailable = true;
            using (SqlCommand command = new SqlCommand("SELECT * FROM Knjiga WHERE Knjiga.ISBN= '" + ISBN + "'", connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (!(Int32.Parse(reader["BrojDostupnih"].ToString()) >= 1))
                        {
                            isAvailable = false;
                        }
                    }
                }
                command.ExecuteNonQuery();
                if (isAvailable)
                {
                    SqlCommand newCommand = new SqlCommand("UPDATE Knjiga SET Knjiga.BrojDostupnih=Knjiga.BrojDostupnih-1 WHERE Knjiga.ISBN= '" + ISBN + "'", connection);
                    newCommand.ExecuteNonQuery();
                }
                else
                    Console.WriteLine("Knjiga trenutno nije dostupna.");
                connection.Close();
            }
        }
    }
}
