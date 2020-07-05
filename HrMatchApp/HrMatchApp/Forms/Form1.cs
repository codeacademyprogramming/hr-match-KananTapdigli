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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


            using (HrMatchContext db = new HrMatchContext())
            {
                int countCity = 0;

                foreach (var dbCity in db.Cities)
                {
                    countCity++;
                }
                if (countCity == 0)
                {
                    db.Cities.Add(new City() { Name = "Bakı" });
                    db.Cities.Add(new City() { Name = "Sumqayıt" });
                    db.Cities.Add(new City() { Name = "Gəncə" });
                    db.Cities.Add(new City() { Name = "Quba" });
                    db.Cities.Add(new City() { Name = "Qəbələ" });
                }


                int countCategory = 0;

                foreach (var dbCategory in db.Categories)
                {
                    countCategory++;
                }

                if (countCategory==0)
                {
                db.Categories.Add(new Category() { Name = "Journalist" });
                db.Categories.Add(new Category() { Name = "Doctor" });
                db.Categories.Add(new Category() { Name = "Translator" });
                db.Categories.Add(new Category() { Name = "IT Specialist" });
                db.Categories.Add(new Category() { Name = "Designer" });
                }

                db.SaveChanges();
            }
        }

        private void SignUp_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void SignIn_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }
    }
}
