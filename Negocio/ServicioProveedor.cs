using Datos;
using Datos.Interfaces;
using Entidades;
using Negocio.Interfaces;
using System.Diagnostics;

namespace Negocio
{
    public class ServicioProveedor : IServicioProveedor
    {
        private readonly IDatosProveedor _proveedor;
        public ServicioProveedor()
        {
            _proveedor = new DatosProveedor();
        }

        public List<Proveedor> Obtener()
        {
            try
            {
                return _proveedor.Obtener();
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                throw;
            }
        }

        public Proveedor ObtenerPorId(Guid idProveedor)
        {
            try
            {
                return _proveedor.ObtenerPorId(idProveedor);
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                throw;
            }
        }
        public void AgregarProveedor(Proveedor proveedor)
        {
            try
            {
                _proveedor.AgregarProveedor(proveedor);
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                throw;
            }
        }

        public void EditarProveedor(Proveedor proveedor)
        {
            try
            {
                _proveedor.EditarProveedor(proveedor);
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                throw;
            }
        }

        public void EliminarProveedor(Guid idProveedor)
        {
            try
            {
                _proveedor.EliminarProveedor(idProveedor);
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                throw;
            }
        }

    }
}
