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
        private Cart c;
        public frmCheckout(Cart cart)
        {
            InitializeComponent();
            c = cart;
        }
        private void frmCheckout_Load(object sender, EventArgs e)
        {
            c.UpdateListBox(lstCart);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            c.cart.Clear();
            lstCart.Items.Clear();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int selectedItem = lstCart.SelectedIndex;
            c.cart.RemoveAt(selectedItem);
            lstCart.Items.RemoveAt(selectedItem);
        }
    }
}
