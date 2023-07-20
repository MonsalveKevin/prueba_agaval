using Entidades;

namespace Negocio.Interfaces
{
    public interface IServicioTipoPersona
    {
        List<TipoPersona> Obtener();
        TipoPersona ObtenerPorId(Guid idTipoPersona);
    }
}
