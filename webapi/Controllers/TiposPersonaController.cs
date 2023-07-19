using Entidades;
using Microsoft.AspNetCore.Mvc;
using Negocio;
using Negocio.Interfaces;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposPersonaController : ControllerBase
    {
        private readonly IServicioTipoPersona _servicio;

        public TiposPersonaController()
        {
            _servicio = new ServicioTipoPersona();
        }

        [HttpGet]
        public List<TipoPersona> Obtener()
        {
            return _servicio.Obtener();
        }
    }
}
