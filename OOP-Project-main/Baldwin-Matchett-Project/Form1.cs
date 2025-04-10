using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baldwin_Matchett_Project
{
    public partial class frmLogin : Form
    {
        List<User> users = new List<User>();


        public frmLogin()
        {
            InitializeComponent();
        }


        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userIn = txtUser.Text;
            string passIn = txtPassword.Text;
            if (userIn == "")
            {
                MessageBox.Show("Please enter your username", "Login Failed");
                txtUser.Focus();
            }
            else if (passIn == "")
            {
                MessageBox.Show("Please enter your password", "Login Failed");
                txtUser.Focus();
            }
            else if (Validator.ValidateUser(users, userIn, passIn, out User loginUser))
            {
                frmOrder order = new frmOrder(loginUser);
                order.ShowDialog();
            }
            else
            {
                MessageBox.Show("No user with that name and password", "Login Failed");
                txtUser.Focus();
            }
        }

        private void frmLogin_Load_1(object sender, EventArgs e)
        {
            txtUser.Clear();
            txtPassword.Clear();

            try
            {
                FileHelper.ReadUsers("users.txt", users);
            }
            catch
            {

                DialogResult dialogResult = MessageBox.Show("User file not found, do you want to select a user file?", "Err", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    OpenFileDialog userfile = new OpenFileDialog();

                    if (userfile.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            FileHelper.ReadUsers(userfile.FileName, users);
                        }
                        catch
                        {
                            MessageBox.Show("Invalid file, closing program.");
                            this.Close();
                        }

                    }
                    else
                    {
                        MessageBox.Show("File not selected, closing program.");
                        this.Close();
                    }

                }

                else if (dialogResult == DialogResult.No)
                {
                    this.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {


        }
    }
}
