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
    public partial class ReportDialog : Form
    {
        public ReportDialog(string username)
        {
            InitializeComponent();

            this.usernameLabel.Text = username;
        }
    }
}
