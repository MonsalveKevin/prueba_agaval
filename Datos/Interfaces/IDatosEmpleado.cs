﻿using Entidades;

namespace Datos.Interfaces
{
    public interface IDatosEmpleado
    {
        List<Empleado> Obtener();
        Empleado ObtenerPorId(Guid idEmpleado);
        void AgregarEmpleado(Empleado empleado);
        void EditarEmpleado(Empleado empleado);
        void EliminarEmpleado(Guid idEmpleado);
    }
}
