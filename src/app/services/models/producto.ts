import { Venta } from './venta';

/**
 * Interface que contiene la información del producto
 */
export interface Producto {
  id?: number;
  idVenta?: number;
  nombreProducto: string;
  descripcion?: string;
  unidadesExistentes: number;
  valorProducto: number;

  venta: Venta;
}
