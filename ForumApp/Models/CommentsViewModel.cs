using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ForumApp.Models
{
    class CommentViewModel
    {
        private Koneksi koneksi;

        public CommentViewModel()
        {
            koneksi = new Koneksi();
        }

        public DataTable ReadComments()
        {
            DataTable dataTable = new DataTable();
            try
            {
                koneksi.bukaKoneksi();

                string query = @"SELECT 
                                    c.id_comment, 
                                    c.description AS comment_text, 
                                    c.comment_date, 
                                    u.username AS user_username, 
                                    u.level AS user_level
                                FROM 
                                    comments c
                                INNER JOIN 
                                    users u ON c.user_id = u.id_user";

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

        public void CreateComment(string commentText)
        {
            try
            {
                koneksi.bukaKoneksi();

                string query = @"INSERT INTO comments (description, comment_date) 
                                 VALUES (@comment_text, @comment_date)";
                SqlCommand command = new SqlCommand(query, koneksi.con);
                command.Parameters.AddWithValue("@comment_text", commentText);
                command.Parameters.AddWithValue("@comment_date", DateTime.Now);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Comment created successfully.");
                }
                else
                {
                    MessageBox.Show("Failed to create comment.");
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

        public void UpdateComment(int commentId, string commentText)
        {
            try
            {
                koneksi.bukaKoneksi();

                string query = @"UPDATE comments SET description = @comment_text 
                                 WHERE id_comment = @commentId";
                SqlCommand command = new SqlCommand(query, koneksi.con);
                command.Parameters.AddWithValue("@comment_text", commentText);
                command.Parameters.AddWithValue("@commentId", commentId);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Comment updated successfully.");
                }
                else
                {
                    MessageBox.Show("Failed to update comment.");
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

        public void DeleteComment(int commentId)
        {
            try
            {
                koneksi.bukaKoneksi();

                string deleteCommentQuery = "DELETE FROM comments WHERE id_comment = @commentId";
                SqlCommand deleteCommentCommand = new SqlCommand(deleteCommentQuery, koneksi.con);
                deleteCommentCommand.Parameters.AddWithValue("@commentId", commentId);
                deleteCommentCommand.ExecuteNonQuery();

                MessageBox.Show("Comment deleted successfully.");
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
