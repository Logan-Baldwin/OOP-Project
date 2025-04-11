using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Forms.VisualStyles;

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

    /* |=======================================================|                     
     * |                     FileHelper                        |
     * |-------------------------------------------------------|
     * |                    No properties                      |
     * |-------------------------------------------------------|
     * |+ReadSize(path:string):integer                         |
     * |+ReadProducts(path:string, inventorycart:list)         |  
     * |+ReadUsers(path:string, userList:list)                 |
     * |+ClearFile(path:string, length:integer)                | 
     * |+ReadToArrary(path:string, length:integer):string array| 
     * |+AddProduct(path:string, p:product)                    | 
     * |+RemoveProduct(path:string, p:product, length:integer) |
     * |=======================================================|
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
            reader.Close();
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
                    if (arr[0] == "furniture")
                    {
                        inventorycart.Add(new AntiqueFurniture(code, arr[2], price, qty, arr[5], arr[6]));
                    }
                    else if (arr[0] == "jewelry")
                    {
                        inventorycart.Add(new VintageJewelry(code, arr[2], price, qty, age, arr[6]));
                    }
                }


            }
            reader.Close();
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

            for (int i = 0; i < size; i++)
            {
                arr = reader.ReadLine().Split(',');

                if (arr[3] == "customer")
                {
                    userList.Add(new Customer(arr[0], arr[1], arr[2]));
                }
                else if (arr[3] == "admin")
                {
                    userList.Add(new Admin(arr[0], arr[1], arr[2]));
                }

            }
            reader.Close();

        }

        public static void ClearFile(string path, int length)
        {
            StreamWriter writer = new StreamWriter(path, false);

            for (int i = 0; i <= length; i++)
            {
                writer.WriteLine("");
            }
            System.Diagnostics.Debug.WriteLine("File cleared");
            writer.Close();
        }

        public static void RemoveByQty(string path, Product p, Inventory i)
        {
            string[] products = ReadToArray(path, i.inventory.Count);
            int code = p.Code;
            int newQty = 0;

            //getting new quantity to insert in inventory file
            //  by searching for the product in the inventory list
            foreach(Product item in i.inventory)
            {
                if(item.Code == code)
                {
                    newQty = item.Quantity;
                }
            }

            //clear the file
            ClearFile(path, i.inventory.Count);




            //re-fill out the data, skipping the line to remove
            // write all unchanged products back into inventory
            // insert the altered quantity product with it's new quantity
            StreamWriter writer = new StreamWriter(path);
            foreach (string s in products)
            {
                System.Diagnostics.Debug.WriteLine($"Testing if string {s} contains {p.Description}");
                if (!s.Contains(p.Description))
                {
                    System.Diagnostics.Debug.WriteLine($"Yes, writing to file");
                    writer.WriteLine(s);
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine($"no, making new data string with new quantity");
                    if (p.Quantity > 0)
                    {
                        if (p is AntiqueFurniture)
                        {

                            AntiqueFurniture af = (AntiqueFurniture)p;
                            writer.WriteLine($"furniture,{af.Code},{af.Description},{af.Price},{newQty},{af.Creator},{af.Origin}");
                            System.Diagnostics.Debug.WriteLine($"Item '{af}' has been written back into file with new qty");
                        }
                        if (p is VintageJewelry)
                        {
                            VintageJewelry j = (VintageJewelry)p;
                            writer.WriteLine($"jewelry,{j.Code},{j.Description},{j.Price},{newQty},{j.Age},{j.Metal}");
                            System.Diagnostics.Debug.WriteLine($"Item '{j}' has been written back into file with new qty");
                        }
                    }


                }

            }
            writer.Close();
        }

        public static string[] ReadToArray(string path, int length)
        {
            StreamReader reader = new StreamReader(path);
            string[] products = new string[length];


            for (int i = 0; i < length; i++)
            {
                products[i] = reader.ReadLine();
            }
            reader.Close();
            return products;
        }

        public static void AddProduct(string path, Product p)
        {
            StreamWriter writer = File.AppendText(path);
            if (p is AntiqueFurniture)
            {
                AntiqueFurniture af = (AntiqueFurniture)p;
                writer.WriteLine($"furniture,{af.Code},{af.Description},{af.Price},{af.Quantity},{af.Creator},{af.Origin}");
            }
            else if (p is VintageJewelry)
            {
                VintageJewelry j = (VintageJewelry)p;
                writer.WriteLine($"furniture,{j.Code},{j.Description},{j.Price},{j.Quantity},{j.Age},{j.Metal}");
            }
            writer.Close();
        }

        public static void RemoveProduct(string path, Product p, int length)
        {

            string[] products = ReadToArray(path, length);

            ClearFile("path", products.Length);

            StreamWriter writer = new StreamWriter(path);
            //re-fill out the data, skipping the line to remove
            foreach (string s in products)
            {
                if (!s.Contains(p.Description) & s != null)
                {
                    System.Diagnostics.Debug.WriteLine($"Item '{s}' has been written back into file");
                    writer.WriteLine(s);
                }
            }

            writer.Close();

        }

        /*
         *  Writes a detailed receipt to orders.txt every time a checkout
         *      is performed
         */
        public static void OrderReciept(string path, List<Product> products, string user)
        {
            decimal total = 0;

            StreamWriter writer = File.AppendText(path);
            writer.WriteLine("************************************************************");
            writer.WriteLine($"Order Reciept for User '{user}'");
            writer.WriteLine("************************************************************");

            writer.WriteLine($"Items in order:");
            foreach (Product p in products)
            {
                total += p.Price;
                writer.WriteLine($"Code: {p.Code}    Desc: {p.Description}");
                writer.WriteLine($"Qty Ordered: {p.Quantity}    Price/item: {p.Price}\n");
            }
            writer.WriteLine($"Subtotal:  ${total}");
            writer.WriteLine($"Tax (15%): ${total * 0.015M}");
            writer.WriteLine($"Total: ${total + (total * 0.015M)}");
            writer.WriteLine("************************************************************");

            writer.Close();

        }


    }





    /* |==============================================================================================|
     * |                                         Validator                                            |
     * |----------------------------------------------------------------------------------------------|
     * |                                       No properties                                          |
     * |----------------------------------------------------------------------------------------------|
     * |+Err(code:string)                                                                             |
     * |+FindInt(s:string, d:integer):boolean                                                         | 
     * |+FindDecimal(s:string, d:decimal):boolean                                                     |
     * |+ValidateItem(arr:string array, code:integer, price:decimal, qty:integer, age:integer):boolean| 
     * |+ValidateUser(userList:list, user:string, passwd:string, loginuser:User):boolean              |
     * |==============================================================================================|
     */
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
        public static bool ValidateItem(string[] arr, out int Code, out decimal Price, out int Qty, out int Age)
        {
            bool result = false;

            //if item is furniture, validate all numerical values associated with furniture objects
            //  if ANY of Validator's Find methods fail, we know we will not be able to construct this product (ValidateItem will return false)
            if (arr[0] == "furniture")
            {
                result = Validator.FindInt(arr[1], out int code) & Validator.FindDecimal(arr[3], out decimal price) & Validator.FindInt(arr[4], out int qty);
                Code = code;
                Price = price;
                Qty = qty;
                Age = 0;
            }

            //if item is jewelry, validate all numerical values associated with furniture objects
            //  if ANY of Validator's Find methods fail, we know we will not be able to construct this product (ValidateItem will return false)
            else if (arr[0] == "jewelry")
            {
                result = Validator.FindInt(arr[1], out int code) & Validator.FindDecimal(arr[3], out decimal price) & Validator.FindInt(arr[4], out int qty) & Validator.FindInt(arr[5], out int age);
                Code = code;
                Price = price;
                Qty = qty;
                Age = age;

            }
            else
            {
                Code = 0;
                Price = 0;
                Qty = 0;
                Age = 0;

                Err(arr[1]);
            }

            return result;

        }

        /*
         *      ValidateUser()
         *      
         */
        public static bool ValidateUser(List<User> userlist, string user, string passwd, out User loginuser)
        {

            foreach (User u in userlist)
            {
                if (u.UserID == user)
                {
                    if (u.Password == passwd)
                    {
                        loginuser = u;
                        return true;
                    }
                }

            }
            loginuser = new User("n/a", "n/a", "n/a");
            return false;
        }


    }



    /* |==================|      
     * |      User        |
     * |------------------|
     * |+UserID:string    |
     * |+Password:string  |
     * |+Name:string      |
     * |+Access:string    |
     * |+User:object      |
     * |------------------|
     * |+ToString():string|
     * |==================|
     */
    public class User
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
    /* |==================|
     * |     Customer     |
     * |------------------|
     * |+Customer:object  | 
     * |------------------|
     * |+ToString():string|
     * |==================|
     */
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
    /*|==================|
    * |      Admin       |
    * |------------------|
    * |+Admin:object     |
    * |------------------|
    * |+ToString():string|
    * |==================|
    */
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
    /* |======================|    
     * |    Product           |
     * |----------------------|
     * |+Code:integer         |
     * |+Description:string   |
     * |+Price:decimal        |
     * |+Quantity:int         |
     * |+Product:object       |
     * |----------------------|
     * |+ToString():string    |
     * |+IsAvailable():boolean|
     * |+Clone():object       |
     * |======================|
     */

    public abstract class Product : ICloneable
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

        public abstract object Clone();





    }
    /* |======================|
     * |   VintageJewelry     |
     * |----------------------|
     * |+Age:int              |
     * |+Metal:string         |
     * |+VintageJewelry:object|
     * |----------------------|
     * |+IsAvailable():boolean|
     * |+ToString():string    |
     * |+Clone():object       |
     * |+overload>:           |
     * |     VintageJewelry   |
     * |======================|
     */
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

        public override object Clone()
        {
            VintageJewelry newItem = new VintageJewelry(this.Code,this.Description,this.Price,this.Quantity,this.Age,this.Metal);
            return newItem;
        }

        /*
         *   '<' AND '>' operators are overloaded to perform Clone()
         *   
         *      the 'arrow' points to the product that is being cloned, the other being the product that will become the clone
         */
        public static Product operator >(VintageJewelry A, VintageJewelry B)
        {
            return (Product)A.Clone();
        }
        public static Product operator <(VintageJewelry A, VintageJewelry B)
        {
            return (Product)B.Clone();
        }

        public override string ToString()
        {
            return "ProductCode: " + this.Code + "  Description: " + this.Description + "  Price: $" + this.Price +
                    "   Qty: " + this.Quantity + "  Age: " + this.Age + "  Metal: " + this.Metal;
        }

    }
    /*|========================|
    * |   AntiqueFurniture     |
    * |------------------------|
    * |+Creator:string         |
    * |+Origin:string          | 
    * |+AntiqueFurniture:object|
    * |------------------------|
    * |+IsAvailable():boolean  |
    * |+ToString():string      |
    * |+Clone():object         |
    * |+overload>:             |
    * |     AntiqueFurniture   |
    * |========================|
    */
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

        public override object Clone()
        {
            AntiqueFurniture newItem = new AntiqueFurniture(this.Code, this.Description, this.Price, this.Quantity, this.Creator, this.Origin);
            return newItem;
        }

        /*
         *   < AND > operators are overloaded to perform Clone()
         *   
         *      the 'arrow' points to the product that is being cloned, the other being the product that will become the clone
         */ 
        public static Product operator >(AntiqueFurniture A, AntiqueFurniture B)
        {
            return (Product)B.Clone();
        }
        public static Product operator <(AntiqueFurniture A, AntiqueFurniture B)
        {
            return (Product)A.Clone();
        }

        public override string ToString()
        {
            return "ProductCode: " + this.Code + "  Description: " + this.Description + "  Price: $" + this.Price +
                    "   Qty: " + this.Quantity + "  Creator: " + this.Creator + "  Origin: " + this.Origin;
        }


    }
    /* |==========================|
     * |       Inventory          |
     * |------------------------- |
     * |+Inventory:list           |
     * |------------------------- |
     * |+UpdateListBox(l:listbox) |
     * |+Clear(l:listbox)         |
     * |+HideZeroes(l:listbox)    |
     * |==========================|
     */
    public class Inventory : IUpdater
    {

        public List<Product> inventory = new List<Product>();

        public Inventory()
        {
            inventory = new List<Product>();
        }


        public void UpdateListBox(ListBox l)
        {
            l.Items.Clear();

            foreach (Product p in inventory)
            {
                l.Items.Add($"{p.Description}  Qty: {p.Quantity}");
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
    /* |=========================|
     * |         Cart            |
     * |-------------------------|
     * |+cart:list               |
     * |+count:int               |
     * |-------------------------|
     * |+TotalCart():decimal     |
     * |+ClearCart(total:decimal)|
     * |+Clear(l:listbox)        |
     * |+UpdateListBox(l:listbox)|
     * |+HideZeroes(l:listbox)   |
     * |=========================|
     */
    public class Cart : IUpdater
    {
        public List<Product> cart = new List<Product>();
        public int count { get; set; }
        public decimal subtotal { get; set; }

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

        /*
         *      '+' operator overload
         *          will return a new cart object containing an updated cart
         *          , adding product p into it
         */
        public static Cart operator +(Cart c, Product p)
        {
            Cart newCart = new Cart();
            foreach(Product item in c.cart)
            {
                newCart.cart.Add(item);
            }
            newCart.cart.Add(p);
            return newCart;
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
                l.Items.Add($"{p.Description}   qty: {p.Quantity}");
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

    }





     
}
