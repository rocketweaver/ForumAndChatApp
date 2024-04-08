using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ForumApp
{
    class SharedViews
    {
        private Koneksi.Koneksi koneksi;
        public int SharedPostId { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }

        public SharedViews()
        {
            koneksi = new Koneksi.Koneksi();
        }

        public void Create()
        {
            try
            {
                koneksi.bukaKoneksi();
                string query = "INSERT INTO shared_posts (user_id, post_id) VALUES (@UserId, @PostId)";
                using (SqlCommand command = new SqlCommand(query, koneksi.con))
                {
                    command.Parameters.AddWithValue("@UserId", UserId);
                    command.Parameters.AddWithValue("@PostId", PostId);

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
                string query = "SELECT * FROM shared_posts";
                SqlDataAdapter da = new SqlDataAdapter(query, koneksi.con);
                da.Fill(ds, "shared_posts");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return ds;
        }

        public void Update()
        {
            // Jika Anda membutuhkan fungsi update, implementasikan sesuai kebutuhan
            MessageBox.Show("Fungsi Update belum diimplementasikan");
        }

        public void Delete()
        {
            // Jika Anda membutuhkan fungsi delete, implementasikan sesuai kebutuhan
            MessageBox.Show("Fungsi Delete belum diimplementasikan");
        }
    }
}
