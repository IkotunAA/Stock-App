using STOCKPROFITANDLOSSAPP.Context;
using STOCKPROFITANDLOSSAPP.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace STOCKPROFITANDLOSSAPP.Managers
{
    public class ProductManager
    {
        public bool Check(string name)
        {
            foreach (var item in StockContext.Products)
            {
                if (item.Name == name)
                {
                    return true;
                }
            }
            return false;
        }
        public Product Create(string name, double costPrice)
        {
            var exists = Check(name);
            if (exists)
            {
                Console.WriteLine("Already exist");
                return null;
            }
            var product = new Product(StockContext.Products.Count + 1, name, costPrice, 0.2 * costPrice, 0, DateTime.Now);
            StockContext.Products.Add(product);
            return product;
        }
        public Product Get(string name)
        {
            foreach (var item in StockContext.Products)
            {
                if (item.Name.ToLower().Trim() == name.ToLower().Trim())
                {
                    Console.WriteLine($"{item.Name}");
                    return item;
                }
            }
            Console.WriteLine($"This {name} does not exist in our products");
            return null;
        }
        public Product GetProductByName(string name)
        {
            foreach (var item in StockContext.Products)
            {
                if (item.Name.ToLower().Trim() == name.ToLower().Trim())
                {
                    return item;
                }
            }
            return null;
        }
        public List<Product> GetAll()
        {
            foreach (var item in StockContext.Products)
            {
                Console.WriteLine($"Name: {item.Name} and Quantity: {item.Quantity}");
            }
            return StockContext.Products;
        }
        public Product Get(int Id)
        {
            foreach (var item in StockContext.Products)
            {
                if (item.Id == Id)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
