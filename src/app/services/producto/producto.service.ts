import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Producto } from '../models/producto';

/**
 * Constante con la información de la url al endpoint a apuntar
 */
const url = 'https://localhost:44336/api/Producto/';

/**
 * Servicio encargado de conectarse con la Api
 */
@Injectable({
  providedIn: 'root',
})
export class ProductoService {
  /**
   * Crea una nueva instancia de la clase
   * @param http This service is available as an injectable class, with methods to perform HTTP requests.
   */
  public constructor(private http: HttpClient) {}

  /**
   * Método encargado de crear un producto
   */
  public postClient(producto: Producto): Observable<Producto> {
    return this.http.post<Producto>(url, producto);
  }

  /**
   * Método encargado de obtener todos los productos
   */
  public getProductos(): Observable<Producto> {
    return this.http.get<Producto>(url);
  }

  /**
   * Método encargado de obtener todos los productos
   */
  public getProductosById(id: number): Observable<Producto> {
    const direccion = url + id;

    return this.http.get<Producto>(direccion);
  }

  /**
   * Método encargado de actualizar un producto
   */
  public putProducto(producto: Producto): Observable<Producto> {
    return this.http.put<Producto>(url, producto);
  }

  /**
   * Método encargado de eliminar un producto
   * @param id id del registro a eliminar
   * @returns retorna true si el registro se eliminó correctamente
   */
  public deleteProducto(id: number): Observable<Producto> {
    const direccion = url + id;

    return this.http.delete<Producto>(direccion);
  }
}
