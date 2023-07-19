using Datos.Interfaces;
using Entidades;
using System.Data.SqlClient;

namespace Datos
{
    public class DatosTipoPersona : IDatosTipoPersona
    {
        public List<TipoPersona> Obtener()
        {
            var tipoPersonas = new List<TipoPersona>();

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

                        tipoPersonas.Add(new TipoPersona { IdTipoPersona = idTipoPersona, Nombre = nombre });

                    }
                    return tipoPersonas;
                }
            }
        }
    }
}
