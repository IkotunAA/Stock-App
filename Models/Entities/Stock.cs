namespace STOCKPROFITANDLOSSAPP.Models.Entities
{
	public class Stock : BaseEntity
	{
		public string ReferenceNumber { get; set; }
		public Dictionary<string, int> Goods { get; set; }
		public Stock(int id, string refNumber, Dictionary<string, int> goods, DateTime dateCreated) : base(id, dateCreated)
		{
			ReferenceNumber = refNumber;
			Goods = goods;
		}
	}
}