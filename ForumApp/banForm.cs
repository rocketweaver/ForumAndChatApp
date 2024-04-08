using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ForumApp
{
    public partial class banForm : Form
    {
        public banForm()
        {
            InitializeComponent();
            LoadData();
        }

        private void banForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void textLevel_TextChanged(object sender, EventArgs e)
        {

        }
        void LoadData()
        {
            try
            {
                BanView ban = new BanView();
                DataSet ds = ban.Read();
                dataGridViewBans.DataSource = ds;
                dataGridViewBans.DataMember = "bans";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void ClearData()
        {
            textBanId.Text = "";
            textUserId.Text = "";
            textBanCount.Text = "";
            textStartDate.Text = "";
            textEndDate.Text = "";
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            BanView ban = new BanView();
            if (int.TryParse(textUserId.Text, out int userId) && int.TryParse(textBanCount.Text, out int banCount))
            {
                ban.UserId = userId;
                ban.BanCount = banCount;
                ban.StartDate = Convert.ToDateTime(textStartDate.Text);
                ban.EndDate = Convert.ToDateTime(textEndDate.Text);
                ban.Create();
                LoadData();
                ClearData();
            }
            else
            {
                MessageBox.Show("UserID dan Ban Count harus berupa bilangan bulat.");
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            BanView ban = new BanView();
            if (int.TryParse(textUserId.Text, out int userId) && int.TryParse(textBanCount.Text, out int banCount))
            {
                ban.UserId = userId;
                ban.BanCount = banCount;

                // Validasi dan konversi tanggal mulai (Start Date)
                if (DateTime.TryParseExact(textStartDate.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime startDate))
                {
                    ban.StartDate = startDate;

                    // Validasi dan konversi tanggal selesai (End Date)
                    if (DateTime.TryParseExact(textEndDate.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime endDate))
                    {
                        ban.EndDate = endDate;

                        // Jika semua data sudah valid, lakukan operasi penyimpanan
                        ban.Create();
                        LoadData();
                        ClearData();
                    }
                    else
                    {
                        MessageBox.Show("Format tanggal akhir tidak valid. Harap masukkan tanggal dengan format 'YYYY-MM-DD'.");
                    }
                }
                else
                {
                    MessageBox.Show("Format tanggal mulai tidak valid. Harap masukkan tanggal dengan format 'YYYY-MM-DD'.");
                }
            }
            else
            {
                MessageBox.Show("UserID dan Ban Count harus berupa bilangan bulat.");
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            BanView ban = new BanView();
            if (int.TryParse(textBanId.Text, out int banId))
            {
                ban.BanId = banId;
                ban.Delete();
                LoadData();
                ClearData();
            }
            else
            {
                MessageBox.Show("BanID harus berupa bilangan bulat.");
            }
        }

        private void dataGridViewBans_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.RowIndex < dataGridViewBans.RowCount - 1)
            {
                textBanId.Text = dataGridViewBans.Rows[e.RowIndex].Cells[0].Value.ToString();
                textUserId.Text = dataGridViewBans.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBanCount.Text = dataGridViewBans.Rows[e.RowIndex].Cells[2].Value.ToString();
                textStartDate.Text = dataGridViewBans.Rows[e.RowIndex].Cells[3].Value.ToString();
                textEndDate.Text = dataGridViewBans.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
        }
    }
}
