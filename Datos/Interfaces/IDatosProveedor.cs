﻿using Entidades;

namespace Datos.Interfaces
{
    public interface IDatosProveedor
    {
        List<Proveedor> Obtener();
        Proveedor ObtenerPorId(Guid idProveedor);
        void AgregarProveedor(Proveedor proveedor);
        void EditarProveedor(Proveedor proveedor);
        void EliminarProveedor(Guid proveedor);
    }
}
