using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ForumApp
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();

            logoutBtn.FlatStyle = FlatStyle.Flat;
            logoutBtn.FlatAppearance.BorderSize = 0;
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            UsersModel.SetUsers("","");

            this.Hide();

            LoginForm login = new LoginForm();
            login.Closed += (s, args) => this.Close();
            login.Show();
        }

        private void LoadPosts(DataSet filteredPosts = null)
        {
            flowLayoutPosts.Controls.Clear();

            try
            {
                DataSet panelData;

                if (filteredPosts != null)
                {
                    panelData = filteredPosts;
                }
                else
                {
                    PostsModel posts = new PostsModel();
                    panelData = posts.Read();
                }

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


        private void Home_Load(object sender, EventArgs e)
        {
            usernameTxt.Text = UsersModel.Username;

            if (string.IsNullOrEmpty(usernameTxt.Text))
            {
                MessageBox.Show("Username is empty.");
            }

            LoadPosts();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            PostsModel post = new PostsModel();

            string keyword = searchTxt.Text;
            LoadPosts(post.Search(keyword));
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = (Panel)sender;
            using (Pen pen = new Pen(Color.LightGray, 1))
            {
                e.Graphics.DrawLine(pen, 0, panel.Height - 1, panel.Width, panel.Height - 1);
            }
        }

        private void usernameTxt_Click(object sender, EventArgs e)
        {
            this.Hide();

            Profile profile = new Profile(UsersModel.UserId);
            profile.Closed += (s, args) => this.Close();
            profile.Show();
        }

        private void postBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            PostForm postForm = new PostForm();
            postForm.Closed += (s, args) => this.Close();
            postForm.Show();
        }
    }
}
