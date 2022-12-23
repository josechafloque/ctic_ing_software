import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { DetalleProyecto } from 'src/app/interfaces/detalle-proyecto';
import { ProyectoService } from 'src/app/services/proyecto.service';

@Component({
  selector: 'app-lista-proyectos',
  templateUrl: './lista-proyectos.component.html',
  styleUrls: ['./lista-proyectos.component.css']
})
export class ListaProyectosComponent implements OnInit, AfterViewInit {
  displayedColumns: string[] = ['fecha_registro', 'id_usuario_responsable', 'nombre', 'apellido', 'nombre_proyecto', 'acciones'];
  dataSource = new MatTableDataSource<DetalleProyecto>();
  loading: boolean = false;
  
  @ViewChild(MatPaginator) paginator!: MatPaginator
  @ViewChild(MatSort) sort!: MatSort;
  
  constructor(private _snackBar: MatSnackBar, 
            private _proyectoService:ProyectoService) { }

  ngOnInit(): void {
    this.obtenerProyectos();
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
    if(this.dataSource.data.length > 0) {
      this.paginator._intl.itemsPerPageLabel = 'Items por pagina'
    }
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  obtenerProyectos() {

    this.loading = true;
    this._proyectoService.getProyectos().subscribe(data => {
      this.loading = false;
      this.dataSource.data = data;
    })
  }

  mensajeExito() {
    this._snackBar.open('El Proyecto fue eliminado con exito','', {
      duration: 4000,
      horizontalPosition: 'right',
    });
  }
}
