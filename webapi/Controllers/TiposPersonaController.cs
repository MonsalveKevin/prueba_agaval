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
        private readonly IServicioTipoPersona _tipoPersona;

        public TiposPersonaController()
        {
            _tipoPersona = new ServicioTipoPersona();
        }

        [HttpGet]
        public List<TipoPersona> Obtener()
        {
            return _tipoPersona.Obtener();
        }

        [HttpGet("{idTipoPersona}")]
        public TipoPersona ObetenerPorId(Guid idTipoPersona)
        {
            return _tipoPersona.ObtenerPorId(idTipoPersona);
        }
    }
}
