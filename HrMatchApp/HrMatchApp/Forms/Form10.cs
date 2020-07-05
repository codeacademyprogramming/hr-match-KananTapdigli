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

namespace HrMatchApp.Forms
{
    public partial class Form10 : Form
    {
        User activeWorker;
        CV cv;
        public Form10(User activeWorker)
        {
            InitializeComponent();
            this.activeWorker = activeWorker;
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            searchFor.Items.Add("Category");
            searchFor.Items.Add("Age");
            searchFor.Items.Add("Education");
            searchFor.Items.Add("City");
            searchFor.Items.Add("Salary");
            searchFor.Items.Add("Experience");


        }

        private void searchFor_SelectedIndexChanged(object sender, EventArgs e)
        {

            var choosing = searchFor.Text;
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

                        choosingName.Text = $"Maximum {choosing}";

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

                        choosingName.Text = $"Minimum {choosing}";

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


        IQueryable<Announcement> query;
        private void button1_Click(object sender, EventArgs e)
        {
            if (searchFor.Text != string.Empty && (combobox.Text != string.Empty || textBox.Text != string.Empty))
            {
                var choosing = searchFor.Text;

                listView.Items.Clear();

                using (HrMatchContext db = new HrMatchContext())
                {
                    if (searchFor.Items.Contains(choosing))
                    {
                        if ((combobox.Visible == false) || (combobox.Visible = true && combobox.Items.Contains(combobox.Text)))
                        {
                            switch (choosing)
                            {
                                case "Category":

                                    int categoryID = db.Categories.FirstOrDefault(c => c.Name == combobox.Text).ID;

                                    query = db.Announcements
                                                .Where(a => a.CategoryID.Equals(categoryID));

                                    if (query.Any(a => a.CategoryID.Equals(categoryID)))
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

                                        query = db.Announcements
                                             .Where(a => a.Age <= Age);

                                        if (query.Any(a => a.Age <= Age))
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

                                    query = db.Announcements
                                            .Where(a => a.Education.Equals(combobox.Text));


                                    if (query.Any(a => a.Education.Equals(combobox.Text)))
                                    {
                                        AddtoListView();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Your search did not match any documents.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }

                                    break;


                                case "City":

                                    query = db.Announcements
                                        .Where(a => a.City.Name.Equals(combobox.Text));

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

                                    if (decimal.TryParse(combobox.Text, out decimal Salary))
                                    {

                                        query = db.Announcements
                                               .Where(a => a.Salary > Salary);

                                        if (query.Any(c => c.Salary > Salary))
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

                                    query = db.Announcements
                                          .Where(a => a.Experience.Equals(combobox.Text));

                                    if (query.Any(a => a.Experience.Equals(combobox.Text)))
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
                        else
                        {
                            MessageBox.Show("2th Search field has not chosen correctly!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("'Search for' field has not chosen correctly!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Search fields must be filled!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void listView_MouseClick(object sender, MouseEventArgs e)
        {
            if (cv != null)
            {
                for (int itemIndex = 0; itemIndex < listView.Items.Count; itemIndex++)
                {
                    var rectangle = listView.GetItemRect(itemIndex);

                    ListViewItem item = listView.Items[itemIndex];

                    var subItems = item.SubItems;

                    if (rectangle.Contains(e.Location) && subItems[0].Text == "APPLY HERE")
                    {

                        DialogResult dialogResult = MessageBox.Show("Do You Want to Pass Apply Form?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (dialogResult.Equals(DialogResult.Yes))
                        {

                            string name = subItems[1].Text;
                            string companyName = subItems[2].Text;
                            string categoryName = subItems[3].Text;
                            string information = subItems[4].Text;
                            string education = subItems[5].Text;
                            string experience = subItems[6].Text;
                            byte age = Convert.ToByte(subItems[7].Text);
                            string cityName = subItems[8].Text;
                            decimal salary = Convert.ToDecimal(subItems[9].Text);
                            string phoneNumber = subItems[10].Text;

                            Announcement announcement;
                            using (HrMatchContext db = new HrMatchContext())
                            {
                                int categoryID = db.Categories.FirstOrDefault(c => c.Name.Equals(categoryName)).ID;
                                int cityID = db.Cities.FirstOrDefault(c => c.Name.Equals(cityName)).ID;

                                announcement = db.Announcements
                                             .FirstOrDefault(a => a.Name.Equals(name) && a.CompanyName.Equals(companyName) && a.CategoryID.Equals(categoryID) && a.CityID.Equals(cityID) && a.Information.Equals(information) && a.Education.Equals(education) && a.Experience.Equals(experience) && a.Age.Equals(age) && a.Salary.Equals(salary) && a.PhoneNumber.Equals(phoneNumber));
                            }

                            Form11 form11 = new Form11(activeWorker, announcement);
                            form11.ShowDialog();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("You must add Your CV for Any Apply!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void AddtoListView()
        {
            using (HrMatchContext db = new HrMatchContext())
            {
                foreach (var dbAnnouncement in query)
                {
                    string categoryName = db.Categories.FirstOrDefault(c => c.ID.Equals(dbAnnouncement.CategoryID)).Name;
                    string cityName = db.Cities.FirstOrDefault(c => c.ID.Equals(dbAnnouncement.CityID)).Name;

                    ListViewItem listViewItem;

                    if (HasCV() && cv.CategoryID == dbAnnouncement.CategoryID)
                    {
                        string[] item = { "APPLY HERE", dbAnnouncement.Name, dbAnnouncement.CompanyName, categoryName, dbAnnouncement.Information, dbAnnouncement.Education, dbAnnouncement.Experience, dbAnnouncement.Age.ToString(), cityName, dbAnnouncement.Salary.ToString(), dbAnnouncement.PhoneNumber };

                        listViewItem = new ListViewItem(item);
                    }
                    else
                    {
                        string[] item = { "NOT SUITABLE FOR YOUR CV", dbAnnouncement.Name, dbAnnouncement.CompanyName, categoryName, dbAnnouncement.Information, dbAnnouncement.Education, dbAnnouncement.Experience, dbAnnouncement.Age.ToString(), cityName, dbAnnouncement.Salary.ToString(), dbAnnouncement.PhoneNumber };

                        listViewItem = new ListViewItem(item);
                    }

                    listView.Items.Add(listViewItem);
                }
            }
        }

        public bool HasCV()
        {
            using (HrMatchContext db = new HrMatchContext())
            {
                cv = db.CVs.FirstOrDefault(c => c.UserID == activeWorker.ID);

                if (cv != null)
                {
                    return true;
                }

                return false;
            }
        }

    }
}
