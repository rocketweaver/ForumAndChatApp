using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ForumApp
{
    class UsersView
    {
        private Koneksi.Koneksi koneksi;
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Level { get; set; }

        public UsersView()
        {
            koneksi = new Koneksi.Koneksi();
        }

        public void Create()
        {
            try
            {
                koneksi.bukaKoneksi();
                string query = "INSERT INTO users (Username, Email, Password, Level) VALUES (@Username, @Email, @Password, @Level)";
                using (SqlCommand command = new SqlCommand(query, koneksi.con))
                {
                    command.Parameters.AddWithValue("@Username", Username);
                    command.Parameters.AddWithValue("@Email", Email);
                    command.Parameters.AddWithValue("@Password", Password);
                    command.Parameters.AddWithValue("@Level", Level);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Data berhasil dimasukkan");
                    }
                    else
                    {
                        MessageBox.Show("Data gagal dimasukkan");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                koneksi.tutupKoneksi();
            }
        }

        public DataSet Read()
        {
            DataSet ds = new DataSet();
            try
            {
                string query = "SELECT * FROM users";
                SqlDataAdapter da = new SqlDataAdapter(query, koneksi.con);
                da.Fill(ds, "users");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return ds;
        }

        public void Update()
        {
            try
            {
                koneksi.bukaKoneksi();
                string query = "UPDATE users SET Username = @Username, Email = @Email, Password = @Password, Level = @Level WHERE UserId = @UserId";
                using (SqlCommand command = new SqlCommand(query, koneksi.con))
                {
                    command.Parameters.AddWithValue("@Username", Username);
                    command.Parameters.AddWithValue("@Email", Email);
                    command.Parameters.AddWithValue("@Password", Password);
                    command.Parameters.AddWithValue("@Level", Level);
                    command.Parameters.AddWithValue("@UserId", UserId);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Data berhasil diperbarui");
                    }
                    else
                    {
                        MessageBox.Show("Data gagal diperbarui");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                koneksi.tutupKoneksi();
            }
        }

        public void Delete()
        {
            try
            {
                koneksi.bukaKoneksi();
                string query = "DELETE FROM users WHERE UserId = @UserId";
                using (SqlCommand command = new SqlCommand(query, koneksi.con))
                {
                    command.Parameters.AddWithValue("@UserId", UserId);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Data berhasil dihapus");
                    }
                    else
                    {
                        MessageBox.Show("Data tidak ditemukan atau gagal dihapus");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                koneksi.tutupKoneksi();
            }
        }
    }
}
