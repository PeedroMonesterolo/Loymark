import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'actividad',
    loadChildren: () =>
      import('./modules/actividad/actividad-routing.module').then(
        (m) => m.ActividadRoutingModule
      ),
  },
  {
    path: 'usuario',
    loadChildren: () =>
      import('./modules/usuario/usuario.module').then((m) => m.UsuarioModule),
  },

  { path: '**', redirectTo: '/actividad' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
