using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOCKPROFITANDLOSSAPP.Models.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public double CostPrice { get; set; }
        public double SellingPrice { get; set; }
        public int Quantity { get; set; }
        public Product(int id, string name, double costPrice, double sellingPrice, int quantity, DateTime dateCreated) : base(id, dateCreated)
        {
            Name = name;
            CostPrice = costPrice;
            SellingPrice = sellingPrice;
            Quantity = quantity;
        }
    }
}
