namespace ForumApp
{
    partial class Profile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Profile));
            this.logoutBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.homeLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.pictureProfile = new System.Windows.Forms.PictureBox();
            this.postTab = new System.Windows.Forms.TabControl();
            this.tabShares = new System.Windows.Forms.TabPage();
            this.flowLayoutPosts = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPosts = new System.Windows.Forms.TabPage();
            this.flowLayoutShares = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureProfile)).BeginInit();
            this.postTab.SuspendLayout();
            this.tabShares.SuspendLayout();
            this.tabPosts.SuspendLayout();
            this.SuspendLayout();
            // 
            // logoutBtn
            // 
            this.logoutBtn.BackColor = System.Drawing.Color.Brown;
            this.logoutBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logoutBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.logoutBtn.FlatAppearance.BorderSize = 0;
            this.logoutBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logoutBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.logoutBtn.ForeColor = System.Drawing.Color.White;
            this.logoutBtn.Location = new System.Drawing.Point(334, 20);
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Size = new System.Drawing.Size(80, 32);
            this.logoutBtn.TabIndex = 1;
            this.logoutBtn.Text = "Logout";
            this.logoutBtn.UseVisualStyleBackColor = false;
            this.logoutBtn.Click += new System.EventHandler(this.logoutBtn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.homeLabel);
            this.panel1.Controls.Add(this.logoutBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(20);
            this.panel1.Size = new System.Drawing.Size(434, 72);
            this.panel1.TabIndex = 2;
            // 
            // homeLabel
            // 
            this.homeLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.homeLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.homeLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.homeLabel.Location = new System.Drawing.Point(20, 20);
            this.homeLabel.Name = "homeLabel";
            this.homeLabel.Size = new System.Drawing.Size(50, 32);
            this.homeLabel.TabIndex = 2;
            this.homeLabel.Text = "Home";
            this.homeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.homeLabel.Click += new System.EventHandler(this.homeLabel_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.usernameLabel);
            this.panel2.Controls.Add(this.pictureProfile);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 72);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(20);
            this.panel2.Size = new System.Drawing.Size(434, 378);
            this.panel2.TabIndex = 3;
            // 
            // usernameLabel
            // 
            this.usernameLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.usernameLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLabel.Location = new System.Drawing.Point(175, 117);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(70, 25);
            this.usernameLabel.TabIndex = 3;
            this.usernameLabel.Text = "Username";
            this.usernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureProfile
            // 
            this.pictureProfile.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureProfile.Image = ((System.Drawing.Image)(resources.GetObject("pictureProfile.Image")));
            this.pictureProfile.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureProfile.InitialImage")));
            this.pictureProfile.Location = new System.Drawing.Point(175, 35);
            this.pictureProfile.Name = "pictureProfile";
            this.pictureProfile.Size = new System.Drawing.Size(70, 70);
            this.pictureProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureProfile.TabIndex = 2;
            this.pictureProfile.TabStop = false;
            // 
            // postTab
            // 
            this.postTab.Controls.Add(this.tabShares);
            this.postTab.Controls.Add(this.tabPosts);
            this.postTab.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.postTab.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.postTab.Location = new System.Drawing.Point(0, 242);
            this.postTab.Name = "postTab";
            this.postTab.SelectedIndex = 0;
            this.postTab.Size = new System.Drawing.Size(434, 208);
            this.postTab.TabIndex = 4;
            // 
            // tabShares
            // 
            this.tabShares.Controls.Add(this.flowLayoutPosts);
            this.tabShares.Location = new System.Drawing.Point(4, 24);
            this.tabShares.Name = "tabShares";
            this.tabShares.Padding = new System.Windows.Forms.Padding(3);
            this.tabShares.Size = new System.Drawing.Size(426, 180);
            this.tabShares.TabIndex = 0;
            this.tabShares.Text = "Posts";
            this.tabShares.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPosts
            // 
            this.flowLayoutPosts.AutoScroll = true;
            this.flowLayoutPosts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPosts.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPosts.Name = "flowLayoutPosts";
            this.flowLayoutPosts.Size = new System.Drawing.Size(420, 174);
            this.flowLayoutPosts.TabIndex = 0;
            // 
            // tabPosts
            // 
            this.tabPosts.Controls.Add(this.flowLayoutShares);
            this.tabPosts.Location = new System.Drawing.Point(4, 24);
            this.tabPosts.Name = "tabPosts";
            this.tabPosts.Padding = new System.Windows.Forms.Padding(3);
            this.tabPosts.Size = new System.Drawing.Size(426, 180);
            this.tabPosts.TabIndex = 1;
            this.tabPosts.Text = "Shares";
            this.tabPosts.UseVisualStyleBackColor = true;
            // 
            // flowLayoutShares
            // 
            this.flowLayoutShares.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutShares.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutShares.Name = "flowLayoutShares";
            this.flowLayoutShares.Size = new System.Drawing.Size(420, 174);
            this.flowLayoutShares.TabIndex = 0;
            // 
            // Profile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(434, 450);
            this.Controls.Add(this.postTab);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Profile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Profile";
            this.Load += new System.EventHandler(this.Profile_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureProfile)).EndInit();
            this.postTab.ResumeLayout(false);
            this.tabShares.ResumeLayout(false);
            this.tabPosts.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button logoutBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label homeLabel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl postTab;
        private System.Windows.Forms.TabPage tabShares;
        private System.Windows.Forms.TabPage tabPosts;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPosts;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutShares;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.PictureBox pictureProfile;
    }
}