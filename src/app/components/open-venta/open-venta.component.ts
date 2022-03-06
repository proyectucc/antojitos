import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ClienteService } from 'src/app/services/client/cliente.service';

/**
 * Componente encargado de recibir la información de un cliente
 */
@Component({
  selector: 'app-open-venta',
  templateUrl: './open-venta.component.html',
  styleUrls: ['./open-venta.component.scss'],
})
export class OpenVentaComponent implements OnInit {
  /**
   * A service that provides navigation among views and URL manipulation capabilities.
   */
  private readonly router: Router;
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

  /**
   * Crea una nueva instancia de la clase
   */
  public constructor(formBuilder: FormBuilder, clienteService: ClienteService, router: Router) {
    this.formBuilder = formBuilder;
    this.clienteService = clienteService;
    this.router = router;

    this.frmGroup = formBuilder.group({
      numberDocument: [Validators.minLength(4), [Validators.required]],
    });
  }

  /**
   * A lifecycle hook that is called after Angular has initialized
   */
  public ngOnInit(): void {}

  /**
   * Método encargado de validar si el cliente existe
   */
  public validateDocument() {
    const form = this.frmGroup.value;

    this.clienteService.getClienteByNumberDocument(form.numberDocument ).subscribe((response) => {
      if(response === null) {
        this.router.navigate(['create-client']);
      } else {
        this.router.navigate(['compras', response.documentoIdentidad]);
      }
    });
  }
}
