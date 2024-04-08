using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ForumApp
{
    class PostsView
    {
        private Koneksi.Koneksi koneksi;
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PostDate { get; set; }
        public int LikeCount { get; set; }
        public int UserId { get; set; }

        public PostsView()
        {
            koneksi = new Koneksi.Koneksi();
        }

        public void Create()
        {
            try
            {
                koneksi.bukaKoneksi();
                string query = "INSERT INTO posts (title, description, post_date, like_count, user_id) VALUES (@Title, @Description, @PostDate, @LikeCount, @UserId)";
                using (SqlCommand command = new SqlCommand(query, koneksi.con))
                {
                    command.Parameters.AddWithValue("@Title", Title);
                    command.Parameters.AddWithValue("@Description", Description);
                    command.Parameters.AddWithValue("@PostDate", PostDate);
                    command.Parameters.AddWithValue("@LikeCount", LikeCount);
                    command.Parameters.AddWithValue("@UserId", UserId);

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
                string query = "SELECT * FROM posts";
                SqlDataAdapter da = new SqlDataAdapter(query, koneksi.con);
                da.Fill(ds, "posts");
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
                string query = "UPDATE posts SET title = @Title, description = @Description, post_date = @PostDate, like_count = @LikeCount, user_id = @UserId WHERE id_post = @PostId";
                using (SqlCommand command = new SqlCommand(query, koneksi.con))
                {
                    command.Parameters.AddWithValue("@Title", Title);
                    command.Parameters.AddWithValue("@Description", Description);
                    command.Parameters.AddWithValue("@PostDate", PostDate);
                    command.Parameters.AddWithValue("@LikeCount", LikeCount);
                    command.Parameters.AddWithValue("@UserId", UserId);
                    command.Parameters.AddWithValue("@PostId", PostId);

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
                string query = "DELETE FROM posts WHERE id_post = @PostId";
                using (SqlCommand command = new SqlCommand(query, koneksi.con))
                {
                    command.Parameters.AddWithValue("@PostId", PostId);

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
