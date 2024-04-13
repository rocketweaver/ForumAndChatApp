using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ForumApp.Admin;
using ForumApp.Models;

namespace ForumApp
{
    public partial class AdminForm : Form
    {

        userAdmin userAdmin = new userAdmin();
        BanAdmin banForm = new BanAdmin();
        PostAdmin PostAdmin = new PostAdmin();
        ReportAdmin ReportAdmin = new ReportAdmin();
        CommentAdmin CommentAdmin = new CommentAdmin();
        public AdminForm()
        {
            InitializeComponent();
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;

        }

        private void btnUsers_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (tabControl1.SelectedTab.Name)
            {
                case "first_tab":
                    // Tampilkan AdminForm saat userAdmin dipilih
                    this.Hide();
                   
                    MessageBox.Show("This is our homepage");
                    break;
                case "second_tab":
                    // Tampilkan AdminForm saat shareAdmin dipilih
                    this.Hide();
                    userAdmin.FormClosed += (s, args) => this.Show();
                    userAdmin.Show();
                   
                    break;
                case "three_tab":
                    // Tampilkan AdminForm saat reportAdmin dipilih
                    this.Hide();
                    banForm.FormClosed += (s, args) => this.Show();
                    banForm.Show();
                   
                    break;
                case "four_tab":
                    // Tampilkan AdminForm saat postAdmin dipilih
                    this.Hide();
                    PostAdmin.FormClosed += (s, args) => this.Show();
                    PostAdmin.Show();
                    
                    break;
                case "five_tab":
                    // Tampilkan AdminForm saat postAdmin dipilih
                    this.Hide();
                    ReportAdmin.FormClosed += (s, args) => this.Show();
                   ReportAdmin.Show();
                
                    break;
                case "six_tab":
                    // Tampilkan AdminForm saat postAdmin dipilih
                    this.Hide();

                    CommentAdmin.FormClosed += (s, args) => this.Show();
                    CommentAdmin.Show();

                    break;
                default:
                    break;
            }
        }

        private void four_page_Click(object sender, EventArgs e)
        {

        }

        private void AdminForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            usernameTxt.Text = UsersModel.Username;
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {

        }

        private void AdminForm_Load_1(object sender, EventArgs e)
        {
            try
            {
                // Tampilkan pesan selamat datang
                MessageBox.Show("Welcome, Admin!", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Set username ke properti Username dari model Users
                usernameTxt.Text = UsersModel.Username;
            }
            catch (Exception ex)
            {
                // Tangani kesalahan yang mungkin terjadi saat mengakses properti Username
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Periksa apakah username kosong atau tidak
            if (string.IsNullOrEmpty(usernameTxt.Text))
            {
                MessageBox.Show("Username is empty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void logoutBtn_Click_1(object sender, EventArgs e)
        {

            // Konfirmasi logout sebelum menutup aplikasi
            DialogResult result = MessageBox.Show("Do you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Lakukan logout
                UsersModel.SetUsers("", "");

                // Tutup form saat login ditutup
                this.Close();

                // Tampilkan form login
                LoginForm login = new LoginForm();
                login.Show();
            }
        }

        private void usernameTxt_Click(object sender, EventArgs e)
        {

        }
    }
}
