import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { MatTableModule } from '@angular/material/table';
import { MatTabsModule } from '@angular/material/tabs';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatRadioModule } from '@angular/material/radio';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatSelectModule } from '@angular/material/select';
import { MatIconModule } from '@angular/material/icon';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';

import { AppComponent } from './app.component';
import { FooterComponent } from './components/footer/footer.component';
import { OpenVentaComponent } from './components/open-venta/open-venta.component';
import { AppRoutingModule } from './app-routing.module';
import { HeaderComponent } from './components/header/header.component';
import { ClienteService } from './services/client/cliente.service';
import { CreateClientComponent } from './components/create-client/create-client.component';
import { ComprasComponent } from './components/compras/compras.component';
import { AddComponent } from './components/productos/add/add.component';
import { EditComponent } from './components/productos/edit/edit.component';
import { ListComponent } from './components/productos/list/list.component';
import { ProductoService } from './services/producto/producto.service';
import { VentaService } from './services/venta/venta.service';

@NgModule({
  declarations: [
    AppComponent,
    FooterComponent,
    OpenVentaComponent,
    HeaderComponent,
    CreateClientComponent,
    ComprasComponent,
    AddComponent,
    EditComponent,
    ListComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    MatInputModule,
    MatRadioModule,
    MatCheckboxModule,
    MatSelectModule,
    MatIconModule,
    MatDatepickerModule,
    MatTableModule,
    MatTabsModule,
    NgbModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    NgxDatatableModule,
    MatDialogModule,
    MatButtonModule,
  ],
  providers: [ClienteService, ProductoService, VentaService],
  bootstrap: [AppComponent],
})
export class AppModule {}
