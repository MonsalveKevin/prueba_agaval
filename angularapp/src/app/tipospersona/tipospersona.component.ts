import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { TipoPersona } from '../../Interfaces/TipoPersona';

@Component({
  selector: 'app-tipopersona',
  templateUrl: './tipospersona.component.html',
  styleUrls: ['./tipospersona.component.css']
})
export class TiposPersonaComponent {
  public tipospersona?: TipoPersona[];
  public title = "Tipo Persona";

  constructor(private http: HttpClient,
    private toastr: ToastrService,
    private router: Router) {
    this.obtenerTiposPersona();
  }

  private obtenerTiposPersona() {
    this.http.get<any>('api/tipospersona').subscribe(result => {
      this.tipospersona = result;
    }, error => console.error(error));
  }

  editar(idTipoPersona: string) {
    if (!idTipoPersona) return;

    this.router.navigate(['/tipopersona', idTipoPersona]);
  }

  eliminar(idTipoPersona: string) {
    this.http.delete(`api/tipospersona/${idTipoPersona}`).subscribe(result => {
      this.toastr.success("Eliminado correctamente", "Exito");
      this.obtenerTiposPersona();
    }, error => console.error(error));
  }
}

