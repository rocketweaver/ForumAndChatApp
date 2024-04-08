using ForumApp.Koneksi;
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
    public partial class Register : Form
    {
        RegisterClass register = new RegisterClass();
        public Register()
        {
            InitializeComponent();
           
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtAcc_Click(object sender, EventArgs e)
        {
            this.Hide();

            LoginForm login = new LoginForm();
            login.ShowDialog();

            this.Show();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {

            string email = txtEmail.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            bool success = register.CreateUser(email, username, password);

            if (success)
            {
                MessageBox.Show("Registrasi berhasil!");
                this.Hide();

                LoginForm loginForm = new LoginForm();
                loginForm.ShowDialog();

                this.Show();
            }
            else
            {
                MessageBox.Show("Registrasi gagal. Silakan coba lagi.");
            }
        }
    }
}

     
    

