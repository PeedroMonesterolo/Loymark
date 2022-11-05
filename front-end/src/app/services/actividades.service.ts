import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map, Observable } from 'rxjs';
import { Actividad } from '../models/actividad.model';

@Injectable({
  providedIn: 'root',
})
export class ActividadesService {
  public actividadesListSubject = new BehaviorSubject<Actividad[]>([]);
  constructor(private http: HttpClient) {}

  getActividades(): Observable<Actividad[]> {
    return this.http
      .get<Actividad[]>(`/api/Actividad`)
      .pipe(map((data: Actividad[]) => { 
        this.actividadesListSubject.next(data)
        return data;
      }));
  }

  getActividadById(id: number): Observable<Actividad> {
    return this.http.get<Actividad>(`/api/Actividad/${id}`);
  }

  postActividad(actividad: any): Observable<Actividad> {
    return this.http.post<Actividad>(`/api/Actividad`, actividad);
  }

  putActividad(id: number, usuario: Actividad): Observable<Actividad> {
    return this.http.put<Actividad>(`/api/Actividad/${id}`, usuario);
  }

  deleteActividad(id: number): Observable<any> {
    return this.http.delete<any>(`/api/Actividad/${id}`);
  }
}
