using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupermercadoAntojitos.Contexto.Api;
using SupermercadoAntojitos.Entitiess.Api;
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
    public class ClienteController : ControllerBase
    {
        /// <summary>
        /// A DbContext instance represents a session with the database and can be used to
        /// </summary>
        private readonly ServiceContext _context;

        /// <summary>
        /// Crea una nueva instancia de la clase
        /// </summary>
        /// <param name="contexto"></param>
        public ClienteController(ServiceContext contexto)
        {
            _context = contexto;
        }

        /// <summary>
        /// Método encargado de traer todos los clientes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            return await _context.Clientes.ToListAsync();
        }

        /// <summary>
        /// Método encargado de retornar un cliente por id
        /// </summary>
        /// <param name="id">id del cliente a consultar</param>
        /// <returns></returns>
        [HttpGet("{documentoIdentidad}")]
        public async Task<ActionResult<Cliente>> GetClienteById(decimal documentoIdentidad)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(x => x.DocumentoIdentidad == documentoIdentidad);

            if (cliente == null)
            {
                return NoContent();
            }
            return cliente;
        }

        /// <summary>
        /// Método encargado de crear un cliente
        /// </summary>
        /// <param name="cliente">registro a crear</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            var dateCreate = new DateTime();
            cliente.FechaCreacion = dateCreate;
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetClienteById), new { documentoIdentidad = cliente.DocumentoIdentidad }, cliente);
        }

        /// <summary>
        /// Método encargado de actualizar un registro
        /// </summary>
        /// <param name="cliente">Registro a actualizar</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<Cliente>> PutCliente(int id, Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return BadRequest();
            }

            _context.Entry(cliente).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
