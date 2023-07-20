using Entidades;

namespace Negocio.Interfaces
{
    public interface IServicioEmpleado
    {
        List<Empleado> Obtener();
        Empleado ObtenerPorId(Guid idCliente);

        void AgregarEmpleado(Empleado empleado);
        void EditarEmpleado(Empleado empleado);
        void EliminarEmpleado(Guid idEmpleado);
    }
}
