using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;

namespace ForumApp.Models
{
    internal class ReportsModel
    {
        public int? id;
        public int reporterId;
        public int? postId;
        public int? commentId;
        public string desc;

        Koneksi koneksi = new Koneksi();

        public void Create()
        {
            try
            {
                koneksi.bukaKoneksi();
                string query;

                if (postId == null)
                {
                    query = "INSERT INTO reports (reporter_id, comment_id, description) " +
                            "VALUES (@reporterId, @commentId, @desc)";
                }
                else
                {
                    query = "INSERT INTO reports (reporter_id, post_id, description) " +
                            "VALUES (@reporterId, @postId, @desc)";
                }

                SqlCommand com = new SqlCommand(query, koneksi.con);
                com.Parameters.AddWithValue("@reporterId", reporterId);
                com.Parameters.AddWithValue("@desc", desc);

                if (postId == null)
                {
                    com.Parameters.AddWithValue("@commentId", commentId);
                }
                else
                {
                    com.Parameters.AddWithValue("@postId", postId);
                }

                int i = com.ExecuteNonQuery();
                MessageBox.Show("Your report has been submitted.");
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
