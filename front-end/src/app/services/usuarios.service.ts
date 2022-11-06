import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { UserDto, Usuario } from '../models/usuario.model';

@Injectable({
  providedIn: 'root',
})
export class UsuariosService {
  public usuariosListSubject = new BehaviorSubject<Usuario[]>([]);

  constructor(private http: HttpClient) {}

  getUsuarios(): Observable<Usuario[]> {
    return this.http.get<Usuario[]>(`${environment.urlApi}/Usuario`).pipe(
      map((data: Usuario[]) => {
        this.usuariosListSubject.next(data);
        return data;
      })
    );
  }

  getUserioById(id: number): Observable<Usuario> {
    return this.http.get<Usuario>(`${environment.urlApi}/Usuario/${id}`);
  }

  postUsuario(usuario: UserDto): Observable<Usuario> {
    return this.http.post<Usuario>(
      `${environment.urlApi}/Usuario`,
      usuario
    );
  }

  putUsuario(id: number, usuario: Usuario): Observable<Usuario> {
    return this.http.put<Usuario>(
      `${environment.urlApi}/Usuario/${id}`,
      usuario
    );
  }

  deleteUsuario(id: number): Observable<any> {
    return this.http.delete<any>(`${environment.urlApi}/Usuario/${id}`);
  }
}
