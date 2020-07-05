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
    public partial class Form5 : Form
    {
        User activeEmployer;
        public Form5(User activeEmployer)
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
            Form8 form8 = new Form8(activeEmployer);
            form8.ShowDialog();
        }

        private void search_Click(object sender, EventArgs e)
        {
            Form9 form9 = new Form9();
            form9.ShowDialog();
        }

        private void applies_Click(object sender, EventArgs e)
        {
            Form15 form15 = new Form15(activeEmployer);
            form15.ShowDialog();
        }

        private void logOut_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
