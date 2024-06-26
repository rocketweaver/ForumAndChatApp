﻿using System;
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
    public partial class EditCommentDialog : Form
    {
        string idComment;
        public EditCommentDialog(string id)
        {
            idComment = id;

            InitializeComponent();
        }

        private void EditCommentDialog_Load(object sender, EventArgs e)
        {
            CommentsModel comment = new CommentsModel();

            comment.id = idComment;
            DataRow row = comment.ReadById();

            if(row != null ) { 
                commentTxt.Text = row["description"].ToString();
            } else
            {
                MessageBox.Show("No related comment.");

                this.Close();
            }
        }

        public delegate void CommentEditedEventHandler(object sender, EventArgs e);
        public event CommentEditedEventHandler CommentEdited;

        private void submitBtn_Click(object sender, EventArgs e)
        {
            CommentsModel comment = new CommentsModel();  

            if(String.IsNullOrEmpty(commentTxt.Text)) {
                MessageBox.Show("The comment can't be empty.");
            } 
            else
            {
                comment.id = idComment;
                comment.description = commentTxt.Text;
                comment.Update();

                CommentEdited?.Invoke(this, EventArgs.Empty);

                this.Close();
            }
        }
    }
}
