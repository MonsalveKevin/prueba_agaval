using Entidades;
using Microsoft.AspNetCore.Mvc;
using Negocio;
using Negocio.Interfaces;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly IServicioEmpleado _empleado;

        public EmpleadosController()
        {
            _empleado = new ServicioEmpleado();
        }

        [HttpGet]
        public List<Empleado> Obtener()
        {
            return _empleado.Obtener();
        }

        [HttpPost]
        public IActionResult AgregarEmpleado([FromBody] Empleado empleado)
        {
            _empleado.AgregarEmpleado(empleado);
            return Ok();
        }

        [HttpPut]
        public IActionResult EditarEmpleado([FromBody] Empleado empleado)
        {
            _empleado.EditarEmpleado(empleado);
            return Ok();
        }

        [HttpDelete("{idEmpleado}")]
        public IActionResult EliminarEmpleado([FromRoute] Guid idEmpleado)
        {
            _empleado.EliminarEmpleado(idEmpleado);
            return Ok();
        }
    }
}

