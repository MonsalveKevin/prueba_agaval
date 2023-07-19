using Datos;
using Datos.Interfaces;
using Entidades;
using Negocio.Interfaces;
using System.Diagnostics;

namespace Negocio
{
    public class ServicioCliente : IServicioCliente
    {
        private readonly IDatosCliente _cliente;
        public ServicioCliente() 
        {
            _cliente = new DatosCliente();
        }

        public List<Cliente> Obtener()
        {
            try
            {
                return _cliente.Obtener();
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                throw;
            }
        }

        public Cliente ObtenerPorId(Guid idCliente)
        {
            try
            {
               return _cliente.ObtenerPorId(idCliente);
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                throw;
            }
        }
        public void AgregarCliente(Cliente cliente)
        {
            try
            {
                _cliente.AgregarCliente(cliente);
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                throw;
            }
        }
        
        public void EditarCliente(Cliente cliente)
        {
            try
            {
                _cliente.EditarCliente(cliente);
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                throw;
            }
        }
        
        public void EliminarCliente(Guid idCliente)
        {
            try
            {
                _cliente.EliminarCliente(idCliente);
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                throw;
            }
        }

    }
}
