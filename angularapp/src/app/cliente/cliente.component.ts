import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-cliente',
  templateUrl: './cliente.component.html',
  styleUrls: ['./cliente.component.css']
})
export class ClienteComponent implements OnInit {
  public title = 'Crear Cliente';
  public cargando = false;
  public subido = false;
  public esEdicion = false;
  public tiposPersona!: any[];

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
      direccion: ['', [Validators.required]],
      idTipoPersona: ['', [Validators.required]],
    });

    this.f['id'].setValue(this.route.snapshot.paramMap.get('id') || '');
    if (this.f['id'].value) {
      this.esEdicion = true;
      this.title = 'Editar Cliente';
    }

    this.llenarTiposPersona();
    this.obtenerCliente();
  }

  get f() {
    return this.detalleForm.controls;
  }

  llenarTiposPersona() {
    this.http.get<any>('/api/tipospersona').subscribe(
      (result) => {
        this.tiposPersona = result;
      },
      (error) => {
        this.toastr.error(error, 'Error');
      }
    );
  }

  obtenerCliente() {
    if (!this.f['id'].value) {
      return;
    }

    this.http.get<any>(`/api/clientes/${this.f['id'].value}`).subscribe(
      (result) => {
        this.f['id'].disable();
        this.f['nombre'].setValue(result.nombre);
        this.f['direccion'].setValue(result.direccion);
        this.f['idTipoPersona'].setValue(result.idTipoPersona);
      },
      (error) => {
        this.toastr.error(error, 'Error');
      }
    );
  }

  public onSubmit() {
    this.subido = true;

    // stop here if form is invalid
    if (this.detalleForm.invalid) {
      return;
    }

    this.cargando = true;

    let cliente = {
      idCliente: null,
      nombre: this.f['nombre'].value,
      direccion: this.f['direccion'].value,
      idTipoPersona: this.f['idTipoPersona'].value,
    };

    if (!this.esEdicion) {
      this.http.post<any>('/api/clientes', cliente).subscribe(
        () => {
          this.toastr.success('Almacenado correctamente', 'Éxito');
          setTimeout(() => {
            this.router.navigateByUrl('clientes');
          }, 2000);
        },
        (error) => {
          this.toastr.error(error, 'Error');
          this.subido = false;
          this.cargando = false;
        }
      );
    } else {
      cliente.idCliente = this.f['id'].value,
        this.http.put<any>('/api/clientes', cliente).subscribe(
          () => {
            this.toastr.success('Modificado correctamente', 'Éxito');
            setTimeout(() => {
              this.router.navigateByUrl('clientes');
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
