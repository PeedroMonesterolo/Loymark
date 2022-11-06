import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Usuario } from 'src/app/models/usuario.model';
import { UsuariosService } from 'src/app/services/usuarios.service';
import { ModalConfirmComponent } from '../modal-confirm/modal-confirm.component';
import { ModalUsuarioComponent } from '../modal-usuario/modal-usuario.component';

@Component({
  selector: 'app-table-usuario',
  templateUrl: './table-usuario.component.html',
  styleUrls: ['./table-usuario.component.scss'],
})
export class TableUsuarioComponent implements OnInit {
  @Input() data!: MatTableDataSource<Usuario>;
  displayedColumns: string[] = [
    'nombre',
    'apellido',
    'fechaNacimiento',
    'codPais',
    'email',
    'acciones',
  ];
  @ViewChild(MatPaginator, { static: true }) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  pageSize = 10;
  pageSizeOptions: number[] = [5, 10, 25, 100];
  // MatPaginator Output
  pageEvent!: PageEvent;
  constructor(
    private usuarioService: UsuariosService,
    public dialog: MatDialog,
    private snackBar: MatSnackBar
  ) {}

  ngOnInit(): void {
    this.usuarioService.usuariosListSubject.asObservable().subscribe((list) => {
      this.data = new MatTableDataSource(list);
      this.data.paginator = this.paginator;
      this.data.sort = this.sort;
    });
    this.paginator._intl.itemsPerPageLabel = 'Items por pagina:';
  }

  deleteUser(id: number) {
    const dialogRef = this.dialog.open(ModalConfirmComponent);

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.usuarioService.deleteUsuario(id).subscribe((data) => {
          this.usuarioService.getUsuarios().subscribe();
        });
      }
    });
  }

  editUser(usuario: Usuario) {
    const dialogRef = this.dialog.open(ModalUsuarioComponent, {
      width: '700px',
      height: '800px',
      data: {
        title: 'Editar Usuario',
        usuario,
      },
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.usuarioService
          .putUsuario(usuario.id!, result)
          .subscribe((data) => {
            this.usuarioService.getUsuarios().subscribe();
            this.snackBar.open('Usuario actualizado correctamente', 'OK');
          });
      }
    });
  }
}
