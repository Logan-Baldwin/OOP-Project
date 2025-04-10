using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baldwin_Matchett_Project
{
    public partial class frmEditProduct : Form
    {
        private frmOrder mainform;
        Product p;
        Inventory i;
        string path;
        public frmEditProduct(Form frm ,Product tmp, Inventory I, string Path)
        {
            InitializeComponent();
            mainform = frm as frmOrder;
            p = tmp;
            i = I;
            path = Path;

        }

        private void frmEditProduct_Load(object sender, EventArgs e)
        {
            //set product type to label
            //fill in product information in controls
            if (p is AntiqueFurniture)
            {
                AntiqueFurniture af = (AntiqueFurniture)p;
                lblEditType.Text = "Antique Furniture";
                txtOpt1.Text = $"{af.Creator}";
                txtOpt2.Text = $"{af.Origin}";
            }
            else if(p is VintageJewelry )
            {
                VintageJewelry j = (VintageJewelry)p;
                lblEditType.Text = "Vintage Jewelry";
                txtOpt1.Text = $"{j.Age}";
                txtOpt2.Text = $"{j.Metal}";
            }

            txtCode.Text = $"{p.Code}";
            txtDesc.Text = $"{p.Description}";
            txtPrice.Text = $"{p.Price}";

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Validator.FindDecimal(txtPrice.Text, out decimal price);
            decimal Price = price;
            Validator.FindInt(txtCode.Text, out int code);
            int Code = code;

            string Desc = txtDesc.Text;
            string opt2 = txtOpt2.Text;
            string opt1 = txtOpt1.Text;

            //remove within the file
            FileHelper.RemoveProduct("inventory.txt", i.inventory[mainform.lstProducts.SelectedIndex], i.inventory.Count);

            try
            {

                if (p is VintageJewelry)
                {
                    VintageJewelry j = (VintageJewelry)p;
                    Validator.FindInt(txtOpt1.Text, out int age);
                    int Age = age;
                    VintageJewelry tmp = new VintageJewelry(Code, Desc, Price, (int)nudQty.Value, Age, opt2);
                    FileHelper.AddProduct(path, tmp);
                }
                else if (p is AntiqueFurniture)
                {
                    AntiqueFurniture af = (AntiqueFurniture)p;
                    AntiqueFurniture tmp = new AntiqueFurniture(Code, Desc, Price, (int)nudQty.Value, opt1, opt2);
                    FileHelper.AddProduct(path, tmp);
                }

            }
            catch
            {
                MessageBox.Show("Could not add product, please verify all values are correct and present");
            }






            //clear list
            i.inventory.Clear();
            //re-fill and validate list
            FileHelper.ReadProducts(path, i.inventory);
            //update listbox, changing index as to avoid exception (index is being removed)
            mainform.lstProducts.SelectedIndex = 0;
            i.UpdateListBox(mainform.lstProducts);

            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
