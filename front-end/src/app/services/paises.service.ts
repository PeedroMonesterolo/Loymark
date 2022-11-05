import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Pais } from '../models/paises.model';

@Injectable({
  providedIn: 'root'
})
export class PaisesService {

  constructor(private http: HttpClient) { }

  getPaises(): Observable<Pais[]> {
    return this.http.get<Pais[]>('/assets/paises.json');
  }
}
