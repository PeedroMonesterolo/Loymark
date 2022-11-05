import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import moment from 'moment';
import { Usuario } from 'src/app/models/usuario.model';
import { UsuariosService } from 'src/app/services/usuarios.service';
import { ModalUsuarioComponent } from '../modal-usuario/modal-usuario.component';

@Component({
  selector: 'app-usuario',
  templateUrl: './usuario.component.html',
  styleUrls: ['./usuario.component.scss'],
})
export class UsuarioComponent implements OnInit {
  usuariosList: Usuario[] = [];
  constructor(
    private usuarioService: UsuariosService,
    public dialog: MatDialog
  ) {
    this.getUsuarios();
  }

  ngOnInit(): void {}

  getUsuarios() {
    this.usuarioService
      .getUsuarios()
      .subscribe((data) => (this.usuariosList = data));
  }

  newUser() {
    const dialogRef = this.dialog.open(ModalUsuarioComponent, {
      width: '700px',
      height: '650px',
      data: {
        title: 'Nuevo Usuario',
        usuario: {
          nombre: '',
          apellido: '',
          email: '',
          fechaNacimiento: moment().toDate().toISOString(),
          telefono: null,
          codPais: '',
          recibirInfo: true,
        },
      },
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.usuarioService.postUsuario(result).subscribe(data => {
          this.usuarioService.getUsuarios().subscribe();
        })
      }
    });
  }
}
