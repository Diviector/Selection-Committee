using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Selection_Committee.Classes
{
    public static class User
    {
        private static string username;
        public static bool agreement = false;

        public static void setUsername(string username)
        {
            User.username = username;
            agreement = checkAgreement();
        }

        public static string getUsername()
        {
            if (username == null)
            {
                throw new Exception("Нельзя получить имя. Оно не установлено");
            }
            return username;
        }

        private static bool checkAgreement()
        {
            Database db = new Database();

            MySqlCommand command = new MySqlCommand("get_agreement", db.GetConnection());

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("_username", MySqlDbType.VarChar).Value = username;

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = command;

            DataTable table = new DataTable();
            db.OpenConnection();
            adapter.Fill(table);
            db.CloseConnection();

            if (table.Rows[0][0].ToString() == "1")
            {
                return true;
            }
            return false;
        }

        public static void setAgreementTrue()
        {
            Database db = new Database();

            MySqlCommand command = new MySqlCommand("agreement_set_true", db.GetConnection());

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("_username", MySqlDbType.VarChar).Value = username;

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = command;

            db.OpenConnection();
            command.ExecuteNonQuery();
            db.CloseConnection();
        }
    }
}