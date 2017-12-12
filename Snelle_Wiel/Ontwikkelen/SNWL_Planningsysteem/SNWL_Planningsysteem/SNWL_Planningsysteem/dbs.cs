using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using BCrypt.Net;
using System.Data;
using System.Windows;

namespace SNWL_Planningsysteem
{
    class dbs
    {
        #region fields
        private string conn;
        private MySqlConnection connect;
        #endregion

        //Connectie met de database
        public void db_connection()
        {
            try
            {
                conn = "Server=146.185.166.227;Database=planningsysteem_snwl;Uid=groenevingers;Pwd=groenevingers123;";
                connect = new MySqlConnection(conn);
                connect.Open();
            }

            catch (MySqlException) //Foutafhandeling
            {
                MessageBox.Show("Kan geen verbinding maken met de database", "Error");
                throw;
            }
        }

        public DataTable Search(string sTable)
        {
            DataTable retValue = new DataTable();
            db_connection();
            using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM " + sTable))
            {
                cmd.Connection = connect;
                MySqlDataReader reader = cmd.ExecuteReader();
                retValue.Load(reader);
                connect.Close();
            }

            //Return result
            return retValue;
        }

        public DataTable SearchParameter(string sTable, string sParameterA, string sParameterB)
        {
            DataTable retValue = new DataTable();
            db_connection();
            using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM " + sTable + " WHERE " + sParameterA + "=" + sParameterB))
            {
                cmd.Connection = connect;
                MySqlDataReader reader = cmd.ExecuteReader();
                retValue.Load(reader);
                connect.Close();
            }

            //Return result
            return retValue;
        }

        public DataTable SearchParameterLike(string sTable, string sParameterA, string sParameterB)
        {
            DataTable retValue = new DataTable();
            db_connection();
            using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM " + sTable + " WHERE " + sParameterA + " LIKE '%" + sParameterB + "%'"))
            {
                cmd.Connection = connect;
                MySqlDataReader reader = cmd.ExecuteReader();
                retValue.Load(reader);
                connect.Close();
            }

            //Return result
            return retValue;
        }

        public DataTable SearchNameAccount(string sTable, string sParameterA)
        {
            DataTable retValue = new DataTable();
            db_connection();
            using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM " + sTable + " WHERE Firstname LIKE '%" + sParameterA + "%' OR Insertion LIKE '%" + sParameterA + "%' OR Lastname LIKE '%" + sParameterA + "%'"))
            {
                cmd.Connection = connect;
                MySqlDataReader reader = cmd.ExecuteReader();
                retValue.Load(reader);
                connect.Close();
            }

            //Return result
            return retValue;
        }

        public bool DeleteAccount(string sTable, string id)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand("DELETE FROM " + sTable + " WHERE ID = @id");
            cmd.Connection = connect;
            cmd.Parameters.AddWithValue("@id", id);     //Parameter with ID

            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }

            catch       //Foutafhandeling
            {
                return false;
            }

            finally     //Close database connection
            {
                connect.Close();
            }
        }

        public bool updateAccount(string sTable, string id, string voornaam, string tussenvoegsel, string achternaam, string straatnaam, string huisnummer, string woonplaats)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand("UPDATE " + sTable + " SET `Firstname`= '" + voornaam + "', `Insertion`= '" + tussenvoegsel + "', `Lastname`= '" + achternaam + "', `Streetname`= '" + straatnaam + "', `Housenumber`= '" + huisnummer + "', `City`= '" + woonplaats + "' WHERE ID =" + id);
            cmd.Connection = connect;

            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }

            catch       //Foutafhandeling
            {
                return false;
            }

            finally     //Close database connection
            {
                connect.Close();
            }
        }
    }
}