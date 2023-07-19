import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Cliente } from 'src/Interfaces/Cliente';

@Component({
  selector: 'app-clientes',
  templateUrl: './clientes.component.html',
  styleUrls: ['./clientes.component.css']
})
export class ClientesComponent {
  public clientes?: Cliente[];
  public title = "Clientes";

  constructor(private http: HttpClient,
    private toastr: ToastrService,
    private router: Router) {
    this.obtenerClientes();
  }

    private obtenerClientes() {
        this.http.get<Cliente[]>('api/clientes').subscribe(result => {
            this.clientes = result;
        }, error => console.error(error));
    }

  editar(idCliente: string) {
    if (!idCliente) return;

    this.router.navigate(['/cliente', idCliente]);
  }

  eliminar(idCliente: string) {
    this.http.delete(`api/clientes/${idCliente}`).subscribe(result => {
      this.toastr.success("Eliminado correctamente", "Exito");
      this.obtenerClientes();
    }, error => console.error(error));
  }
}

