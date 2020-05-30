﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Selection_Committee
{
    public class Database
    {
        private MySqlConnection connection = new MySqlConnection("Server=localhost;Database=data_of_enrollee;Uid=XD0;Pwd=8Q}McX0gIdtP2c{8;");

        public void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public MySqlConnection GetConnection()
        {
            return connection;
        }
    }
}