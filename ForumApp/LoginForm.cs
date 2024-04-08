using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ForumApp
{
    public partial class LoginForm : Form
    {
        Users usr = new Users();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            string email = emailTxt.Text;
            string password = passwordTxt.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("An input can't be empty.");
            }
            else
            {
                if (IsValidEmail(email))
                {
                    if (usr.SetUsers(email, password))
                    {
                        MessageBox.Show("Welcome, " + usr.Username + "!");

                        // Tutup kotak pesan sebelum menavigasi ke halaman utama
                        this.Hide();
                        Home home = new Home();
                        home.Closed += (s, args) => this.Close();
                        home.Show();

                        // Check level and open the corresponding form
                        if (usr.Level == 1)
                        {
                            // Open user form
                            this.Hide();
                        
                            home.Closed += (s, args) => this.Close();
                            home.Show();
                        }
                        else if (usr.Level == 2)
                        {
                            // Open admin form
                            this.Hide();
                            AdminForm adminForm = new AdminForm();
                            adminForm.Show();
                        }
                        else
                        {
                            // Handle unexpected level value
                            MessageBox.Show("Invalid user level.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Wrong email or password.");
                    }
                }
                else
                {
                    MessageBox.Show("Your email format is incorrect.");
                }
            }
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email.Trim();
            }
            catch
            {
                return false;
            }
        }

        private void txtAcc_Click(object sender, EventArgs e)
        {
            this.Hide();

            Register register = new Register();
            register.ShowDialog();

            this.Show();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
