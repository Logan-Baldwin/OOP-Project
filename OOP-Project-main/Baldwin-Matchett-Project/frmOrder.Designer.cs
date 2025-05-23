﻿namespace Baldwin_Matchett_Project
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
            this.lblCost = new System.Windows.Forms.Label();
            this.tabOrders = new System.Windows.Forms.TabControl();
            this.tabCustomer = new System.Windows.Forms.TabPage();
            this.lblItemsInCart = new System.Windows.Forms.Label();
            this.btnViewCart = new System.Windows.Forms.Button();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPurchase = new System.Windows.Forms.Button();
            this.tabAdmin = new System.Windows.Forms.TabPage();
            this.btnRemoveProduct = new System.Windows.Forms.Button();
            this.btnEditProduct = new System.Windows.Forms.Button();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnLogOut = new System.Windows.Forms.Button();
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
            this.lstProducts.ItemHeight = 16;
            this.lstProducts.Location = new System.Drawing.Point(4, 81);
            this.lstProducts.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstProducts.Name = "lstProducts";
            this.lstProducts.Size = new System.Drawing.Size(555, 292);
            this.lstProducts.TabIndex = 2;
            this.lstProducts.SelectedIndexChanged += new System.EventHandler(this.lstProducts_SelectedIndexChanged_1);
            // 
            // lblDescription
            // 
            this.lblDescription.BackColor = System.Drawing.Color.Silver;
            this.lblDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDescription.Location = new System.Drawing.Point(577, 162);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(345, 211);
            this.lblDescription.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label2.Location = new System.Drawing.Point(531, 452);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 22);
            this.label2.TabIndex = 7;
            this.label2.Text = "Cost:";
            // 
            // lblCost
            // 
            this.lblCost.BackColor = System.Drawing.Color.Silver;
            this.lblCost.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCost.Location = new System.Drawing.Point(600, 454);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(100, 23);
            this.lblCost.TabIndex = 8;
            // 
            // tabOrders
            // 
            this.tabOrders.Controls.Add(this.tabCustomer);
            this.tabOrders.Controls.Add(this.tabAdmin);
            this.tabOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabOrders.Location = new System.Drawing.Point(4, 420);
            this.tabOrders.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabOrders.Name = "tabOrders";
            this.tabOrders.SelectedIndex = 0;
            this.tabOrders.Size = new System.Drawing.Size(527, 113);
            this.tabOrders.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabOrders.TabIndex = 9;
            // 
            // tabCustomer
            // 
            this.tabCustomer.Controls.Add(this.lblItemsInCart);
            this.tabCustomer.Controls.Add(this.btnViewCart);
            this.tabCustomer.Controls.Add(this.nudQuantity);
            this.tabCustomer.Controls.Add(this.label1);
            this.tabCustomer.Controls.Add(this.btnPurchase);
            this.tabCustomer.Location = new System.Drawing.Point(4, 31);
            this.tabCustomer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabCustomer.Name = "tabCustomer";
            this.tabCustomer.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabCustomer.Size = new System.Drawing.Size(519, 78);
            this.tabCustomer.TabIndex = 0;
            this.tabCustomer.Text = "tabCustomer";
            this.tabCustomer.UseVisualStyleBackColor = true;
            // 
            // lblItemsInCart
            // 
            this.lblItemsInCart.AutoSize = true;
            this.lblItemsInCart.Location = new System.Drawing.Point(8, 48);
            this.lblItemsInCart.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblItemsInCart.Name = "lblItemsInCart";
            this.lblItemsInCart.Size = new System.Drawing.Size(129, 22);
            this.lblItemsInCart.TabIndex = 10;
            this.lblItemsInCart.Text = "Items in Cart:";
            // 
            // btnViewCart
            // 
            this.btnViewCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewCart.Location = new System.Drawing.Point(365, 0);
            this.btnViewCart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnViewCart.Name = "btnViewCart";
            this.btnViewCart.Size = new System.Drawing.Size(151, 65);
            this.btnViewCart.TabIndex = 2;
            this.btnViewCart.Text = "View Cart";
            this.btnViewCart.UseVisualStyleBackColor = true;
            this.btnViewCart.Click += new System.EventHandler(this.btnViewCart_Click);
            // 
            // nudQuantity
            // 
            this.nudQuantity.Location = new System.Drawing.Point(88, 0);
            this.nudQuantity.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nudQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(120, 28);
            this.nudQuantity.TabIndex = 0;
            this.nudQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 22);
            this.label1.TabIndex = 9;
            this.label1.Text = "Quantity:";
            // 
            // btnPurchase
            // 
            this.btnPurchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPurchase.Location = new System.Drawing.Point(215, 0);
            this.btnPurchase.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPurchase.Name = "btnPurchase";
            this.btnPurchase.Size = new System.Drawing.Size(151, 65);
            this.btnPurchase.TabIndex = 1;
            this.btnPurchase.Text = "Add To Cart";
            this.btnPurchase.UseVisualStyleBackColor = true;
            this.btnPurchase.Click += new System.EventHandler(this.btnPurchase_Click);
            // 
            // tabAdmin
            // 
            this.tabAdmin.Controls.Add(this.btnRemoveProduct);
            this.tabAdmin.Controls.Add(this.btnEditProduct);
            this.tabAdmin.Controls.Add(this.btnAddProduct);
            this.tabAdmin.Location = new System.Drawing.Point(4, 31);
            this.tabAdmin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabAdmin.Name = "tabAdmin";
            this.tabAdmin.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabAdmin.Size = new System.Drawing.Size(519, 78);
            this.tabAdmin.TabIndex = 1;
            this.tabAdmin.Text = "tabAdmin";
            this.tabAdmin.UseVisualStyleBackColor = true;
            // 
            // btnRemoveProduct
            // 
            this.btnRemoveProduct.Location = new System.Drawing.Point(315, 6);
            this.btnRemoveProduct.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRemoveProduct.Name = "btnRemoveProduct";
            this.btnRemoveProduct.Size = new System.Drawing.Size(151, 65);
            this.btnRemoveProduct.TabIndex = 2;
            this.btnRemoveProduct.Text = "Remove Product";
            this.btnRemoveProduct.UseVisualStyleBackColor = true;
            this.btnRemoveProduct.Click += new System.EventHandler(this.btnRemoveProduct_Click);
            // 
            // btnEditProduct
            // 
            this.btnEditProduct.Location = new System.Drawing.Point(159, 6);
            this.btnEditProduct.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEditProduct.Name = "btnEditProduct";
            this.btnEditProduct.Size = new System.Drawing.Size(151, 65);
            this.btnEditProduct.TabIndex = 1;
            this.btnEditProduct.Text = "Edit Product";
            this.btnEditProduct.UseVisualStyleBackColor = true;
            this.btnEditProduct.Click += new System.EventHandler(this.btnEditProduct_Click);
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Location = new System.Drawing.Point(3, 6);
            this.btnAddProduct.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(151, 65);
            this.btnAddProduct.TabIndex = 0;
            this.btnAddProduct.Text = "Add Product";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.lblWelcome.Location = new System.Drawing.Point(3, 11);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(687, 47);
            this.lblWelcome.TabIndex = 10;
            this.lblWelcome.Text = "Welcome to L and P Vintage and Antiques";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(695, 11);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(184, 146);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // btnLogOut
            // 
            this.btnLogOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.Location = new System.Drawing.Point(556, 491);
            this.btnLogOut.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(133, 37);
            this.btnLogOut.TabIndex = 14;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // frmOrder
            // 
            this.AcceptButton = this.btnViewCart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnLogOut;
            this.ClientSize = new System.Drawing.Size(947, 535);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.tabOrders);
            this.Controls.Add(this.lblCost);
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCost;
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
        private System.Windows.Forms.Button btnViewCart;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label lblDescription;
        public System.Windows.Forms.ListBox lstProducts;
        private System.Windows.Forms.Label lblItemsInCart;
        private System.Windows.Forms.Button btnLogOut;
    }
}