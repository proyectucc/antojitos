import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ClienteService } from 'src/app/services/client/cliente.service';
import { Cliente } from 'src/app/services/models/cliente';

@Component({
  selector: 'app-create-client',
  templateUrl: './create-client.component.html',
  styleUrls: ['./create-client.component.scss'],
})
export class CreateClientComponent implements OnInit {
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
  public constructor(
    formBuilder: FormBuilder,
    router: Router,
    clienteService: ClienteService
  ) {
    this.router = router;
    this.clienteService = clienteService;
    this.frmGroup = formBuilder.group({
      nombres: ['', [Validators.required, Validators.max(64)]],
      documentoIdentidad: [
        null,
        [Validators.required, Validators.maxLength(28)],
      ],
    });
  }

  /**
   * A lifecycle hook that is called after Angular has initialized
   */
  public ngOnInit(): void {}

  /**
   * Método encargado de crear un cliente
   * @param form información del cliente
   */
  public postForm(cliente: Cliente) {
    this.clienteService.postClient(cliente).subscribe(
      () => {
        this.router.navigate(['open-venta']);
      },
      (error) => console.log(error)
    );
  }
}
