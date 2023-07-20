using Entidades;
using Microsoft.AspNetCore.Mvc;
using Negocio;
using Negocio.Interfaces;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedoresController : ControllerBase
    {
        private readonly IServicioProveedor _proveedor;

        public ProveedoresController()
        {
            _proveedor = new ServicioProveedor();
        }

        [HttpGet]
        public List<Proveedor> Obtener()
        {
            return _proveedor.Obtener();
        }

        [HttpGet("{idProveedor}")]
        public Proveedor ObetenerPorId(Guid idProveedor)
        {
            return _proveedor.ObtenerPorId(idProveedor);
        }

        [HttpPost]
        public IActionResult AgregarProveedor([FromBody] Proveedor proveedor)
        {
            _proveedor.AgregarProveedor(proveedor);
            return Ok();
        }

        [HttpPut]
        public IActionResult EditarProveedor([FromBody] Proveedor proveedor)
        {
            _proveedor.EditarProveedor(proveedor);
            return Ok();
        }

        [HttpDelete("{idProveedor}")]
        public IActionResult EliminarProveedor([FromRoute] Guid idProveedor)
        {
            _proveedor.EliminarProveedor(idProveedor);
            return Ok();
        }
    }
}

