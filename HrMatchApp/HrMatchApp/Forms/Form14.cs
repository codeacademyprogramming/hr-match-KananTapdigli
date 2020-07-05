using HrMatch;
using HrMatch.Models;
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
    public partial class Form14 : Form
    {
        User activeWorker;
        public Form14(User activeWorker)
        {
            InitializeComponent();
            this.activeWorker = activeWorker;
        }

        private void Form14_Load(object sender, EventArgs e)
        {
            using (HrMatchContext db = new HrMatchContext())
            {
                IQueryable<Announcement> query = db.Announcements;

                CV cv = db.CVs.FirstOrDefault(c => c.UserID == activeWorker.ID);

                foreach (var dbAnnouncement in query)
                {
                    string categoryName = db.Categories.FirstOrDefault(c => c.ID.Equals(dbAnnouncement.CategoryID)).Name;
                    string cityName = db.Cities.FirstOrDefault(c => c.ID.Equals(dbAnnouncement.CityID)).Name;

                    ListViewItem listViewItem;


                    if (cv != null && cv.CategoryID == dbAnnouncement.CategoryID)
                    {
                        string[] item = { "APPLY HERE", dbAnnouncement.Name, dbAnnouncement.CompanyName, categoryName, dbAnnouncement.Information, dbAnnouncement.Education, dbAnnouncement.Experience, dbAnnouncement.Age.ToString(), cityName, dbAnnouncement.Salary.ToString(), dbAnnouncement.PhoneNumber };
                        listViewItem = new ListViewItem(item);
                    }
                    else
                    {
                        string[] item = { "NOT SUITABLE FOR YOUR CV", dbAnnouncement.Name, dbAnnouncement.CompanyName, categoryName, dbAnnouncement.Information, dbAnnouncement.Education, dbAnnouncement.Experience, dbAnnouncement.Age.ToString(), cityName, dbAnnouncement.Salary.ToString(), dbAnnouncement.PhoneNumber };
                        listViewItem = new ListViewItem(item);
                    }

                    listView.Items.Add(listViewItem);

                }
            }
        }

        private void listView_MouseClick(object sender, MouseEventArgs e)
        {
            {
                for (int itemIndex = 0; itemIndex < listView.Items.Count; itemIndex++)
                {

                    var rectangle = listView.GetItemRect(itemIndex);

                    ListViewItem item = listView.Items[itemIndex];

                    var subItems = item.SubItems;

                    if (rectangle.Contains(e.Location) && subItems[0].Text == "APPLY HERE")
                    {

                        DialogResult dialogResult = MessageBox.Show("Do You Want to Pass Apply Form?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (dialogResult.Equals(DialogResult.Yes))
                        {
                            string name = subItems[1].Text;
                            string companyName = subItems[2].Text;
                            string categoryName = subItems[3].Text;
                            string information = subItems[4].Text;
                            string education = subItems[5].Text;
                            string experience = subItems[6].Text;
                            byte age = Convert.ToByte(subItems[7].Text);
                            string cityName = subItems[8].Text;
                            decimal salary = Convert.ToDecimal(subItems[9].Text);
                            string phoneNumber = subItems[10].Text;

                            Announcement announcement;
                            using (HrMatchContext db = new HrMatchContext())
                            {
                                int categoryID = db.Categories.FirstOrDefault(c => c.Name.Equals(categoryName)).ID;
                                int cityID = db.Cities.FirstOrDefault(c => c.Name.Equals(cityName)).ID;

                                announcement = db.Announcements
                                             .FirstOrDefault(a => a.Name.Equals(name) && a.CompanyName.Equals(companyName) && a.CategoryID.Equals(categoryID) && a.CityID.Equals(cityID) && a.Information.Equals(information) && a.Education.Equals(education) && a.Experience.Equals(experience) && a.Age.Equals(age) && a.Salary.Equals(salary) && a.PhoneNumber.Equals(phoneNumber));
                            }

                            Form11 form11 = new Form11(activeWorker, announcement);
                            form11.ShowDialog();
                        }
                    }
                }
            }
        }
    }
}
