namespace inventario.Models
{
    public class Usuario
    {
        [ColumnSqlAttribute("Id")]
        public int Id { get; set; }
        [ColumnSqlAttribute("Nombre")]
        public string Nombre { get; set; }
        [ColumnSqlAttribute("CorreoElectronico")]
        public string CorreoElectronico { get; set; }
        [ColumnSqlAttribute("Password")]
        public string Password { get; set; }

    }
    public class ColumnSqlAttribute : Attribute
    {
        public string NameColumn { get; set; }

        public ColumnSqlAttribute(string nameColumn)
        {
            NameColumn = nameColumn;
        }
    }
}
