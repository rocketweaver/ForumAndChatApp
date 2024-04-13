using ForumApp.Models;
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
    public partial class BanAdmin : Form
    {
        private BanViewModel banViewModel = new BanViewModel();
        private int selectedBanId;
        public BanAdmin()
        {
            InitializeComponent();
            LoadBans();
        }

        private void banForm_Load(object sender, EventArgs e)
        {
            LoadBans();
            // Set placeholder for text boxes
            SetPlaceholder(textUserId, "User ID");
            SetPlaceholder(textStartDate, "MM-DD-YYYY");
            SetPlaceholder(textEndDate, "MM-DD-YYYY");
        }

        private void textLevel_TextChanged(object sender, EventArgs e)
        {

        }
        private void LoadBans()
        {
            try
            {
                dataGridViewBans.DataSource = banViewModel.ReadBans();
                ClearData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearData()
        {
            textStartDate.Text = "";
            textEndDate.Text = "";
            selectedBanId = 0;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                int userId = Convert.ToInt32(textUserId.Text);
                DateTime startDate = Convert.ToDateTime(textStartDate.Text);
                DateTime endDate = Convert.ToDateTime(textEndDate.Text);
                banViewModel.CreateBan(userId, startDate, endDate);
                LoadBans();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedBanId != 0)
                {
                    if (DateTime.TryParse(textStartDate.Text, out DateTime startDate) &&
                        DateTime.TryParse(textEndDate.Text, out DateTime endDate))
                    {
                        if (startDate <= endDate)
                        {
                            // Update ban
                            banViewModel.UpdateBan(selectedBanId, startDate, endDate);

                            // Reload bans
                            LoadBans();
                        }
                        else
                        {
                            MessageBox.Show("Start date cannot be after end date.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid date format.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a ban to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedBanId != 0)
                {
                    banViewModel.DeleteBan(selectedBanId);
                    LoadBans();
                }
                else
                {
                    MessageBox.Show("Please select a ban to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewBans_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = dataGridViewBans.Rows[e.RowIndex];
                    selectedBanId = Convert.ToInt32(row.Cells["id_ban"].Value);
                    textStartDate.Text = row.Cells["start_date"].Value.ToString();
                    textEndDate.Text = row.Cells["end_date"].Value.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void SetPlaceholder(TextBox textBox, string placeholder)
        {
            textBox.ForeColor = Color.Gray;
            textBox.Text = placeholder;
            textBox.GotFocus += (source, e) =>
            {
                if (textBox.Text == placeholder)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;
                }
            };
            textBox.LostFocus += (source, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholder;
                    textBox.ForeColor = Color.Gray;
                }
            };
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearData();
        }
    }
}
