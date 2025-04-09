﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Baldwin_Matchett_Project
{

    /*
     *  @author Parker Matchett
     *  date 2025/04/05 additions:
     *
     *
     *  TODO:
     *      - overload 1 relational operator
     *      - overload 1 mathematical operator
     *      
     *      
     *      
     *      ***file formatting***
     *      
     *      Inserting Products
     *      
     *      every line is a product, using a comma as a delimiter for each piece of data,
     *      when they are read in, numerical values are validated, but strings are left alone,
     *      this assumes the strings make sense.
     *      
     *      the first piece of data signifies to our methods what type of object to create
     *      
     *      FURNITURE data comes in the form of:
     *      furniture,code,description,price,quantity,creator,origin
     *      
     *      and 
     *      
     *      JEWELRY data comes in the form of:
     *      jewelry,code,description,price,quantity,age,metal
     *      
     *      when we read a file to fill the inventory list, we call 
     *      
     *     (1)     Inventory inventory = new Inventory
     *              -> to initialize the inventory list
     *             
     *     (2)     FileHelper.ReadProducts(pathtofile, inventory)
     *          
     *     (3)     UpdateListbox(lstInventory)
     *              -> to update the on-screen listbox with the contents of lstInventory
     *              
     *              IF the we are displaying this on the customer view, it may be best to call HideZeroes(lstInventory)
     *                  to hide the products that have a quantity of 0 in our inventory to the customer
     *                  
     *                  in the admin view however we dont need to hide anything
     *      
     *      
     *      
     *      
     */


     static class FileHelper
    {

        /*
         *  ReadSize
         *      param: string
         *      returns: Amount of lines within the file at path string.
         * 
         */
        public static int ReadSize(string path)
        {
            StreamReader reader = new StreamReader(path);
            int lineCount = 0;

            while (!reader.EndOfStream)
            {
                reader.ReadLine();
                lineCount++;
            }
            return lineCount;
        }

        /*
         *  ReadProducts
         *      param: string, List<Product>
         *      returns: n/a
         *      
         *      Will validate all products within the given file and add them into the
         *      provided list if they are valid
         *      
         */
        public static void ReadProducts(string path, List<Product> inventorycart)
        {
            StreamReader reader = new StreamReader(path);
            int size = ReadSize(path);
            string[] arr;
            int code, qty, age;
            decimal price;


            for (int i = 0; i < size; i++)
            {
                arr = reader.ReadLine().Split(',');


                if (Validator.ValidateItem(arr, out code, out price, out qty, out age))
                {
                    if (arr[0] == "Furniture")
                    {
                        inventorycart.Add(new AntiqueFurniture(code, arr[2], price, qty, arr[5], arr[6]));
                    }
                    else if (arr[0] == "Jewelry")
                    {
                        inventorycart.Add(new VintageJewelry(code, arr[2], price, qty, age, arr[6]));
                    }
                }
            }

        }
        /*
   *  ReadUsers
   *      param: string, List<User>
   *      returns: n/a
   *      
   *      Same as ReadProducts, but for users
   *      
   */
        public static void ReadUsers(string path, List<User> userList)
        {
            StreamReader reader = new StreamReader(path);
            int size = ReadSize(path);
            string[] arr;
            string userID, password, name, access;

            for (int i = 0; i < size; i++)
            {
                arr = reader.ReadLine().Split(',');

                if (Validator.ValidateItem(arr, out userID, out password, out name, out access))
                {
                    userList.Add(new User(userID, password, name, access));
                }

            }

        }


    }






    static class Validator
    {
        /*
         *  Err(itemcode)
         *  Method convenient for automatically creating a message box when something goes wrong
         */
        public static void Err(string code)
        {
            MessageBox.Show("Error", $"There was an error adding this item ( item code = {code} ).");
        }

        public static bool FindInt(string s, out int d)
        {
            if (Int32.TryParse(s, out int result))
            {
                d = result;
                return true;
            }

            d = -1;
            return false;

        }

        public static bool FindDecimal(string s, out decimal d)
        {
            if (Decimal.TryParse(s, out decimal result))
            {
                d = result;
                return true;
            }

            d = -1;
            return false;

        }

        /*
         *      ValidateItem
         *          param: string[], out int, out decimal, out int, out int
         *          returns: Whether the string[] passed in will be able to be constructed into a product or not. (bool)
         *          
         *          **strings are not passed into ValidateItem because we dont really need to validate them
         */
        public static bool ValidateItem(string[] arr, out int code, out decimal price, out int qty, out int age)
        {
            bool result = false;
            code = 0;
            price = 0;
            qty = 0;
            age = 0;

            //if item is furniture, validate all numerical values associated with furniture objects
            //  if ANY of Validator's Find methods fail, we know we will not be able to construct this product (ValidateItem will return false)
            if (arr[0] == "Furniture")
            {
                result = Validator.FindInt(arr[1], out code) || Validator.FindDecimal(arr[3], out price) || Validator.FindInt(arr[4], out qty);
            }

            //if item is jewelry, validate all numerical values associated with furniture objects
            //  if ANY of Validator's Find methods fail, we know we will not be able to construct this product (ValidateItem will return false)
            else if (arr[0] == "Vintage Jewelry")
            {
                result = Validator.FindInt(arr[1], out code) || Validator.FindDecimal(arr[3], out price) || Validator.FindInt(arr[4], out qty) || Validator.FindInt(arr[5], out age);
            }
            if (result == false)
            {
                Err(arr[1]);
            }

            return result;
        }

    }




    class User
    {
        public string UserID { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Access { get; set; }

        public User(string userid, string password, string name)
        {
            this.UserID = userid;
            this.Password = password;
            this.Name = name;
        }

        public override string ToString()
        {
            return "ID: " + this.UserID + "  Name: " + this.Name;
        }

    }

    class Customer : User
    {
        public Customer(string userid, string password, string name) : base(userid, password, name)
        {
            this.Access = "customer";
        }


        public override string ToString()
        {
            return "ID: " + this.UserID + "  Name: " + this.Name + "  Access Level: " + this.Access;
        }

    }

    class Admin : User
    {
        public Admin(string userid, string password, string name) : base(userid, password, name)
        {
            this.Access = "admin";
        }
        public override string ToString()
        {
            return "ID: " + this.UserID + "  Name: " + this.Name + "  Access Level: " + this.Access;
        }

    }

    abstract class Product
    {
        public int Code { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public Product(int code, string desc, decimal price, int instock)
        {
            this.Code = code;
            this.Description = desc;
            this.Price = price;
            this.Quantity = instock;
        }

        public override abstract string ToString();

        public abstract bool IsAvailable();


    }

    sealed class VintageJewelry : Product
    {
        public int Age { get; set; }
        public string Metal { get; set; }

        public VintageJewelry(int code, string desc, decimal price, int instock, int age, string metal) : base(code, desc, price, instock)
        {
            this.Age = age;
            this.Metal = metal;
        }

        public override bool IsAvailable()
        {
            if (this.Quantity > 0)
            { return true; }
            else
            { return false; }
        }

        public override string ToString()
        {
            return "ProductCode: " + this.Code + "  Description: " + this.Description + "  Price: $" + this.Price +
                    "   Qty: " + this.Quantity + "  Age: " + this.Age + "  Metal: " + this.Metal;
        }

    }

    sealed class AntiqueFurniture : Product
    {
        public string Creator { get; set; }
        public string Origin { get; set; }

        public AntiqueFurniture(int code, string desc, decimal price, int instock, string creator, string origin) : base(code, desc, price, instock)
        {
            this.Creator = creator;
            this.Origin = origin;
        }

        public override bool IsAvailable()
        {
            if (this.Quantity > 0)
            { return true; }
            else
            { return false; }
        }

        public override string ToString()
        {
            return "ProductCode: " + this.Code + "  Description: " + this.Description + "  Price: $" + this.Price +
                    "   Qty: " + this.Quantity + "  Creator: " + this.Creator + "  Origin: " + this.Origin;
        }
    }

    class Inventory : IUpdater
    {
        public List<Product> inventory = new List<Product>();


        public void UpdateListBox(ListBox l)
        {
            l.Items.Clear();
            foreach (Product p in inventory)
            {
                l.Items.Add(p);
            }
        }
        public void Clear(ListBox l)
        {
            foreach (Product p in l.Items)
            {
                l.Items.Remove(p);
            }
        }
        public void HideZeroes(ListBox l)
        {
            foreach (Product p in l.Items)
            {
                if (p.Quantity == 0)
                {
                    l.Items.Remove(p);
                }
            }
        }
    }

    public class Cart : IUpdater
    {
        public List<Product> cart = new List<Product>();


        public decimal TotalCart()
        {
            decimal total = 0;
            foreach (Product p in cart)
            {
                total += p.Price;
            }
            return total;
        }

        public void ClearCart(decimal total)
        {
            foreach (Product p in cart)
            {
                cart.Remove(p);
            }

        }

        public void Clear(ListBox l)
        {
            foreach (Product p in l.Items)
            {
                l.Items.Remove(p);
            }
        }
        public void UpdateListBox(ListBox l)
        {
            l.Items.Clear();
            foreach (Product p in cart)
            {
                l.Items.Add(p);
            }
        }

        public void HideZeroes(ListBox l)
        {
            foreach (Product p in l.Items)
            {
                if (p.Quantity == 0)
                {
                    l.Items.Remove(p);
                }
            }
        }

    }

    /*
     *  Interface IUpdater 
     *      allows Inventory and Cart to interact seamlessly 
     *      with the form's listboxes
     */
     interface IUpdater
    {

        /*
         *  Clear(l) i is a method only used in UpdateListBox()
         *  
         */
        void Clear(ListBox l);

        /*
         * UpdateListBox(l) updates the listbox passed into it, clearing items
         * and adding in every item currently in inventory
         * 
         */
        void UpdateListBox(ListBox l);

        /*
         *  HideZeroes(l) hides removes all items with a quantity of
         *   zero from given listbox
         *  
         */
        void HideZeroes(ListBox l);

    }






}
