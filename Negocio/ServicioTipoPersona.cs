using Datos;
using Datos.Interfaces;
using Entidades;
using Negocio.Interfaces;
using System.Diagnostics;

namespace Negocio
{
    public class ServicioTipoPersona : IServicioTipoPersona
    {
        private readonly IDatosTipoPersona _tipoPersona;
        public ServicioTipoPersona()
        {
            _tipoPersona = new DatosTipoPersona();
        }

        public List<TipoPersona> Obtener()
        {
            try
            {
                return _tipoPersona.Obtener();
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                throw;
            }
        }

        public TipoPersona ObtenerPorId(Guid idTipoPersona)
        {
            try
            {
                return _tipoPersona.ObtenerPorId(idTipoPersona);
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                throw;
            }
        }
        public void AgregarTipoPersona(TipoPersona tipoPersona)
        {
            try
            {
                _tipoPersona.AgregarTipoPersona(tipoPersona);
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                throw;
            }
        }

        public void EditarTipoPersona(TipoPersona tipoPersona)
        {
            try
            {
                _tipoPersona.EditarTipoPersona(tipoPersona);
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                throw;
            }
        }

        public void EliminarTipoPersona(Guid idTipoPersona)
        {
            try
            {
                _tipoPersona.EliminarTipoPersona(idTipoPersona);
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                throw;
            }
        }

    }
}
