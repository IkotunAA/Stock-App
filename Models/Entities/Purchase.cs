namespace STOCKPROFITANDLOSSAPP.Models.Entities
{
    public class Purchase : BaseEntity
    {
        public string ReferenceNumber { get; set; }
        public string CustomerName { get; set; }
        public Dictionary<string, int> PurchasedGoods { get; set; }
        public double TotalPrice { get; set; }
        public Purchase(int id, string referenceNumber, string customerName, Dictionary<string, int> purchasedGoods, double totalPrice, DateTime dateCreated) : base(id, dateCreated)
        {
            ReferenceNumber = referenceNumber;
            CustomerName = customerName;
            PurchasedGoods = purchasedGoods;
            TotalPrice = totalPrice;
        }
    }
}