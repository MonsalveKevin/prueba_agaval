using Entidades;

namespace Datos.Interfaces
{
    public interface IDatosTipoPersona
    {
        List<TipoPersona> Obtener();
        TipoPersona ObtenerPorId(Guid idTipoPersona);
    }
}
