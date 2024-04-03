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

        private void dateLabel_Click(object sender, EventArgs e)
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
    }
}
