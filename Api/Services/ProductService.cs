using API.Context;
using API.Dtos;
using API.Models;
using API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
	public class ProductService : IProductService
	{
		private readonly InventarioDbContext _dbContext;

		public ProductService(InventarioDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public List<Product> GetProduct()
		{
			return _dbContext.Products.ToList();
		}

		public List<Product> GetProduct(string idType)
		{
			return _dbContext.Products.Where(x => x.IdType == idType).ToList();
				//_dbContext.Products.FirstOrDefault(x => x.IdType == idType);
		}

		public Product CreateProduct(Product product)
		{
			_dbContext.Products.Add(product);
			_dbContext.SaveChanges();

			return product;
		}

		public Product UpdateProduct(int id, Product product)
		{
			_dbContext.Products.Update(product);
			_dbContext.SaveChangesAsync();

			return product;
		}

		public Product DeleteProduct(string id)
		{
			var product = _dbContext.Products.FirstOrDefault(x => x.IdType == id);

			if (product != null)
			{
				_dbContext.Products.Remove(product);
				_dbContext.SaveChanges();
			}
			return product;
		}
	}

}
