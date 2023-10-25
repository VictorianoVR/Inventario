using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Context
{
	public partial class InventarioDbContext : DbContext
	{
		public InventarioDbContext()
		{
		}

		public InventarioDbContext(DbContextOptions<InventarioDbContext> options)
		: base(options)
		{
		}

		public virtual DbSet<User> Users { get; set; }
		public virtual DbSet<Product> Products { get; set; }
	}
}