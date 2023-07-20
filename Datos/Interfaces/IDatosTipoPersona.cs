using Entidades;

namespace Datos.Interfaces
{
    public interface IDatosTipoPersona
    {
        List<TipoPersona> Obtener();
        TipoPersona ObtenerPorId(Guid idTipoPersona);
        void AgregarTipoPersona(TipoPersona tipoPersona);
        void EditarTipoPersona(TipoPersona tipoPersona);
        void EliminarTipoPersona(Guid idTipoPersona);
    }
}
