using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ForumApp.Models
{
    class PostViewModel
    {
        private Koneksi koneksi;

        public PostViewModel()
        {
            koneksi = new Koneksi();
        }

        public DataTable ReadPosts()
        {
            DataTable dataTable = new DataTable();
            try
            {
                koneksi.bukaKoneksi();

                string query = @"SELECT 
                                    p.id_post, 
                                    p.title, 
                                    p.description, 
                                    p.post_date, 
                                    p.like_count, 
                                    u.username AS user_username, 
                                    u.level AS user_level
                                FROM 
                                    posts p
                                INNER JOIN 
                                    users u ON p.user_id = u.id_user";

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

        public void CreatePost(string title, string description, int userId)
        {
            try
            {
                koneksi.bukaKoneksi();

                string query = @"INSERT INTO posts (title, description, post_date, user_id) 
                                 VALUES (@title, @description, @post_date, @user_id)";
                SqlCommand command = new SqlCommand(query, koneksi.con);
                command.Parameters.AddWithValue("@title", title);
                command.Parameters.AddWithValue("@description", description);
                command.Parameters.AddWithValue("@post_date", DateTime.Now);
                command.Parameters.AddWithValue("@user_id", userId);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Post created successfully.");
                }
                else
                {
                    MessageBox.Show("Failed to create post.");
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

        public void UpdatePost( string title, string description, int adminId)
        {
            try
            {
                koneksi.bukaKoneksi();

                string query = @"UPDATE posts SET title = @title, description = @description, edited = 1 
                                 WHERE user_id = @adminId";
                SqlCommand command = new SqlCommand(query, koneksi.con);
                command.Parameters.AddWithValue("@title", title);
                command.Parameters.AddWithValue("@description", description);
                command.Parameters.AddWithValue("@adminId", adminId);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Post updated successfully.");
                }
                else
                {
                    MessageBox.Show("Failed to update post.");
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

        public void DeletePost(int postId)
        {
            try
            {
                koneksi.bukaKoneksi();

                string deleteReportsQuery = "DELETE FROM reports WHERE post_id = @postId";
                SqlCommand deleteReportsCommand = new SqlCommand(deleteReportsQuery, koneksi.con);
                deleteReportsCommand.Parameters.AddWithValue("@postId", postId);
                deleteReportsCommand.ExecuteNonQuery();

                string deletePostQuery = "DELETE FROM posts WHERE id_post = @postId";
                SqlCommand deletePostCommand = new SqlCommand(deletePostQuery, koneksi.con);
                deletePostCommand.Parameters.AddWithValue("@postId", postId);
                deletePostCommand.ExecuteNonQuery();

                MessageBox.Show("Post deleted successfully.");
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
