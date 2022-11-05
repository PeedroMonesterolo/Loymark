export interface Usuario {
  id?: number;
  nombre: string;
  apellido: string;
  email: string;
  fechaNacimiento: string;
  telefono?: any;
  codPais: string;
  recibirInfo: number;
}

export interface UserDto {
  nombre: string;
  apellido: string;
  email: string;
  fechaNacimiento: any;
  telefono?: number;
  codPais: string;
  recibirInfo: number;
}

export interface DialogDataUsuario {
  title: string;
  usuario: Usuario;
}
