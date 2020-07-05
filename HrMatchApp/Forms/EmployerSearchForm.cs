using HrMatch;
using HrMatch.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HrMatchApp
{
    public partial class EmployerSearchForm : Form
    {
        public EmployerSearchForm()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            searchFor.Items.Add("Category");
            searchFor.Items.Add("Gender");
            searchFor.Items.Add("Age");
            searchFor.Items.Add("Education");
            searchFor.Items.Add("City");
            searchFor.Items.Add("Salary");
            searchFor.Items.Add("Experience");
        }

        string choosing;
        private void searchFor_SelectedIndexChanged(object sender, EventArgs e)
        {
            choosing = searchFor.Text;
            choosingName.Text = choosing;

            textBox.Text = string.Empty;
            combobox.Text = string.Empty;
            combobox.Items.Clear();

            using (HrMatchContext db = new HrMatchContext())
            {
                switch (choosing)
                {
                    case "Category":

                        textBox.Visible = false;
                        combobox.Visible = true;

                        foreach (var dbCategory in db.Categories)
                        {
                            combobox.Items.Add(dbCategory.Name);
                        }

                        break;

                    case "Gender":

                        textBox.Visible = false;
                        combobox.Visible = true;

                        combobox.Items.Add("Man");
                        combobox.Items.Add("Woman");

                        break;

                    case "Age":

                        textBox.Visible = true;
                        combobox.Visible = false;

                        choosingName.Text = $"Maximum";

                        break;

                    case "Education":

                        textBox.Visible = false;
                        combobox.Visible = true;

                        combobox.Items.Add("Secondary education");
                        combobox.Items.Add("Incomplete Higher education");
                        combobox.Items.Add("High education");

                        break;

                    case "City":

                        textBox.Visible = false;
                        combobox.Visible = true;

                        foreach (var dbCity in db.Cities)
                        {
                            string cityName = dbCity.Name;
                            combobox.Items.Add(cityName);
                        }

                        break;

                    case "Salary":

                        textBox.Visible = true;
                        combobox.Visible = false;

                        choosingName.Text = $"Minimum";

                        break;

                    case "Experience":

                        textBox.Visible = false;
                        combobox.Visible = true;

                        combobox.Items.Add("Less than 1 year");
                        combobox.Items.Add("1 - 3 years");
                        combobox.Items.Add("3 - 5 years");
                        combobox.Items.Add("Greater than 5 years");

                        break;

                    default:
                        break;
                }
            }
        }

        IQueryable<CV> query;
        private void button1_Click(object sender, EventArgs e)
        {
            listView.Items.Clear();

            if (CheckFields())
            {
                using (HrMatchContext db = new HrMatchContext())
                {
                    switch (choosing)
                    {
                        case "Category":

                            int categoryID = db.Categories.FirstOrDefault(c => c.Name == combobox.Text).ID;

                            query = db.CVs
                                        .Where(c => c.CategoryID.Equals(categoryID));

                            if (query.Any(c => c.CategoryID.Equals(categoryID)))
                            {
                                AddtoListView();
                            }
                            else
                            {
                                MessageBox.Show("Your search did not match any documents.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            break;

                        case "Gender":


                            query = db.CVs
                                    .Where(c => c.Gender.Equals(combobox.Text));

                            if (query.Any(c => c.Gender.Equals(combobox.Text)))
                            {
                                AddtoListView();
                            }
                            else
                            {
                                MessageBox.Show("Your search did not match any documents.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            break;


                        case "Age":

                            if (byte.TryParse(textBox.Text, out byte Age))
                            {
                                query = db.CVs
                                     .Where(c => c.Age <= Age);

                                if (query.Any(c => c.Age <= Age))
                                {
                                    AddtoListView();
                                }
                                else
                                {
                                    MessageBox.Show("Your search did not match any documents.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("'Age' field is not valid format! It must be a number!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            break;

                        case "Education":

                            query = db.CVs
                                    .Where(c => c.Education.Equals(combobox.Text));


                            if (query.Any(c => c.Education.Equals(combobox.Text)))
                            {
                                AddtoListView();
                            }
                            else
                            {
                                MessageBox.Show("Your search did not match any documents.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }


                            break;

                        case "City":

                            query = db.CVs
                                    .Where(c => c.City.Name.Equals(combobox.Text));

                            if (query.Any(c => c.City.Name.Equals(combobox.Text)))
                            {
                                AddtoListView();
                            }
                            else
                            {
                                MessageBox.Show("Your search did not match any documents.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            break;

                        case "Salary":

                            if (decimal.TryParse(textBox.Text, out decimal Salary))
                            {
                                query = db.CVs
                                            .Where(c => c.Salary >= Salary);

                                if (query.Any(c => c.Salary >= Salary))
                                {
                                    AddtoListView();
                                }
                                else
                                {
                                    MessageBox.Show("Your search did not match any documents.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("'Salary' field is not valid format! It must be a number!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            break;

                        case "Experience":

                            query = db.CVs
                                  .Where(c => c.Experience.Equals(combobox.Text));

                            if (query.Any(c => c.Experience.Equals(combobox.Text)))
                            {
                                AddtoListView();
                            }
                            else
                            {
                                MessageBox.Show("Your search did not match any documents.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            break;

                        default:
                            break;
                    }

                }
            }
        }

        public bool CheckFields()
        {
            if ((searchFor.Text == string.Empty && combobox.Text == string.Empty) || (searchFor.Text == string.Empty && textBox.Text == string.Empty))
            {
                MessageBox.Show("Search fields must be filled!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            else if (!searchFor.Items.Contains(choosing))
            {
                MessageBox.Show("'Search for' field has not chosen correctly!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            else if ((combobox.Visible == true && !combobox.Items.Contains(combobox.Text)))
            {
                MessageBox.Show("2th Search field has not chosen correctly!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            return true;

        }



        public void AddtoListView()
        {
            using (HrMatchContext db = new HrMatchContext())
            {
                foreach (var dbCV in query)
                {
                    string categoryName = db.Categories.FirstOrDefault(c => c.ID.Equals(dbCV.CategoryID)).Name;
                    string cityName = db.Cities.FirstOrDefault(c => c.ID.Equals(dbCV.CityID)).Name;

                    string[] item = { dbCV.Name, dbCV.Surname, dbCV.Gender, dbCV.Age.ToString(), dbCV.Education, dbCV.Experience, categoryName, cityName, dbCV.Salary.ToString(), dbCV.PhoneNumber };

                    ListViewItem listViewItem = new ListViewItem(item);

                    listView.Items.Add(listViewItem);
                }
            }
        }


    }
}
