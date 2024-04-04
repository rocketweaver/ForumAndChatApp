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
    public class RegisterClass
    {
        private Koneksi.Koneksi koneksi;

        public RegisterClass()
        {
            koneksi = new Koneksi.Koneksi();
        }

        public bool CreateUser(string email, string username, string fullName, string password)
        {
            try
            {
                if (!IsValidEmail(email))
                {
                    MessageBox.Show("Format email tidak valid.");
                    return false;
                }

                koneksi.bukaKoneksi();

                string query = "INSERT INTO Users (Email, Username, FullName, Password) VALUES (@Email, @Username, @FullName, @Password)";
                SqlCommand command = new SqlCommand(query, koneksi.con);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@FullName", fullName);
                command.Parameters.AddWithValue("@Password", password);
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
        private bool IsValidEmail(string email)
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
