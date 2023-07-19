using Entidades;

namespace Datos.Interfaces
{
    public interface IDatosCliente
    {
        List<Cliente> Obtener();
        Cliente ObtenerPorId(Guid idCliente);
        void AgregarCliente(Cliente cliente);
        void EditarCliente(Cliente cliente);
        void EliminarCliente(Guid idCliente);
    }
}
