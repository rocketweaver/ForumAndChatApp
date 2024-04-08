namespace ForumApp
{
    partial class LoginForm
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.emailTxt = new System.Windows.Forms.TextBox();
            this.passwordTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.submitBtn = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.txtAcc = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Location = new System.Drawing.Point(149, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 54);
            this.label1.TabIndex = 0;
            this.label1.Text = "LOGIN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label2.Location = new System.Drawing.Point(44, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Email:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // emailTxt
            // 
            this.emailTxt.BackColor = System.Drawing.Color.WhiteSmoke;
            this.emailTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.emailTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.emailTxt.Location = new System.Drawing.Point(48, 164);
            this.emailTxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.emailTxt.Name = "emailTxt";
            this.emailTxt.Size = new System.Drawing.Size(360, 26);
            this.emailTxt.TabIndex = 2;
            // 
            // passwordTxt
            // 
            this.passwordTxt.BackColor = System.Drawing.Color.WhiteSmoke;
            this.passwordTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.passwordTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.passwordTxt.Location = new System.Drawing.Point(48, 242);
            this.passwordTxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.passwordTxt.Name = "passwordTxt";
            this.passwordTxt.Size = new System.Drawing.Size(360, 26);
            this.passwordTxt.TabIndex = 4;
            this.passwordTxt.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label3.Location = new System.Drawing.Point(44, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "Password:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // submitBtn
            // 
            this.submitBtn.BackColor = System.Drawing.Color.SteelBlue;
            this.submitBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.submitBtn.FlatAppearance.BorderSize = 0;
            this.submitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submitBtn.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.submitBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.submitBtn.Location = new System.Drawing.Point(48, 298);
            this.submitBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(360, 43);
            this.submitBtn.TabIndex = 5;
            this.submitBtn.Text = "Submit";
            this.submitBtn.UseVisualStyleBackColor = false;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // txtAcc
            // 
            this.txtAcc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAcc.AutoSize = true;
            this.txtAcc.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.txtAcc.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.txtAcc.Location = new System.Drawing.Point(157, 357);
            this.txtAcc.Name = "txtAcc";
            this.txtAcc.Size = new System.Drawing.Size(137, 19);
            this.txtAcc.TabIndex = 7;
            this.txtAcc.Text = "Didn\'t have account?";
            this.txtAcc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.txtAcc.Click += new System.EventHandler(this.txtAcc_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(467, 466);
            this.Controls.Add(this.txtAcc);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.passwordTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.emailTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox emailTxt;
        private System.Windows.Forms.TextBox passwordTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label txtAcc;
    }
}

