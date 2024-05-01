using STOCKPROFITANDLOSSAPP.Context;
using STOCKPROFITANDLOSSAPP.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOCKPROFITANDLOSSAPP.Menu
{
    internal class ProductMenu
    {
        StockManager stockManager = new();
        PurchaseManager purchaseManager = new();
        ProductManager productManager = new();
        UserManager userManager = new();
        public void ProductMain()
        {
            Console.WriteLine($"Enter 1 to create a product\nEnter 2 to view product by name\nEnter 3 to view all products");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    CreateProduct();
                    break;
                case "2":
                    GetProductbyName();
                    break;
                case "3":
                    GetAllProduct();
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    ProductMain();
                    break;
            }
        }
        public void CreateProduct()
        {
            Console.WriteLine($"Enter the name of the product");
            string productName = Console.ReadLine();
            Console.WriteLine($"Enter the cost price");
            double cp = double.Parse(Console.ReadLine());
            var response = productManager.Create(productName, cp);
        }
        public void GetProductbyName()
        {
            Console.WriteLine($"Enter the product name");
            string productNeme = Console.ReadLine();
            var response = productManager.Get(productNeme);
        }
        public void GetAllProduct()
        {
            Console.WriteLine($"These are all the products available and their quantities");
            productManager.GetAll();
        }
    }
}
