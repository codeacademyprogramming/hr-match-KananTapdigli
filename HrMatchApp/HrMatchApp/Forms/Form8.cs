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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HrMatchApp
{
    public partial class Form8 : Form
    {
        User activeEmployer;
        public Form8(User activeEmployer)
        {
            InitializeComponent();
            this.activeEmployer = activeEmployer;
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            using (HrMatchContext db = new HrMatchContext())
            {
                foreach (var dbCategory in db.Categories)
                {
                    category.Items.Add(dbCategory.Name);
                }

                foreach (var dbCity in db.Cities)
                {
                    city.Items.Add(dbCity.Name);
                }
            }

            AddComboboxItems();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckFields())
            {
                using (HrMatchContext db = new HrMatchContext())
                {
                    if (db.Categories.Any(c => c.Name == category.Text))
                    {
                        if (db.Cities.Any(c => c.Name == city.Text))
                        {
                            if (Byte.TryParse(age.Text, out byte Age))
                            {
                                if (education.Text == "Secondary education" || education.Text == "Incomplete Higher education" || education.Text == "High education")
                                {
                                    if (experience.Text == "Less than 1 year" || experience.Text == "1 - 3 years" || experience.Text == "3 - 5 years" || experience.Text == "Greater than 5 years")
                                    {
                                        if (Decimal.TryParse(salary.Text, out decimal Salary))
                                        {
                                            if (isValidPhoneNumber(phoneNumber.Text))
                                            {
                                                int categoryID = db.Categories.FirstOrDefault(c => c.Name.Equals(category.Text)).ID;
                                                int cityID = db.Cities.FirstOrDefault(c => c.Name.Equals(city.Text)).ID;

                                                Announcement announcement = new Announcement(activeEmployer.ID, name.Text, company.Text, categoryID, information.Text, cityID, Age, education.Text, experience.Text, Salary, phoneNumber.Text);
                                                db.Announcements.Add(announcement);

                                                db.SaveChanges();



                                                MessageBox.Show("Your Announcement is Successfully Added!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                                name.Text = string.Empty;
                                                company.Text = string.Empty;
                                                category.Text = string.Empty;
                                                information.Text = string.Empty;
                                                city.Text = string.Empty;
                                                age.Text = string.Empty;
                                                education.Text = string.Empty;
                                                experience.Text = string.Empty;
                                                salary.Text = string.Empty;
                                                phoneNumber.Text = string.Empty;
                                            }
                                            else
                                            {
                                                MessageBox.Show("'Phone Number' field has not written correctly! Example: +994-55-555-55-55", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }                                
                                        }
                                        else
                                        {
                                            MessageBox.Show("Salary field is not valid format! It must be a number!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("'Experience' field has not chosen correctly!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("'Education' field has not chosen correctly!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("'Age' field is not valid format! It must be a number!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                        else
                        {
                            MessageBox.Show("'City' field has not chosen correctly!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("'Category' field has not chosen correctly!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }             
                }
            }
            else
            {
                MessageBox.Show("All fields must be filled!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool CheckFields()
        {
            if (name.Text != string.Empty &&
                company.Text != string.Empty &&
                category.Text != string.Empty &&
                information.Text != string.Empty &&
                city.Text != string.Empty &&
                age.Text != string.Empty &&
                education.Text != string.Empty &&
                experience.Text != string.Empty &&
                salary.Text != string.Empty &&
                phoneNumber.Text != string.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddComboboxItems()
        {
            education.Items.Add("Secondary education");
            education.Items.Add("Incomplete Higher education");
            education.Items.Add("High education");

            experience.Items.Add("Less than 1 year");
            experience.Items.Add("1 - 3 years");
            experience.Items.Add("3 - 5 years");
            experience.Items.Add("Greater than 5 years");
        }

        public bool isValidPhoneNumber(string phoneNumber)
        {

            Regex regex = new Regex(@"([+994]{4})[- ]?([50,51,55,70,77]{2})[- ]?([0-9]{3})[- ]?([0-9]{2})[- ]?([0-9]{2})");
            bool isValidated = regex.IsMatch(phoneNumber);

            return isValidated;
        }
    }
}
