using STOCKPROFITANDLOSSAPP.Context;
using STOCKPROFITANDLOSSAPP.Models.Entities;
using System.Reflection.Metadata.Ecma335;

namespace STOCKPROFITANDLOSSAPP
{
	public class StockManager
	{
		public Stock AddStock(Dictionary<string, int> goods)
		{
			Stock stock = new Stock(StockContext.Stocks.Count + 1, Ref(), goods, DateTime.Now);
			StockContext.Stocks.Add(stock);
			foreach (var item in goods)
			{
				foreach (var item1 in StockContext.Products)
				{
					if (item1.Name == item.Key)
					{
						item1.Quantity += item.Value;
					}
				}
			}
			return stock;
		}
		private string Ref()
		{
			Random random = new();
			return $"ref:stk/{random.Next(1234, 6789)}";
		}

		public Stock Get(string refNumber)
		{
			foreach (var item in StockContext.Stocks)
			{
				if (item.ReferenceNumber == refNumber)
				{
					return item;
				}
			}
			return null;
		}
		public List<Stock> GetAll()
		{
			return StockContext.Stocks;
		}
	}
}