using HrMatch.Models;
using HrMatchApp.Forms;
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
    public partial class EmployerMenuForm : Form
    {
        User activeEmployer;
        public EmployerMenuForm(User activeEmployer)
        {
            InitializeComponent();
            this.activeEmployer = activeEmployer;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            title.Text = $"WELCOME, {activeEmployer.Username.ToUpper()}";
        }

        private void addAnnouncement_Click(object sender, EventArgs e)
        {
            AddAnnouncementForm addAnnouncementForm = new AddAnnouncementForm(activeEmployer);
            addAnnouncementForm.ShowDialog();
        }

        private void search_Click(object sender, EventArgs e)
        {
            EmployerSearchForm employerSearchForm = new EmployerSearchForm();
            employerSearchForm.ShowDialog();
        }

        private void applies_Click(object sender, EventArgs e)
        {
            AppliesForm appliesForm = new AppliesForm(activeEmployer);
            appliesForm.ShowDialog();
        }

        private void logOut_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
