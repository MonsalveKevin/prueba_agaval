import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-tipoPersona',
  templateUrl: './tipoPersona.component.html',
  styleUrls: ['./tipoPersona.component.css']
})
export class TipoPersonaComponent implements OnInit {
  public title = 'Crear un tipo de persona';
  public cargando = false;
  public subido = false;
  public esEdicion = false;

  public detalleForm!: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private toastr: ToastrService,
    private route: ActivatedRoute,
    private router: Router,
    private http: HttpClient
  ) { }

  ngOnInit(): void {
    this.detalleForm = this.formBuilder.group({
      id: [''],
      nombre: ['', [Validators.required]],
    });

    this.f['id'].setValue(this.route.snapshot.paramMap.get('id') || '');
    if (this.f['id'].value) {
      this.esEdicion = true;
      this.title = 'Editar tipo de persona';
    }

    this.obtenerTipoPersona();
  }

  get f() {
    return this.detalleForm.controls;
  }

  obtenerTipoPersona() {
    if (!this.f['id'].value) {
      return;
    }

    this.http.get<any>(`/api/tiposPersona/${this.f['id'].value}`).subscribe(
      (result) => {
        this.f['id'].disable();
        this.f['nombre'].setValue(result.nombre);
      },
      (error) => {
        this.toastr.error(error, 'Error');
      }
    );
  }

  public onSubmit() {
    this.subido = true;

    if (this.detalleForm.invalid) {
      return;
    }

    this.cargando = true;

    let tipoPersona = {
      idTipoPersona: null,
      nombre: this.f['nombre'].value,
    };

    if (!this.esEdicion) {
      this.http.post<any>('/api/tiposPersona', tipoPersona).subscribe(
        () => {
          this.toastr.success('Almacenado correctamente', 'Éxito');
          setTimeout(() => {
            this.router.navigateByUrl('tiposPersona');
          }, 2000);
        },
        (error) => {
          this.toastr.error(error, 'Error');
          this.subido = false;
          this.cargando = false;
        }
      );
    } else {
      tipoPersona.idTipoPersona = this.f['id'].value,
        this.http.put<any>('/api/tiposPersona', tipoPersona).subscribe(
          () => {
            this.toastr.success('Modificado correctamente', 'Éxito');
            setTimeout(() => {
              this.router.navigateByUrl('tiposPersona');
            }, 2000);
          },
          (error) => {
            this.toastr.error(error, 'Error');
            this.subido = false;
            this.cargando = false;
          }
        );
    }
  }
}
