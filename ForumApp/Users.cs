using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumApp.Koneksi;

namespace ForumApp
{

    class Users
    {
        private Koneksi.Koneksi koneksi;

        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Username { get;  set; }

        public Users()
        {
            koneksi = new Koneksi.Koneksi();
        }

        public bool SetUsers(string email, string password)
        {
            try
            {
                koneksi.bukaKoneksi();

                string query = "SELECT Username FROM Users WHERE Email = @Email AND Password = @Password";
                SqlCommand command = new SqlCommand(query, koneksi.con);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", password);

                // Execute the query
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read()) // If there is a matching entry
                {
                    Email = email;
                    Password = password;
                    Username = reader["Username"].ToString();

                    reader.Close();
                    return true;
                }
                else
                {
                    reader.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
            finally
            {
                koneksi.tutupKoneksi();
            }
        }
    }
}

