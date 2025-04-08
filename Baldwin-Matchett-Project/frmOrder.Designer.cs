namespace Baldwin_Matchett_Project
{
    partial class frmOrder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrder));
            this.lstProducts = new System.Windows.Forms.ListBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblStock = new System.Windows.Forms.Label();
            this.tabOrders = new System.Windows.Forms.TabControl();
            this.tabCustomer = new System.Windows.Forms.TabPage();
            this.btnViewCart = new System.Windows.Forms.Button();
            this.lblItemsInCart = new System.Windows.Forms.Label();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPurchase = new System.Windows.Forms.Button();
            this.tabAdmin = new System.Windows.Forms.TabPage();
            this.btnRemoveProduct = new System.Windows.Forms.Button();
            this.btnEditProduct = new System.Windows.Forms.Button();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabOrders.SuspendLayout();
            this.tabCustomer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            this.tabAdmin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lstProducts
            // 
            this.lstProducts.FormattingEnabled = true;
            this.lstProducts.ItemHeight = 20;
            this.lstProducts.Location = new System.Drawing.Point(1, 132);
            this.lstProducts.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstProducts.Name = "lstProducts";
            this.lstProducts.Size = new System.Drawing.Size(402, 264);
            this.lstProducts.TabIndex = 2;
            // 
            // lblDescription
            // 
            this.lblDescription.BackColor = System.Drawing.Color.Silver;
            this.lblDescription.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDescription.Location = new System.Drawing.Point(436, 132);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(403, 265);
            this.lblDescription.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label2.Location = new System.Drawing.Point(612, 415);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 26);
            this.label2.TabIndex = 7;
            this.label2.Text = "In Stock:";
            // 
            // lblStock
            // 
            this.lblStock.BackColor = System.Drawing.Color.Silver;
            this.lblStock.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStock.Location = new System.Drawing.Point(713, 415);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(112, 29);
            this.lblStock.TabIndex = 8;
            // 
            // tabOrders
            // 
            this.tabOrders.Controls.Add(this.tabCustomer);
            this.tabOrders.Controls.Add(this.tabAdmin);
            this.tabOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabOrders.Location = new System.Drawing.Point(14, 405);
            this.tabOrders.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabOrders.Name = "tabOrders";
            this.tabOrders.SelectedIndex = 0;
            this.tabOrders.Size = new System.Drawing.Size(592, 141);
            this.tabOrders.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabOrders.TabIndex = 9;
            // 
            // tabCustomer
            // 
            this.tabCustomer.Controls.Add(this.btnViewCart);
            this.tabCustomer.Controls.Add(this.lblItemsInCart);
            this.tabCustomer.Controls.Add(this.nudQuantity);
            this.tabCustomer.Controls.Add(this.label1);
            this.tabCustomer.Controls.Add(this.btnPurchase);
            this.tabCustomer.Location = new System.Drawing.Point(4, 35);
            this.tabCustomer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabCustomer.Name = "tabCustomer";
            this.tabCustomer.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabCustomer.Size = new System.Drawing.Size(584, 102);
            this.tabCustomer.TabIndex = 0;
            this.tabCustomer.Text = "tabCustomer";
            this.tabCustomer.UseVisualStyleBackColor = true;
            // 
            // btnViewCart
            // 
            this.btnViewCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewCart.Location = new System.Drawing.Point(411, 0);
            this.btnViewCart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnViewCart.Name = "btnViewCart";
            this.btnViewCart.Size = new System.Drawing.Size(169, 82);
            this.btnViewCart.TabIndex = 11;
            this.btnViewCart.Text = "View Cart";
            this.btnViewCart.UseVisualStyleBackColor = true;
            this.btnViewCart.Click += new System.EventHandler(this.btnViewCart_Click);
            // 
            // lblItemsInCart
            // 
            this.lblItemsInCart.AutoSize = true;
            this.lblItemsInCart.Location = new System.Drawing.Point(-2, 55);
            this.lblItemsInCart.Name = "lblItemsInCart";
            this.lblItemsInCart.Size = new System.Drawing.Size(177, 26);
            this.lblItemsInCart.TabIndex = 10;
            this.lblItemsInCart.Text = "Items In Cart: 0";
            // 
            // nudQuantity
            // 
            this.nudQuantity.Location = new System.Drawing.Point(99, 0);
            this.nudQuantity.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(135, 32);
            this.nudQuantity.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 26);
            this.label1.TabIndex = 9;
            this.label1.Text = "Quantity:";
            // 
            // btnPurchase
            // 
            this.btnPurchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPurchase.Location = new System.Drawing.Point(241, 0);
            this.btnPurchase.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPurchase.Name = "btnPurchase";
            this.btnPurchase.Size = new System.Drawing.Size(169, 82);
            this.btnPurchase.TabIndex = 7;
            this.btnPurchase.Text = "Add To Cart";
            this.btnPurchase.UseVisualStyleBackColor = true;
            this.btnPurchase.Click += new System.EventHandler(this.btnPurchase_Click);
            // 
            // tabAdmin
            // 
            this.tabAdmin.Controls.Add(this.btnRemoveProduct);
            this.tabAdmin.Controls.Add(this.btnEditProduct);
            this.tabAdmin.Controls.Add(this.btnAddProduct);
            this.tabAdmin.Location = new System.Drawing.Point(4, 35);
            this.tabAdmin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabAdmin.Name = "tabAdmin";
            this.tabAdmin.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabAdmin.Size = new System.Drawing.Size(584, 102);
            this.tabAdmin.TabIndex = 1;
            this.tabAdmin.Text = "tabAdmin";
            this.tabAdmin.UseVisualStyleBackColor = true;
            // 
            // btnRemoveProduct
            // 
            this.btnRemoveProduct.Location = new System.Drawing.Point(354, 8);
            this.btnRemoveProduct.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRemoveProduct.Name = "btnRemoveProduct";
            this.btnRemoveProduct.Size = new System.Drawing.Size(169, 82);
            this.btnRemoveProduct.TabIndex = 2;
            this.btnRemoveProduct.Text = "Remove Product";
            this.btnRemoveProduct.UseVisualStyleBackColor = true;
            // 
            // btnEditProduct
            // 
            this.btnEditProduct.Location = new System.Drawing.Point(179, 8);
            this.btnEditProduct.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEditProduct.Name = "btnEditProduct";
            this.btnEditProduct.Size = new System.Drawing.Size(169, 82);
            this.btnEditProduct.TabIndex = 1;
            this.btnEditProduct.Text = "Edit Product";
            this.btnEditProduct.UseVisualStyleBackColor = true;
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Location = new System.Drawing.Point(3, 8);
            this.btnAddProduct.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(169, 82);
            this.btnAddProduct.TabIndex = 0;
            this.btnAddProduct.Text = "Add Product";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.lblWelcome.Location = new System.Drawing.Point(53, 41);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(578, 64);
            this.lblWelcome.TabIndex = 10;
            this.lblWelcome.Text = "WELCOME TO [STORE NAME]";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(722, -2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(117, 131);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // frmOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 545);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.tabOrders);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lstProducts);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Order - Logan, Parker";
            this.Load += new System.EventHandler(this.frmOrder_Load);
            this.tabOrders.ResumeLayout(false);
            this.tabCustomer.ResumeLayout(false);
            this.tabCustomer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            this.tabAdmin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox lstProducts;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.TabControl tabOrders;
        private System.Windows.Forms.TabPage tabCustomer;
        private System.Windows.Forms.TabPage tabAdmin;
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPurchase;
        private System.Windows.Forms.Button btnRemoveProduct;
        private System.Windows.Forms.Button btnEditProduct;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblItemsInCart;
        private System.Windows.Forms.Button btnViewCart;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}