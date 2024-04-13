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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.first_tab = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.second_tab = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.three_tab = new System.Windows.Forms.TabPage();
            this.four_tab = new System.Windows.Forms.TabPage();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.usernameTxt = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.logoutBtn = new System.Windows.Forms.Button();
            this.five_tab = new System.Windows.Forms.TabPage();
            this.six_tab = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.first_tab.SuspendLayout();
            this.second_tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.first_tab);
            this.tabControl1.Controls.Add(this.second_tab);
            this.tabControl1.Controls.Add(this.three_tab);
            this.tabControl1.Controls.Add(this.four_tab);
            this.tabControl1.Controls.Add(this.five_tab);
            this.tabControl1.Controls.Add(this.six_tab);
            this.tabControl1.Location = new System.Drawing.Point(-4, 164);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(808, 287);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // first_tab
            // 
            this.first_tab.BackColor = System.Drawing.Color.WhiteSmoke;
            this.first_tab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.first_tab.Controls.Add(this.label1);
            this.first_tab.Location = new System.Drawing.Point(4, 25);
            this.first_tab.Name = "first_tab";
            this.first_tab.Padding = new System.Windows.Forms.Padding(3);
            this.first_tab.Size = new System.Drawing.Size(800, 258);
            this.first_tab.TabIndex = 0;
            this.first_tab.Text = "Homepage";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(279, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "WELCOME!! TO OUR ADMIN PAGE";
            // 
            // second_tab
            // 
            this.second_tab.Controls.Add(this.label2);
            this.second_tab.Location = new System.Drawing.Point(4, 25);
            this.second_tab.Name = "second_tab";
            this.second_tab.Padding = new System.Windows.Forms.Padding(3);
            this.second_tab.Size = new System.Drawing.Size(800, 258);
            this.second_tab.TabIndex = 1;
            this.second_tab.Text = "Users page";
            this.second_tab.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(367, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "two page";
            // 
            // three_tab
            // 
            this.three_tab.Location = new System.Drawing.Point(4, 25);
            this.three_tab.Name = "three_tab";
            this.three_tab.Size = new System.Drawing.Size(800, 258);
            this.three_tab.TabIndex = 2;
            this.three_tab.Text = "Comment page";
            this.three_tab.UseVisualStyleBackColor = true;
            // 
            // four_tab
            // 
            this.four_tab.Location = new System.Drawing.Point(4, 25);
            this.four_tab.Name = "four_tab";
            this.four_tab.Size = new System.Drawing.Size(800, 258);
            this.four_tab.TabIndex = 3;
            this.four_tab.Text = "Report page";
            this.four_tab.UseVisualStyleBackColor = true;
            this.four_tab.Click += new System.EventHandler(this.four_page_Click);
            // 
            // usernameTxt
            // 
            this.usernameTxt.AutoSize = true;
            this.usernameTxt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.usernameTxt.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.usernameTxt.Location = new System.Drawing.Point(89, 35);
            this.usernameTxt.Margin = new System.Windows.Forms.Padding(0);
            this.usernameTxt.Name = "usernameTxt";
            this.usernameTxt.Size = new System.Drawing.Size(87, 23);
            this.usernameTxt.TabIndex = 2;
            this.usernameTxt.Text = "Username";
            this.usernameTxt.Click += new System.EventHandler(this.usernameTxt_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(29, 36);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 22);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // logoutBtn
            // 
            this.logoutBtn.BackColor = System.Drawing.Color.Brown;
            this.logoutBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logoutBtn.FlatAppearance.BorderSize = 0;
            this.logoutBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logoutBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.logoutBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.logoutBtn.Location = new System.Drawing.Point(640, 36);
            this.logoutBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Size = new System.Drawing.Size(116, 34);
            this.logoutBtn.TabIndex = 4;
            this.logoutBtn.Text = "Logout";
            this.logoutBtn.UseVisualStyleBackColor = false;
            this.logoutBtn.Click += new System.EventHandler(this.logoutBtn_Click_1);
            // 
            // five_tab
            // 
            this.five_tab.Location = new System.Drawing.Point(4, 25);
            this.five_tab.Name = "five_tab";
            this.five_tab.Size = new System.Drawing.Size(800, 258);
            this.five_tab.TabIndex = 4;
            this.five_tab.Text = "Ban Page";
            this.five_tab.UseVisualStyleBackColor = true;
            // 
            // six_tab
            // 
            this.six_tab.Location = new System.Drawing.Point(4, 25);
            this.six_tab.Name = "six_tab";
            this.six_tab.Size = new System.Drawing.Size(800, 258);
            this.six_tab.TabIndex = 5;
            this.six_tab.Text = "Post Page";
            this.six_tab.UseVisualStyleBackColor = true;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.logoutBtn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.usernameTxt);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdminForm_FormClosing);
            this.Load += new System.EventHandler(this.AdminForm_Load_1);
            this.tabControl1.ResumeLayout(false);
            this.first_tab.ResumeLayout(false);
            this.first_tab.PerformLayout();
            this.second_tab.ResumeLayout(false);
            this.second_tab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage first_tab;
        private System.Windows.Forms.TabPage second_tab;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage three_tab;
        private System.Windows.Forms.TabPage four_tab;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label usernameTxt;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button logoutBtn;
        private System.Windows.Forms.TabPage five_tab;
        private System.Windows.Forms.TabPage six_tab;
    }
}