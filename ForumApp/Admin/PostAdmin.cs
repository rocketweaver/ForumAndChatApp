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
    public partial class PostAdmin : Form
    {
        PostViewModel postViewModel = new PostViewModel();
        public PostAdmin()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                dataGridViewPosts.DataSource = postViewModel.ReadPosts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearData()
        {
            textTitle.Text = "";
            textDescription.Text = "";
            textUserId.Text = "";
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            // Mengambil ID post dari sel yang dipilih dalam DataGridView
            int postId;
            if (int.TryParse(dataGridViewPosts.CurrentRow.Cells["id_post"].Value.ToString(), out postId))
            {
                // Menampilkan pesan konfirmasi
                DialogResult result = MessageBox.Show("Are you sure you want to delete this post?", "Delete Post", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Memeriksa hasil dari pesan konfirmasi
                if (result == DialogResult.Yes)
                {
                    // Menghapus post jika pengguna menekan tombol "Yes"
                    postViewModel.DeletePost(postId);
                    LoadData();
                    ClearData();
                }
            }
            else
            {
                MessageBox.Show("Please select a post to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void buttonClearData_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            int adminId;
            if (int.TryParse(textUserId.Text, out adminId))
            {
                postViewModel.UpdatePost(textTitle.Text, textDescription.Text, adminId);
                LoadData();
                ClearData();
            }
            else
            {
                MessageBox.Show("User ID must be an integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            int userId;
            if (int.TryParse(textUserId.Text, out userId))
            {
                postViewModel.CreatePost(textTitle.Text, textDescription.Text, userId);
                LoadData();
                ClearData();
            }
            else
            {
                MessageBox.Show("User ID must be an integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PostAdmin_Load(object sender, EventArgs e)
        {

        }
    }
}
