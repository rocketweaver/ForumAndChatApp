using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ForumApp
{
    public class RegisterModel
    {
        private Koneksi koneksi;

        public RegisterModel()
        {
            koneksi = new Koneksi();
        }

        public bool CreateUser(string email, string username, string password, string pin)
        {
            try
            {
               /* if (!IsValidEmail(email))
                {
                    MessageBox.Show("Format email is incorrect.");
                    return false;
                }*/

                koneksi.bukaKoneksi();

                string query = "INSERT INTO Users (Email, Username, Password, Level, pin) " +
                                "VALUES (@Email, @Username, @Password, @Level, @pin)";
                SqlCommand command = new SqlCommand(query, koneksi.con);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);
                command.Parameters.AddWithValue("@pin", pin);
                command.Parameters.AddWithValue("@Level", 1); // Set level default ke 1

                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
            finally
            {
                koneksi.tutupKoneksi();
            }
        }
        public bool IsValidEmail(string email)
        {
            // Pattern regex untuk email
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            // Membuat objek regex
            Regex regex = new Regex(pattern);

            // Memeriksa apakah email sesuai dengan pola regex
            return regex.IsMatch(email);
        }
    }
}
