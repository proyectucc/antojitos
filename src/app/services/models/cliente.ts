import { Venta } from './venta';

/**
 * Interfaz que contiene la información del client
 */
export interface Cliente {
  nombres: string;
  documentoIdentidad: number;
  fechaCreacion: Date;
  ventas: Venta;
}
