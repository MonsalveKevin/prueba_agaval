using Datos.Interfaces;
using Entidades;
using System.Data.SqlClient;

namespace Datos
{
    public class DatosTipoPersona : IDatosTipoPersona
    {
        public List<TipoPersona> Obtener()
        {
            var datosTipoPersona = new List<TipoPersona>();

            using (SqlConnection connection = new SqlConnection(Conexion.ConnectionString))
            {
                string query = "SELECT IdTipoPersona, Nombre FROM TipoPersona";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var idTipoPersona = reader.GetGuid(0);
                        var nombre = reader.GetString(1);

                        datosTipoPersona.Add(new TipoPersona { IdTipoPersona = idTipoPersona, Nombre = nombre});

                    }
                    return datosTipoPersona;
                }

            }
        }

        public TipoPersona ObtenerPorId(Guid idTipoPersona)
        {
            using (SqlConnection connection = new SqlConnection(Conexion.ConnectionString))
            {
                string query = "SELECT IdTipoPersona, Nombre FROM TipoPersona WHERE IdTipoPersona = @IdTipoPersona";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdTipoPersona", idTipoPersona);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var nombre = reader.GetString(1);

                        return new TipoPersona { IdTipoPersona = idTipoPersona, Nombre = nombre };
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public void AgregarTipoPersona(TipoPersona tipoPersona)
        {
            tipoPersona.IdTipoPersona = Guid.NewGuid();

            using (SqlConnection connection = new SqlConnection(Conexion.ConnectionString))
            {
                string query = "INSERT INTO TipoPersona (IdTipoPersona, Nombre) VALUES (@IdTipoPersona, @Nombre)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdTipoPersona", tipoPersona.IdTipoPersona);
                command.Parameters.AddWithValue("@Nombre", tipoPersona.Nombre);
                connection.Open();

                //Verificar si una fila tuvo cambios
                int rowsAffected = command.ExecuteNonQuery();
            }
        }

        public void EditarTipoPersona(TipoPersona tipoPersona)
        {
            using (SqlConnection connection = new SqlConnection(Conexion.ConnectionString))
            {
                string query = "UPDATE TipoCliente SET Nombre = @Nombre WHERE IdTipoPersona = @IdTipoPersona";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdTipoPersona", tipoPersona.IdTipoPersona);
                command.Parameters.AddWithValue("@Nombre", tipoPersona.Nombre);
                connection.Open();

                //Verificar si una fila tuvo cambios
                int rowsAffected = command.ExecuteNonQuery();
            }
        }

        public void EliminarTipoPersona(Guid idTipoPersona)
        {
            using (SqlConnection connection = new SqlConnection(Conexion.ConnectionString))
            {
                string query = "DELETE FROM TipoPersona WHERE IdTipoPersona = @IdTipoPersona";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdTipoPersona", idTipoPersona);
                connection.Open();

                //Verificar si una fila tuvo cambios
                int rowsAffected = command.ExecuteNonQuery();
            }
        }
    }
}
