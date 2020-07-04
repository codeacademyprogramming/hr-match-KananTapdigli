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
    public partial class AppliesForm : Form
    {
        User activeEmployer;
        public AppliesForm(User activeEmployer)
        {
            InitializeComponent();
            this.activeEmployer = activeEmployer;
        }

        private void Form15_Load(object sender, EventArgs e)
        {
            List<WorkersAnnouncements> workersAnnouncements;

            using (HrMatchContext db = new HrMatchContext())
            {
                IQueryable<Announcement> query = db.Announcements
                                                                 .Where(x => x.UserID == activeEmployer.ID);

                workersAnnouncements = new List<WorkersAnnouncements>();
              
                foreach (var dbAnnouncement in query)
                {
                    workersAnnouncements.AddRange(db.workersAnnouncements.Where(x=> x.AnnouncementID == dbAnnouncement.ID));
                }

                foreach (var item in workersAnnouncements)
                {
                    CV cv = db.CVs.FirstOrDefault(c=> c.UserID == item.WorkerID);


                    string announceName = db.Announcements.FirstOrDefault(a=> a.ID == item.AnnouncementID).Name;
                    string workerName = cv.Name;
                    string surname = cv.Surname;
                    string gender = cv.Gender;
                    byte age = cv.Age;
                    string education = cv.Education;
                    string experince = cv.Experience;
                    string categoryName = db.Categories.FirstOrDefault(c => c.ID == cv.CategoryID).Name;
                    string cityName = db.Cities.FirstOrDefault(c => c.ID == cv.CityID).Name;
                    string phoneNumber = cv.PhoneNumber;
                    decimal salary = cv.Salary;


                    string[] itemm = {announceName,workerName,surname,gender,age.ToString(),education,experince,categoryName,cityName,phoneNumber,salary.ToString() };

                    ListViewItem listViewItem = new ListViewItem(itemm);

                    listView.Items.Add(listViewItem);
                }
            }
        }
    }
}
