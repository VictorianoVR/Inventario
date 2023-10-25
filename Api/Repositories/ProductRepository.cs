using API.Models;
using API.Context;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
	public class ProductRepository  : IProductRepository
	{
		private readonly InventarioDbContext _dbContext;

		public ProductRepository(InventarioDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public List<Product> GetProduct()
		{
			return  _dbContext.Products.ToList();
		}

		public Product GetProduct(string idType)
		{
			return  _dbContext.Products.FirstOrDefault(x => x.IdType == idType);
		}

		public Product CreateProduct(Product product)
		{
			_dbContext.Products.Add(product);
			 _dbContext.SaveChanges();

			return product;
		}

		public  Product UpdateProduct(Product product)
		{
			_dbContext.Products.Update(product);
			_dbContext.SaveChangesAsync();

			return product;
		}

		public Product DeleteProduct(int id)
		{
			var product =  _dbContext.Products.FirstOrDefault(x => x.Id == id) ;

			if (product != null)
			{
				_dbContext.Products.Remove(product);
				_dbContext.SaveChanges();
			}
			return product;
		}
	}
}
