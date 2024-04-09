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

namespace ForumApp
{
    public partial class PostForm : Form
    {
        string idPost;
        public event EventHandler PostEdited;
        public PostForm(string id = "")
        {
            idPost = id;

            InitializeComponent();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            PostsModel post = new PostsModel();

            if (String.IsNullOrEmpty(titleTxt.Text) || String.IsNullOrEmpty(descTxt.Text))
            {
                MessageBox.Show("Title or description can't be empty.");
            } else
            {
                if(String.IsNullOrEmpty(idPost))
                {
                    post.title = titleTxt.Text;
                    post.desc = descTxt.Text;
                    post.userId = UsersModel.UserId.ToString();

                    DialogResult result = MessageBox.Show("Are you sure you want to submit this post?",
                                    "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        post.Create();

                        this.Hide();

                        Home home = new Home();
                        home.Closed += (s, args) => this.Close();
                        home.Show();
                    }
                } 
                else
                {
                    post.id = idPost;
                    post.title = titleTxt.Text;
                    post.desc = descTxt.Text;

                    DialogResult result = MessageBox.Show("Are you sure you want to edit this post?",
                                    "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        post.Update();
                        PostEdited?.Invoke(this, EventArgs.Empty);

                        this.Close();
                    }
                }
            }
        }

        private void homeLabel_Click(object sender, EventArgs e)
        {
            this.Hide();

            Home home = new Home();
            home.Closed += (s, args) => this.Close();
            home.Show();
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            UsersModel.SetUsers("", "");

            this.Hide();

            LoginForm login = new LoginForm();
            login.Closed += (s, args) => this.Close();
            login.Show();
        }

        private void usernameTxt_Click(object sender, EventArgs e)
        {
            this.Hide();

            Profile profile = new Profile();
            profile.Closed += (s, args) => this.Close();
            profile.Show();
        }

        private void userIcon_Click(object sender, EventArgs e)
        {
            this.Hide();

            Profile profile = new Profile();
            profile.Closed += (s, args) => this.Close();
            profile.Show();
        }

        private void PostForm_Load(object sender, EventArgs e)
        {
            usernameTxt.Text = UsersModel.Username;

            PostsModel post = new PostsModel();

            if(!String.IsNullOrEmpty(idPost))
            {
                postLabel.Text = "EDIT POST";
                submitBtn.Text = "Edit";
                panel1.Controls.Remove(usernameTxt);
                panel1.Controls.Remove(userIcon);
                panel1.Controls.Remove(logoutBtn);
                this.Controls.Remove(panel1);

                foreach (Control control in this.Controls)
                {
                    control.Location = new Point(control.Location.X, control.Location.Y - 20);
                }

                post.id = idPost;

                DataRow postById = post.ReadById();

                if (postById != null)
                {
                    titleTxt.Text = postById["title"].ToString();
                    descTxt.Text = postById["description"].ToString();
                }
                else
                {
                    MessageBox.Show("Related post doesn't exist.");
                }
            }   
        }
    }
}
