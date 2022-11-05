import { Component, OnInit } from '@angular/core';
import { Actividad } from 'src/app/models/actividad.model';
import { ActividadesService } from 'src/app/services/actividades.service';

@Component({
  selector: 'app-actividad',
  templateUrl: './actividad.component.html',
  styleUrls: ['./actividad.component.scss'],
})
export class ActividadComponent implements OnInit {
  constructor(private actividadService: ActividadesService) {
    this.getActividades();
  }

  ngOnInit(): void {}

  getActividades() {
    this.actividadService.getActividades().subscribe();
  }
}
