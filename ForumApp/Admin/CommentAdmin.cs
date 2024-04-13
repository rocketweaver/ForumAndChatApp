using ForumApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ForumApp.Admin
{
    public partial class CommentAdmin : Form
    {
        CommentViewModel commentViewModel = new CommentViewModel();
        private int selectedCommentId;
        public CommentAdmin()
        {
            InitializeComponent();
            LoadComments();
        }
        private void LoadComments()
        {
            try
            {
                dataGridViewComments.DataSource = commentViewModel.ReadComments();

                // Clear data in TextBox
                ClearData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearData()
        {
            // Clear TextBox
            textComment.Text = "";

            // Reset selected comment ID
            selectedCommentId = 0;
        }


        private void dataGridViewComments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = dataGridViewComments.Rows[e.RowIndex];
                    selectedCommentId = Convert.ToInt32(row.Cells["id_comment"].Value);
                    textComment.Text = row.Cells["comment_text"].Value.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a valid row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            try
            {
                string commentText = textComment.Text;

                // Create comment
                commentViewModel.CreateComment(commentText);

                // Reload comments
                LoadComments();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedCommentId != 0)
                {
                    string commentText = textComment.Text;

                    // Update comment
                    commentViewModel.UpdateComment(selectedCommentId, commentText);

                    // Reload comments
                    LoadComments();
                }
                else
                {
                    MessageBox.Show("Please select a comment to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedCommentId != 0)
                {
                    // Tampilkan dialog konfirmasi
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this comment?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    // Cek hasil dialog
                    if (result == DialogResult.Yes)
                    {
                        // Delete comment
                        commentViewModel.DeleteComment(selectedCommentId);

                        // Reload comments
                        LoadComments();
                    }
                }
                else
                {
                    MessageBox.Show("Please select a comment to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void CommentAdmin_Load(object sender, EventArgs e)
        {

        }
    }
}
