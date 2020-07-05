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

namespace HrMatchApp
{
    public partial class Form7 : Form
    {
        User activeWorker;
        public Form7(User activeWorker)
        {
            InitializeComponent();
            this.activeWorker = activeWorker;
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            using (HrMatchContext db = new HrMatchContext())
            {
                CV cv = db.CVs.FirstOrDefault(c => c.UserID == activeWorker.ID);

                title.Text = db.Users.FirstOrDefault(u => u.ID == cv.UserID).Username + "'s" + " " + "CV";
                category.Text = db.Categories.FirstOrDefault(c => c.ID == cv.CategoryID).Name;
                city.Text = db.Cities.FirstOrDefault(c => c.ID == cv.CityID).Name;
                name.Text = cv.Name;
                surname.Text = cv.Surname;
                gender.Text = cv.Gender;
                age.Text = cv.Age.ToString();
                education.Text = cv.Education;
                experience.Text = cv.Experience;
                salary.Text = cv.Salary.ToString();
                phoneNumber.Text = cv.PhoneNumber;
            }
        }
    }
}
