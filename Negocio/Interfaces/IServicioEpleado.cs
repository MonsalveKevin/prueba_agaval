using Entidades;

namespace Negocio.Interfaces
{
    public interface IServicioEmpleado
    {
        List<Empleado> Obtener();
        void AgregarEmpleado(Empleado empleado);
        void EditarEmpleado(Empleado empleado);
        void EliminarEmpleado(Guid idEmpleado);
    }
}
