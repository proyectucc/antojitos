import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Producto } from 'src/app/services/models/producto';
import { ProductoService } from 'src/app/services/producto/producto.service';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
})
export class EditComponent implements OnInit {
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
  private readonly productoService: ProductoService;
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
    productoService: ProductoService,
    router: Router,
    activatedRoute: ActivatedRoute
  ) {
    this.router = router;
    this.productoService = productoService;
    this.activatedRoute = activatedRoute;

    this.frmGroup = formBuilder.group({
      id: [0],
      nombreProducto: ['', [Validators.required, Validators.max(64)]],
      unidadesExistentes: [null, [Validators.required]],
      valorProducto: [null, [Validators.required]],
      descripcion: ['', [Validators.max(512)]],
    });
  }

  public ngOnInit(): void {
    // se obtiene el ID a modificar
    const productoId = this.activatedRoute.snapshot.paramMap.get('id');

    // Se realiza búsqueda del registro para mapear los datos en los campos
    this.productoService
      .getProductosById(Number(productoId))
      .subscribe((response) => {
        this.frmGroup.setValue({
          nombreProducto: response.nombreProducto,
          unidadesExistentes: response.unidadesExistentes,
          valorProducto: response.valorProducto,
          descripcion: response.descripcion,
          id: response.id,
        });
      });
  }

  /**
   * Método encargado de actualizar un registro
   */
  public putfrom(producto: Producto) {
    producto.venta = null;

    this.productoService.putProducto(producto).subscribe(
      () => {
        this.router.navigate(['list-producto']);
      },
      (error) => console.log(error)
    );
  }
}
