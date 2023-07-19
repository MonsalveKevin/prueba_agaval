using Entidades;

namespace Negocio.Interfaces
{
    public interface IServicioCliente
    {
        List<Cliente> Obtener();
        Cliente ObtenerPorId(Guid idCliente);
        void AgregarCliente(Cliente cliente);
        void EditarCliente(Cliente cliente);
        void EliminarCliente(Guid idCliente);
    }
}
