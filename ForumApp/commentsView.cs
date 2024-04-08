using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ForumApp
{
    class CommentsView
    {
        private Koneksi.Koneksi koneksi;
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public DateTime CommentDate { get; set; }

        public CommentsView()
        {
            koneksi = new Koneksi.Koneksi();
        }

        public void Create()
        {
            try
            {
                koneksi.bukaKoneksi();
                string query = "INSERT INTO comments (user_id, description, comment_date) VALUES (@UserId, @Description, @CommentDate)";
                using (SqlCommand command = new SqlCommand(query, koneksi.con))
                {
                    command.Parameters.AddWithValue("@UserId", UserId);
                    command.Parameters.AddWithValue("@Description", Description);
                    command.Parameters.AddWithValue("@CommentDate", CommentDate);

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
                string query = "SELECT * FROM comments";
                SqlDataAdapter da = new SqlDataAdapter(query, koneksi.con);
                da.Fill(ds, "comments");
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
                string query = "UPDATE comments SET user_id = @UserId, description = @Description, comment_date = @CommentDate WHERE id_comment = @CommentId";
                using (SqlCommand command = new SqlCommand(query, koneksi.con))
                {
                    command.Parameters.AddWithValue("@UserId", UserId);
                    command.Parameters.AddWithValue("@Description", Description);
                    command.Parameters.AddWithValue("@CommentDate", CommentDate);
                    command.Parameters.AddWithValue("@CommentId", CommentId);

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
                string query = "DELETE FROM comments WHERE id_comment = @CommentId";
                using (SqlCommand command = new SqlCommand(query, koneksi.con))
                {
                    command.Parameters.AddWithValue("@CommentId", CommentId);

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
