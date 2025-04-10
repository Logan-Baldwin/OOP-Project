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
    public partial class frmAddProduct : Form
    {
        string path;
        public frmAddProduct(string Path)
        {
            InitializeComponent();
            path = Path;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Validator.FindDecimal(txtPrice.Text, out decimal price);
            decimal Price = price;
            Validator.FindInt(txtCode.Text, out int code);
            int Code = code;

            string Desc = txtDesc.Text;
            string opt2 = txtOpt2.Text;
            string opt1 = txtOpt1.Text;

            try
            {

                if (cmbType.SelectedIndex == 0)
                {
                    Validator.FindInt(txtOpt1.Text, out int age);
                    int Age = age;
                    VintageJewelry tmp = new VintageJewelry(Code, Desc, Price, (int)nudQty.Value, Age, opt2);
                    FileHelper.AddProduct(path, tmp);
                }
                if (cmbType.SelectedIndex == 1)
                {
                    AntiqueFurniture tmp = new AntiqueFurniture(Code, Desc, Price, (int)nudQty.Value, opt1, opt2);
                    FileHelper.AddProduct(path, tmp);
                }

            }
            catch
            {
                MessageBox.Show("Could not add product, please verify all values are correct and present");
            }
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddProduct_Load(object sender, EventArgs e)
        {

        }
    }
}

