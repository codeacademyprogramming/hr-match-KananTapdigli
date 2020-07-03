using HrMatch;
using HrMatch.Models;
using HrMatchApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HrMatchApp.Forms
{
    public partial class Form13 : Form
    {
        User activeWorker;
        public Form13(User activeWorker)
        {
            InitializeComponent();

            this.activeWorker = activeWorker;
        }

        IQueryable<WorkersAnnouncements> query;
        private void Form13_Load(object sender, EventArgs e)
        {
            using (HrMatchContext db = new HrMatchContext())
            {
                query = db.workersAnnouncements
                                    .Where(x => x.WorkerID == activeWorker.ID);

                 List<Announcement> announcements = new List<Announcement>();

                foreach (var dbworkerAnnouncement in query)
                {
                    announcements.AddRange(db.Announcements.Where(a=> a.ID == dbworkerAnnouncement.AnnouncementID));
                }

                foreach (var dbAnnouncement in announcements)
                {
                    string categoryName = db.Categories.FirstOrDefault(c => c.ID.Equals(dbAnnouncement.CategoryID)).Name;
                    string cityName = db.Cities.FirstOrDefault(c => c.ID.Equals(dbAnnouncement.CityID)).Name;

                    string[] item = { dbAnnouncement.Name, dbAnnouncement.CompanyName, categoryName, dbAnnouncement.Information, dbAnnouncement.Education, dbAnnouncement.Experience, dbAnnouncement.Age.ToString(), cityName, dbAnnouncement.Salary.ToString(), dbAnnouncement.PhoneNumber };

                    ListViewItem listViewItem = new ListViewItem(item);

                    listView.Items.Add(listViewItem);
                }
            }
        }

       
    }
}
