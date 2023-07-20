import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Empleado } from 'src/Interfaces/Empleados';
import { Proveedor } from '../../Interfaces/Proveedor';

@Component({
  selector: 'app-proveedor',
  templateUrl: './proveedores.component.html',
  styleUrls: ['./proveedores.component.css']
})
export class ProveedoresComponent {
  public proveedores?: Proveedor[];
  public title = "Proveedores";

  constructor(private http: HttpClient,
    private toastr: ToastrService,
    private router: Router) {
    this.obtenerProveedores();
  }

  private obtenerProveedores() {
    this.http.get<any>('api/proveedores').subscribe(result => {
      this.proveedores = result;
    }, error => console.error(error));
  }

  editar(idProveedor: string) {
    if (!idProveedor) return;

    this.router.navigate(['/proveedor', idProveedor]);
  }

  eliminar(idProveedor: string) {
    this.http.delete(`api/proveedores/${idProveedor}`).subscribe(result => {
      this.toastr.success("Eliminado correctamente", "Exito");
      this.obtenerProveedores();
    }, error => console.error(error));
  }
}

