using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProject3App.Classes
{
    class VerkiezingSoortDB
    {
        #region fields
        MySqlConnection _connection = new MySqlConnection("Server=localhost;Database=verkiezingenprj3;Uid=root;Pwd=;");
        #endregion 

        public DataTable selectSoort()
        {
            DataTable result = new DataTable();

            _connection.Open();
            MySqlCommand command = _connection.CreateCommand();
            command.CommandText = "SELECT DISTINCT Verkiezingsoort FROM verkiezingsoort WHERE Verkiezingsoort IS NOT NULL;";
            MySqlDataReader reader = command.ExecuteReader();
            result.Load(reader);

            _connection.Close();
            return result;
        }
        public DataTable SelectVerkiezingSoort()
        {
            DataTable result = new DataTable();
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "SELECT * FROM verkiezingsoort;";
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

        public bool InsertVerkiezingSoort(string VerkiezingSoort)
        {
            bool succes = false;
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "INSERT INTO `verkiezingsoort` ( `SoortId`,`Verkiezingsoort`) VALUES ( NULL, @Soort) ";
                command.Parameters.AddWithValue("@Soort", VerkiezingSoort);
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
        public bool UpdateVerkiezingSoort(string VerkiezingSoort, string id)
        {
            bool succes = false;
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "UPDATE `verkiezingsoort` SET `Verkiezingsoort` = @Soort WHERE `verkiezingsoort`.`SoortId` = @id; ";
                command.Parameters.AddWithValue("@SoortId", id);
                command.Parameters.AddWithValue("@Soort", VerkiezingSoort);
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
        public bool DeleteVerkiezingSoort(string id)
        {
            bool succes = false;
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "DELETE FROM `verkiezingsoort` WHERE `verkiezingsoort`.`SoortId` = @id;";
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

    }
}
    

