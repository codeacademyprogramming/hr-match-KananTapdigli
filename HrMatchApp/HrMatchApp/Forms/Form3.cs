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
    public partial class Form3 : Form
    {
        HrMatchContext db;
        List<User> users;

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            users = new List<User>();

            using (db = new HrMatchContext())
            {
                foreach (var user in db.Users)
                {
                    User dbUser = new User(user.ID,user.Username, user.Email, user.Status, user.Password);
                    users.Add(dbUser);
                }
            }
        }

        private void signIn_Click(object sender, EventArgs e)
        {

            if (users.Exists(u => u.Username.ToLower().Equals(username.Text.ToLower()) && u.Password.Equals(password.Text)))
            {
                User activeUser = users.FirstOrDefault(u => u.Username.ToLower().Equals(username.Text.ToLower()) && u.Password.Equals(password.Text));

                if (activeUser.Status.Equals("Worker"))
                {
                    Form4 form4 = new Form4(activeUser);
                    form4.ShowDialog();
                }
                else
                {
                    Form5 form5 = new Form5(activeUser);
                    form5.ShowDialog();
                }

                username.Text = string.Empty;
                password.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Username or Password are incorrect!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }   
    }
}
