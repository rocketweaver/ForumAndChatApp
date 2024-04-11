using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ForumApp
{
    class PostsModel
    {
        Koneksi koneksi = new Koneksi();

        public string like;
        public string id;
        public string userId;
        public string title;
        public string desc;
        public string postId;

        public DataSet Read()
        {
            DataSet ds = new DataSet();
            try
            {
                string query = "SELECT * FROM posts";
                SqlCommand com = new SqlCommand(query, koneksi.con);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds, "posts");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ds;
        }

        public DataRow ReadById()
        {
            DataRow row = null;
            try
            {
                koneksi.bukaKoneksi();

                if (string.IsNullOrEmpty(id))
                {
                    MessageBox.Show("No post related.");
                    return row;
                }

                string query = @"SELECT posts.*, users.username 
                                FROM posts JOIN users 
                                ON posts.user_id = users.id_user 
                                WHERE posts.id_post = @id";
                SqlCommand com = new SqlCommand(query, koneksi.con);
                com.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = com.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);

                if (dt.Rows.Count > 0)
                {
                    row = dt.Rows[0];
                }

                return row;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                koneksi.tutupKoneksi();
            }
        }

        public DataSet ReadByUserId()
        {
            DataSet ds = new DataSet();
            if (string.IsNullOrEmpty(userId))
            {
                MessageBox.Show("No post related.");
                return ds;
            }

            try
            {
                string query = "SELECT * FROM posts WHERE user_id = @id";
                SqlCommand com = new SqlCommand(query, koneksi.con);
                com.Parameters.AddWithValue("@id", userId);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds, "posts");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ds;
        }

        public DataSet ReadByShare()
        {
            DataSet ds = new DataSet();
            if (string.IsNullOrEmpty(userId))
            {
                MessageBox.Show("User ID is required.");
                return ds;
            }

            try
            {
                string query = @"SELECT p.* 
                         FROM posts p
                         INNER JOIN shared_posts sp ON p.id_post = sp.post_id
                         WHERE sp.user_id = @userId";

                SqlCommand com = new SqlCommand(query, koneksi.con);
                com.Parameters.AddWithValue("@userId", userId);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds, "posts");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ds;
        }


        public DataSet Search(string keyword)
        {
            DataSet ds = new DataSet();
            try
            {
                string query;

                if (string.IsNullOrEmpty(keyword))
                {
                    MessageBox.Show("Please enter a keyword.");
                    query = "SELECT * FROM posts";
                } else
                {
                    query = "SELECT * FROM posts WHERE title LIKE @keyword";
                }

                SqlCommand com = new SqlCommand(query, koneksi.con);

                if (!string.IsNullOrEmpty(keyword))
                {
                    com.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                }
                
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds, "posts");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ds;
        }

        public bool HasLiked()
        {
            try
            {
                koneksi.bukaKoneksi();

                string query = "SELECT COUNT(*) FROM liked_posts WHERE " +
                                "post_id = @postId AND user_id = @userId";
                SqlCommand com = new SqlCommand(query, koneksi.con);
                com.Parameters.AddWithValue("@postId", postId);
                com.Parameters.AddWithValue("@userId", UsersModel.UserId);

                int likeCount = (int)com.ExecuteScalar();

                return likeCount > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                koneksi.tutupKoneksi();
            }
        }

        public void Like()
        {
            try
            {
                koneksi.bukaKoneksi();

                string likeQuery = "INSERT INTO liked_posts (post_id, " +
                                    "user_id) VALUES (@postId, @userId)";
                SqlCommand likeCommand = new SqlCommand(likeQuery, koneksi.con);
                likeCommand.Parameters.AddWithValue("@postId", postId);
                likeCommand.Parameters.AddWithValue("@userId", UsersModel.UserId);
                likeCommand.ExecuteNonQuery();

                string updateQuery = "UPDATE posts SET like_count = like_count " +
                                    "+ 1 WHERE id_post = @postId";
                SqlCommand updateCommand = new SqlCommand(updateQuery, koneksi.con);
                updateCommand.Parameters.AddWithValue("@postId", postId);
                updateCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                koneksi.tutupKoneksi();
            }
        }

        public void Unlike()
        {
            try
            {
                koneksi.bukaKoneksi();

                string unlikeQuery = "DELETE FROM liked_posts WHERE post_id = @postId AND user_id = @userId";
                SqlCommand unlikeCommand = new SqlCommand(unlikeQuery, koneksi.con);
                unlikeCommand.Parameters.AddWithValue("@postId", postId);
                unlikeCommand.Parameters.AddWithValue("@userId", UsersModel.UserId);
                unlikeCommand.ExecuteNonQuery();

                string updateQuery = "UPDATE posts SET like_count = like_count - 1 WHERE id_post = @postId";
                SqlCommand updateCommand = new SqlCommand(updateQuery, koneksi.con);
                updateCommand.Parameters.AddWithValue("@postId", postId);
                updateCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                koneksi.tutupKoneksi();
            }
        }

        public bool HasShared()
        {
            try
            {
                koneksi.bukaKoneksi();

                string query = "SELECT COUNT(*) FROM shared_posts WHERE " +
                                "post_id = @postId AND user_id = @userId";
                SqlCommand com = new SqlCommand(query, koneksi.con);
                com.Parameters.AddWithValue("@postId", postId);
                com.Parameters.AddWithValue("@userId", UsersModel.UserId);

                int shareCount = (int)com.ExecuteScalar();

                return shareCount > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                koneksi.tutupKoneksi();
            }
        }

        public void Share()
        {
            try
            {
                koneksi.bukaKoneksi();

                string likeQuery = "INSERT INTO shared_posts (post_id, " +
                                    "user_id) VALUES (@postId, @userId)";
                SqlCommand likeCommand = new SqlCommand(likeQuery, koneksi.con);
                likeCommand.Parameters.AddWithValue("@postId", postId);
                likeCommand.Parameters.AddWithValue("@userId", UsersModel.UserId);
                likeCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                koneksi.tutupKoneksi();
            }
        }

        public void Unshare()
        {
            try
            {
                koneksi.bukaKoneksi();

                string unlikeQuery = "DELETE FROM shared_posts WHERE post_id = @postId AND user_id = @userId";
                SqlCommand unlikeCommand = new SqlCommand(unlikeQuery, koneksi.con);
                unlikeCommand.Parameters.AddWithValue("@postId", postId);
                unlikeCommand.Parameters.AddWithValue("@userId", UsersModel.UserId);
                unlikeCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                koneksi.tutupKoneksi();
            }
        }

        public void Create()
        {
            try
            {
                koneksi.bukaKoneksi();

                string query = "INSERT INTO posts (title, description, post_date, user_id) " +
                                "VALUES (@title, @desc, @post_date, @user_id)";
                SqlCommand com = new SqlCommand(query, koneksi.con);
                com.Parameters.AddWithValue("@title", title);
                com.Parameters.AddWithValue("@desc", desc);
                com.Parameters.AddWithValue("@post_date", DateTime.Now.ToString("yyyy-MM-dd"));
                com.Parameters.AddWithValue("@user_id", userId);
                int i = com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                koneksi.tutupKoneksi();
            }
        }

        public void Update()
        {
            try
            {
                koneksi.bukaKoneksi();

                string query = "UPDATE posts set title = @title, description = @desc " +
                                "WHERE id_post = @id";
                SqlCommand com = new SqlCommand(query, koneksi.con);
                com.Parameters.AddWithValue("@title", title);
                com.Parameters.AddWithValue("@desc", desc);
                com.Parameters.AddWithValue("@id", id);
                int i = com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

                using (SqlTransaction transaction = koneksi.con.BeginTransaction())
                {
                    try
                    {
                        string deleteReportsQuery = "DELETE FROM reports WHERE post_id = @id";
                        SqlCommand deleteReportsCommand = new SqlCommand(deleteReportsQuery, koneksi.con, transaction);
                        deleteReportsCommand.Parameters.AddWithValue("@id", id);
                        deleteReportsCommand.ExecuteNonQuery();

                        string deletePostQuery = "DELETE FROM posts WHERE id_post = @id";
                        SqlCommand deletePostCommand = new SqlCommand(deletePostQuery, koneksi.con, transaction);
                        deletePostCommand.Parameters.AddWithValue("@id", id);
                        deletePostCommand.ExecuteNonQuery();

                        transaction.Commit();

                        MessageBox.Show("Post deleted successfully.");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Failed to delete post: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to delete post: " + ex.Message);
            }
            finally
            {
                koneksi.tutupKoneksi();
            }
        }

    }
}
