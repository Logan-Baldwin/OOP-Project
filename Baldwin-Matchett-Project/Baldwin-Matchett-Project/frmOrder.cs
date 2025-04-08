﻿using System;
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
    public partial class frmOrder : Form
    {
        Inventory i = new Inventory();
        Cart c = new Cart();
        string UserAccess;
        public frmOrder(string useraccess)
        {
            InitializeComponent();
            this.UserAccess = useraccess;
        }
        private void frmOrder_Load(object sender, EventArgs e)
        {
            // Hides the tab headers
            tabOrders.Appearance = TabAppearance.FlatButtons;
            tabOrders.ItemSize = new Size(0, 1);
            tabOrders.SizeMode = TabSizeMode.Fixed;


            //testing file reading vvv
            // this reads the file, we may want to simplify it so that
            // the left lstBox reads a code, name, qty, and furhter information
            // displays while selected
            FileHelper.ReadProducts("inventory.txt", i.inventory);
            i.UpdateListBox(lstProducts);

            if(UserAccess=="customer")
            {

                i.HideZeroes(lstProducts); //hide unavailable items if in customer view

            }
            else
            {
                tabOrders.SelectedIndex = 1;
                lblWelcome.Text = "WELCOME BACK ADMIN";
            }

        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            // For testing, remove later
            tabOrders.SelectedIndex = 1;
            // Improve appearance later
            lblWelcome.Text = "WELCOME BACK ADMIN";
           
        }
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            // For testing, remove later
            tabOrders.SelectedIndex = 0;
            // Improve appearance later
            lblWelcome.Text = "WELCOME TO [STORE NAME]";
        }

        private void btnViewCart_Click(object sender, EventArgs e)
        {
            frmCheckout cart = new frmCheckout();
            cart.ShowDialog();
        }

        private void lstProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblDescription.Text = i.inventory[lstProducts.SelectedIndex].ToString();
        }
    }
}
