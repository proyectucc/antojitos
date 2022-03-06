using SupermercadoAntojitos.Entities.Api;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SupermercadoAntojitos.Entitiess.Api
{
    /// <summary>
    /// Información de la entidad a crear
    /// </summary>
    public class Cliente
    {
        /// <summary>
        /// Id del cliente
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nombe del cliente
        /// </summary>
        [Required]
        [StringLength(64, MinimumLength = 1, ErrorMessage = "The Nombres field is required.")]
        public string Nombres { get; set; }
        /// <summary>
        /// Identificación del cliente, se deja strin con el fin de permitir pasaportes y documentos que utilicen letras
        /// </summary>
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "The {0} field not is valid.")]
        public decimal DocumentoIdentidad { get; set; }
        /// <summary>
        /// Fecha creación del registro
        /// </summary>
        public DateTime FechaCreacion { get; set; }

        /// <summary>
        /// Relación con la venta
        /// </summary>
        public List<Venta> Ventas { get; set; } = new List<Venta>();
    }
}
