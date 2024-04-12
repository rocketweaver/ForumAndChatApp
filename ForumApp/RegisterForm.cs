using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ForumApp
{
    public partial class RegisterForm : Form
    {   
        public RegisterForm()
        {
            InitializeComponent();
           
        }

        private void txtAcc_Click(object sender, EventArgs e)
        {
            this.Hide();

            LoginForm login = new LoginForm();
            login.ShowDialog();
            login.Show();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            RegisterModel register = new RegisterModel();

            string email = txtEmail.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string pin = pinTxt.Text;

            if(string.IsNullOrEmpty(email) || string.IsNullOrEmpty(username) 
                || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(pin) )
            {
                MessageBox.Show("The input can't be empty.");
            } 
            else
            {
                if(register.IsValidEmail(email))
                {
                    if (pin.Length == 6 && Regex.IsMatch(pin, @"^\d{6}$"))
                    {
                        bool success = register.CreateUser(email, username, password, pin);

                        if (success)
                        {
                            this.Hide();
                            LoginForm login = new LoginForm();
                            login.Closed += (s, args) => this.Close();
                            login.Show();
                        }
                        else
                        {
                            MessageBox.Show("Failed to register. Try again.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("The input only accepts 6 digit numbers.");
                    }
                } else
                {
                    MessageBox.Show("Format email is incorrect.");
                }
            }
        }
    }
}

     
    

