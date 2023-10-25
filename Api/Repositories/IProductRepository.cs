using API.Dtos;
using API.Models;

namespace API.Repositories
{
	public interface IProductRepository
	{
		List<Product>? GetProduct();
		Product GetProduct(string idType);
		Product CreateProduct(Product product);
		Product UpdateProduct(Product product);
		Product DeleteProduct(int id);
		
	}
}
