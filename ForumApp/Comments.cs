using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ForumApp
{
    class Comments
    {

        public string id;
        public string userId;
        public string postId;
        public string description;
        public string commentDate;

        Koneksi.Koneksi koneksi = new Koneksi.Koneksi();

        public DataSet ReadByPostId()
        {
            DataSet ds = new DataSet();
            try
            {
                string query = @"SELECT c.*, u.username 
                                FROM comments c
                                JOIN users u ON c.user_id = u.id_user
                                WHERE c.post_id = @post_id
                                ORDER BY c.id_comment";
                SqlCommand com = new SqlCommand(query, koneksi.con);
                com.Parameters.AddWithValue("@post_id", postId);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds, "comments");
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
                    MessageBox.Show("No comment related.");
                    return row;
                }

                string query = @"SELECT description
                                FROM comments WHERE id_comment = @id";
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

        public void Create()
        {
            try
            {
                koneksi.bukaKoneksi();
                string query = "INSERT INTO comments (user_id, post_id, description, comment_date) " +
                                "VALUES (@user_id, @post_id, @desc, @date);";
                SqlCommand com = new SqlCommand(query, koneksi.con);
                com.Parameters.AddWithValue("@user_id", userId);
                com.Parameters.AddWithValue("@post_id", postId);
                com.Parameters.AddWithValue("@desc", description);
                com.Parameters.AddWithValue("@date", DateTime.Now);
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
                string query = "UPDATE comments SET description = @desc, comment_date = @date, " +
                                "edited = 1 WHERE id_comment = @id;";
                SqlCommand com = new SqlCommand(query, koneksi.con);
                com.Parameters.AddWithValue("@date", DateTime.Now);
                com.Parameters.AddWithValue("@desc", description);
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
                string query = "DELETE FROM comments WHERE id_comment = @id;";
                SqlCommand com = new SqlCommand(query, koneksi.con);
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

    }
}
