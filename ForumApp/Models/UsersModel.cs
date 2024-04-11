using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumApp;
using System.Text.RegularExpressions;
using System.Data;
using System.Windows.Forms;

namespace ForumApp
{
    class UsersModel
    {
        private static Koneksi koneksi = new Koneksi();

        public static int UserId { get; private set; }
        public static string Username { get; private set; }
        public static string Email { get; private set; }
        public static int Level { get; private set; }

        public int id;
        public string username;
        public string email;
        public string password;

        public static bool SetUsers(string email, string password)
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

        public DataRow ReadById()
        {
            DataRow row = null;
            try
            {
                koneksi.bukaKoneksi();

                if (id == null)
                {
                    MessageBox.Show("No user related.");
                    return row;
                }

                string query = @"SELECT *
                                FROM users WHERE id_user = @id";
                SqlCommand com = new SqlCommand(query, koneksi.con);
                com.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = com.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);

                if (dt.Rows.Count > 0)
                {
                    row = dt.Rows[0];
                }

                return row;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                koneksi.tutupKoneksi();
            }
        }
    }
}

