import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { TipoPersona } from '../../Interfaces/TipoPersona';

@Component({
  selector: 'app-tipoPersona',
  templateUrl: './tiposPersonas.component.html',
  styleUrls: ['./tiposPersonas.component.css']
})
export class TiposPersonaComponent {
  public tiposPersona?: TipoPersona[];
  public title = "Tipo Personas";

  constructor(private http: HttpClient,
    private toastr: ToastrService,
    private router: Router) {
    this.obtenerTiposPersona();
  }

  private obtenerTiposPersona() {
    this.http.get<any>('api/tiposPersona').subscribe(result => {
      this.tiposPersona = result;
    }, error => console.error(error));
  }

  editar(idTipoPersona: string) {
    if (!idTipoPersona) return;

    this.router.navigate(['/tipoPersona', idTipoPersona]);
  }

  eliminar(idTipoPersona: string) {
    this.http.delete(`api/tiposPersona/${idTipoPersona}`).subscribe(result => {
      this.toastr.success("Eliminado correctamente", "Exito");
      this.obtenerTiposPersona();
    }, error => console.error(error));
  }
}

