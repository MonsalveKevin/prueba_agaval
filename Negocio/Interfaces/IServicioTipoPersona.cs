using Entidades;

namespace Negocio.Interfaces
{
    public interface IServicioTipoPersona
    {
        List<TipoPersona> Obtener();
        TipoPersona ObtenerPorId(Guid idTipoPersona);
        void AgregarTipoPersona(TipoPersona tipoPersona);
        void EditarTipoPersona(TipoPersona tipoPersona);
        void EliminarTipoPersona(Guid idTipoPersona);
    }
}
