using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumApp.Koneksi;
using System.Text.RegularExpressions;

namespace ForumApp
{

    class Users
    {
        private Koneksi.Koneksi koneksi;

        // Properties for user information
        public int UserId { get; private set; }
        public string Username { get; set; }
        public string Email { get; private set; }
        public int Level { get; private set; }

        public Users()
        {
            koneksi = new Koneksi.Koneksi();
        }

        public bool SetUsers(string email, string password)
        {
            try
            {
                koneksi.bukaKoneksi();

                string query = "SELECT COUNT(*) FROM Users WHERE Email = @Email AND Password = @Password";
                SqlCommand command = new SqlCommand(query, koneksi.con);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", password);

                int count = (int)command.ExecuteScalar();

                if (count > 0)
                {
                    // Jika autentikasi berhasil, ambil informasi pengguna
                    query = "SELECT id_user, Username, level FROM Users WHERE Email = @Email";
                    command = new SqlCommand(query, koneksi.con);
                    command.Parameters.AddWithValue("@Email", email);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        UserId = Convert.ToInt32(reader["id_user"]);
                        Username = reader["Username"].ToString();
                        Email = email;
                        Level = Convert.ToInt32(reader["level"]);
                    }

                    reader.Close();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during login: " + ex.Message);
                return false;
            }
            finally
            {
                koneksi.tutupKoneksi();
            }
        }
    }
}

