import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { Usuario } from 'src/app/interfaces/usuario';
import { UsuarioService } from 'src/app/services/usuario.service';

@Component({
  selector: 'app-agregar-editar-usuario',
  templateUrl: './agregar-editar-usuario.component.html',
  styleUrls: ['./agregar-editar-usuario.component.css']
})
export class AgregarEditarUsuarioComponent implements OnInit {
  loading: boolean = false;
  form: FormGroup;
  id: number;

  operacion: string = 'Agregar';

  constructor(private fb: FormBuilder,
    private _usuarioService: UsuarioService,
    private _snackBar: MatSnackBar,
    private router: Router,
    private aRoute: ActivatedRoute) {
    this.form = this.fb.group({
      nombre: ['', Validators.required],
      apellido: ['', Validators.required],
      correo: ['', Validators.required],
      contrasena: ['', Validators.required],
      dni: ['', Validators.required],
      telefono: ['', Validators.required],
      id_rol: ['', Validators.required],
    })
    this.id = Number(this.aRoute.snapshot.paramMap.get('id'));
  }

  ngOnInit(): void {

    if(this.id != 0) {
      this.operacion = 'Editar';
      this.obtenerUsuario(this.id)
    }
  }

  obtenerUsuario(id: number) {
    this.loading = true;
    this._usuarioService.getUsuario(id).subscribe(data => {
      this.form.setValue({
        nombre: data.nombre,
        apellido: data.apellido,
        correo: data.correo,
        contrasena: data.contrasena,
        dni: data.dni,
        telefono: data.telefono,
        id_rol:data.id_rol,
      })
      this.loading = false;
    })
  }

  agregarEditarUsuario() {
    /* const nombre = this.form.get('nombre')?.value; */

    // Armamos el objeto
    const usuario: Usuario = {
      nombre: this.form.value.nombre,
      apellido: this.form.value.apellido,
      correo: this.form.value.correo,
      contrasena: this.form.value.contrasena,
      dni: this.form.value.dni,
      telefono: this.form.value.telefono,
      id_rol: this.form.value.id_rol,
    }

    if(this.id != 0) {
      usuario.id = this.id;
      this.editarUsuario(this.id, usuario);
    } else {
      this.agregarUsuario(usuario);
    }
  }

  editarUsuario(id: number, usuario: Usuario) {
    this.loading = true;
    this._usuarioService.updateUsuario(usuario).subscribe(() => {
      this.loading = false;
      console.log('llegue')
      this.mensajeExito('actualizado');
      this.router.navigate(['/listUsuarios']);
    })
  }

  agregarUsuario(usuario: Usuario) {
      this._usuarioService.addUsuario(usuario).subscribe(data => {
        this.mensajeExito('registrado');
        this.router.navigate(['/listUsuarios']);
      })
  }

  mensajeExito(texto: string) {
    this._snackBar.open(`El Usuario fue ${texto} con exito`,'', {
      duration: 4000,
      horizontalPosition: 'right',
    });
  }

}
