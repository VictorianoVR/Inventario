using inventario.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace inventario.Context
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

		public virtual DbSet<Usuario> Usuarios { get; set; }
	}
}
