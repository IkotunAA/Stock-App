using STOCKPROFITANDLOSSAPP.Context;
using STOCKPROFITANDLOSSAPP.Managers;
using STOCKPROFITANDLOSSAPP.Models.Entities;
using STOCKPROFITANDLOSSAPP.Models.Enums;

namespace STOCKPROFITANDLOSSAPP.Menu
{
    public class MainMenu
    {
        UserManager userManager = new();
        StockMenu stockMenu = new();
        ProductMenu productMenu = new();
        PurchaseMenu purchaseMenu = new();
        PurchaseManager purchaseManager = new();
        public void Menu()
        {
            Console.WriteLine("Welcome to STOCKPROFITANDLOSSAPP");
            LoginMenu();
        }
        public void LoginMenu()
        {
            Console.WriteLine("Enter your Email");
            string email = Console.ReadLine();
            Console.WriteLine("Enter your password");
            string password = Console.ReadLine();
            var response = userManager.Login(email, password);
            if (response != null)
            {
                UserDashboard();
            }
            else
            {
                Console.WriteLine("No user record found");
                LoginMenu();
            }
        }
        public void UserDashboard()
        {
            Console.WriteLine($"Welcome to your dashboard!");
            Console.WriteLine($"Enter 1 for Stock Management\nEnter 2 for Product Management\nEnter 3 to Purchase Manager\nEnter 4 for the Profit and loss Account");
            string keyInput = Console.ReadLine();
            switch (keyInput)
            {
                case "1":
                    stockMenu.StockMain();
                    UserDashboard();
                    break;
                case "2":
                    productMenu.ProductMain();
                    UserDashboard();
                    break;
                case "3":
                    purchaseMenu.PurchaseMain();
                    UserDashboard();
                    break;
                case "4":
                    GetProfitOrLoss();
                    UserDashboard();
                    break;
                default:
                    Console.WriteLine("Invalid Selection");
                    UserDashboard();
                    break;
            }
        }
        public void GetProfitOrLoss()
        {
            Console.WriteLine("Do you want to filter with date y/n");
            string option = Console.ReadLine();
            if (option is "y")
            {
                Console.WriteLine("Enter Start Date");
                DateTime startDate = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Enter End Date");
                DateTime lastDate = DateTime.Parse(Console.ReadLine());
                purchaseManager.GetProfitOrLoss(startDate, lastDate, true);
            }
            else
            {
                purchaseManager.GetProfitOrLoss(null, null, false);
            }
        }
    }
}