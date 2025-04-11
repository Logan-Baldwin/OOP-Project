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
    public partial class frmCheckout : Form
    {
        Cart c;
        Inventory i;
        string path;
        string username;
        public frmCheckout(Cart cart, string Path, Inventory I, string name)
        {
            InitializeComponent();
            c = cart;
            path = Path;
            i = I;
            username = name;
        }
        private void frmCheckout_Load(object sender, EventArgs e)
        {
            foreach(Product p in c.cart)
            {
                System.Diagnostics.Debug.WriteLine($"Product code {p.Code} is in the cart with a quantity of {p.Quantity}");
            }
            c.UpdateListBox(lstCart);
            FillLabels();
        }

        /* Name: ClearAll
        * Sent: string 
        * Returned: Nothing
        * Description: Empties the listbox, cart, and labels
        */
        private void ClearAll(string type)
        {
            // If the user removes all items instead of purchasing, their quantities will go back up
            if(type == "return")
            {
                for (int n = 0; n < lstCart.Items.Count; n++)
                {
                    for(int x = 0; x < i.inventory.Count; x++)
                    {
                        if (i.inventory[x].Code == c.cart[n].Code)
                        {
                            i.inventory[x].Quantity = c.cart[n].Quantity;
                        }
                    }
                }
            }
            c.cart.Clear();
            lstCart.Items.Clear();
            lblSubtotal.Text = "";
            lblTax.Text = "";
            lblTotal.Text = "";
        }

        /* Name: FillLabels
        * Sent: Nothing
        * Returned: Nothing
        * Description: caluculates the subtotal, total and tax, then fills the labels with that information
        */
        private void FillLabels()
        {
            decimal subtotal = c.TotalCart(), taxedAmount = 0, total = 0, tax = 0.15M;

            taxedAmount = decimal.Round(subtotal * tax, 2);

            total = decimal.Round(subtotal + taxedAmount, 2);

            lblSubtotal.Text = "$" + subtotal.ToString();
            lblTax.Text = "$" + taxedAmount.ToString();
            lblTotal.Text = "$" + total.ToString();
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            string type = "return";
            ClearAll(type);
        }

        private void btnRemove_Click_1(object sender, EventArgs e)
        { 
            try
            {

                for (int n = 0; n < lstCart.Items.Count; n++)
                {
                    for (int x = 0; x < i.inventory.Count; x++)
                    {
                        if (i.inventory[x].Code == c.cart[n].Code)
                        {
                            i.inventory[x].Quantity = c.cart[n].Quantity;
                        }
                    }
                }


                int selectedItem = lstCart.SelectedIndex;
                c.cart[selectedItem].Quantity += 1;
                c.cart.RemoveAt(selectedItem);
                lstCart.Items.RemoveAt(selectedItem);
                c.UpdateListBox(lstCart);



                FillLabels();
            }
            catch { }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string type = "purchase";
            string total = lblTotal.Text;
            
            if (total != "")
            {
                MessageBox.Show("Thank you for purchasing your order for " + total, "Purchase Succesful");
                //write receipt
                FileHelper.OrderReciept("orders.txt", c.cart, username);
                //remove items from cart and inventory file



                // i need 
                //  - the initial quantity (quantity currently in inventory)
                //  - the quantity held in cart (p.Quantity)
                //      
                //      then subtract initial by held in cart for new qty

                for (int n = 0; n < c.cart.Count; n++)
                {
                    FileHelper.RemoveByQty(path, c.cart[n], i);
                }
                 
                
            }
            else
            {
                MessageBox.Show("Please add items on the previous screen", "No Items In Cart");
            }


            ClearAll(type);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}