namespace ForumApp
{
    partial class AdminForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnComment = new System.Windows.Forms.Button();
            this.btnPost = new System.Windows.Forms.Button();
            this.btnBan = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnReports);
            this.panel1.Controls.Add(this.btnComment);
            this.panel1.Controls.Add(this.btnPost);
            this.panel1.Controls.Add(this.btnBan);
            this.panel1.Controls.Add(this.btnUsers);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(186, 450);
            this.panel1.TabIndex = 0;
            // 
            // btnReports
            // 
            this.btnReports.Location = new System.Drawing.Point(45, 322);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(75, 23);
            this.btnReports.TabIndex = 4;
            this.btnReports.Text = "Reports";
            this.btnReports.UseVisualStyleBackColor = true;
            // 
            // btnComment
            // 
            this.btnComment.Location = new System.Drawing.Point(45, 271);
            this.btnComment.Name = "btnComment";
            this.btnComment.Size = new System.Drawing.Size(75, 23);
            this.btnComment.TabIndex = 3;
            this.btnComment.Text = "Comments";
            this.btnComment.UseVisualStyleBackColor = true;
            // 
            // btnPost
            // 
            this.btnPost.Location = new System.Drawing.Point(45, 226);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(75, 23);
            this.btnPost.TabIndex = 2;
            this.btnPost.Text = "Post";
            this.btnPost.UseVisualStyleBackColor = true;
            // 
            // btnBan
            // 
            this.btnBan.Location = new System.Drawing.Point(45, 186);
            this.btnBan.Name = "btnBan";
            this.btnBan.Size = new System.Drawing.Size(75, 23);
            this.btnBan.TabIndex = 1;
            this.btnBan.Text = "Ban";
            this.btnBan.UseVisualStyleBackColor = true;
            // 
            // btnUsers
            // 
            this.btnUsers.Location = new System.Drawing.Point(45, 139);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(75, 23);
            this.btnUsers.TabIndex = 0;
            this.btnUsers.Text = "Users";
            this.btnUsers.UseVisualStyleBackColor = true;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnComment;
        private System.Windows.Forms.Button btnPost;
        private System.Windows.Forms.Button btnBan;
    }
}