namespace API.Dtos
{
	public class ProductDto
	{
	
		public string? IdType { get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }
		public decimal? Price { get; set; }
		public decimal? PriceTotal { get; set; }
		public decimal? Amount { get; set; }
	}
}