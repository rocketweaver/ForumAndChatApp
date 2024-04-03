using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ForumApp
{
    class Posts
    {
        public string[] panelId = { "P001", "P002", "P003", "P004", "P005", "P006", "P007", "P008", "P009" };
        public string[] panelTitles = { "How Do I clear this?", "Fix my code", "Panel 3", "Panel 4", 
                                        "Panel 5", "Panel 6", "Panel 7", "Panel 8", "Panel 59", };
        public DateTime[] panelDates = { DateTime.Now, DateTime.Now.AddDays(1), DateTime.Now.AddDays(2),
                                        DateTime.Now.AddDays(3), DateTime.Now.AddDays(4),
                                        DateTime.Now.AddDays(5), DateTime.Now.AddDays(3), DateTime.Now.AddDays(4),
                                        DateTime.Now.AddDays(5) };

        Dictionary<string, (string title, DateTime date)> panelData = new Dictionary<string, (string, DateTime)>();

        public Posts()
        {
            panelData = new Dictionary<string, (string, DateTime)>();

            for (int i = 0; i < panelId.Length; i++)
            {
                panelData[panelId[i]] = (panelTitles[i], panelDates[i]);
            }
        }

        public Dictionary<string, (string title, DateTime date)> GetPanelData()
        {
            return panelData;
        }

        public Dictionary<string, (string title, DateTime date)> GetPostById(string id)
        {
            if (string.IsNullOrEmpty(id) || !panelData.Any(p => p.Key.ToUpper().Contains(id.ToUpper())))
            {
                MessageBox.Show("No post related.");
                return panelData;
            }

            id = id.ToUpper();
            var filteredData = panelData.Where(p => p.Key.ToUpper().Contains(id)).ToDictionary(p => p.Key, p => p.Value);

            return filteredData;
        }

        public Dictionary<string, (string title, DateTime date)> SearchPost(string keyword)
        {
            if (string.IsNullOrEmpty(keyword) || !panelData.Any(p => p.Value.title.ToLower().Contains(keyword.ToLower())))
            {
                MessageBox.Show("No post with specific keyword.");
                return panelData; 
            }

            keyword = keyword.ToLower();
            var filteredData = panelData.Where(p => p.Value.title.ToLower().Contains(keyword)).ToDictionary(p => p.Key, p => p.Value);

            return filteredData;
        }
    }
}
