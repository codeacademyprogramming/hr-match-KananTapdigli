using HrMatch;
using HrMatch.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HrMatchApp
{
    public partial class AddCVForm : Form
    {
        User activeWorker;

        CV UserCV;
        string categoryName;
        string cityName;
        int categoryID;
        int cityID;


        public AddCVForm(User activeWorker)
        {
            InitializeComponent();
            this.activeWorker = activeWorker;
        }

        private void Form6_Load(object sender, EventArgs e)
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

            if (CheckHasCV())
            {
                AddInformations();
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            

            if (CheckFields())
            {
                using (HrMatchContext db = new HrMatchContext())
                {

                    Byte.TryParse(age.Text, out byte Age);
                    Decimal.TryParse(salary.Text, out decimal Salary);

                    if (CheckHasCV())
                    {
                        categoryID = db.Categories.FirstOrDefault(c => c.Name.Equals(category.Text)).ID;
                        cityID = db.Cities.FirstOrDefault(c => c.Name.Equals(city.Text)).ID;

                        db.CVs.FirstOrDefault(c => c.UserID.Equals(UserCV.UserID)).CategoryID = categoryID;
                        db.CVs.FirstOrDefault(c => c.UserID.Equals(UserCV.UserID)).CityID = cityID;
                        db.CVs.FirstOrDefault(c => c.UserID.Equals(UserCV.UserID)).Name = name.Text;
                        db.CVs.FirstOrDefault(c => c.UserID.Equals(UserCV.UserID)).Surname = surname.Text;
                        db.CVs.FirstOrDefault(c => c.UserID.Equals(UserCV.UserID)).Gender = gender.Text;
                        db.CVs.FirstOrDefault(c => c.UserID.Equals(UserCV.UserID)).Age = Age;
                        db.CVs.FirstOrDefault(c => c.UserID.Equals(UserCV.UserID)).Education = education.Text;
                        db.CVs.FirstOrDefault(c => c.UserID.Equals(UserCV.UserID)).Experience = experience.Text;
                        db.CVs.FirstOrDefault(c => c.UserID.Equals(UserCV.UserID)).Salary = Salary;
                        db.CVs.FirstOrDefault(c => c.UserID.Equals(UserCV.UserID)).PhoneNumber = phoneNumber.Text;

                        MessageBox.Show("CV is Successfully Updated!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        int categoryID = db.Categories.FirstOrDefault(c => c.Name.Equals(category.Text)).ID;
                        int cityID = db.Cities.FirstOrDefault(c => c.Name.Equals(city.Text)).ID;

                        CV cv = new CV(activeWorker.ID, categoryID, cityID, name.Text, surname.Text, gender.Text, Age, education.Text, experience.Text, Salary, phoneNumber.Text);
                        db.CVs.Add(cv);

                        button1.Text = "UPDATE";
                        title.Text = "UPDATE CV";

                        MessageBox.Show("Your CV is Successfully Added!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }

                    db.SaveChanges();

                }
            }
        }

        public bool CheckFields()
        {
            if (category.Text == string.Empty ||
           city.Text == string.Empty ||
           name.Text == string.Empty ||
           surname.Text == string.Empty ||
           gender.Text == string.Empty ||
           age.Text == string.Empty ||
           education.Text == string.Empty ||
           experience.Text == string.Empty ||
           salary.Text == string.Empty)
            {
                MessageBox.Show("All field must be filled!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            using (HrMatchContext db = new HrMatchContext())
            {
                if (!db.Categories.Any(c => c.Name == category.Text))
                {
                    MessageBox.Show("'Category' field has not chosen correctly!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (!db.Cities.Any(c => c.Name == city.Text))
                {
                    MessageBox.Show("'City' field has not chosen correctly!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (!gender.Items.Contains(gender.Text))
                {
                    MessageBox.Show("'Gender' field has not chosen correctly!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (!Byte.TryParse(age.Text, out byte Age))
                {
                    MessageBox.Show("Age field is not valid format! It must be a number!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (!education.Items.Contains(education.Text))
                {
                    MessageBox.Show("'Education' field has not chosen correctly!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (!experience.Items.Contains(experience.Text))
                {
                    MessageBox.Show("'Experience' field has not chosen correctly!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (!Decimal.TryParse(salary.Text, out decimal Salary))
                {
                    MessageBox.Show("Salary field is not valid format! It must be a number!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (!isValidPhoneNumber(phoneNumber.Text))
                {
                    MessageBox.Show("'Phone Number' field has not written correctly! Example: +994-55-555-55-55", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                return true;


            }
        }

        public  void AddInformations()
        {
             category.Text = categoryName;
            city.Text = cityName;
            name.Text = UserCV.Name;
            surname.Text = UserCV.Surname;
            gender.Text = UserCV.Gender;
            age.Text = UserCV.Age.ToString();
            education.Text = UserCV.Education;
            experience.Text = UserCV.Experience;
            salary.Text = UserCV.Salary.ToString();
            phoneNumber.Text = UserCV.PhoneNumber;
            button1.Text = "UPDATE";
            title.Text = "UPDATE CV";
        }

        public void AddComboboxItems()
        {
            gender.Items.Add("Man");
            gender.Items.Add("Woman");

            education.Items.Add("Secondary education");
            education.Items.Add("Incomplete Higher education");
            education.Items.Add("High education");

            experience.Items.Add("Less than 1 year");
            experience.Items.Add("1 - 3 years");
            experience.Items.Add("3 - 5 years");
            experience.Items.Add("Greater than 5 years");
        }

        public bool CheckHasCV()
        {
            using (HrMatchContext db = new HrMatchContext())
            {
                foreach (var dbCV in db.CVs)
                {
                    if (dbCV.UserID.Equals(activeWorker.ID))
                    {
                        UserCV = db.CVs.FirstOrDefault(c => c.UserID.Equals(activeWorker.ID));

                        categoryName = db.Categories.FirstOrDefault(c => c.ID.Equals(UserCV.CategoryID)).Name;
                        cityName = db.Cities.FirstOrDefault(c => c.ID.Equals(UserCV.CityID)).Name;

                        return true;
                    }
                }
                return false;
            }
        }

        public bool isValidPhoneNumber(string phoneNumber)
        {

            Regex regex = new Regex(@"([+994]{4})[- ]?([50,51,55,70,77]{2})[- ]?([0-9]{3})[- ]?([0-9]{2})[- ]?([0-9]{2})");
            bool isValidated = regex.IsMatch(phoneNumber);

            return isValidated;
        }
    }
}
