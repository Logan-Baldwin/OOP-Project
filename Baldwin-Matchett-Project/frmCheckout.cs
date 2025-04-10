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
        public frmCheckout(Cart cart)
        {
            InitializeComponent();
            c = cart;

        }
        private void frmCheckout_Load(object sender, EventArgs e)
        {
            c.UpdateListBox(lstCart);
            FillLabels();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
        /* Name: ClearAll
        * Sent: Nothing
        * Returned: Nothing
        * Description: Empties the listbox, cart, and labels
        */
        private void ClearAll()
        {
            c.cart.Clear();
            lstCart.Items.Clear();
            lblSubtotal.Text = "";
            lblTax.Text = "";
            lblTotal.Text = "";
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int selectedItem = lstCart.SelectedIndex;
            c.cart.RemoveAt(selectedItem);
            lstCart.Items.RemoveAt(selectedItem);
            c.UpdateListBox(lstCart);
            FillLabels();
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

        private void lstCart_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            string total = lblTotal.Text;
            if (total != "")
                MessageBox.Show("Thank you for purchasing your order for " + total, "Purchase Succesful");
            else
                MessageBox.Show("Please add items on the previous screen", "No Items In Cart");

            ClearAll();
        }
    }
}