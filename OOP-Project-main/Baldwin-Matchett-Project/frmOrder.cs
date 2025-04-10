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
    public partial class frmOrder : Form
    {
        Inventory i = new Inventory();
        private Cart c = new Cart();
        string username;
        string access;

        public frmOrder(User user)
        {
            InitializeComponent();
            username = user.Name;
            access = user.Access;

        }

        private void frmOrder_Load(object sender, EventArgs e)
        {
            // Hides the tab headers
            tabOrders.Appearance = TabAppearance.FlatButtons;
            tabOrders.ItemSize = new Size(0, 1);
            tabOrders.SizeMode = TabSizeMode.Fixed;

            if (access == "admin")
            {
                tabOrders.SelectedIndex = 1;
            }
            if (access == "customer")
            {

                tabOrders.SelectedIndex = 2;
                i.HideZeroes(lstProducts); //hide unavailable items if in customer view

            }


            //testing file reading vvv
            // this reads the file, we may want to simplify it so that
            // the left lstBox reads a code, name, qty, and furhter information
            // displays while selected
            FileHelper.ReadProducts("inventory.txt", i.inventory);
            i.UpdateListBox(lstProducts);



        }


        private void btnPurchase_Click(object sender, EventArgs e)
        {

            int qty = (int)nudQuantity.Value;



            //add selected item to cart
            try
            {
                int selectedQty = i.inventory[lstProducts.SelectedIndex].Quantity;
                if (selectedQty > 0)
                {
                    if (selectedQty >= qty)
                    {
                        for (int n = qty; n > 0; n--)
                        {
                            c.cart.Add(i.inventory[lstProducts.SelectedIndex]);
                            c.count++;
                            i.inventory[lstProducts.SelectedIndex].Quantity--;
                            lblItemsInCart.Text = $"Items in Cart: {c.count}";
                            lblCost.Text = $"$ {c.TotalCart()}";
                        }
                        i.UpdateListBox(lstProducts);
                    }
                    else
                    {
                        MessageBox.Show("That amount is not available to order", "err");
                    }

                }
            }
            catch
            {
                MessageBox.Show("No item selected", "err");
            }





        }


        private void btnViewCart_Click(object sender, EventArgs e)
        {
            frmCheckout cart = new frmCheckout(c);
            cart.ShowDialog();
        }

        private void lstProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get currently selected product
            // determine its type
            // then fill out further information


            if (i.inventory[lstProducts.SelectedIndex] is AntiqueFurniture)
            {
                AntiqueFurniture selected = (AntiqueFurniture)i.inventory[lstProducts.SelectedIndex];
                lblDescription.Text =  $"Item Code:   {selected.Code}\n";
                lblDescription.Text += $"Price:       ${selected.Price}\n";
                lblDescription.Text += $"Creator:     {selected.Creator}\n";
                lblDescription.Text += $"Origin:      {selected.Origin}";
            }
            if (i.inventory[lstProducts.SelectedIndex] is VintageJewelry)
            {
                VintageJewelry selected = (VintageJewelry)i.inventory[lstProducts.SelectedIndex];
                lblDescription.Text =  $"Item Code:   {selected.Code}\n";
                lblDescription.Text += $"Price:       ${selected.Price}\n";
                lblDescription.Text += $"Material:    {selected.Metal}\n";
                lblDescription.Text += $"Age:         {selected.Age} Years";
            }
        }

        /*
         *  Admin controls
         */ 

        private void btnAddProduct_Click(object sender, EventArgs e)
        {


        }

        private void btnEditProduct_Click(object sender, EventArgs e)
        {

        }

        private void btnRemoveProduct_Click(object sender, EventArgs e)
        {

        }
    }
}
