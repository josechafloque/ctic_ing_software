import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

// Modulos
import { SharedModule } from './shared/shared.module';

// Componentes
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { VerUsuarioComponent } from './components/ver-usuario/ver-usuario.component';
import { ListadoUsuarioComponent } from './components/listado-usuario/listado-usuario.component';
import { AgregarEditarUsuarioComponent } from './components/agregar-editar-usuario/agregar-editar-usuario.component';
import { ListaProyectosComponent } from './components/lista-proyectos/lista-proyectos.component';
import { VerProyectoComponent } from './components/ver-proyecto/ver-proyecto.component';
import { ProyectoEditarComponent } from './components/proyecto-editar/proyecto-editar.component';
import {MatDatepickerModule} from '@angular/material/datepicker';
import { MenuAdministradorComponent } from './components/menu-administrador/menu-administrador.component';
import { MenuJefeComponent } from './components/menu-jefe/menu-jefe.component';
import { MenuDirectorComponent } from './components/menu-director/menu-director.component';

@NgModule({
  declarations: [
    AppComponent,
    VerUsuarioComponent,
    ListadoUsuarioComponent,
    AgregarEditarUsuarioComponent,
    ListaProyectosComponent,
    VerProyectoComponent,
    ProyectoEditarComponent,
    MenuAdministradorComponent,
    MenuJefeComponent,
    MenuDirectorComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    SharedModule,
    MatDatepickerModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
