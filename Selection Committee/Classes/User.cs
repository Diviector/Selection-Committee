using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Selection_Committee.Classes
{
    public static class User
    {
        private static string username;

        public static void setUsername(string username)
        {
            User.username = username;
        }

        public static string getUsername()
        {
            if (username == null)
            {
                throw new Exception("Нельзя получить имя. Оно не установлено");
            }
            return username;
        }
    }
}