﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ForumApp
{
    internal class Koneksi
    {
        string source;
        public SqlConnection con;

        public Koneksi()
        {
            try
            {
                source = "Integrated Security =true;Initial Catalog=DBforum;Data Source=.";
                con = new SqlConnection(source);
            }
            catch (Exception sqle)
            {
                MessageBox.Show("Error database :" + sqle.Message);
            }
        }
        public void bukaKoneksi()
        {
            try
            {
                con.Open();
            }
            catch (Exception sqle)
            {
                MessageBox.Show("Error database :" + sqle.Message);
            }
        }

        public void tutupKoneksi()
        {
            try
            {
                con.Close();
            }
            catch (Exception sqle)
            {
                MessageBox.Show("Error database :" + sqle.Message);
            }
        }
    }
}

