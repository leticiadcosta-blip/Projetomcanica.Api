using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projetomecanica.API.Data;
using Projetomecanica.Api.Models;

namespace Projetomecanica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClientesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            return await _context.Cliente.ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarCliente(Cliente cliente)
        {
            _context.Cliente.Add(cliente);
            await _context.SaveChangesAsync();
            return Ok("Cliente Cadastrado com sucesso");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutClientes(int id, Cliente cliente)
        {
            var clienteAtual = await _context.Cliente.FindAsync(id);
            if (clienteAtual == null)
            {
                return NotFound();
            }

            clienteAtual.Nome = cliente.Nome;
            clienteAtual.Telefone = cliente.Telefone;
            clienteAtual.Cpf = cliente.Cpf;
            clienteAtual.Email = cliente.Email;

            await _context.SaveChangesAsync();
            return Ok("Cliente salvo com sucesso");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletarCliente(int id, Cliente cliente)
        {
            var clientes = await _context.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _context.Cliente.Remove(cliente);

            await _context.SaveChangesAsync();

            return Ok("Cliente deletado com sucesso");
        }
    }
}