import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import moment from 'moment';
import { ModalUsuarioComponent } from './modules/usuario/components/modal-usuario/modal-usuario.component';
import { ActividadesService } from './services/actividades.service';
import { UsuariosService } from './services/usuarios.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  title = 'front-end';

  constructor(
    public dialog: MatDialog,
    private usuarioService: UsuariosService,
    private actividadService: ActividadesService
  ) {}

  newUser() {
    const dialogRef = this.dialog.open(ModalUsuarioComponent, {
      width: '700px',
      height: '800px',
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
        this.usuarioService.postUsuario(result).subscribe((data) => {
          this.usuarioService.getUsuarios().subscribe();
          this.actividadService.getActividades().subscribe();
        });
      }
    });
  }
}
