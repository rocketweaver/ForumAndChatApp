using ForumApp.Koneksi;
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
    class Posts
    {
        Koneksi.Koneksi koneksi = new Koneksi.Koneksi();

        public int like;
        public int id;

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

        public DataRow ReadById(string id)
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

        public DataSet ReadByUserId(string id)
        {
            DataSet ds = new DataSet();
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("No post related.");
                return ds;
            }

            try
            {
                string query = "SELECT * FROM posts WHERE user_id = @id";
                SqlCommand com = new SqlCommand(query, koneksi.con);
                com.Parameters.AddWithValue("@id", id);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds, "posts");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ds;
        }

        public DataSet ReadByShare(string id)
        {
            DataSet ds = new DataSet();
            if (string.IsNullOrEmpty(id))
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
                com.Parameters.AddWithValue("@userId", id);
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
                if (string.IsNullOrEmpty(keyword))
                {
                    MessageBox.Show("Please enter a keyword.");
                    return ds;
                }

                string query = "SELECT * FROM posts WHERE title LIKE @keyword";
                SqlCommand com = new SqlCommand(query, koneksi.con);
                com.Parameters.AddWithValue("@keyword", "%" + keyword + "%"); // Add wildcard % to search for partial matches
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds, "posts");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ds;
        }

        public bool HasLiked(string postId)
        {
            try
            {
                koneksi.bukaKoneksi();

                string query = "SELECT COUNT(*) FROM liked_posts WHERE " +
                                "post_id = @postId AND user_id = @userId";
                SqlCommand com = new SqlCommand(query, koneksi.con);
                com.Parameters.AddWithValue("@postId", postId);
                com.Parameters.AddWithValue("@userId", Users.UserId);

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

        public void Like(string postId)
        {
            try
            {
                koneksi.bukaKoneksi();

                string likeQuery = "INSERT INTO liked_posts (post_id, " +
                                    "user_id) VALUES (@postId, @userId)";
                SqlCommand likeCommand = new SqlCommand(likeQuery, koneksi.con);
                likeCommand.Parameters.AddWithValue("@postId", postId);
                likeCommand.Parameters.AddWithValue("@userId", Users.UserId);
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

        public void Unlike(string postId)
        {
            try
            {
                koneksi.bukaKoneksi();

                string unlikeQuery = "DELETE FROM liked_posts WHERE post_id = @postId AND user_id = @userId";
                SqlCommand unlikeCommand = new SqlCommand(unlikeQuery, koneksi.con);
                unlikeCommand.Parameters.AddWithValue("@postId", postId);
                unlikeCommand.Parameters.AddWithValue("@userId", Users.UserId);
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

        public bool HasShared(string postId)
        {
            try
            {
                koneksi.bukaKoneksi();

                string query = "SELECT COUNT(*) FROM shared_posts WHERE " +
                                "post_id = @postId AND user_id = @userId";
                SqlCommand com = new SqlCommand(query, koneksi.con);
                com.Parameters.AddWithValue("@postId", postId);
                com.Parameters.AddWithValue("@userId", Users.UserId);

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

        public void Share(string postId)
        {
            try
            {
                koneksi.bukaKoneksi();

                string likeQuery = "INSERT INTO shared_posts (post_id, " +
                                    "user_id) VALUES (@postId, @userId)";
                SqlCommand likeCommand = new SqlCommand(likeQuery, koneksi.con);
                likeCommand.Parameters.AddWithValue("@postId", postId);
                likeCommand.Parameters.AddWithValue("@userId", Users.UserId);
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

        public void Unshare(string postId)
        {
            try
            {
                koneksi.bukaKoneksi();

                string unlikeQuery = "DELETE FROM shared_posts WHERE post_id = @postId AND user_id = @userId";
                SqlCommand unlikeCommand = new SqlCommand(unlikeQuery, koneksi.con);
                unlikeCommand.Parameters.AddWithValue("@postId", postId);
                unlikeCommand.Parameters.AddWithValue("@userId", Users.UserId);
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
    }
}
