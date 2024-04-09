using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ForumApp
{
    public partial class PostForm : Form
    {
        string idPost;
        
        Posts post = new Posts();
        Comments comment = new Comments();
        public PostForm(string id)
        {
            idPost = id;

            InitializeComponent();
        }

        private void postPanel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, postPanel.ClientRectangle, Color.LightGray, ButtonBorderStyle.Solid);
        }

        private void AdjustPostPanelHeight()
        {
            int requiredHeight = TextRenderer.MeasureText(descLabel.Text, descLabel.Font, 
                new Size(descLabel.Width, int.MaxValue), TextFormatFlags.WordBreak).Height;

            postPanel.Height = requiredHeight;
        }

        public void LoadPost()
        {
            DataRow postById = post.ReadById(idPost);

            if (postById != null)
            {
                titleLabel.Text = postById["title"].ToString();
                dateLabel.Text = ((DateTime)postById["post_date"]).ToString("yyyy-MM-dd");
                authorLabel.Text = "by " + postById["username"].ToString();
                descLabel.Text = postById["description"].ToString();

                bool isLiked = post.HasLiked(idPost);

                if (isLiked)
                {
                    likeBtn.Text = "Unlike (" + postById["like_count"].ToString() + ")";
                }
                else
                {
                    likeBtn.Text = "Like (" + postById["like_count"].ToString() + ")";
                }

                if(postById["user_id"].ToString() == Users.UserId.ToString())
                {
                    panel3.Controls.Remove(shareBtn);
                    panel3.Controls.Remove(reportBtn);

                    var editPostBtn = new Button
                    {
                        Name = "edit",
                        Tag = idPost,
                        Text = "Edit",
                        ForeColor = Color.White,
                        BackColor = Color.DarkOrange,
                        FlatStyle = FlatStyle.Flat,
                        FlatAppearance =
                        {
                            BorderSize = 0
                        },
                        Dock = DockStyle.Fill,
                        Cursor = Cursors.Hand,
                        Font = new Font("Segoe UI", 9),
                    };
                    editPostBtn.Click += editPostBtn_Click;

                    var deletePostBtn = new Button
                    {
                        Name = "delete",
                        Tag = idPost,
                        Text = "Delete",
                        ForeColor = Color.White,
                        BackColor = Color.Firebrick,
                        FlatStyle = FlatStyle.Flat,
                        FlatAppearance =
                        {
                            BorderSize = 0
                        },
                        Dock = DockStyle.Right,
                        Cursor = Cursors.Hand,
                        Width = 169,
                        Font = new Font("Segoe UI", 9),
                    };
                    deletePostBtn.Click += deletePostBtn_Click;

                    panel3.Controls.Add(deletePostBtn);
                    panel3.Controls.Add(editPostBtn);
                } else
                {
                    bool isShared = post.HasShared(idPost);

                    if (isShared)
                    {
                        shareBtn.Text = "Unshare";
                    }
                    else
                    {
                        shareBtn.Text = "Share";
                    }
                }
            }
            else
            {
                MessageBox.Show("Post not found.");
            }
        }

        private void desc_TextChanged(object sender, EventArgs e)
        {
            AdjustPostPanelHeight();
        }

        private void LoadComments()
        {
            flowLayoutComment.Controls.Clear();

            comment.postId = idPost;

            DataSet commentData = comment.ReadByPostId();

            foreach (DataRow row in commentData.Tables["comments"].Rows)
            {
                string idComment = row["id_comment"].ToString();
                string username = row["username"].ToString();
                string commentText = row["description"].ToString();
                string commentDate = ((DateTime)row["comment_date"]).ToString("dd MMMM yyyy - hh:MM");

                bool edited = (bool)row["edited"];

                Panel commentPanel = new Panel();
                commentPanel.BackColor = Color.WhiteSmoke;
                commentPanel.BorderStyle = BorderStyle.FixedSingle;
                commentPanel.Margin = new Padding(13);
                commentPanel.Width = 250;
                commentPanel.MaximumSize = new Size(400, int.MaxValue);
                commentPanel.Tag = idComment;

                // Set the context menu to the panel
                commentPanel.ContextMenuStrip = LoadContextMenu(username);

                Label authorLabel = new Label();
                authorLabel.Text = $"{username} - {(edited ? "Edited " : "")}{commentDate}";
                authorLabel.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                authorLabel.AutoSize = true;
                authorLabel.BackColor = Color.Transparent;
                authorLabel.Padding = new Padding(10, 8, 8, 0);

                Label commentLabel = new Label();
                commentLabel.Text = InsertNewlines(commentText, 70);
                commentLabel.Font = new Font("Segoe UI", 9);
                commentLabel.AutoSize = true;
                commentLabel.BackColor = Color.Transparent;
                commentLabel.Padding = new Padding(0, 8, 8, 20);

                commentLabel.Location = new Point(10, authorLabel.Bottom + 5);

                commentPanel.Controls.Add(authorLabel);
                commentPanel.Controls.Add(commentLabel);

                int totalHeight = commentLabel.Bottom + commentPanel.Padding.Bottom;

                commentPanel.Height = Math.Min(totalHeight, commentPanel.MaximumSize.Height);

                flowLayoutComment.Controls.Add(commentPanel);
            }
        }


        private void PostForm_Load(object sender, EventArgs e)
        {
            LoadPost();
            LoadComments();
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = (Panel)sender;
            using (Pen pen = new Pen(Color.Black, 1)) 
            {
                e.Graphics.DrawRectangle(pen, 0, 0, panel.Width - 1, panel.Height - 1);
            }
        }

        private string InsertNewlines(string input, int charactersPerLine)
        {
            StringBuilder result = new StringBuilder();
            int count = 0;

            foreach (char c in input)
            {
                result.Append(c);
                count++;

                if (count % charactersPerLine == 0)
                {
                    result.Append("\n");
                }
            }

            return result.ToString();
        }

        private ContextMenuStrip LoadContextMenu(string username)
        {
            ContextMenuStrip customContextMenu = new ContextMenuStrip();
            ToolStripMenuItem deleteComment = new ToolStripMenuItem("Delete");
            ToolStripMenuItem editComment = new ToolStripMenuItem("Edit");
            ToolStripMenuItem reportComment = new ToolStripMenuItem("Report");

            deleteComment.Click += deleteComment_Click;
            editComment.Click += editComment_Click;
            reportComment.Click += reportComment_Click;

            if (username == Users.Username)
            {
                customContextMenu.Items.Add(deleteComment);
                customContextMenu.Items.Add(editComment);
            }
            else
            {
                customContextMenu.Items.Add(reportComment);
            }

            return customContextMenu;
        }

        private void commentBtn_Click(object sender, EventArgs e)
        {
            

            comment.userId = Users.UserId.ToString();

            comment.postId = idPost;
            comment.description = commentTxt.Text;
            comment.Create();

            LoadComments();
        }

        private void deletePostBtn_Click(object sender, EventArgs e)
        {
            // Handle the click event for Custom Option 1
        }

        private void editPostBtn_Click(object sender, EventArgs e)
        {
            // Handle the click event for Custom Option 1
        }

        private void deleteComment_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            ContextMenuStrip strip = (ContextMenuStrip)item.Owner;
            Panel panel = (Panel)strip.SourceControl;
            comment.id = panel.Tag.ToString();

            DialogResult result = MessageBox.Show("Are you sure you want to delete this comment?", 
                                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                comment.id = panel.Tag.ToString();
                comment.Delete();

                LoadComments();
            }
        }

        private void editComment_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            ContextMenuStrip strip = (ContextMenuStrip)item.Owner;
            Panel panel = (Panel)strip.SourceControl;

            EditCommentDialog edit = new EditCommentDialog(panel.Tag.ToString());
            edit.CommentEdited += Edit_CommentEdited;
            edit.ShowDialog();
        }

        private void Edit_CommentEdited(object sender, EventArgs e)
        {
            LoadComments();
        }

        private void reportComment_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            ContextMenuStrip strip = (ContextMenuStrip)item.Owner;
            Panel panel = (Panel)strip.SourceControl;
            Label authorLabel = (Label)panel.Controls[0];
            string username = authorLabel.Text.Split('-')[0].Trim();

            ReportDialog report = new ReportDialog(username);
            report.ShowDialog();
        }

        private void commentTxt_TextChanged(object sender, EventArgs e)
        {
            if(commentTxt.Text.Length > 280) {
                MessageBox.Show("The comment can't be more than 280 characters.");

                commentTxt.Text = commentTxt.Text.Substring(0, 280);
                commentTxt.SelectionStart = commentTxt.Text.Length;
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();

            Home home = new Home();
            home.Closed += (s, args) => this.Close();
            home.Show();
        }

        private void likeBtn_Click(object sender, EventArgs e)
        {
            bool isLiked = post.HasLiked(idPost);

            if (!isLiked)
            {
                post.Like(idPost);
            }
            else
            {
                post.Unlike(idPost);
            }

            LoadPost();
        }

        private void shareBtn_Click(object sender, EventArgs e)
        {
            bool isShared = post.HasShared(idPost);

            if (!isShared)
            {
                post.Share(idPost);
            }
            else
            {
                post.Unshare(idPost);
            }

            LoadPost();
        }
    }
}
