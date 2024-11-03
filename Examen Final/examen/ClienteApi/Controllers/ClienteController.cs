using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClienteApi.Data;
using ClienteApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ClientesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> CreateCliente(Cliente cliente)
        {
            cliente.FechaCreacion = DateTime.UtcNow; // Establecer la fecha de creación
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCliente), new { id = cliente.ID }, cliente);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return cliente;
        }

        [HttpGet("ListadoGeneral")]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetListadoGeneral()
        {
            return await _context.Clientes
                .OrderBy(c => c.FechaCreacion)
                .ThenBy(c => c.Apellidos)
                .ToListAsync();
        }
    }
}