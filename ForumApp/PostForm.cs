using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            Dictionary<string, (string title, DateTime date)> postById = post.GetPostById(idPost);

            foreach (var kvp in postById)
            {
                titleLabel.Text = kvp.Value.title;
                dateLabel.Text = kvp.Value.date.ToString("yyyy-MM-dd");
            }
        }

        private void desc_TextChanged(object sender, EventArgs e)
        {
            AdjustPostPanelHeight();
        }

        private void PostForm_Load(object sender, EventArgs e)
        {
            LoadPost();
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

        private ContextMenuStrip loadContextMenu()
        {
            ContextMenuStrip customContextMenu = new ContextMenuStrip();
            ToolStripMenuItem deleteComment = new ToolStripMenuItem("Delete");
            ToolStripMenuItem reportComment = new ToolStripMenuItem("Report");

            deleteComment.Click += deleteComment_Click;
            reportComment.Click += reportComment_Click;

            customContextMenu.Items.Add(deleteComment);
            customContextMenu.Items.Add(reportComment);

            return customContextMenu;
        }

        private void makeComment()
        {
            Panel commentPanel = new Panel();
            commentPanel.BackColor = Color.WhiteSmoke;
            commentPanel.BorderStyle = BorderStyle.FixedSingle;
            commentPanel.Margin = new Padding(13);
            commentPanel.Width = flowLayoutComment.Width - 30;
            commentPanel.MaximumSize = new Size(flowLayoutComment.Width - 30, 200);

            commentPanel.ContextMenuStrip = loadContextMenu();

            Label authorLabel = new Label();
            authorLabel.UseCompatibleTextRendering = true;

            string username = Users.username;
            string date = DateTime.Now.ToString("dd MMMM yyyy");
            string hour = DateTime.Now.ToString("hh:MM");

            authorLabel.Text = $"{username} - {date} - {hour}";
            authorLabel.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            authorLabel.AutoSize = true;
            authorLabel.BackColor = Color.Transparent;
            authorLabel.Padding = new Padding(10, 8, 8, 0);

            commentPanel.Controls.Add(authorLabel);

            Label commentLabel = new Label();
            commentLabel.Text = InsertNewlines(commentTxt.Text, 70);
            commentLabel.Font = new Font("Segoe UI", 9);
            commentLabel.AutoSize = true;
            commentLabel.BackColor = Color.Transparent;
            commentLabel.Padding = new Padding(0, 8, 8, 20);

            commentLabel.Location = new Point(10, authorLabel.Bottom + 5);

            commentPanel.Controls.Add(commentLabel);

            int totalHeight = commentLabel.Bottom + commentPanel.Padding.Bottom;

            commentPanel.Height = Math.Min(totalHeight, commentPanel.MaximumSize.Height);

            flowLayoutComment.Controls.Add(commentPanel);
        }

        private void commentBtn_Click(object sender, EventArgs e)
        {
            makeComment();
        }

        private void deleteComment_Click(object sender, EventArgs e)
        {
            // Handle the click event for Custom Option 1
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
    }
}
