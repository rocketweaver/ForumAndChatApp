using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ForumApp.Models
{
    class BanViewModel
    {
        private Koneksi koneksi;

        public BanViewModel()
        {
            koneksi = new Koneksi();
        }

        public DataTable ReadBans()
        {
            DataTable dataTable = new DataTable();
            try
            {
                koneksi.bukaKoneksi();

                string query = @"SELECT 
                                    b.id_ban, 
                                    b.user_id,
                                    u.username,
                                    b.start_date, 
                                    b.end_date
                                FROM 
                                    ban b
                                INNER JOIN 
                                    users u ON b.user_id = u.id_user";

                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, koneksi.con);
                dataAdapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                koneksi.tutupKoneksi();
            }

            return dataTable;
        }

        public void CreateBan(int userId, DateTime startDate, DateTime endDate)
        {
            try
            {
                koneksi.bukaKoneksi();

                string query = @"INSERT INTO ban (user_id, start_date, end_date) 
                                 VALUES (@user_id, @start_date, @end_date)";
                SqlCommand command = new SqlCommand(query, koneksi.con);
                command.Parameters.AddWithValue("@user_id", userId);
                command.Parameters.AddWithValue("@start_date", startDate);
                command.Parameters.AddWithValue("@end_date", endDate);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Ban created successfully.");
                }
                else
                {
                    MessageBox.Show("Failed to create ban.");
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

        public void UpdateBan(int banId, DateTime newStartDate, DateTime newEndDate)
        {
            try
            {
                koneksi.bukaKoneksi();

                string query = @"UPDATE ban SET start_date = @newStartDate, end_date = @newEndDate 
                         WHERE id_ban = @banId";
                SqlCommand command = new SqlCommand(query, koneksi.con);
                command.Parameters.AddWithValue("@newStartDate", newStartDate);
                command.Parameters.AddWithValue("@newEndDate", newEndDate);
                command.Parameters.AddWithValue("@banId", banId);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Ban updated successfully.");
                }
                else
                {
                    MessageBox.Show("Failed to update ban.");
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


        public void DeleteBan(int banId)
        {
            try
            {
                koneksi.bukaKoneksi();

                string deleteBanQuery = "DELETE FROM ban WHERE id_ban = @banId";
                SqlCommand deleteBanCommand = new SqlCommand(deleteBanQuery, koneksi.con);
                deleteBanCommand.Parameters.AddWithValue("@banId", banId);
                deleteBanCommand.ExecuteNonQuery();

                MessageBox.Show("Ban deleted successfully.");
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
