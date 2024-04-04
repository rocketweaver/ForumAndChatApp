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
            // Calculate the required height for the desc label based on its content and width
            int requiredHeight = TextRenderer.MeasureText(descLabel.Text, descLabel.Font, 
                new Size(descLabel.Width, int.MaxValue), TextFormatFlags.WordBreak).Height;

            // Adjust the height of the postPanel to accommodate the desc label's content
            postPanel.Height = requiredHeight;

            // Optional: If you want to adjust the position of other controls below the postPanel, you can do so here
            // otherControl.Top = postPanel.Bottom + spacing;
        }

        private void desc_TextChanged(object sender, EventArgs e)
        {
            AdjustPostPanelHeight();
        }

        private void PostForm_Load(object sender, EventArgs e)
        {
            LoadPost();
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

        private void descLabel_Click(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = (Panel)sender;
            using (Pen pen = new Pen(Color.Black, 1)) 
            {
                e.Graphics.DrawRectangle(pen, 0, 0, panel.Width - 1, panel.Height - 1);
            }
        }

        private void commentBtn_Click(object sender, EventArgs e)
        {
            Panel commentPanel = new Panel();
            commentPanel.AutoSize = true;
            commentPanel.BackColor = Color.WhiteSmoke;
            commentPanel.BorderStyle = BorderStyle.FixedSingle;
            commentPanel.Margin = new Padding(13);

            Label authorLabel = new Label();
            authorLabel.Text = "John Doe"; // You can replace this with the actual author's name
            authorLabel.Font = new Font("Segoe UI", 9);
            authorLabel.AutoSize = true;
            authorLabel.BackColor = Color.Transparent;
            authorLabel.Padding = new Padding(10, 8, 8, 0); // Removed bottom padding for authorLabel

            // Add authorLabel to commentPanel first
            commentPanel.Controls.Add(authorLabel);

            Label commentLabel = new Label();
            commentLabel.Text = commentTxt.Text;
            commentLabel.Font = new Font("Segoe UI", 9);
            commentLabel.AutoSize = true;
            commentLabel.BackColor = Color.Transparent;
            commentLabel.Padding = new Padding(10, 8, 8, 0); // Removed bottom padding for commentLabel

            Label commentDateLabel = new Label();
            commentDateLabel.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            commentDateLabel.Font = new Font("Segoe UI", 9);
            commentDateLabel.AutoSize = true;
            commentDateLabel.BackColor = Color.Transparent;
            commentDateLabel.Padding = new Padding(10, 10, 8, 10); // Adjusted top and bottom padding for commentDateLabel

            // Set the location of the labels
            commentLabel.Location = new Point(authorLabel.Left, authorLabel.Bottom + 5); // Adjusted position for commentLabel
            commentDateLabel.Location = new Point(commentLabel.Left, commentLabel.Bottom + 5); // Adjusted position for commentDateLabel

            // Add the remaining labels to the commentPanel
            commentPanel.Controls.Add(commentLabel);
            commentPanel.Controls.Add(commentDateLabel);

            // Add the commentPanel to the flowLayoutComment control
            flowLayoutComment.Controls.Add(commentPanel);
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
