using ForumApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ForumApp.Admin
{
    public partial class ReportAdmin : Form
    {
        private ReportViewModel reportViewModel;
        public ReportAdmin()
        {
            InitializeComponent();
            reportViewModel = new ReportViewModel();
            LoadReportData();

        }

        private void LoadReportData()
        {
            DataSet dataSet = reportViewModel.Read();
            if (dataSet != null)
            {
                DataGridView.DataSource = dataSet.Tables["reports"];
            }
        }

        private void ReportAdmin_Load(object sender, EventArgs e)
        {

        }
    }
}
