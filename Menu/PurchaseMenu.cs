using STOCKPROFITANDLOSSAPP.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOCKPROFITANDLOSSAPP.Menu
{
    internal class PurchaseMenu
    {
        StockManager stockManager = new();
        PurchaseManager purchaseManager = new();
        ProductManager productManager = new();
        UserManager userManager = new();
        public void PurchaseMain()
        {
            Console.WriteLine($"Enter 1 to Make Purchase\nEnter 2 to see all purchases\nEnter 3 to filter purchase by date");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    MakePurchase();
                    break;
                case "2":
                    GetAllPurchase();
                    break;
                case "3":
                    FilterPurchasesByDate();
                    break;
            }
        }
        public void MakePurchase()
        {
            Dictionary<string, int> produce = new Dictionary<string, int>();
            double price = 0;
            Console.WriteLine("Enter Customer Name");
            string customerName = Console.ReadLine();
            bool flag = true;
            while (flag)
            {
                var products = productManager.GetAll();
                foreach (var product in products)
                {
                    Console.WriteLine($"{product.Id} : {product.Name}");
                }
                Console.WriteLine("Pick a product by pressing the ID number");
                int opt = int.Parse(Console.ReadLine());
                var prd = productManager.Get(opt);
                if (prd == null)
                {
                    Console.WriteLine("Product does not exist");
                    continue;
                }
                Console.WriteLine($"enter the quantity of {prd.Name} you want");
                int qty = int.Parse(Console.ReadLine());
                if (qty > prd.Quantity)
                {
                    Console.WriteLine($"The Quantity entered is more than what is in stock\n will you go for {prd.Quantity} that remains in the stock?\ny/n");
                    string qtyOption = Console.ReadLine();
                    if (qtyOption.ToLower() == "n")
                    {
                        Console.WriteLine($"Choose another product");
                        continue;
                    }
                    else
                    {
                        if (prd.Quantity < 1)
                        {
                            Console.WriteLine($"Product is out of stock");
                            continue;
                        }
                        qty = prd.Quantity;
                    }
                }
                if (produce.ContainsKey(prd.Name))
                {
                    produce[prd.Name] += qty;
                }
                else
                {
                    produce.Add(prd.Name, qty);
                }
                price += prd.SellingPrice * qty;
                prd.Quantity -= qty;
                Console.WriteLine("do you want to purchase more product, y/n");
                string option = Console.ReadLine();
                if (option == "n")
                {
                    flag = false;
                }
            }
            var prod = purchaseManager.MakePurchase(customerName, produce, price);
            Console.WriteLine("Enter any key to continue...");
            Console.ReadKey();
        }
        public void GetAllPurchase()
        {
            purchaseManager.GetAllPurchase();
        }
        public void FilterPurchasesByDate()
        {
            Console.WriteLine("Enter first date");
            DateTime firstDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter last date");
            DateTime lastDate = DateTime.Parse(Console.ReadLine());
            purchaseManager.FilterPurchasesByDate(firstDate, lastDate);
        }
    }
}

