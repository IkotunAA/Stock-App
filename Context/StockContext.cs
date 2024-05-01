using STOCKPROFITANDLOSSAPP.Models.Entities;
using STOCKPROFITANDLOSSAPP.Models.Enums;

namespace STOCKPROFITANDLOSSAPP.Context
{
	public class StockContext
	{
		public static ICollection<User> Users = new List<User>()
		{
			new User("Super Admin", "admin@gmail.com", "password", Gender.Male, 0),
		};
		public static ICollection<Product> Products = new List<Product>()
		{
			new Product(1, "Biscuit", 1600, 1900,78, DateTime.Now),
			new Product(2, "Sweet", 900, 1200,22, DateTime.Now),
			new Product(3, "Book", 1100, 1500,47, DateTime.Now),
		};
		public static ICollection<Stock> Stocks = new List<Stock>();
		public static ICollection<Purchase> Purchases = new List<Purchase>();
		public string UserFile = @"C:\Users\Accounts\Desktop\StockProfitAndLoss\Users.txt";
		public string ProductFile = @"C:\Users\Accounts\Desktop\StockProfitAndLoss\Products.txt";
		public string StockFile = @"C:\Users\Accounts\Desktop\StockProfitAndLoss\Stocks.txt";
		public string PurchaseFile = @"C:\Users\Accounts\Desktop\StockProfitAndLoss\Purchases.txt";

	}
	
}
