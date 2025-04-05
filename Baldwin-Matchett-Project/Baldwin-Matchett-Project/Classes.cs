using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baldwin_Matchett_Project
{

    /*
  *  @author Parker Matchett
  *  date 2025/04/05 additions:
  *      -every basic class and derived class layout made
  *      
  *
  *  TODO:
  *      - one interface (custom or built in)
  *      - one of each: *sealed *abstract *static
  *      - respective methods
  *      - overload 1 mathematical operator and 1 relational operator within the Product class
  *      - at least 1 list
  *      - Static Helper class for files
  *      - Static Helper class for data validation
  *
  */
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

    class Product
    {
        public int Code { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool InStock { get; set; }

        public Product(int code, string desc, decimal price, bool instock)
        {
            this.Code = code;
            this.Description = desc;
            this.Price = price;
            this.InStock = instock;
        }


    }

    class VintageJewelry : Product
    {
        public int Age { get; set; }
        public string Metal { get; set; }

        public VintageJewelry(int code, string desc, decimal price, bool InStock, int age, string metal) : base(code, desc, price, instock)
        {
            this.Age = age;
            this.Metal = metal;
        }

        public override string ToString()
        {
            return "ProductCode: " + this.Code + "  Description: " + this.Description + "  Price: $" + this.Price +
                    "   Available: " + this.InStock + "  Age: " + this.Age + "  Metal: " + this.Metal;
        }

    }

    class AntiqueFurniture : Product
    {
        public string Creator { get; set; }
        public string Origin { get; set; }

        public AntiqueFurniture(int code, string desc, decimal price, bool InStock, string creator, string origin) : base(code, desc, price, instock)
        {
            this.Creator = creator;
            this.Origin = origin;
        }

        public override string ToString()
        {
            return "ProductCode: " + this.Code + "  Description: " + this.Description + "  Price: $" + this.Price +
                    "   Available: " + this.InStock + "  Age: " + this.Age + "  Origin: " + this.Origin;
        }
    }

}
