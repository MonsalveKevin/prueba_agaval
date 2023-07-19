using Datos;
using Datos.Interfaces;
using Entidades;
using Negocio.Interfaces;
using System.Diagnostics;

namespace Negocio
{
    public class ServicioTipoPersona : IServicioTipoPersona
    {
        private readonly IDatosTipoPersona _datosTipoPersona;
        public ServicioTipoPersona()
        {
            _datosTipoPersona = new DatosTipoPersona();
        }
        public List<TipoPersona> Obtener()
        {
            try
            {
                return _datosTipoPersona.Obtener();
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                throw;
            }
        }
    }
}
