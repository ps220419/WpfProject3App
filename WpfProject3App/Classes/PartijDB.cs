
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProject3App.Classes
{
    class PartijDB
    {
        #region fields
        MySqlConnection _connection = new MySqlConnection("Server=localhost;Database=verkiezingenprj3;Uid=root;Pwd=;");
        #endregion 

        #region methods/functions
        public DataTable SelectPartij()
        {
            DataTable result = new DataTable();
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "SELECT * FROM partij;";
                MySqlDataReader reader = command.ExecuteReader();
                result.Load(reader);
            }
            catch (Exception)
            {
                //Problem with the database
            }
            finally
            {
                _connection.Close();
            }
            return result;
        }

        public bool InsertPartij(string PartijName, string PartijAdres, string PartijPostcode, string PartijGemeente, string PartijEmailAdres, string PartijTelefoonNummer)
        {
            bool succes = false;
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "INSERT INTO `partij` ( `PartijName`,`Adres`, `Postcode`, `Gemeente`, `EmailAdres`, `Telefoonnummer`) VALUES ( @PartijName, @Adres, @Postcode, @Gemeente, @EmailAdres, @Telefoonnummer) ";
                command.Parameters.AddWithValue("@PartijName", PartijName);
                command.Parameters.AddWithValue("@Adres", PartijAdres);
                command.Parameters.AddWithValue("@Postcode", PartijPostcode);
                command.Parameters.AddWithValue("@Gemeente", PartijGemeente);
                command.Parameters.AddWithValue("@EmailAdres", PartijEmailAdres);
                command.Parameters.AddWithValue("@Telefoonnummer", PartijTelefoonNummer);

                int nrOfRowsAffected = command.ExecuteNonQuery();
                succes = (nrOfRowsAffected != 0);
            }
            catch (Exception)
            {
                //Problem with the database
            }
            finally
            {
                _connection.Close();
            }
            return succes;
        }
        public bool UpdatePartij(string Id ,string PartijName, string PartijAdres, string PartijPostcode, string PartijGemeente, string PartijEmailAdres, string PartijTelefoonnummer)
        {
            bool succes = false;
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "UPDATE `partij` SET `PartijName` = @PartijName, `Adres` = @Adres, `Postcode` = @Postocde, `Gemeente` = @Gemeente, `EmailAdres` = @EmailAdres, `Telefoonnummer` = @Telefoonnummer WHERE `partij`.`PartijId` = @id; ";
                command.Parameters.AddWithValue("@PartijName", PartijName);
                command.Parameters.AddWithValue("@Adres", PartijAdres);
                command.Parameters.AddWithValue("@Postcode", PartijPostcode);
                command.Parameters.AddWithValue("@Gemeente", PartijGemeente);
                command.Parameters.AddWithValue("@EmailAdres", PartijEmailAdres);
                command.Parameters.AddWithValue("@Telefoonnummer", PartijTelefoonnummer);
                command.Parameters.AddWithValue("@id", Id);
                int nrOfRowsAffected = command.ExecuteNonQuery();
                succes = (nrOfRowsAffected != 0);
            }
            catch (Exception)
            {
                //Problem with the database
            }
            finally
            {
                _connection.Close();
            }
            return succes;
        }
        public bool DeletePartij(string id)
        {
            bool succes = false;
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "DELETE FROM `partij` WHERE `partij`.`PartijId` = @id;";
                command.Parameters.AddWithValue("@id", id);
                int nrOfRowsAffected = command.ExecuteNonQuery();
                succes = (nrOfRowsAffected != 0);
            }
            catch (Exception)
            {
                //Problem with the database
            }
            finally
            {
                _connection.Close();
            }
            return succes;
        }
        #endregion
    }
}

