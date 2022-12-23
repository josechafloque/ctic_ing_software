import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Usuario } from 'src/app/interfaces/usuario';
import { UsuarioService } from 'src/app/services/usuario.service';

@Component({
  selector: 'app-listado-usuario',
  templateUrl: './listado-usuario.component.html',
  styleUrls: ['./listado-usuario.component.css']
})
export class ListadoUsuarioComponent implements OnInit, AfterViewInit{
  displayedColumns: string[] = ['nombre', 'apellido', 'dni', 'correo', 'contrasena', 'acciones'];
  dataSource = new MatTableDataSource<Usuario>();
  loading: boolean = false;
  
  @ViewChild(MatPaginator) paginator!: MatPaginator
  @ViewChild(MatSort) sort!: MatSort;
  
  constructor(private _snackBar: MatSnackBar, 
            private _usuarioService:UsuarioService) { }

  ngOnInit(): void {
    this.obtenerUsuarios();
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

  obtenerUsuarios() {

    this.loading = true;
    this._usuarioService.getUsuarios().subscribe(data => {
      this.loading = false;
      this.dataSource.data = data;
    })
  }
 

  eliminarUsuario(id: number) {
    this.loading = true;

    this._usuarioService.deleteUsuario(id).subscribe(() => {
     this.mensajeExito();
     this.loading = false;
     this.obtenerUsuarios();
    });    
  }

  mensajeExito() {
    this._snackBar.open('El Usuario fue eliminado con exito','', {
      duration: 4000,
      horizontalPosition: 'right',
    });
  }
}

