import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Producto } from 'src/app/services/models/producto';
import { ProductoService } from 'src/app/services/producto/producto.service';

/**
 * Componente encargado de listar los productos
 */
@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss'],
})
export class ListComponent implements OnInit {
  /**
   * A service that provides navigation among views and URL manipulation capabilities.
   */
  private readonly router: Router;
  /**
   * Servicio encargado de realizar la comunicación con la Api
   */
  private readonly productoService: ProductoService;
  /**
   * Lista de productos
   */
  public productos: Producto;

  public constructor(productoService: ProductoService, router: Router) {
    this.productoService = productoService;
    this.router = router;
  }

  currentPage = 1;
  itemsPerPage = 10;
  pageSize: number;
  longitud: number;

  /**
   * Se ejecuta cuando se inicializa el componente
   */
  public ngOnInit(): void {
    this.productoService.getProductos().subscribe((response) => {
      console.log('PRODUCTOSSS', response);
      this.productos = response;
    });
  }

  /**
   * Método encargado de direccionarlo al módulo de edición
   * @param id del registro a editar
   */
  public editarproducto(id: number) {
    this.productoService.getProductosById(id).subscribe((data) => {
      this.router.navigate(['edit-producto', data.id]);
    });
  }

  /**
   * Método encargado de eliminar el registro seleccionado
   */
  public deleteProducto(id: number) {
    this.productoService.deleteProducto(id).subscribe(() => {
      this.router.navigate(['open-venta']);
    });
  }

  /**
   * Método encargado de redireccionar
   */
  public crearProducto() {
    this.router.navigate(['create-producto']);
  }
}
