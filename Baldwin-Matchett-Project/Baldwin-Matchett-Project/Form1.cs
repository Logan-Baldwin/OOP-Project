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
        List<User> userList = new List<User>();
        Customer customer1 = new Customer("parker", "parker", "parker");
        Customer customer2 = new Customer("logan", "logan", "logan");
        Admin admin = new Admin("admin", "admin", "admin");

        public frmLogin()
        {
            InitializeComponent();
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                FileHelper.ReadUsers("users.txt", userList);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error reading file");
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userIn = txtUser.Text;
            string passIn = txtPassword.Text;

            switch (userIn)
            {
                case "admin":
                    if (passIn == "admin")
                    {
                        frmOrder order = new frmOrder(admin.Access);
                        order.ShowDialog();
                        break;
                    }
                    MessageBox.Show("Username or Password incorrect");
                    break;
                case "parker":
                    if (passIn == "parker")
                    {
                        frmOrder order = new frmOrder(customer1.Access);
                        order.ShowDialog();
                        break;
                    }
                    MessageBox.Show("Username or Password incorrect");
                    break;
                case "logan":
                    if (passIn == "logan")
                    {
                        frmOrder order = new frmOrder(customer2.Access);
                        order.ShowDialog();
                        break;
                    }
                    MessageBox.Show("Username or Password incorrect");
                    break;
                default:
                    MessageBox.Show("Please enter your information");
                    break;


            }


        }


    }
}
