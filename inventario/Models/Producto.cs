namespace inventario.Models
{
	public class Producto
	{
		[ColumnSqlAttribute("IdProducto")]
		public string IdProducto { get; set; }
		[ColumnSqlAttribute("Nombre")]
		public string Nombre { get; set; }
		[ColumnSqlAttribute("Unidades")]
		public int Unidades { get; set; }
		[ColumnSqlAttribute("Precio")]
		public int Precio { get; set; }

	}
	public class ColumnSqlAttributeProducto : Attribute
	{
		public string NameColumn { get; set; }

		public ColumnSqlAttributeProducto(string nameColumn)
		{
			NameColumn = nameColumn;
		}
	}
}

