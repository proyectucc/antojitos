import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ComprasComponent } from './components/compras/compras.component';
import { CreateClientComponent } from './components/create-client/create-client.component';
import { OpenVentaComponent } from './components/open-venta/open-venta.component';
import { AddComponent } from './components/productos/add/add.component';
import { EditComponent } from './components/productos/edit/edit.component';
import { ListComponent } from './components/productos/list/list.component';

/**
 * Sistema de enrutamiento
 */
const routes: Routes = [
  { path: 'open-venta', component: OpenVentaComponent },
  { path: '', redirectTo: 'open-venta', pathMatch: 'full' },
  {path: 'create-client', component: CreateClientComponent},
  {path: 'compras/:id', component: ComprasComponent},
  {path: 'create-producto', component: AddComponent},
  {path: 'list-producto', component: ListComponent},
  {path: 'edit-producto/:id', component: EditComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {enableTracing: true})],
  exports: [RouterModule],
})
export class AppRoutingModule {}
