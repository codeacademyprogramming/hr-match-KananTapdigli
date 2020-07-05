using HrMatch;
using HrMatch.Models;
using HrMatchApp.Forms;
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

namespace HrMatchApp
{
    public partial class WorkerMenuForm : Form
    {
        User activeWorker;
        public WorkerMenuForm(User activeWorker)
        {
            InitializeComponent();
            this.activeWorker = activeWorker;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            title.Text = $"WELCOME, {activeWorker.Username.ToUpper()}";
        }



        private void addCV_Click(object sender, EventArgs e)
        {
            AddCVForm addCVForm = new AddCVForm(activeWorker);
            addCVForm.ShowDialog();
        }

        private void information_Click(object sender, EventArgs e)
        {
            using (HrMatchContext db = new HrMatchContext())
            {
                CV cv = db.CVs.FirstOrDefault(c => c.UserID == activeWorker.ID);

                if (cv != null)
                {
                    CVInformationForm cVInformationForm = new CVInformationForm(activeWorker);
                    cVInformationForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("You haven't Added Your CV", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }       
        }

        private void search_Click(object sender, EventArgs e)
        {
            WorkerSearchForm workerSearchForm = new WorkerSearchForm(activeWorker);
            workerSearchForm.ShowDialog();
        }

        private void suitableAnnouncements_Click(object sender, EventArgs e)
        {
            CV activeCV;
            IQueryable<Announcement> query;

            using (HrMatchContext db = new HrMatchContext())
            {
                activeCV = db.CVs.FirstOrDefault(c => c.UserID == activeWorker.ID);

                if (activeCV != null)
                {

                    query = db.Announcements
                                 .Where(a => (a.CategoryID == activeCV.CategoryID) && (a.Education == activeCV.Education || a.Experience == activeCV.Experience || a.Age == activeCV.Age || a.City == activeCV.City || a.Salary > activeCV.Salary));

                    if (query.Any(a => a.CategoryID == activeCV.CategoryID || a.Education == activeCV.Education || a.Experience == activeCV.Experience || a.Age >= activeCV.Age || a.City == activeCV.City || a.Salary >= activeCV.Salary))
                    {
                        SuitableAnnouncementsForm suitableAnnouncementsForm = new SuitableAnnouncementsForm(activeWorker);
                        suitableAnnouncementsForm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("There is no Suitable Announcement for You.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    MessageBox.Show("You must add Your CV for showing Suitable Announcements", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void appliedAnnouncements_Click(object sender, EventArgs e)
        {
            using (HrMatchContext db = new HrMatchContext())
            {
                IQueryable<WorkersAnnouncements> query = db.workersAnnouncements
                                                                              .Where(x => x.WorkerID == activeWorker.ID);

                if (query.Any(x => x.WorkerID == activeWorker.ID))
                {
                    AppliedAnnouncementsForm appliedAnnouncementsForm = new AppliedAnnouncementsForm(activeWorker);
                    appliedAnnouncementsForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("There is no Applied Announcement for You.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void allAnnouncements_Click(object sender, EventArgs e)
        {
            AllAnnouncements allAnnouncements = new AllAnnouncements(activeWorker);
            allAnnouncements.ShowDialog();
        }

        private void logOut_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
