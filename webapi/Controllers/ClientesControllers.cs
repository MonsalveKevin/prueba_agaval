using Entidades;
using Microsoft.AspNetCore.Mvc;
using Negocio;
using Negocio.Interfaces;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IServicioCliente _cliente;

        public ClientesController()
        {
            _cliente = new ServicioCliente();
        }

        [HttpGet]
        public List<Cliente> Obtener()
        {
            return _cliente.Obtener();
        }

        [HttpGet("{idCliente}")]
        public Cliente ObetenerPorId(Guid idCliente)
        {
           return _cliente.ObtenerPorId(idCliente);
        }


        [HttpPost]
        public IActionResult AgregarCliente([FromBody] Cliente cliente)
        {
            _cliente.AgregarCliente(cliente);
            return Ok();
        }

        [HttpPut]
        public IActionResult EditarCliente([FromBody] Cliente cliente)
        {
            _cliente.EditarCliente(cliente);
            return Ok();
        }

        [HttpDelete("{idCliente}")]
        public IActionResult EliminarCliente([FromRoute] Guid idCliente)
        {
            _cliente.EliminarCliente(idCliente);
            return Ok();
        }
    }
}

