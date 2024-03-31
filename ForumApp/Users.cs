using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApp
{
    class Users
    {


        public static string email;
        public static string password;
        public static string username;

        string usersEmail = "arbhy@gmail.com";
        string usersPassword = "arb123";

        public bool SetUsers(string email, string password)
        {
            if (email == usersEmail && password == usersPassword)
            {
                Users.email = email;
                Users.password = password;
                Users.username = "Arbhy";

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
