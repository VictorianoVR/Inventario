namespace API.Models
{
	public class Product
	{
		public int? Id { get; set; }
		public string IdType { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; } = 0;
		public decimal PriceTotal { get; set; }
		public decimal Amount { get; set; }
	}
}