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

            List<User> userlist = new List<User>();
            FileHelper.ReadUsers("users.txt", userlist);


            if (Validator.ValidateUser(userlist, userIn, passIn, out User loginUser))
            {
                frmOrder order = new frmOrder(loginUser);
                order.ShowDialog();
            }


        }




    }
}
