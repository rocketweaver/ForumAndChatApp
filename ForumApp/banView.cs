using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ForumApp
{
    class BanView
    {
        private Koneksi.Koneksi koneksi;
        public int BanId { get; set; }
        public int UserId { get; set; }
        public int BanCount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public BanView()
        {
            koneksi = new Koneksi.Koneksi();
        }

        public void Create()
        {
            try
            {
                koneksi.bukaKoneksi();
                string query = "INSERT INTO ban (user_id, ban_count, start_date, end_date) VALUES (@UserId, @BanCount, @StartDate, @EndDate)";
                using (SqlCommand command = new SqlCommand(query, koneksi.con))
                {
                    command.Parameters.AddWithValue("@UserId", UserId);
                    command.Parameters.AddWithValue("@BanCount", BanCount);
                    command.Parameters.AddWithValue("@StartDate", StartDate);
                    command.Parameters.AddWithValue("@EndDate", EndDate);

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
                string query = "SELECT * FROM ban";
                SqlDataAdapter da = new SqlDataAdapter(query, koneksi.con);
                da.Fill(ds, "ban");
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
                string query = "UPDATE ban SET user_id = @UserId, ban_count = @BanCount, start_date = @StartDate, end_date = @EndDate WHERE id_ban = @BanId";
                using (SqlCommand command = new SqlCommand(query, koneksi.con))
                {
                    command.Parameters.AddWithValue("@UserId", UserId);
                    command.Parameters.AddWithValue("@BanCount", BanCount);
                    command.Parameters.AddWithValue("@StartDate", StartDate);
                    command.Parameters.AddWithValue("@EndDate", EndDate);
                    command.Parameters.AddWithValue("@BanId", BanId);

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
                string query = "DELETE FROM ban WHERE id_ban = @BanId";
                using (SqlCommand command = new SqlCommand(query, koneksi.con))
                {
                    command.Parameters.AddWithValue("@BanId", BanId);

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
