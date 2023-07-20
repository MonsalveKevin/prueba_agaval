using Datos.Interfaces;
using Entidades;
using System.Data.SqlClient;

namespace Datos
{
    public class DatosProveedor : IDatosProveedor
    {
        public List<Proveedor> Obtener()
        {
            var datosProveedor = new List<Proveedor>();

            using (SqlConnection connection = new SqlConnection(Conexion.ConnectionString))
            {
                string query = "SELECT IdProveedor, Nombre, Direccion, Telefono FROM Proveedor";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        var idProveedor = reader.GetGuid(0);
                        var nombre = reader.GetString(1);
                        var direccion = reader.GetString(2);
                        var telefono = reader.GetString(3);

                        datosProveedor.Add(new Proveedor { IdProveedor = idProveedor, Nombre = nombre, Direccion = direccion, Telefono = telefono });

                    }
                    return datosProveedor;
                }

            }
        }

        public Proveedor ObtenerPorId(Guid idProveedor)
        {
            using (SqlConnection connection = new SqlConnection(Conexion.ConnectionString))
            {
                string query = "SELECT IdProveedor, Nombre, Direccion, Telefono FROM Proveedor WHERE IdProveedor = @IdProveedor";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdProveedor", idProveedor);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var nombre = reader.GetString(1);
                        var direccion = reader.GetString(2);
                        var telefono = reader.GetString(3);

                        return new Proveedor { IdProveedor = idProveedor, Nombre = nombre, Direccion = direccion, Telefono = telefono};
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public void AgregarProveedor(Proveedor proveedor)
        {
            proveedor.IdProveedor = Guid.NewGuid();

            using (SqlConnection connection = new SqlConnection(Conexion.ConnectionString))
            {
                string query = "INSERT INTO Proveedor (IdProveedor, Nombre, Direccion, Telefono) VALUES (@IdProveedor, @Nombre, @Direccion, @Telefono)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdProveedor", proveedor.IdProveedor);
                command.Parameters.AddWithValue("@Nombre", proveedor.Nombre);
                command.Parameters.AddWithValue("@Direccion", proveedor.Direccion);
                command.Parameters.AddWithValue("@Telefono", proveedor.Telefono);
                connection.Open();

                //Verificar si una fila tuvo cambios
                int rowsAffected = command.ExecuteNonQuery();
            }
        }

        public void EditarProveedor(Proveedor proveedor)
        {
            using (SqlConnection connection = new SqlConnection(Conexion.ConnectionString))
            {
                string query = "UPDATE Proveedor SET Nombre = @Nombre, Telefono = @Telefono, Direccion = @Direccion WHERE IdProveedor = @IdProveedor";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdProveedor", proveedor.IdProveedor);
                command.Parameters.AddWithValue("@Nombre", proveedor.Nombre);
                command.Parameters.AddWithValue("@Direccion", proveedor.Direccion);
                command.Parameters.AddWithValue("@Telefono", proveedor.Telefono);
                connection.Open();

                //Verificar si una fila tuvo cambios
                int rowsAffected = command.ExecuteNonQuery();
            }
        }

        public void EliminarProveedor(Guid idProveedor)
        {
            using (SqlConnection connection = new SqlConnection(Conexion.ConnectionString))
            {
                string query = "DELETE FROM Proveedor WHERE IdProveedor = @IdProveedor";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdProveedor", idProveedor);
                connection.Open();

                //Verificar si una fila tuvo cambios
                int rowsAffected = command.ExecuteNonQuery();
            }
        }
    }
}
