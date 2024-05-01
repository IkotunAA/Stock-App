using STOCKPROFITANDLOSSAPP.Managers;

namespace STOCKPROFITANDLOSSAPP.Menu
{
    public class StockMenu
    {
        StockManager stockManager = new();
        ProductManager productManager = new();
        public void StockMain()
        {
            Console.WriteLine($"Enter 1 to Add stock\nEnter 2 to get Stock by reference number\nEnter 3 to get view all stock");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    AddStock();
                    break;
                case "2":
                    GetStockByRef();
                    break;
                case "3":
                    GetAll();
                    break;
            }
        }
        public void AddStock()
        {
            Dictionary<string, int> stocks = new Dictionary<string, int>();
            bool flag = true;
            while (flag)
            {
                var products = productManager.GetAll();
                foreach (var product in products)
                {
                    Console.WriteLine($"enter {product.Id} to stock {product.Name}");
                }
                int opt = int.Parse(Console.ReadLine());
                var prd = productManager.Get(opt);
                Console.WriteLine($"enter the quantity of {prd.Name} to stock");
                int qty = int.Parse(Console.ReadLine());
                if (stocks.ContainsKey(prd.Name))
                {
                    stocks[prd.Name] += qty;
                }
                else
                {
                    stocks.Add(prd.Name, qty);
                }
                Console.WriteLine("do you want to add more stock, y/n");
                string option = Console.ReadLine();
                if (option == "n")
                {
                    flag = false;
                }
            }
            var good = stockManager.AddStock(stocks);
            Console.WriteLine("Enter any key to continue...");
            Console.ReadKey();
            //UserDashboard();
        }
        public void GetStockByRef()
        {
            Console.WriteLine("Enter Reference Number of the stock");
            string refInput = Console.ReadLine();
            stockManager.Get(refInput);
        }
        public void GetAll()
        {
            stockManager.GetAll();
        }
    }
}