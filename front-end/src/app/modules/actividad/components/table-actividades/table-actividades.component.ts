import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Actividad } from 'src/app/models/actividad.model';
import { ActividadesService } from 'src/app/services/actividades.service';

@Component({
  selector: 'app-table-actividades',
  templateUrl: './table-actividades.component.html',
  styleUrls: ['./table-actividades.component.scss'],
})
export class TableActividadesComponent implements OnInit {
  @Input() data!: MatTableDataSource<Actividad>;
  displayedColumns: string[] = ['createDate', 'usuario', 'actividad1'];
  @ViewChild(MatPaginator, { static: true }) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  pageSize = 10;
  pageSizeOptions: number[] = [5, 10, 25, 100];
  pageEvent!: PageEvent;
  constructor(private actividadService: ActividadesService) {}

  ngOnInit(): void {
    this.actividadService.actividadesListSubject
      .asObservable()
      .subscribe((list) => {
        this.data = new MatTableDataSource(list);
        this.data.paginator = this.paginator;
        this.data.sort = this.sort;
      });
    this.paginator._intl.itemsPerPageLabel = 'Items por pagina:';
  }

  setPageSizeOptions(setPageSizeOptionsInput: string) {
    if (setPageSizeOptionsInput) {
      this.pageSizeOptions = setPageSizeOptionsInput
        .split(',')
        .map((str) => +str);
    }
  }
}
