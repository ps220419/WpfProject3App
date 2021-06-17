using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WpfProject3App.Classes
{
    class VerkiezingDB
    {
        #region fields
        MySqlConnection _connection = new MySqlConnection("Server=localhost;Database=verkiezingenprj3;Uid=root;Pwd=;");
        #endregion 

        #region methods/functions
        public DataTable SelectVerkiezing()
        {
            DataTable result = new DataTable();
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "SELECT * FROM verkiezing;";
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

        public bool InsertVerkiezing(string PartijName, string PartijAdres, string PartijPostcode, string PartijGemeente, string PartijEmailAdres, string PartijTelefoonNummer)
        {
            bool succes = false;
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "INSERT INTO `Partij` ( `PartijName`,`Adres`, `Postcode`, `Gemeente`, `EmailAdres`, `Telefoonnummer`) VALUES ( @PartijName, @Adres, @Postcode, @Gemeente, @EmailAdres, @Telefoonnummer) ";
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

      

        public bool UpdateVerkiezing(string Id, string SoortId, string VerkiezingSoort, string Datum)
        {
            bool succes = false;
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "UPDATE `verkiezing` SET `VerkiezingId` = @VerkiezingId, `Soort` = @Soort, `Verkiezingsoort` = @Verkiezingsoort, `Datum` = @Datum WHERE `verkiezing`.`VerkiezingId` = @VerkieizngId; ";
                command.Parameters.AddWithValue("@VerkiezingId", Id);
                command.Parameters.AddWithValue("@Soort", SoortId);
                command.Parameters.AddWithValue("@Verkiezingsoort", VerkiezingSoort);
                command.Parameters.AddWithValue("@Datum", Datum);
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
        public bool DeleteVerkiezing(string id)
        {
            bool succes = false;
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "DELETE FROM `verkiezing` WHERE `verkiezing`.`VerkiezingId` = @VerkiezingId;";
                command.Parameters.AddWithValue("@VerkiezingId", id);
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