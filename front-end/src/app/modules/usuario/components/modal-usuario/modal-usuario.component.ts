import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import moment from 'moment';
import { Pais } from 'src/app/models/paises.model';
import {
  DialogDataUsuario,
  UserDto,
  Usuario,
} from 'src/app/models/usuario.model';
import { PaisesService } from 'src/app/services/paises.service';

@Component({
  selector: 'app-modal-usuario',
  templateUrl: './modal-usuario.component.html',
  styleUrls: ['./modal-usuario.component.scss'],
})
export class ModalUsuarioComponent implements OnInit {
  user!: FormGroup;
  paises: Pais[] = [];
  constructor(
    @Inject(MAT_DIALOG_DATA) public data: DialogDataUsuario,
    private paisService: PaisesService,
    public dialogRef: MatDialogRef<ModalUsuarioComponent>,
    private snackBar: MatSnackBar
  ) {
    this.paisService.getPaises().subscribe((data) => {
      this.paises = data;
    });
  }

  ngOnInit(): void {
    this.user = new FormGroup({
      nombre: new FormControl(this.data.usuario.nombre, [
        Validators.required,
        Validators.maxLength(25),
      ]),
      apellido: new FormControl(this.data.usuario.apellido, [
        Validators.required,
        Validators.maxLength(35),
      ]),
      email: new FormControl(this.data.usuario.email, [
        Validators.required,
        Validators.email,
      ]),
      fechaNacimiento: new FormControl(
        this.data.usuario.fechaNacimiento,
        Validators.required
      ),
      telefono: new FormControl(this.data.usuario.telefono, [
        Validators.minLength(10),
        Validators.maxLength(10),
      ]),
      codPais: new FormControl(this.data.usuario.codPais, [
        Validators.required,
        Validators.maxLength(3),
      ]),
      recibirInfo: new FormControl(
        Boolean(this.data.usuario.recibirInfo).toString(),
        [Validators.required, Validators.maxLength(10)]
      ),
    });
  }

  save() {
    if (
      !this.user.valid &&
      !moment(
        moment(this.user.controls['fechaNacimiento'].value).toDate()
      ).isValid()
    ) {
      this.snackBar.open(
        'Error en la carga de datos. Verifique los datos cargados.',
        'OK'
      );
      return;
    }

    const value: Usuario = {
      apellido: this.user.controls['apellido'].value,
      codPais: this.user.controls['codPais'].value,
      email: this.user.controls['email'].value,
      fechaNacimiento: this.user.controls['fechaNacimiento'].value,
      nombre: this.user.controls['nombre'].value,
      recibirInfo: Boolean(this.user.controls['recibirInfo'].value) ? 1 : 0,
      telefono:
        this.user.controls['telefono'].value.length === 0
          ? null
          : Number(this.user.controls['telefono'].value),
      id: this.data.title.toUpperCase().includes('EDITAR')
        ? Number(this.data.usuario['id'])
        : undefined,
    };

    this.dialogRef.close(value);
  }

  soloLetras(event: any) {
    const regex = new RegExp('^[a-zA-Z ]+$');
    const key = String.fromCharCode(
      !event.charCode ? event.which : event.charCode
    );
    if (!regex.test(key)) {
      event.preventDefault();
      return false;
    }
    return true;
  }

  soloNumeros(event: any) {
    let key;
    if (event.type === 'paste') {
      key = event.clipboardData.getData('text/plain');
    } else {
      key = event.keyCode;
      key = String.fromCharCode(key);
    }
    const regex = /[0-9]|\./;
    if (!regex.test(key)) {
      event.returnValue = false;
      if (event.preventDefault) {
        event.preventDefault();
      }
    }
  }

  maximaCantidad(event: any) {
    if (event.code == 'Backspace' || event.code == 'Delete') {
      return true;
    }
    if (event.code == 'Minus') {
      return false;
    }
    if (this.user.controls['telefono'].value === null) {
      return true;
    }
    return this.user.controls['telefono'].value.toString().length < 10;
  }
}
