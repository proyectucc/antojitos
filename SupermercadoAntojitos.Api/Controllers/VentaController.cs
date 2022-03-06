using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupermercadoAntojitos.Contexto.Api;
using SupermercadoAntojitos.Entities.Api;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupermercadoAntojitos.Api.Controllers
{
    /// <summary>
    /// A base class for an MVC controller with view support.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        /// <summary>
        /// A DbContext instance represents a session with the database and can be used to
        /// </summary>
        private readonly ServiceContext _context;

        /// <summary>
        /// Crea una nueva instancia de la clase
        /// </summary>
        /// <param name="contexto"></param>
        public VentaController(ServiceContext contexto)
        {
            _context = contexto;
        }

        /// <summary>
        /// Método encargado de traer todos los clientes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Venta>>> GetVentas()
        {
            return await _context.Ventas.ToListAsync();
        }

        /// <summary>
        /// Método encargado de retornar una venta por su id
        /// </summary>
        /// <param name="id">id de la venta realizada a consultar</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Venta>> GetVentaById(int id)
        {
            var cliente = await _context.Ventas.FindAsync(id);

            if (cliente == null)
            {
                return NotFound("Venta realizada no encontrada");
            }
            return cliente;
        }

        /// <summary>
        /// Método encargado de crear una venta
        /// </summary>
        /// <param name="venta">registro a crear</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Venta>> PostVenta(Venta venta)
        {
            var dateVenta = new DateTime();
            venta.FechaVenta = dateVenta;
            await _context.Ventas.AddAsync(venta);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVentaById), new { id = venta.Id }, venta);
        }

        /// <summary>
        /// Método encargado de actualizar un registro
        /// </summary>
        /// <param name="venta">Registro a actualizar</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<Venta>> PutVenta(int id, Venta venta)
        {
            if (id != venta.Id)
            {
                return BadRequest();
            }

            _context.Entry(venta).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }


        /// <summary>
        /// Método encargado de eliminar un registro
        /// </summary>
        /// <param name="id">id del registro a eliminar</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVenta(int id)
        {
            var libro = await _context.Producto.FindAsync(id);

            if (libro == null)
            {
                return NotFound("No se encontró una venta realizada con ese ID");
            }

            _context.Producto.Remove(libro);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
