using SupermercadoAntojitos.Entitiess.Api;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SupermercadoAntojitos.Entities.Api
{
    /// <summary>
    /// Información de la entidad a crear
    /// </summary>
    public class Venta
    {
        /// <summary>
        /// Id de la venta
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Id del cliente
        /// </summary>
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "The IdCliente field is required.")]
        public int IdCliente { get; set; }
        /// <summary>
        /// valor a cancelar por el cliente
        /// </summary>
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "The ValorPagar field is required.")]
        public decimal ValorPagar { get; set; }
        /// <summary>
        /// Unidades seleccionadas por producto
        /// </summary>
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "The UnidadesPorProducto field is required.")]
        public decimal UnidadesPorProducto { get; set; }
        /// <summary>
        /// Venta de la venta
        /// </summary>
        [Required]
        public DateTime FechaVenta { get; set; }

        /// <summary>
        /// Cliente relacionado con la venta
        /// </summary>
        public Cliente Clientes { get; set; }
        /// <summary>
        /// Lista de productos seleccionados
        /// </summary>
        public List<Producto> Productos { get; set; } = new List<Producto>();

    }
}
