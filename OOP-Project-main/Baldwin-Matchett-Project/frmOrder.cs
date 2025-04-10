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
        string path;
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
                for (int n = 0; n < i.inventory.Count; n++)
                {
                    if (i.inventory[n].Quantity == 0)
                    {
                        lstProducts.Items.RemoveAt(n);
                    }
                }
            }

            try
            {
                FileHelper.ReadProducts("inventory.txt", i.inventory);
                path = "inventory.txt";
            }
            catch
            {

                DialogResult dialogResult = MessageBox.Show("Inventory file not found, do you want to select an inventory file?", "Err", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    OpenFileDialog userfile = new OpenFileDialog();

                    if (userfile.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            FileHelper.ReadProducts(userfile.FileName, i.inventory);
                            path = userfile.FileName;
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

            i.UpdateListBox(lstProducts);



        }


        private void btnPurchase_Click(object sender, EventArgs e)
        {

            int qty = (int)nudQuantity.Value;

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
                            //lblItemsInCart.Text = $"Items in Cart: {c.count}";
                            //lblCost.Text = $"$ {c.TotalCart()}";
                        }
                        //i.UpdateListBox(lstProducts);
                        UpdateInfo();
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

            UpdateInfo();
        }

        /* Name: UpdateInfo
        * Sent: Nothing
        * Returned: Nothing
        * Description: Updates the listbox and labels with new information 
        */
        private void UpdateInfo()
        {
            i.UpdateListBox(lstProducts);
            lblItemsInCart.Text = $"Items in Cart: {c.cart.Count}";
            lblCost.Text = $"$ {c.TotalCart()}";
        }


        /*
         *  Admin controls
         */

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            //open form to add item
            frmAddProduct frmAdd = new frmAddProduct(path);
            frmAdd.ShowDialog();

            //clear list
            i.inventory.Clear();
            //re-fill and validate list
            FileHelper.ReadProducts(path, i.inventory);
            lstProducts.SelectedIndex = 0;
            i.UpdateListBox(lstProducts);

        }

        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            if (lstProducts.SelectedIndex != -1)
            {
                frmEditProduct edit = new frmEditProduct(this, i.inventory[lstProducts.SelectedIndex], i, path);
                edit.ShowDialog();
            }
        }

        private void btnRemoveProduct_Click(object sender, EventArgs e)
        {
            if (lstProducts.SelectedIndex != -1)
            {
                //remove within the file
                FileHelper.RemoveProduct("inventory.txt", i.inventory[lstProducts.SelectedIndex], i.inventory.Count);
                //clear list
                i.inventory.Clear();
                //re-fill and validate list
                FileHelper.ReadProducts(path, i.inventory);
                //update listbox, changing index as to avoid exception (index is being removed)
                lstProducts.SelectedIndex = 0;
                i.UpdateListBox(lstProducts);
            }

        }

        private void lstProducts_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // get currently selected product
            // determine its type
            // then fill out further information

            if(lstProducts.SelectedIndex != -1)
            {
            if (i.inventory[lstProducts.SelectedIndex] is AntiqueFurniture)
            {
                AntiqueFurniture selected = (AntiqueFurniture)i.inventory[lstProducts.SelectedIndex];
                lblDescription.Text = $"Item Code:   {selected.Code}\n";
                lblDescription.Text += $"Price:       ${selected.Price}\n";
                lblDescription.Text += $"Creator:     {selected.Creator}\n";
                lblDescription.Text += $"Origin:      {selected.Origin}";
            }
            if (i.inventory[lstProducts.SelectedIndex] is VintageJewelry)
            {
                VintageJewelry selected = (VintageJewelry)i.inventory[lstProducts.SelectedIndex];
                lblDescription.Text = $"Item Code:   {selected.Code}\n";
                lblDescription.Text += $"Price:       ${selected.Price}\n";
                lblDescription.Text += $"Material:    {selected.Metal}\n";
                lblDescription.Text += $"Age:         {selected.Age} Years";
            }
            }

        }

        /*
         *  Logout btn
         */
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
