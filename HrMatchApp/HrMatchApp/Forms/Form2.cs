using HrMatch;
using HrMatch.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HrMatchApp
{
    public partial class Form2 : Form
    {
        List<User> users;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            users = new List<User>();

            using (HrMatchContext db = new HrMatchContext())
            {
                foreach (var user in db.Users)
                {
                    User dbUser = new User(user.ID, user.Username, user.Email, user.Status, user.Password);
                    users.Add(dbUser);
                }
            }

            status.Items.Add("Worker");
            status.Items.Add("Employer");

            CodeText.Text = GetRandomPassword();
        }

        private void signUp_Click(object sender, EventArgs e)
        {
            if (username.Text != string.Empty &&
            email.Text != string.Empty &&
            status.Text != string.Empty &&
            password.Text != string.Empty &&
            confirmPassword.Text != string.Empty &&
            code.Text != string.Empty)
            {
                if (users.Exists(u => u.Username.ToLower().Equals(username.Text.ToLower())) == false)
                {
                    if (IsValidUsername(username.Text))
                    {
                        if (IsValidEmail(email.Text))
                        {
                            if (IsValidStatus(status.Text))
                            {
                                if (users.Exists(u => u.Email.Equals(email.Text)) == false)
                                {
                                    if (IsValidPassword(password.Text))
                                    {
                                        if (password.Text.Equals(confirmPassword.Text))
                                        {
                                            if (CodeText.Text.Equals(code.Text))
                                            {
                                                User user = new User(username.Text, email.Text, status.Text, password.Text);

                                                using (HrMatchContext db = new HrMatchContext())
                                                {
                                                    db.Users.Add(user);
                                                    db.SaveChanges();
                                                }

                                                MessageBox.Show("You Successfully Signed Up", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                                username.Text = string.Empty;
                                                email.Text = string.Empty;
                                                status.Text = string.Empty;
                                                password.Text = string.Empty;
                                                confirmPassword.Text = string.Empty;
                                                code.Text = string.Empty;
                                                CodeText.Text = GetRandomPassword();
                                            }
                                            else
                                            {
                                                MessageBox.Show("Checking Code had not written correctly!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                CodeText.Text = GetRandomPassword();
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Password and Confirm Password are Different!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Password is not valid format! It must be [8-16] characters and  must contain at least 1 Number , 1 Upper Letter and 1 Symbols.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("This Email has already been Signed Up", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Status has not chosen correctly!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Email is not valid format (Example: 'example@example.com')!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Username is not valid format! It must be [3-15] characters ", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show($"This user has already been registered!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("All fields must be filled!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static bool IsValidEmail(string email)
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }

        public static bool IsValidPassword(string password)
        {
            var input = password;

            var regex = new Regex(@"^(?=.*\d)(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%^&*()_+=\[{\]};:<>|./?,-]).{8,15}$");


            var isValidated = regex.IsMatch(input);
            return isValidated;
        }

        public static bool IsValidUsername(string username)
        {
            var input = username;

            var hasMinMax = new Regex(@"^([a-zA-Z0-9@*#]{3,15})$");

            var isValidated = hasMinMax.IsMatch(input);

            return isValidated;
        }

        public static bool IsValidStatus(string status)
        {

            if (status.Equals("Worker") || status.Equals("Employer"))
            {
                return true;
            }


            return false;
        }

        public static string GetRandomPassword()
        {
            string chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

            StringBuilder sb = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < 4; i++)
            {
                int index = random.Next(chars.Length);
                sb.Append(chars[index]);
            }

            return sb.ToString();
        }

        
    }
}
