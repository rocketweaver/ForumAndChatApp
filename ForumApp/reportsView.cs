using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ForumApp
{
    class ReportsView
    {
        private Koneksi.Koneksi koneksi;
        public int ReportId { get; set; }
        public int ReporterId { get; set; }
        public int ReportedId { get; set; }
        public int PostId { get; set; }
        public int CommentId { get; set; }
        public string Description { get; set; }

        public ReportsView()
        {
            koneksi = new Koneksi.Koneksi();
        }

        public void Create()
        {
            try
            {
                koneksi.bukaKoneksi();
                string query = "INSERT INTO reports (reporter_id, reported_id, post_id, comment_id, description) VALUES (@ReporterId, @ReportedId, @PostId, @CommentId, @Description)";
                using (SqlCommand command = new SqlCommand(query, koneksi.con))
                {
                    command.Parameters.AddWithValue("@ReporterId", ReporterId);
                    command.Parameters.AddWithValue("@ReportedId", ReportedId);
                    command.Parameters.AddWithValue("@PostId", PostId);
                    command.Parameters.AddWithValue("@CommentId", CommentId);
                    command.Parameters.AddWithValue("@Description", Description);

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
                string query = "SELECT * FROM reports";
                SqlDataAdapter da = new SqlDataAdapter(query, koneksi.con);
                da.Fill(ds, "reports");
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
