import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { Proyecto } from 'src/app/interfaces/proyecto';
import { ProyectoService } from 'src/app/services/proyecto.service';

@Component({
  selector: 'app-proyecto-editar',
  templateUrl: './proyecto-editar.component.html',
  styleUrls: ['./proyecto-editar.component.css']
})
export class ProyectoEditarComponent implements OnInit {
  loading: boolean = false;
  form: FormGroup;
  id: number;

  operacion: string = 'Agregar';

  constructor(private fb: FormBuilder,
    private _proyectoService: ProyectoService,
    private _snackBar: MatSnackBar,
    private router: Router,
    private aRoute: ActivatedRoute) {
    this.form = this.fb.group({
      fecha_registro: ['', Validators.required],
      id_usuario_responsable: ['', Validators.required],
      nombre_proyecto: ['', Validators.required],
    })
    this.id = Number(this.aRoute.snapshot.paramMap.get('id'));
  }

  ngOnInit(): void {

    if(this.id != 0) {
      this.operacion = 'Editar';
      this.obtenerProyecto(this.id)
    }
  }

  obtenerProyecto(id: number) {
    this.loading = true;
    this._proyectoService.getProyecto(id).subscribe(data => {
      this.form.setValue({
        fecha_registro: data.fecha_registro,
        id_usuario_responsable: data.id_usuario_responsable,
        nombre_proyecto: data.nombre_proyecto,
      })
      this.loading = false;
    })
  }

  agregarEditarProyecto() {
    /* const nombre = this.form.get('nombre')?.value; */

    // Armamos el objeto
    const proyecto: Proyecto = {
      fecha_registro: this.form.value.fecha_registro,
      id_usuario_responsable: this.form.value.id_usuario_responsable,
      nombre_proyecto: this.form.value.nombre_proyecto,
    }

    if(this.id != 0) {
      proyecto.id = this.id;
      this.editarProyecto(this.id, proyecto);
    } else {
      this.agregarProyecto(proyecto);
    }
  }

  editarProyecto(id: number, proyecto: Proyecto) {
    this.loading = true;
    this._proyectoService.updateProyecto(proyecto).subscribe(() => {
      this.loading = false;
      console.log('llegue')
      this.mensajeExito('actualizado');
      this.router.navigate(['/listProyectos']);
    })
  }

  agregarProyecto(proyecto: Proyecto) {
      this._proyectoService.addProyecto(proyecto).subscribe(data => {
        this.mensajeExito('registrado');
        this.router.navigate(['/listProyectos']);
      })
  }

  mensajeExito(texto: string) {
    this._snackBar.open(`El proyecto fue ${texto} con exito`,'', {
      duration: 4000,
      horizontalPosition: 'right',
    });
  }

}
