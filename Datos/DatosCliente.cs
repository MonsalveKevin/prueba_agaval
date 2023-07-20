using Datos.Interfaces;
using Entidades;
using System.Data.SqlClient;

namespace Datos
{
    public class DatosCliente : IDatosCliente
    {
        public List<Cliente> Obtener()
        {
            var datosCliente = new List<Cliente>();

            using (SqlConnection connection = new SqlConnection(Conexion.ConnectionString))
            {
                string query = "SELECT c.IdCliente, c.Nombre AS NombreCliente, c.Direccion, c.Telefono, c.Identificacion, ti.Nombre AS TipoPersona, ti.IdTipoPersona FROM Cliente AS c INNER JOIN TipoPersona AS ti ON ti.IdTipoPersona = c.IdTipoPersona";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var idCliente = reader.GetGuid(0);
                        var nombre = reader.GetString(1);
                        var direccion = reader.GetString(2);
                        var telefono = reader.GetString(3);
                        var identificacion = reader.GetString(4);
                        var tipoPersona = reader.GetString(5);
                        var idTipoPersona = reader.GetGuid(6);


                        datosCliente.Add(new Cliente { IdCliente = idCliente, Nombre = nombre, Direccion = direccion, Telefono = telefono, Identificacion = identificacion, TipoPersona = tipoPersona, IdTipoPersona = idTipoPersona });

                    }
                    return datosCliente;
                }

            }
        }

        public Cliente ObtenerPorId(Guid idCliente)
        {
            using (SqlConnection connection = new SqlConnection(Conexion.ConnectionString))
            {
                string query = "SELECT c.IdCliente, c.Nombre AS NombreCliente, c.Direccion, c.Telefono, c.Identificacion, ti.Nombre AS TipoPersona, ti.IdTipoPersona FROM Cliente AS c INNER JOIN TipoPersona AS ti ON ti.IdTipoPersona = c.IdTipoPersona WHERE c.IdCliente = @IdCliente";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdCliente", idCliente);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var nombre = reader.GetString(1);
                        var direccion = reader.GetString(2);
                        var telefono = reader.GetString(3);
                        var identificacion = reader.GetString(4);
                        var tipoPersona = reader.GetString(5);
                        var idTipoPersona = reader.GetGuid(6);

                        return new Cliente { IdCliente = idCliente, Nombre = nombre, Direccion = direccion, Telefono = telefono, Identificacion = identificacion, TipoPersona = tipoPersona, IdTipoPersona = idTipoPersona };
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }


        public void AgregarCliente(Cliente cliente)
        {
            cliente.IdCliente = Guid.NewGuid();

            using (SqlConnection connection = new SqlConnection(Conexion.ConnectionString))
            {
                string query = "INSERT INTO Cliente (IdCliente, Nombre, Direccion, Telefono, Identificacion, IdTipoPersona) VALUES (@IdCliente, @Nombre, @Direccion, @Telefono, @Identificacion, @IdTipoPersona)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdCliente", cliente.IdCliente);
                command.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                command.Parameters.AddWithValue("@Direccion", cliente.Direccion);
                command.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                command.Parameters.AddWithValue("@Identificacion", cliente.Identificacion);
                command.Parameters.AddWithValue("@IdTipoPersona", cliente.IdTipoPersona);
                connection.Open();

                //Verificar si una fila tuvo cambios
                int rowsAffected = command.ExecuteNonQuery();
            }
        }

        public void EditarCliente(Cliente cliente)
        {
            using (SqlConnection connection = new SqlConnection(Conexion.ConnectionString))
            {
                string query = "UPDATE Cliente SET Nombre = @Nombre, Direccion = @Direccion, Telefono = @Telefono, Identificacion = @Identificacion, IdTipoPersona = @IdTipoPersona WHERE IdCliente = @IdCliente";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdCliente", cliente.IdCliente);
                command.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                command.Parameters.AddWithValue("@Direccion", cliente.Direccion);
                command.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                command.Parameters.AddWithValue("@Identificacion", cliente.Identificacion);
                command.Parameters.AddWithValue("@IdTipoPersona", cliente.IdTipoPersona);
                connection.Open();

                //Verificar si una fila tuvo cambios
                int rowsAffected = command.ExecuteNonQuery();
            }
        }

        public void EliminarCliente(Guid idCliente)
        {
            using (SqlConnection connection = new SqlConnection(Conexion.ConnectionString))
            {
                string query = "DELETE FROM Cliente WHERE IdCliente = @IdCliente";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdCliente", idCliente);
                connection.Open();

                //Verificar si una fila tuvo cambios
                int rowsAffected = command.ExecuteNonQuery();
            }
        }


    }
}
