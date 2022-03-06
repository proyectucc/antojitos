import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Cliente } from '../models/cliente';

/**
 * Constante con la información de la url al endpoint a apuntar
 */
const url = 'https://localhost:44336/api/Cliente/';
/**
 * Servicio encargado de realizar la comunicación con la Api
 */
@Injectable({
  providedIn: 'root',
})
export class ClienteService {
  /**
   * Crea una nueva instancia de la clase
   * @param http This service is available as an injectable class, with methods to perform HTTP requests.
   */
  public constructor(private http: HttpClient) {}

  /**
   * Método encargado de obtener un cliente por su número de documento
   */
  public getClienteByNumberDocument(
    documentoIdentidad: number
  ): Observable<Cliente> {
    const ruta = url + documentoIdentidad;

    return this.http.get<Cliente>(ruta);
  }

  /**
   * Método encargado de crear un cliente
   */
  public postClient(cliente: Cliente): Observable<Cliente> {
    return this.http.post<Cliente>(url, cliente);
  }
}
