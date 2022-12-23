import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable, Subscription } from 'rxjs';
import { ProyectoService } from 'src/app/services/proyecto.service';
import { DetalleProyecto } from 'src/app/interfaces/detalle-proyecto';

@Component({
  selector: 'app-ver-proyecto',
  templateUrl: './ver-proyecto.component.html',
  styleUrls: ['./ver-proyecto.component.css']
})
export class VerProyectoComponent implements OnInit, OnDestroy {
  id!: number;
  detalle_proyecto!: DetalleProyecto;
  loading: boolean = false;

  routeSub!: Subscription;


  constructor(private _proyectoService: ProyectoService,
    private aRoute: ActivatedRoute) {
    this.id = Number(this.aRoute.snapshot.paramMap.get('id'));
  }

  ngOnInit(): void {
  
    this.obtenerProyecto();
  }

  ngOnDestroy(): void {
    /* this.routeSub.unsubscribe() */
  }

  obtenerProyecto() {
    this.loading = true;
    this._proyectoService.getProyecto(this.id).subscribe(data => {
      this.detalle_proyecto = data;
      this.loading = false;
    })
  }

}
