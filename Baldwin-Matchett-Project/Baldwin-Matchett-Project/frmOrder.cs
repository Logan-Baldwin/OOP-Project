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
            try
            {
                // The antique locket being removed for having 0 quantity messes up all items after it
                // Maybe make an array to keep track of which items have been hidden? Ill think more about a solution tomorrow
                FileHelper.ReadProducts("inventory.txt", i.inventory);
                i.UpdateListBox(lstProducts);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Reading File");
            }


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

        // Need to make the listbox update the quantity
        private void btnPurchase_Click(object sender, EventArgs e)
        {
            decimal quantity = nudQuantity.Value;
            int selectedItem = lstProducts.SelectedIndex;

            if (i.inventory[selectedItem].Quantity - (int)quantity >= 0)
            {
                for (int index = 0; index < quantity; index++)
                {
                    c.cart.Add(i.inventory[selectedItem]);
                    i.inventory[selectedItem].Quantity = i.inventory[selectedItem].Quantity - (int)quantity;
                }
                lblItemsInCart.Text = "Items In Cart: " + c.cart.Count;
            }
            else
            {
                MessageBox.Show("Not enough in stock");
            }
           
        }

        private void btnViewCart_Click(object sender, EventArgs e)
        {
            frmCheckout cart = new frmCheckout();
            cart.ShowDialog();
        }

        private void lstProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstProducts.SelectedIndex != -1)
                lblDescription.Text = i.inventory[lstProducts.SelectedIndex].ToString();
        }
        private void btnAddProduct_Click(object sender, EventArgs e)
        {

        }
        private void btnRemoveProduct_Click(object sender, EventArgs e)
        {
            int selectedItem = lstProducts.SelectedIndex;
            if (selectedItem != -1)
                lstProducts.Items.RemoveAt(selectedItem);
            else
                MessageBox.Show("No item selected", "Deletion Cancelled");
        }

        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            i.UpdateListBox(lstProducts);
        }
    }
}
