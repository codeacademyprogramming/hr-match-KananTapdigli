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
    public partial class Form11 : Form
    {
        User activeWorker;
        Announcement activeAnnouncement;
        public Form11(User activeWorker, Announcement activeAnnouncement)
        {
            InitializeComponent();

            this.activeWorker = activeWorker;
            this.activeAnnouncement = activeAnnouncement;
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            name.Text = activeAnnouncement.Name;
            companyName.Text = activeAnnouncement.CompanyName;
            category.Text = activeAnnouncement.Category.Name;
            information.Text = activeAnnouncement.Information;
            education.Text = activeAnnouncement.Education;
            experience.Text = activeAnnouncement.Experience;
            age.Text = activeAnnouncement.Age.ToString();
            city.Text = activeAnnouncement.City.Name;
            salary.Text = activeAnnouncement.Salary.ToString();
            phoneNumber.Text = activeAnnouncement.PhoneNumber;

            if (CheckAlreadyApply(activeWorker, activeAnnouncement))
            {
                apply.Visible = false;
                alreadyApplied.Visible = true;
            }
        }

        public static bool CheckAlreadyApply(User activeWorker, Announcement activeAnnouncement)
        {
            using (HrMatchContext db = new HrMatchContext())
            {
                if (db.workersAnnouncements.Any(x => x.WorkerID == activeWorker.ID && x.AnnouncementID == activeAnnouncement.ID))
                {
                    return true;
                }

                return false;
            }
        }

        private void apply_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do You Want to Apply this Announcement?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult.Equals(DialogResult.Yes))
            {
                using (HrMatchContext db = new HrMatchContext())
                {
                    WorkersAnnouncements workersAnnouncements = new WorkersAnnouncements(activeWorker.ID, activeAnnouncement.ID);
                    db.workersAnnouncements.Add(workersAnnouncements);

                    db.SaveChanges();
                }

                apply.Visible = false;
                alreadyApplied.Visible = true;
            }
        }
    }
}
