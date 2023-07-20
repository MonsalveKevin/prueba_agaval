import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Cliente } from '../../Interfaces/Cliente';
import { Proveedor } from '../../Interfaces/Proveedor';

@Component({
  selector: 'app-proveedor',
  templateUrl: './proveedor.component.html',
  styleUrls: ['./proveedor.component.css']
})
export class ProveedorComponent implements OnInit {
  public title = 'Crear Proveedor';
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
      telefono: ['', [Validators.required]],
    });

    this.f['id'].setValue(this.route.snapshot.paramMap.get('id') || '');
    if (this.f['id'].value) {
      this.esEdicion = true;
      this.title = 'Editar Proveedor';
    }

    this.obtenerProveedor();
  }

  get f() {
    return this.detalleForm.controls;
  }

  obtenerProveedor() {
    if (!this.f['id'].value) {
      return;
    }

    this.http.get<any>(`/api/proveedores/${this.f['id'].value}`).subscribe(
      (result) => {
        this.f['id'].disable();
        this.f['nombre'].setValue(result.nombre);
        this.f['direccion'].setValue(result.direccion);
        this.f['telefono'].setValue(result.telefono);
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

    let proveedor = {
      idProveedor: null,
      nombre: this.f['nombre'].value,
      direccion: this.f['direccion'].value,
      telefono: this.f['telefono'].value,
    };

    if (!this.esEdicion) {
      this.http.post<any>('/api/proveedores', proveedor).subscribe(
        () => {
          this.toastr.success('Almacenado correctamente', 'Éxito');
          setTimeout(() => {
            this.router.navigateByUrl('proveedores');
          }, 2000);
        },
        (error) => {
          this.toastr.error(error, 'Error');
          this.subido = false;
          this.cargando = false;
        }
      );
    } else {
      proveedor.idProveedor = this.f['id'].value,
        this.http.put<any>('/api/proveedores', proveedor).subscribe(
          () => {
            this.toastr.success('Modificado correctamente', 'Éxito');
            setTimeout(() => {
              this.router.navigateByUrl('proveedores');
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
