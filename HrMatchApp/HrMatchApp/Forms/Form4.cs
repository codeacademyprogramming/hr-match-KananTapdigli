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
    public partial class Form4 : Form
    {
        User activeWorker;
        public Form4(User activeWorker)
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
            Form6 form6 = new Form6(activeWorker);
            form6.ShowDialog();
        }

        private void information_Click(object sender, EventArgs e)
        {
            using (HrMatchContext db = new HrMatchContext())
            {
                CV cv = db.CVs.FirstOrDefault(c => c.UserID == activeWorker.ID);

                if (cv != null)
                {
                    Form7 form7 = new Form7(activeWorker);
                    form7.ShowDialog();
                }
                else
                {
                    MessageBox.Show("You haven't Added Your CV", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }       
        }

        private void search_Click(object sender, EventArgs e)
        {
            Form10 form10 = new Form10(activeWorker);
            form10.ShowDialog();
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
                        Form12 form12 = new Form12(activeWorker);
                        form12.ShowDialog();
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
                    Form13 form13 = new Form13(activeWorker);
                    form13.ShowDialog();
                }
                else
                {
                    MessageBox.Show("There is no Applied Announcement for You.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void allAnnouncements_Click(object sender, EventArgs e)
        {
            Form14 form14 = new Form14(activeWorker);
            form14.ShowDialog();
        }

        private void logOut_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
