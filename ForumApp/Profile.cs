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
    public partial class Profile : Form
    {  

        public Profile()
        {
            InitializeComponent();
        }

        private void LoadUserPosts()
        {
            flowLayoutPosts.Controls.Clear();

            try
            {
                DataSet panelData;

                PostsModel posts = new PostsModel();
                posts.userId = UsersModel.UserId.ToString();
                panelData = posts.ReadByUserId();

                foreach (DataRow row in panelData.Tables["posts"].Rows)
                {
                    var panelId = row["id_post"].ToString();
                    var panelInfo = new { title = row["title"].ToString(), date = (DateTime)row["post_date"] };

                    var panel = new Panel
                    {
                        Name = panelId,
                        Tag = panelId,
                        Size = new Size(flowLayoutPosts.Width - 39, 40),
                        Margin = new Padding(10, 20, 5, 20),
                        BackColor = Color.White,
                        BorderStyle = BorderStyle.FixedSingle,
                        Cursor = Cursors.Hand,
                    };

                    var titleLabel = new Label
                    {
                        Text = panelInfo.title,
                        Location = new Point(10, 10),
                        Font = new Font("Segoe UI", 8, FontStyle.Bold),
                        ForeColor = Color.Black,
                        AutoSize = true
                    };
                    panel.Controls.Add(titleLabel);

                    var dateLabel = new Label
                    {
                        Text = panelInfo.date.ToString("yyyy-MM-dd"),
                        Location = new Point(panel.Width - 110, 10),
                        Font = new Font("Segoe UI", 8),
                        TextAlign = ContentAlignment.MiddleRight
                    };
                    panel.Controls.Add(dateLabel);

                    panel.Click += post_Click;

                    flowLayoutPosts.Controls.Add(panel);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadUserShares()
        {
            flowLayoutShares.Controls.Clear();

            try
            {
                DataSet panelData;

                PostsModel posts = new PostsModel();
                posts.userId = UsersModel.UserId.ToString();
                panelData = posts.ReadByShare();

                foreach (DataRow row in panelData.Tables["posts"].Rows)
                {
                    var panelId = row["id_post"].ToString();
                    var panelInfo = new { title = row["title"].ToString(), date = (DateTime)row["post_date"] };

                    var panel = new Panel
                    {
                        Name = panelId,
                        Tag = panelId,
                        Size = new Size(flowLayoutPosts.Width - 39, 40),
                        Margin = new Padding(10, 20, 5, 20),
                        BackColor = Color.White,
                        BorderStyle = BorderStyle.FixedSingle,
                        Cursor = Cursors.Hand,
                    };

                    var titleLabel = new Label
                    {
                        Text = panelInfo.title,
                        Location = new Point(10, 10),
                        Font = new Font("Segoe UI", 8, FontStyle.Bold),
                        ForeColor = Color.Black,
                        AutoSize = true
                    };
                    panel.Controls.Add(titleLabel);

                    var dateLabel = new Label
                    {
                        Text = panelInfo.date.ToString("yyyy-MM-dd"),
                        Location = new Point(panel.Width - 110, 10),
                        Font = new Font("Segoe UI", 8),
                        TextAlign = ContentAlignment.MiddleRight
                    };
                    panel.Controls.Add(dateLabel);

                    panel.Click += post_Click;

                    flowLayoutShares.Controls.Add(panel);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void post_Click(object sender, EventArgs e)
        {
            var clickedPanel = (Panel)sender;
            string panelId = clickedPanel.Tag.ToString();

            PostsModel posts = new PostsModel();
            posts.id = panelId;
            DataRow postById = posts.ReadById();

            if (postById != null)
            {
                this.Hide();
                Posts postForm = new Posts(panelId);
                postForm.Closed += (s, args) => this.Close();
                postForm.Show();
            }
            else
            {
                MessageBox.Show("Related post doesn't exist.");
            }
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            usernameLabel.Text = UsersModel.Username;

            LoadUserPosts();
            LoadUserShares();
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
    }
}
