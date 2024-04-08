namespace ForumApp
{
    partial class banForm
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
            this.dataGridViewBans = new System.Windows.Forms.DataGridView();
            this.textBanId = new System.Windows.Forms.TextBox();
            this.textUserId = new System.Windows.Forms.TextBox();
            this.textBanCount = new System.Windows.Forms.TextBox();
            this.textStartDate = new System.Windows.Forms.TextBox();
            this.textEndDate = new System.Windows.Forms.TextBox();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBans)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewBans
            // 
            this.dataGridViewBans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBans.Location = new System.Drawing.Point(410, 50);
            this.dataGridViewBans.Name = "dataGridViewBans";
            this.dataGridViewBans.RowHeadersWidth = 51;
            this.dataGridViewBans.RowTemplate.Height = 24;
            this.dataGridViewBans.Size = new System.Drawing.Size(336, 223);
            this.dataGridViewBans.TabIndex = 14;
            this.dataGridViewBans.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewBans_CellClick);
            // 
            // textBanId
            // 
            this.textBanId.Location = new System.Drawing.Point(135, 80);
            this.textBanId.Name = "textBanId";
            this.textBanId.Size = new System.Drawing.Size(145, 22);
            this.textBanId.TabIndex = 15;
            this.textBanId.TextChanged += new System.EventHandler(this.textLevel_TextChanged);
            // 
            // textUserId
            // 
            this.textUserId.Location = new System.Drawing.Point(135, 132);
            this.textUserId.Name = "textUserId";
            this.textUserId.Size = new System.Drawing.Size(145, 22);
            this.textUserId.TabIndex = 16;
            // 
            // textBanCount
            // 
            this.textBanCount.Location = new System.Drawing.Point(135, 168);
            this.textBanCount.Name = "textBanCount";
            this.textBanCount.Size = new System.Drawing.Size(145, 22);
            this.textBanCount.TabIndex = 17;
            // 
            // textStartDate
            // 
            this.textStartDate.Location = new System.Drawing.Point(135, 210);
            this.textStartDate.Name = "textStartDate";
            this.textStartDate.Size = new System.Drawing.Size(145, 22);
            this.textStartDate.TabIndex = 18;
            // 
            // textEndDate
            // 
            this.textEndDate.Location = new System.Drawing.Point(135, 254);
            this.textEndDate.Name = "textEndDate";
            this.textEndDate.Size = new System.Drawing.Size(145, 22);
            this.textEndDate.TabIndex = 19;
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(375, 346);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdate.TabIndex = 20;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(205, 346);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 21;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(532, 346);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 22;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 16);
            this.label1.TabIndex = 23;
            this.label1.Text = "UserId:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 257);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 24;
            this.label2.Text = "End Date: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 213);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 16);
            this.label3.TabIndex = 25;
            this.label3.Text = "Start Date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(58, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 16);
            this.label4.TabIndex = 26;
            this.label4.Text = "Ban Count:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(64, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 16);
            this.label5.TabIndex = 27;
            this.label5.Text = "BanId";
            // 
            // banForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.textEndDate);
            this.Controls.Add(this.textStartDate);
            this.Controls.Add(this.textBanCount);
            this.Controls.Add(this.textUserId);
            this.Controls.Add(this.textBanId);
            this.Controls.Add(this.dataGridViewBans);
            this.Name = "banForm";
            this.Text = "banForm";
            this.Load += new System.EventHandler(this.banForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBans)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewBans;
        private System.Windows.Forms.TextBox textBanId;
        private System.Windows.Forms.TextBox textUserId;
        private System.Windows.Forms.TextBox textBanCount;
        private System.Windows.Forms.TextBox textStartDate;
        private System.Windows.Forms.TextBox textEndDate;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}