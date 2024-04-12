using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ForumApp.Models
{
    class BanModel
    {
        Koneksi koneksi = new Koneksi();

        public int BanId { get; set; }
        public int UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public bool CheckBan()
        {
            try
            {
                koneksi.bukaKoneksi();

                string query = "SELECT start_date, end_date FROM ban WHERE user_id = @userId";
                SqlCommand com = new SqlCommand(query, koneksi.con);
                com.Parameters.AddWithValue("@userId", UserId);

                SqlDataReader reader = com.ExecuteReader();

                if (reader.Read())
                {
                    StartDate = ((DateTime)reader["start_date"]).Date;
                    EndDate = ((DateTime)reader["end_date"]).Date;

                    DateTime CurrentDate = DateTime.Today;

                    if( CurrentDate >= StartDate && CurrentDate <= EndDate ) {
                        TimeSpan remainingDays = EndDate - CurrentDate;
                        int banCount = remainingDays.Days;  

                        MessageBox.Show("Your account is still banned for " + banCount.ToString() + 
                                        " days.");
                        return true;
                    }
                    else 
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                koneksi.tutupKoneksi();
            }
        }
    }
}
