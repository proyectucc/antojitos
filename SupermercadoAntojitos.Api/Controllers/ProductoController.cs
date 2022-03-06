using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupermercadoAntojitos.Contexto.Api;
using SupermercadoAntojitos.Entities.Api;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupermercadoAntojitos.Api.Controllers
{
    /// <summary>
    /// A base class for an MVC controller with view support.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        /// <summary>
        /// A DbContext instance represents a session with the database and can be used to
        /// </summary>
        private readonly ServiceContext _context;

        /// <summary>
        /// Crea una nueva instancia de la clase
        /// </summary>
        /// <param name="contexto"></param>
        public ProductoController(ServiceContext contexto)
        {
            _context = contexto;
        }

        /// <summary>
        /// Método encargado de traer todos los Productos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductos()
        {
            return await _context.Producto.ToListAsync();
        }

        /// <summary>
        /// Método encargado de retornar un Producto por id
        /// </summary>
        /// <param name="id">id del Producto a consultar</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProductoById(int id)
        {
            var producto = await _context.Producto.FindAsync(id);

            if (producto == null)
            {
                return NotFound("Producto no encontrado");
            }
            else if (producto.UnidadesExistentes == 0)
            {

                return NotFound($"No se encontraron existencias del producto {producto.NombreProducto}");
            }
            return producto;
        }

        /// <summary>
        /// Método encargado de crear un Producto
        /// </summary>
        /// <param name="producto">registro a crear</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Producto>> PostProducto(Producto producto)
        {
            await _context.Producto.AddAsync(producto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProductoById), new { id = producto.Id }, producto);
        }

        /// <summary>
        /// Método encargado de actualizar un registro
        /// </summary>
        /// <param name="producto">Registro a actualizar</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<Producto>> PutProducto(Producto producto)
        {
            _context.Entry(producto).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Método encargado de eliminar un registro
        /// </summary>
        /// <param name="id">id del registro a eliminar</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            var libro = await _context.Producto.FindAsync(id);

            if (libro == null)
            {
                return NotFound("No se encontró un producto con ese ID");
            }

            _context.Producto.Remove(libro);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
