import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Proyecto } from '../interfaces/proyecto';
import { DetalleProyecto } from '../interfaces/detalle-proyecto';

@Injectable({
  providedIn: 'root'
})
export class ProyectoService {
  private myAppUrl: string = environment.endpoint;
  private myApiUrl: string = 'api/Controller/Proyectos/';

  constructor(private http: HttpClient) { }

  getProyectos(): Observable<DetalleProyecto[]> {
    return this.http.get<DetalleProyecto[]>(`${this.myAppUrl}${this.myApiUrl}`);
  }

  addProyecto(proyecto: Proyecto): Observable<Proyecto> {
    return this.http.post<Proyecto>(`${this.myAppUrl}${this.myApiUrl}`, proyecto);
  }

  updateProyecto(proyecto: Proyecto): Observable<void> {
    return this.http.put<void>(`${this.myAppUrl}${this.myApiUrl}`, proyecto);
  }

  getProyecto(id: number): Observable<DetalleProyecto> {
    return this.http.get<DetalleProyecto>(`${this.myAppUrl}${this.myApiUrl}${id}`);
  }

}
