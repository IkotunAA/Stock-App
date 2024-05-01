using STOCKPROFITANDLOSSAPP.Context;
using STOCKPROFITANDLOSSAPP.Managers;
using STOCKPROFITANDLOSSAPP.Models.Entities;

namespace STOCKPROFITANDLOSSAPP
{
    public class PurchaseManager
    {
        ProductManager productManager = new();
        double totalPriceofGoodsBought = 0;
        double totalPriceofGoodssold = 0;
        double totalProfitorLoss = 0;
        public Purchase MakePurchase(string customerName, Dictionary<string, int> purchasedGoods, double totalPrice)
        {
            var purchase = new Purchase(StockContext.Purchases.Count + 1, Ref(), customerName, purchasedGoods, totalPrice, DateTime.Now);
            foreach (var item in purchasedGoods)
            {
                var pm = new ProductManager();
                var p = pm.GetProductByName(item.Key);
                StockContext.Users[0].Wallet += p.SellingPrice * item.Value;
            }
            StockContext.Purchases.Add(purchase);
            return purchase;
        }
        private string Ref()
        {
            Random random = new();
            return $"ref:pur/{random.Next(1234, 6789)}";
        }
        public void GetAllPurchase()
        {
            foreach (var item in StockContext.Purchases)
            {
                if (item == null)
                {
                    Console.WriteLine("No purchase made yet");
                }
                Console.WriteLine($"{item.CustomerName} with the total price of {item.TotalPrice}");
                Console.WriteLine($"                 Details of Products               ");
                Console.ForegroundColor = ConsoleColor.Green;
                foreach (var item1 in item.PurchasedGoods)
                {
                    Console.WriteLine($"The product name {item1.Key} and the quantity is {item1.Value}");
                }
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public void FilterPurchasesByDate(DateTime startDate, DateTime endDate)
        {
            if (startDate.Date > endDate.Date)
            {
                Console.WriteLine("Start Date can not be greater than end date");
            }
            else
            {
                int count = 0;
                foreach (var item in StockContext.Purchases)
                {
                    if (item.DateCreated.Date >= startDate.Date && endDate.Date >= item.DateCreated.Date)
                    {
                        count++;
                        foreach (var item1 in item.PurchasedGoods)
                        {
                            Console.WriteLine($"The product name {item1.Key} and the quantity is {item1.Value}");
                        }
                    }
                }
                if (count == 0)
                {
                    Console.WriteLine("No product purchase within the date range");
                }
            }
        }
        public void GetProfitOrLoss(DateTime? startDate, DateTime? endDate, bool checkWithDate)
        {
            Dictionary<string, int> productRecords = new();
            if (checkWithDate is true)
            {
                if (startDate.Value.Date > endDate.Value.Date)
                {
                    Console.WriteLine("Start Date can not be greater than end date");
                }
                else
                {
                    foreach (var item in StockContext.Purchases)
                    {
                        if (item.DateCreated.Date >= startDate.Value.Date && endDate.Value.Date >= item.DateCreated.Date)
                        {
                            foreach (var item1 in item.PurchasedGoods)
                            {
                                if (productRecords.ContainsKey(item1.Key))
                                {
                                    productRecords[item1.Key] += item1.Value;
                                }
                                else
                                {
                                    productRecords.Add(item1.Key, item1.Value);
                                }
                            }
                        }
                    }

                    if (productRecords.Count == 0)
                    {
                        Console.WriteLine("No product within the date range");
                    }
                    else
                    {
                        foreach (var item in productRecords)
                        {
                            var product = productManager.GetProductByName(item.Key);
                            Console.WriteLine($"The profit or loss {product.Name} is {product.SellingPrice * item.Value} less {product.CostPrice * item.Value} is {(product.SellingPrice * item.Value) - (product.CostPrice * item.Value)}");
                            totalPriceofGoodsBought += product.CostPrice * item.Value;
                            totalPriceofGoodssold += product.SellingPrice * item.Value;
                            totalProfitorLoss = totalPriceofGoodssold - totalPriceofGoodsBought;
                        }
                        Console.WriteLine($"The total Purchase is {totalPriceofGoodsBought} and the total sales is {totalPriceofGoodssold} and the total profit is {totalProfitorLoss}");
                    }
                }
            }
            else
            {
                foreach (var item in StockContext.Purchases)
                {
                    foreach (var item1 in item.PurchasedGoods)
                    {
                        if (productRecords.ContainsKey(item1.Key))
                        {
                            productRecords[item1.Key] += item1.Value;
                        }
                        else
                        {
                            productRecords.Add(item1.Key, item1.Value);
                        }
                    }
                }
                if (productRecords.Count == 0)
                {
                    Console.WriteLine("No available product");
                }
                else
                {
                    foreach (var item in productRecords)
                    {
                        var product = productManager.GetProductByName(item.Key);
                        Console.WriteLine($"The profit or loss {product.Name} is {product.SellingPrice * item.Value} minus {product.CostPrice * item.Value} is {(product.SellingPrice * item.Value) - (product.CostPrice * item.Value)}");
                        totalPriceofGoodsBought += product.CostPrice * item.Value;
                        totalPriceofGoodssold += product.SellingPrice * item.Value;
                        totalProfitorLoss = totalPriceofGoodssold - totalPriceofGoodsBought;
                    }
                    Console.WriteLine($"The total Purchase is {totalPriceofGoodsBought} and the total sales is {totalPriceofGoodssold} and the total profit is {totalProfitorLoss}");
                }
            }
        }
    }
}