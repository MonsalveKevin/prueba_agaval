using Datos;
using Datos.Interfaces;
using Entidades;
using Negocio.Interfaces;
using System.Diagnostics;

namespace Negocio
{
    public class ServicioEmpleado : IServicioEmpleado
    {
        private readonly IDatosEmpleado _empleado;
        public ServicioEmpleado()
        {
            _empleado = new DatosEmpleado();
        }

        public List<Empleado> Obtener()
        {
            try
            {
                return _empleado.Obtener();
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                throw;
            }
        }

        public Empleado ObtenerPorId(Guid idEmpleado)
        {
            try
            {
                return _empleado.ObtenerPorId(idEmpleado);
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                throw;
            }
        }

        public void AgregarEmpleado(Empleado empleado)
        {
            try
            {
                _empleado.AgregarEmpleado(empleado);
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                throw;
            }
        }

        public void EditarEmpleado(Empleado empleado)
        {
            try
            {
                _empleado.EditarEmpleado(empleado);
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                throw;
            }
        }

        public void EliminarEmpleado(Guid idEmpleado)
        {
            try
            {
                _empleado.EliminarEmpleado(idEmpleado);
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                throw;
            }
        }

    }
}
