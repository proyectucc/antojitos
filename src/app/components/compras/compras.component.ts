import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import * as moment from 'moment';
import { ClienteService } from 'src/app/services/client/cliente.service';
import { Venta } from 'src/app/services/models/venta';
import { VentaService } from 'src/app/services/venta/venta.service';

/**
 * Componente encargado de registrar una compra
 */
@Component({
  selector: 'app-compras',
  templateUrl: './compras.component.html',
  styleUrls: ['./compras.component.scss'],
})
export class ComprasComponent implements OnInit {
  /**
   * A service that provides navigation among views and URL manipulation capabilities.
   */
  private readonly router: Router;
  /**
   * A service that provides navigation among views and URL manipulation capabilities.
   */
  private readonly activatedRoute: ActivatedRoute;
  /**
   * Servicio encargado de realizar la comunicación con la Api
   */
  private readonly ventaService: VentaService;
  /**
   * Servicio encargado de realizar la comunicación con la Api
   */
  private readonly clienteService: ClienteService;
  /**
   * Permite la configuración de los campos del formulario
   */
  public formBuilder: FormBuilder;
  /**
   * Permite crear grupos de controles para un formulario
   */
  public frmGroup: FormGroup;

  constructor(
    formBuilder: FormBuilder,
    router: Router,
    ventaService: VentaService,
    activatedRoute: ActivatedRoute,
    clienteService: ClienteService
  ) {
    this.router = router;
    this.ventaService = ventaService;
    this.activatedRoute = activatedRoute;
    this.clienteService = clienteService;

    this.frmGroup = formBuilder.group({
      nombres: [{ value: '', disabled: true }, Validators.required],
      documentoIdentidad: [{ value: 0, disabled: true }, Validators.required],
      fechaVenta: [{ value: 0, disabled: true }, Validators.required],
    });
  }

  public ngOnInit(): void {
    // se obtiene el ID a modificar
    const productoId = this.activatedRoute.snapshot.paramMap.get('id');
    this.clienteService
      .getClienteByNumberDocument(Number(productoId))
      .subscribe((response) => {
        const dateVenta = new Date();
        this.frmGroup.setValue({
          nombres: response.nombres,
          documentoIdentidad: response.documentoIdentidad,
          fechaVenta: moment(dateVenta).format('YYYY-MM-DD-HH:mm'),
        });
      });
  }

  public postForm(form: Venta) {}
}
