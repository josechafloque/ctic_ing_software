import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable, Subscription } from 'rxjs';
import { Usuario } from 'src/app/interfaces/usuario';
import { UsuarioService } from 'src/app/services/usuario.service';

@Component({
  selector: 'app-ver-usuario',
  templateUrl: './ver-usuario.component.html',
  styleUrls: ['./ver-usuario.component.css']
})
export class VerUsuarioComponent implements OnInit, OnDestroy {
  id!: number;
  usuario!: Usuario;
  loading: boolean = false;

  routeSub!: Subscription;


  constructor(private _usuarioService: UsuarioService,
    private aRoute: ActivatedRoute) {
    this.id = Number(this.aRoute.snapshot.paramMap.get('id'));
  }

  ngOnInit(): void {
  
    this.obtenerUsuario();
  }

  ngOnDestroy(): void {
    /* this.routeSub.unsubscribe() */
  }

  obtenerUsuario() {
    this.loading = true;
    this._usuarioService.getUsuario(this.id).subscribe(data => {
      this.usuario = data;
      this.loading = false;
    })
  }

}
