using API.Dtos;
using API.Models;

namespace API.Services
{
	public interface IProductService
	{
		List<Product> GetProduct();
		List<Product> GetProduct(string IdType);
		Product CreateProduct(Product product);
		Product UpdateProduct(int id, Product product);
		Product DeleteProduct(string id);
	}
}
