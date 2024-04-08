using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ForumApp
{
    public partial class userAdmin : Form
    {
        public userAdmin()
        {
            InitializeComponent();
            LoadData();
        }

        private void userAdmin_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        void LoadData()
        {
            try
            {
                UsersView user = new UsersView();
                DataSet ds = user.Read();
                dataGridViewUsers.DataSource = ds;
                dataGridViewUsers.DataMember = "users";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void ClearData()
        {
            textUserID.Text = "";
            textUsername.Text = "";
            textEmail.Text = "";
            textPassword.Text = "";
            textLevel.Text = "";
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            UsersView user = new UsersView();
            user.Username = textUsername.Text;
            user.Email = textEmail.Text;
            user.Password = textPassword.Text;
            if (int.TryParse(textLevel.Text, out int level))
            {
                user.Level = level;
                user.Create();
                LoadData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Level harus berupa bilangan bulat.");
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            UsersView user = new UsersView();
            if (int.TryParse(textUserID.Text, out int userId))
            {
                user.UserId = userId;
                user.Username = textUsername.Text;
                user.Email = textEmail.Text;
                user.Password = textPassword.Text;
                if (int.TryParse(textLevel.Text, out int level))
                {
                    user.Level = level;
                    user.Update();
                    LoadData();
                    ClearData();
                }
                else
                {
                    MessageBox.Show("Level harus berupa bilangan bulat.");
                }
            }
            else
            {
                MessageBox.Show("ID user harus berupa bilangan bulat.");
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            UsersView user = new UsersView();
            if (int.TryParse(textUserID.Text, out int userId))
            {
                user.UserId = userId;
                user.Delete();
                LoadData();
                ClearData();
            }
            else
            {
                MessageBox.Show("ID user harus berupa bilangan bulat.");
            }
        }

        private void dataGridViewUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.RowIndex < dataGridViewUsers.RowCount - 1)
            {
                textUserID.Text = dataGridViewUsers.Rows[e.RowIndex].Cells[0].Value.ToString();
                textUsername.Text = dataGridViewUsers.Rows[e.RowIndex].Cells[1].Value.ToString();
                textEmail.Text = dataGridViewUsers.Rows[e.RowIndex].Cells[2].Value.ToString();
                textPassword.Text = dataGridViewUsers.Rows[e.RowIndex].Cells[3].Value.ToString();
                textLevel.Text = dataGridViewUsers.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
        }
    }

}
