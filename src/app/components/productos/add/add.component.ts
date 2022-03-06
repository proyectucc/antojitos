import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Producto } from 'src/app/services/models/producto';
import { ProductoService } from 'src/app/services/producto/producto.service';

/**
 * Componente encargado de crear un producto
 */
@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
})
export class AddComponent implements OnInit {
  /**
   * A service that provides navigation among views and URL manipulation capabilities.
   */
  private readonly router: Router;
  /**
   * Servicio encargado de realizar la comunicación con la Api
   */
  private readonly productoService: ProductoService;
  /**
   * Permite la configuración de los campos del formulario
   */
  public formBuilder: FormBuilder;
  /**
   * Permite crear grupos de controles para un formulario
   */
  public frmGroup: FormGroup;

  public constructor(
    formBuilder: FormBuilder,
    productoService: ProductoService,
    router: Router
  ) {
    this.router = router;
    this.productoService = productoService;

    this.frmGroup = formBuilder.group({
      nombreProducto: ['', [Validators.required, Validators.max(64)]],
      unidadesExistentes: [null, [Validators.required]],
      valorProducto: [null, [Validators.required]],
      descripcion: ['', [Validators.max(512)]],
    });
  }

  public ngOnInit(): void {}

  /**
   * Método encargado de crear un producto
   * @param producto a crear
   */
  public postfrom(producto: Producto) {
    const form: Producto = {
      nombreProducto: producto.nombreProducto,
      descripcion: producto.descripcion,
      unidadesExistentes: producto.unidadesExistentes,
      valorProducto: producto.valorProducto,
      venta: null,
    };

    this.productoService.postClient(form).subscribe((response) => {
      this.router.navigate(['list-producto']);
    });
  }
}
