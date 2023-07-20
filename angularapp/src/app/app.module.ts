import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { ClientesComponent } from './clientes/clientes.component';
import { ClienteComponent } from './cliente/cliente.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ToastrModule } from 'ngx-toastr';
import { NgSelectModule } from '@ng-select/ng-select';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { EmpleadosComponent } from './empleados/empleados.component';
import { EmpleadoComponent } from './empleado/empleado.component';
import { ProveedoresComponent } from './proveedores/proveedores.component';
import { ProveedorComponent } from './proveedor/proveedor.component';


@NgModule({
  declarations: [
    AppComponent,
    ClientesComponent,
    ClienteComponent,
    EmpleadosComponent,
    EmpleadoComponent,
    ProveedoresComponent,
    ProveedorComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    NgSelectModule

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
