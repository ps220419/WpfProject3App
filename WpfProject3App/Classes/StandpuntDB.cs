using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProject3App.Classes
{
    class StandpuntDB
    {
        #region fields
        MySqlConnection _connection = new MySqlConnection("Server=localhost;Database=verkiezingenprj3;Uid=root;Pwd=;");
        #endregion 

        #region methods/functions
        public DataTable SelectStandpunt()
        {
            DataTable result = new DataTable();
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "SELECT * FROM standpunten;";
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


        public bool InsertStandpunt(string PartijName, string Thema, string Standpunt)
        {
            bool succes = false;
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "INSERT INTO `standpunten` ( `StandpuntId` , `PartijId ,`PartijName`,`ThemaId`, `Thema` `Standpunt`) VALUES (NULL , NULL @PartijName , NULL @Thema @Standpunt) ";
                command.Parameters.AddWithValue("@PartijName", PartijName);
                command.Parameters.AddWithValue("@Thema", Thema);
                command.Parameters.AddWithValue("@Standpunt", Standpunt);
                

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
        public bool UpdateStandpunt(string Id, string PartijName, string PartijAdres, string PartijPostcode, string PartijGemeente, string PartijEmailAdres, string PartijTelefoonnummer)
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
        public bool DeleteStandpunt(string id)
        {
            bool succes = false;
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "DELETE FROM `standpunten` WHERE `standpunten`.`StandpuntenId` = @id;";
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
