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

        public DataSet ReadById()
        {
            DataSet ds = new DataSet();
            try
            {
                string query = @"SELECT c.*, u.username 
                                FROM comments c
                                JOIN posts p ON c.post_id = p.id_post
                                JOIN users u ON p.user_id = u.id_user
                                WHERE c.post_id = @post_id
                                ";
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
    }
}
