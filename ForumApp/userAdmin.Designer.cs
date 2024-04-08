namespace ForumApp
{
    partial class userAdmin
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
            this.textUserID = new System.Windows.Forms.TextBox();
            this.textLevel = new System.Windows.Forms.TextBox();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.textEmail = new System.Windows.Forms.TextBox();
            this.textUsername = new System.Windows.Forms.TextBox();
            this.UserId = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.dataGridViewUsers = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // textUserID
            // 
            this.textUserID.Location = new System.Drawing.Point(146, 77);
            this.textUserID.Name = "textUserID";
            this.textUserID.Size = new System.Drawing.Size(145, 22);
            this.textUserID.TabIndex = 0;
            // 
            // textLevel
            // 
            this.textLevel.Location = new System.Drawing.Point(146, 278);
            this.textLevel.Name = "textLevel";
            this.textLevel.Size = new System.Drawing.Size(145, 22);
            this.textLevel.TabIndex = 1;
            // 
            // textPassword
            // 
            this.textPassword.Location = new System.Drawing.Point(146, 227);
            this.textPassword.Name = "textPassword";
            this.textPassword.Size = new System.Drawing.Size(145, 22);
            this.textPassword.TabIndex = 2;
            // 
            // textEmail
            // 
            this.textEmail.Location = new System.Drawing.Point(146, 169);
            this.textEmail.Name = "textEmail";
            this.textEmail.Size = new System.Drawing.Size(145, 22);
            this.textEmail.TabIndex = 3;
            // 
            // textUsername
            // 
            this.textUsername.Location = new System.Drawing.Point(146, 119);
            this.textUsername.Name = "textUsername";
            this.textUsername.Size = new System.Drawing.Size(145, 22);
            this.textUsername.TabIndex = 4;
            // 
            // UserId
            // 
            this.UserId.AutoSize = true;
            this.UserId.Location = new System.Drawing.Point(48, 77);
            this.UserId.Name = "UserId";
            this.UserId.Size = new System.Drawing.Size(50, 16);
            this.UserId.TabIndex = 5;
            this.UserId.Text = "UserId:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 230);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Email:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Username:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 281);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Level:";
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(331, 342);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdate.TabIndex = 10;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(146, 342);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 11;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(501, 342);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 12;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // dataGridViewUsers
            // 
            this.dataGridViewUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUsers.Location = new System.Drawing.Point(427, 77);
            this.dataGridViewUsers.Name = "dataGridViewUsers";
            this.dataGridViewUsers.RowHeadersWidth = 51;
            this.dataGridViewUsers.RowTemplate.Height = 24;
            this.dataGridViewUsers.Size = new System.Drawing.Size(336, 223);
            this.dataGridViewUsers.TabIndex = 13;
            this.dataGridViewUsers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewUsers_CellClick);
            // 
            // userAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridViewUsers);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.UserId);
            this.Controls.Add(this.textUsername);
            this.Controls.Add(this.textEmail);
            this.Controls.Add(this.textPassword);
            this.Controls.Add(this.textLevel);
            this.Controls.Add(this.textUserID);
            this.Name = "userAdmin";
            this.Text = "userAdmin";
            this.Load += new System.EventHandler(this.userAdmin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textUserID;
        private System.Windows.Forms.TextBox textLevel;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.TextBox textEmail;
        private System.Windows.Forms.TextBox textUsername;
        private System.Windows.Forms.Label UserId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.DataGridView dataGridViewUsers;
    }
}