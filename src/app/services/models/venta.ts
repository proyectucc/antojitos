import { Cliente } from './cliente';

/**
 * Interface que contiene la información de la venta
 */
export interface Venta {
  idCliente: number;
  valorPagar: number;
  unidadesPorProducto: number;
  fechVenta: Date;

  cliente: Cliente;
}
