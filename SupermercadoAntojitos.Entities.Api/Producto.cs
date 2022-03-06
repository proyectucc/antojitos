using System;
using System.ComponentModel.DataAnnotations;

namespace SupermercadoAntojitos.Entities.Api
{
    /// <summary>
    /// 
    /// </summary>
    public class Producto
    {
        /// <summary>
        /// Id del cliente
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Id de la venta relacionada
        /// </summary>
        public int? IdVenta { get; set; }
        /// <summary>
        /// Nombe del producto
        /// </summary>
        [Required]
        [StringLength(64, ErrorMessage = "The {0} field not is valid.")]
        public string NombreProducto { get; set; }
        /// <summary>
        /// Descripcion del producto
        /// </summary>
        [StringLength(512, ErrorMessage = "The {0} field not is valid.")]
        public string Descripcion { get; set; }
        /// <summary>
        /// Unidades disponibles para la venta
        /// </summary>
        [Required]
        public decimal UnidadesExistentes { get; set; }
        /// <summary>
        /// Valor del producto por unidad
        /// </summary>
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "The {0} field not is valid.")]
        public decimal ValorProducto { get; set; }

        /// <summary>
        /// Relación con la venta
        /// </summary>
        public Venta Ventas { get; set; }
    }
}
