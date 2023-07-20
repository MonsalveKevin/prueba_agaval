import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { ClientesComponent } from './clientes/clientes.component';
import { ClienteComponent } from './cliente/cliente.component';
import { EmpleadoComponent } from './empleado/empleado.component';
import { EmpleadosComponent } from './empleados/empleados.component';
import { ProveedoresComponent } from './proveedores/proveedores.component';
import { ProveedorComponent } from './proveedor/proveedor.component';
import { TiposPersonaComponent } from './tipospersona/tipospersona.component';
import { TipoPersonaComponent } from './tipopersona/tipopersona.component';


const routes: Routes = [
  { path: 'clientes', component: ClientesComponent },
  { path: 'cliente', component: ClienteComponent },
  { path: 'cliente/:id', component: ClienteComponent },
  { path: 'empleados', component: EmpleadosComponent },
  { path: 'empleado', component: EmpleadoComponent },
  { path: 'empleado/:id', component: EmpleadoComponent },
  { path: 'proveedores', component: ProveedoresComponent },
  { path: 'proveedor', component: ProveedorComponent },
  { path: 'proveedor/:id', component: ProveedorComponent },
  { path: 'tipospersona', component: TiposPersonaComponent },
  { path: 'tipopersona', component: TipoPersonaComponent },
  { path: 'tipopersona/:id', component: TipoPersonaComponent },
  { path: '*', component: AppComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
