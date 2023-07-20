import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-empleado',
  templateUrl: './empleado.component.html',
  styleUrls: ['./empleado.component.css']
})
export class EmpleadoComponent implements OnInit {
  public title = 'Crear Empleado';
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
      identificacion: ['', [Validators.required]],
      nombre: ['', [Validators.required]],
      apellidos: ['', [Validators.required]],
      telefono: ['', [Validators.required]],
      direccion: ['', [Validators.required]],
    });

    this.f['id'].setValue(this.route.snapshot.paramMap.get('id') || '');
    if (this.f['id'].value) {
      this.esEdicion = true;
      this.title = 'Editar Empleado';
    }

    this.obtenerEmpleado();
  }

  get f() {
    return this.detalleForm.controls;
  }

  obtenerEmpleado() {
    if (!this.f['id'].value) {
      return;
    }

    this.http.get<any>(`/api/empleados/${this.f['id'].value}`).subscribe(
      (result) => {
        this.f['id'].disable();
        this.f['identificacion'].setValue(result.identificacion);
        this.f['nombre'].setValue(result.nombre);
        this.f['apellidos'].setValue(result.apellidos);
        this.f['telefono'].setValue(result.telefono);
        this.f['direccion'].setValue(result.direccion);
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

    let empleado = {
      idEmpleado: null,
      identificacion: this.f['identificacion'].value,
      nombre: this.f['nombre'].value,
      apellidos: this.f['apellidos'].value,
      telefono: this.f['telefono'].value,
      direccion: this.f['direccion'].value,
    };

    if (!this.esEdicion) {
      this.http.post<any>('/api/empleados', empleado).subscribe(
        () => {
          this.toastr.success('Almacenado correctamente', 'Éxito');
          setTimeout(() => {
            this.router.navigateByUrl('empleados');
          }, 2000);
        },
        (error) => {
          this.toastr.error(error, 'Error');
          this.subido = false;
          this.cargando = false;
        }
      );
    } else {
      empleado.idEmpleado = this.f['id'].value,
        this.http.put<any>('/api/empleados', empleado).subscribe(
          () => {
            this.toastr.success('Modificado correctamente', 'Éxito');
            setTimeout(() => {
              this.router.navigateByUrl('empleados');
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
