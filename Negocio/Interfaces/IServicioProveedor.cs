using Entidades;

namespace Negocio.Interfaces
{
    public interface IServicioProveedor
    {
        List<Proveedor> Obtener();
        void AgregarProveedor(Proveedor proveedor);
        void EditarProveedor(Proveedor proveedor);
        void EliminarProveedor(Guid proveedor);
    }
}
