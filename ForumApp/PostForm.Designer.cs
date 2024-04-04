namespace ForumApp
{
    partial class PostForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PostForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.commentTxt = new System.Windows.Forms.RichTextBox();
            this.commentBtn = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.shareBtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.flowLayoutComment = new System.Windows.Forms.FlowLayoutPanel();
            this.postPanel = new System.Windows.Forms.Panel();
            this.descLabel = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel3.SuspendLayout();
            this.postPanel.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.postPanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(30, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(740, 658);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.flowLayoutComment);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 266);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(738, 390);
            this.panel2.TabIndex = 4;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 65);
            this.panel4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(738, 102);
            this.panel4.TabIndex = 5;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.Controls.Add(this.panel8);
            this.panel5.Controls.Add(this.commentBtn);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(20, 15, 20, 15);
            this.panel5.Size = new System.Drawing.Size(738, 102);
            this.panel5.TabIndex = 6;
            // 
            // panel8
            // 
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.commentTxt);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel8.Location = new System.Drawing.Point(20, 15);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(408, 72);
            this.panel8.TabIndex = 5;
            // 
            // commentTxt
            // 
            this.commentTxt.BackColor = System.Drawing.Color.Gainsboro;
            this.commentTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.commentTxt.Dock = System.Windows.Forms.DockStyle.Left;
            this.commentTxt.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.commentTxt.Location = new System.Drawing.Point(0, 0);
            this.commentTxt.Name = "commentTxt";
            this.commentTxt.Size = new System.Drawing.Size(406, 70);
            this.commentTxt.TabIndex = 0;
            this.commentTxt.Text = "";
            this.commentTxt.TextChanged += new System.EventHandler(this.commentTxt_TextChanged);
            // 
            // commentBtn
            // 
            this.commentBtn.BackColor = System.Drawing.Color.SteelBlue;
            this.commentBtn.FlatAppearance.BorderSize = 0;
            this.commentBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.commentBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.commentBtn.ForeColor = System.Drawing.Color.White;
            this.commentBtn.Location = new System.Drawing.Point(459, 15);
            this.commentBtn.Name = "commentBtn";
            this.commentBtn.Size = new System.Drawing.Size(258, 45);
            this.commentBtn.TabIndex = 4;
            this.commentBtn.Text = "Comment";
            this.commentBtn.UseVisualStyleBackColor = false;
            this.commentBtn.Click += new System.EventHandler(this.commentBtn_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.shareBtn);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(738, 65);
            this.panel3.TabIndex = 4;
            // 
            // shareBtn
            // 
            this.shareBtn.BackColor = System.Drawing.Color.ForestGreen;
            this.shareBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shareBtn.FlatAppearance.BorderSize = 0;
            this.shareBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.shareBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.shareBtn.ForeColor = System.Drawing.Color.White;
            this.shareBtn.Location = new System.Drawing.Point(254, 0);
            this.shareBtn.Name = "shareBtn";
            this.shareBtn.Size = new System.Drawing.Size(230, 65);
            this.shareBtn.TabIndex = 8;
            this.shareBtn.Text = "Share";
            this.shareBtn.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Firebrick;
            this.button2.Dock = System.Windows.Forms.DockStyle.Right;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(484, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(254, 65);
            this.button2.TabIndex = 7;
            this.button2.Text = "Report";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gray;
            this.button1.Dock = System.Windows.Forms.DockStyle.Left;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(254, 65);
            this.button1.TabIndex = 6;
            this.button1.Text = "Like";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // flowLayoutComment
            // 
            this.flowLayoutComment.AutoScroll = true;
            this.flowLayoutComment.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutComment.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutComment.Location = new System.Drawing.Point(0, 167);
            this.flowLayoutComment.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.flowLayoutComment.Name = "flowLayoutComment";
            this.flowLayoutComment.Size = new System.Drawing.Size(738, 223);
            this.flowLayoutComment.TabIndex = 3;
            this.flowLayoutComment.WrapContents = false;
            // 
            // postPanel
            // 
            this.postPanel.AutoScroll = true;
            this.postPanel.BackColor = System.Drawing.Color.White;
            this.postPanel.Controls.Add(this.descLabel);
            this.postPanel.Controls.Add(this.panel7);
            this.postPanel.Controls.Add(this.panel6);
            this.postPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.postPanel.Location = new System.Drawing.Point(0, 0);
            this.postPanel.Name = "postPanel";
            this.postPanel.Padding = new System.Windows.Forms.Padding(26, 31, 26, 40);
            this.postPanel.Size = new System.Drawing.Size(738, 266);
            this.postPanel.TabIndex = 3;
            // 
            // descLabel
            // 
            this.descLabel.AutoSize = true;
            this.descLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.descLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.descLabel.Location = new System.Drawing.Point(26, 112);
            this.descLabel.MaximumSize = new System.Drawing.Size(650, 0);
            this.descLabel.Name = "descLabel";
            this.descLabel.Size = new System.Drawing.Size(649, 825);
            this.descLabel.TabIndex = 8;
            this.descLabel.Text = resources.GetString("descLabel.Text");
            // 
            // panel7
            // 
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(26, 83);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(660, 69);
            this.panel7.TabIndex = 7;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.titleLabel);
            this.panel6.Controls.Add(this.dateLabel);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(26, 31);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.panel6.Size = new System.Drawing.Size(660, 52);
            this.panel6.TabIndex = 6;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(0, 5);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(61, 32);
            this.titleLabel.TabIndex = 7;
            this.titleLabel.Text = "Title";
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.dateLabel.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.dateLabel.ForeColor = System.Drawing.Color.DimGray;
            this.dateLabel.Location = new System.Drawing.Point(560, 5);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(100, 21);
            this.dateLabel.TabIndex = 6;
            this.dateLabel.Text = "yyyy-MM-dd";
            // 
            // PostForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(800, 738);
            this.Controls.Add(this.panel1);
            this.Name = "PostForm";
            this.Padding = new System.Windows.Forms.Padding(30, 31, 30, 49);
            this.Text = "PostForm";
            this.Load += new System.EventHandler(this.PostForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.postPanel.ResumeLayout(false);
            this.postPanel.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel postPanel;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label descLabel;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutComment;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.RichTextBox commentTxt;
        private System.Windows.Forms.Button commentBtn;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button shareBtn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}