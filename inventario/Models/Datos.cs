using Microsoft.Data.SqlClient;
using System.Reflection;

namespace ProyectoDCU.Models
{
    public static class Datos
    {
        //login
        public static Usuario UsuarioLogin(string correoElectronico, string password)
        {
            string query = $"select  CorreoElectronico, Password from dbo.Usuarios where CorreoElectronico = '{correoElectronico}' and " +
                $"Password = '{password}' ";

            Usuario model = null;
            using SqlConnection con = new SqlConnection("Data source=DESKTOP-8C8J082;initial catalog=inventaris;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(query, con);
            //cmd.Parameters.AddWithValue("@CorreoElectronico", model.CorreoElectronico);
            //cmd.Parameters.AddWithValue("@Password", string.IsNullOrWhiteSpace(model.Password) ? null : model.Password);

            con.Open();
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                model = reader.GetModel<Usuario>();
            }
            con.Close();

            return model;
        }
        //public static void CrearRegistro(Usuario model)
        //{
        //    string query = $"insert into dbo.Usuarios(Nombre, Correo, Clave) values(@Nombre, @Correo, @Clave)";

        //    using (SqlConnection con = new SqlConnection("Data source=DESKTOP-8C8J082;initial catalog=DCU;Integrated Security=True"))
        //    {
        //        SqlCommand cmd = new SqlCommand(query, con);
        //        cmd.Parameters.AddWithValue("@Nombre", model.Nombre);

        //        cmd.Parameters.AddWithValue("@Correo", model.Correo);

        //        cmd.Parameters.AddWithValue("@Celular", string.IsNullOrWhiteSpace(model.Celular) ? null : model.Celular);

        //        con.Open();
        //        cmd.ExecuteNonQuery();
        //        con.Close();
        //    }
        //}

        public static List<Usuario> GetList()
        {
            var result = new List<Usuario>();
            string query = $"select * from dbo.Usuarios";

            Usuario model = null;
            try
            {
                using (SqlConnection con = new SqlConnection("Data source=DESKTOP-8C8J082;initial catalog=DCU;Integrated Security=True"))
                {
                    SqlCommand cmd = new SqlCommand(query, con);

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            model = reader.GetModel<Usuario>();
                            result.Add(model);
                        }
                        con.Close();
                    }
                }
            }
            catch (Exception e)
            {
            }
            return result;
        }

        public static void Eliminar(int id)
        {
            string query = $"delete dbo.DCU where Id = '{id}'";

            using (SqlConnection con = new SqlConnection("Data source=PC\\VVV;initial catalog=DCU;User iD=sa;Password=123456"))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        //terminar
        //public static void Editar(Usuario model, int id)
        //{

        //    try
        //    {
        //        if (id != null)
        //        {
        //            string query = $"update dbo.DCU set Nombre = '{model.Nombre}', Direccion = '{model.Correo}', Celular='{model.Celular}' where Id = '{id}'";


        //            using (SqlConnection con = new SqlConnection("Data source=PC\\VVV;initial catalog=DCU;User iD=sa;Password=123456"))
        //            {
        //                SqlCommand cmd = new SqlCommand(query, con);
        //                con.Open();
        //                cmd.ExecuteNonQuery();
        //                con.Close();
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {

        //    }
        //}

        public static T GetModel<T>(this SqlDataReader reader) where T : class
        {
            T model = Activator.CreateInstance<T>();

            foreach (var item in typeof(T).GetProperties().Where(p => p.CanWrite && p.GetCustomAttributes(typeof(ColumnSqlAttribute), false).Any()))
            {
                var column = item.GetCustomAttributes(typeof(ColumnSqlAttribute), false).FirstOrDefault() as ColumnSqlAttribute;

                if (item.PropertyType == typeof(string))
                    item.SetValue(model, Convert.ToString(reader[column.NameColumn]));
                else if (item.PropertyType == typeof(DateTime))
                    item.SetValue(model, Convert.ToDateTime(reader[column.NameColumn] is DBNull ? DateTime.Now : reader[column.NameColumn]));
                else if (item.PropertyType == typeof(double))
                    item.SetValue(model, Convert.ToDouble(reader[column.NameColumn] is DBNull ? 0 : reader[column.NameColumn]));
                else if (item.PropertyType == typeof(int))
                    item.SetValue(model, Convert.ToInt32(reader[column.NameColumn] is DBNull ? 0 : reader[column.NameColumn]));

                EvaluateDateTime<T>(item, reader, column, model);
            }

            return model;
        }

        private static void EvaluateDateTime<T>(PropertyInfo item, SqlDataReader reader, ColumnSqlAttribute column, T model)
        {
            if (item.PropertyType == typeof(DateTime?))
            {
                if (reader[column.NameColumn] is DBNull)
                {
                    //
                }
                else
                    item.SetValue(model, Convert.ToDateTime(reader[column.NameColumn]));
            }
        }
    }

   
}
