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

namespace ForumApp
{
    public partial class ReportDialog : Form
    {
        int? postId;
        int? commentId;
        string username;

        public ReportDialog(string username, int? postId = null, int? commentId = null)
        {
            InitializeComponent();

            this.postId = postId;
            this.commentId = commentId;
            this.username = username;
        }

        private void ReportDialog_Load(object sender, EventArgs e)
        {
            usernameLabel.Text = "Reported User: " + this.username;

            if (postId == null)
            {
                typeLabel.Text = "Type: Comment";
            }
            else
            {
                typeLabel.Text = "Type: Post";
            }
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            ReportsModel report = new ReportsModel();
            report.reporterId = UsersModel.UserId;
            report.postId = postId;
            report.commentId = commentId;
            report.desc = reportTxt.Text;
            report.Create();

            this.Close();
        }
    }
}
