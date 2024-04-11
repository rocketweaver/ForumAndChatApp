using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ForumApp
{
    public partial class EditProfile : Form
    {
        int id;

        public EditProfile(int id)
        {
            this.id = id;

            InitializeComponent(); 
        }

        private void EditProfile_Load(object sender, EventArgs e)
        {
            UsersModel user = new UsersModel();
            user.id = id;

            DataRow userById = user.ReadById();

            if(userById != null )
            {
                usernameTxt.Text = userById["username"].ToString();
                emailTxt.Text = userById["email"].ToString();   
                passwordTxt.Text = userById["password"].ToString();
            } 
            else
            {
                MessageBox.Show("No related user exist.");

                Home home = new Home();
                home.Closed += (s, args) => this.Close();
                home.Show();
            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            UsersModel users = new UsersModel();

            string email = emailTxt.Text;
            string password = passwordTxt.Text;
            string username = usernameTxt.Text;

            

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password)  
                || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("An input can't be empty.");
            }
            else
            {
                if (IsValidEmail(email))
                {
                    if (passwordTxt.Text == repeatPasswordTxt.Text)
                    {
                        users.id = id;
                        users.email = email;
                        users.username = username;
                        users.password = password;

                        DialogResult result = MessageBox.Show("Are you sure you want to update your account?",
                                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            users.Update();

                            MessageBox.Show("Your account has been updated.");

                            UsersModel.SetUsers("", "");

                            this.Hide();

                            LoginForm login = new LoginForm();
                            login.Closed += (s, args) => this.Close();
                            login.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Your password doesn't match with each other.");
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

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            UsersModel users = new UsersModel();

            users.id = id;

            DialogResult result = MessageBox.Show("Are you sure you want to delete your account?",
                    "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                users.Delete();

                MessageBox.Show("Your account has been deleted.");

                UsersModel.SetUsers("", "");

                this.Hide();

                LoginForm login = new LoginForm();
                login.Closed += (s, args) => this.Close();
                login.Show();
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();

            Profile profile = new Profile(id);
            profile.Closed += (s, args) => this.Close();
            profile.Show();
        }
    }
}
