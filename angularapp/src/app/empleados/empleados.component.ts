import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Empleado } from 'src/Interfaces/Empleados';

@Component({
  selector: 'app-empleado',
  templateUrl: './empleados.component.html',
  styleUrls: ['./empleados.component.css']
})
export class EmpleadosComponent {
  public empleados?: Empleado[];
  public title = "Empleados";

  constructor(private http: HttpClient,
    private toastr: ToastrService,
    private router: Router) {
    this.obtenerEmpleados();
  }

  private obtenerEmpleados() {
    this.http.get<Empleado[]>('api/empleados').subscribe(result => {
      this.empleados = result;
    }, error => console.error(error));
  }

  editar(idEmpleado: string) {
    if (!idEmpleado) return;

    this.router.navigate(['/empleado', idEmpleado]);
  }

  eliminar(idEmpleado: string) {
    this.http.delete(`api/clientes/${idEmpleado}`).subscribe(result => {
      this.toastr.success("Eliminado correctamente", "Exito");
      this.obtenerEmpleados();
    }, error => console.error(error));
  }
}

