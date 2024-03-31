using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ForumApp
{
    public partial class Home : Form
    {
        private const int WS_VSCROLL = 0x200000;
        public Home()
        {
            InitializeComponent();
            SetStyle(ControlStyles.ResizeRedraw, true);
            this.Padding = new Padding(0, 0, 0, 50);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= WS_VSCROLL; // Add WS_VSCROLL style to enable vertical scrollbar
                return cp;
            }
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            Users.username = "";

            this.Hide();

            Login login = new Login();
            login.Closed += (s, args) => this.Close();
            login.Show();
        }

        private string[] panelTitles = { "Panel 1", "Panel 2", "Panel 3", "Panel 4", "Panel 5", "Panel 6" };
        private DateTime[] panelDates = { DateTime.Now, DateTime.Now.AddDays(1), DateTime.Now.AddDays(2),DateTime.Now.AddDays(3), DateTime.Now.AddDays(4), DateTime.Now.AddDays(5) };

        private void LoopThroughPanelsAndTextboxes()
        {
            for (int i = 0; i < panelTitles.Length; i++)
            {
                var panel = new Panel
                {
                    Location = new Point(25, 100 + (i * (60 + 5))),
                    Size = new Size(473, 40),
                    BackColor = Color.White,
                    BorderStyle = BorderStyle.FixedSingle
                };

                var titleLabel = new Label
                {
                    Text = panelTitles[i],
                    Location = new Point(10, 10),
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    ForeColor = Color.Black
                };
                panel.Controls.Add(titleLabel);

                var dateLabel = new Label
                {
                    Text = panelDates[i].ToString("yyyy-MM-dd"),
                    Location = new Point(panel.Width - 100, 10),
                    Font = new Font("Segoe UI", 10),
                    TextAlign = ContentAlignment.MiddleRight
                };
                panel.Controls.Add(dateLabel);

                panel.Click += Panel_Click;

                Controls.Add(panel);
            }
        }

        private void Panel_Click(object sender, EventArgs e)
        {
            var clickedPanel = (Panel)sender;
            MessageBox.Show($"You clicked the panel titled: {clickedPanel.Controls[0].Text}");
        }

        private void Home_Load(object sender, EventArgs e)
        {
            usernameTxt.Text = Users.username;
            LoopThroughPanelsAndTextboxes();
        }
    }
}
