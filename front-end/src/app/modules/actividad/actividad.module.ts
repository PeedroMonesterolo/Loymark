import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ActividadRoutingModule } from './actividad-routing.module';
import { TableActividadesComponent } from './components/table-actividades/table-actividades.component';
import { ActividadComponent } from './components/actividad/actividad.component';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
@NgModule({
  declarations: [TableActividadesComponent, ActividadComponent],
  imports: [
    CommonModule,
    ActividadRoutingModule,
    MatTableModule,
    MatPaginatorModule,
  ],
  exports: [TableActividadesComponent, ActividadComponent],
})
export class ActividadModule {}
