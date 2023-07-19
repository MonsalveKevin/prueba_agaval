using Datos.Interfaces;
using Entidades;
using System.Data.SqlClient;

namespace Datos
{
    public class DatosEmpleado : IDatosEmpleado
    {
        public List<Empleado> Obtener()
        {
            var datosEmpleado = new List<Empleado>();

            using (SqlConnection connection = new SqlConnection(Conexion.ConnectionString))
            {
                string query = "SELECT IdEmpleado, Identificacion, Nombre, Apellidos, Telefono, Direccion FROM Empleado";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        var idEmpleado = reader.GetGuid(0);
                        var identificacion = reader.GetString(1);
                        var nombre = reader.GetString(2);
                        var apellidos = reader.GetString(3);
                        var telefono = reader.GetString(4);
                        var direccion = reader.GetString(5);

                        datosEmpleado.Add(new Empleado { IdEmpleado = idEmpleado, Identificacion = identificacion, Nombre = nombre, Apellidos = apellidos, Telefono = telefono, Direccion = direccion});

                    }
                    return datosEmpleado;
                }

            }
        }

        public void AgregarEmpleado(Empleado empleado)
        {
            empleado.IdEmpleado = Guid.NewGuid();

            using (SqlConnection connection = new SqlConnection(Conexion.ConnectionString))
            {
                string query = "INSERT INTO Empleado (IdEmpleado, Identificacion, Nombre, Apellidos, Telefono, Direccion) VALUES (@IdEmpleado, @Identificacion, @Nombre, @Apellidos, @Telefono, @Direccion)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdEmpleado", empleado.IdEmpleado);
                command.Parameters.AddWithValue("@Identificacion", empleado.Identificacion);
                command.Parameters.AddWithValue("@Nombre", empleado.Nombre);
                command.Parameters.AddWithValue("@Apellidos", empleado.Apellidos);
                command.Parameters.AddWithValue("@Direccion", empleado.Direccion);
                command.Parameters.AddWithValue("@Telefono", empleado.Telefono);
                connection.Open();

                //Verificar si una fila tuvo cambios
                int rowsAffected = command.ExecuteNonQuery();
            }
        }

        public void EditarEmpleado(Empleado empleado)
        {
            using (SqlConnection connection = new SqlConnection(Conexion.ConnectionString))
            {
                string query = "UPDATE Empleado SET Identificacion = @Identificacion, Nombre = @Nombre, Apellidos = @Apellidos, Telefono = @Telefono, Direccion = @Direccion WHERE IdEmpleado = @IdEmpleado";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdEmpleado", empleado.IdEmpleado);
                command.Parameters.AddWithValue("@Identificacion", empleado.Identificacion);
                command.Parameters.AddWithValue("@Nombre", empleado.Nombre);
                command.Parameters.AddWithValue("@Apellidos", empleado.Apellidos);
                command.Parameters.AddWithValue("@Direccion", empleado.Direccion);
                command.Parameters.AddWithValue("@Telefono", empleado.Telefono);
                connection.Open();

                //Verificar si una fila tuvo cambios
                int rowsAffected = command.ExecuteNonQuery();
            }
        }

        public void EliminarEmpleado(Guid idEmpleado)
        {
            using (SqlConnection connection = new SqlConnection(Conexion.ConnectionString))
            {
                string query = "DELETE FROM Empleado WHERE IdEmpleado = @IdEmpleado";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdEmpleado", idEmpleado);
                connection.Open();

                //Verificar si una fila tuvo cambios
                int rowsAffected = command.ExecuteNonQuery();
            }
        }
    }
}
