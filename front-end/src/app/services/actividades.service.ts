import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Actividad } from '../models/actividad.model';

@Injectable({
  providedIn: 'root',
})
export class ActividadesService {
  public actividadesListSubject = new BehaviorSubject<Actividad[]>([]);
  constructor(private http: HttpClient) {}

  getActividades(): Observable<Actividad[]> {
    return this.http
      .get<Actividad[]>(`${environment.urlApi}/Actividad`)
      .pipe(
        map((data: Actividad[]) => {
          this.actividadesListSubject.next(data);
          return data;
        })
      );
  }

  getActividadById(id: number): Observable<Actividad> {
    return this.http.get<Actividad>(
      `${environment.urlApi}/Actividad/${id}`
    );
  }
}
