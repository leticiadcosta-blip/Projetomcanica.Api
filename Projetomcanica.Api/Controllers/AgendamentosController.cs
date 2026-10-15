using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projetomecanica.API.Data;
using Projetomecanica.Api.Models;

namespace Projetomecanica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AgendamentosController(AppDbContext context)
        {
            _context = context;
        }

      
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agendamento>>> GetAgendamentos()
        {
            return await _context.Agendamento.ToListAsync();
        }

    
        [HttpGet("{id}")]
        public async Task<ActionResult<Agendamento>> GetAgendamento(int id)
        {
            var agendamento = await _context.Agendamento.FindAsync(id);

            if (agendamento == null)
            {
                return NotFound();
            }

            return agendamento;
        }

       
        [HttpPost]
        public async Task<ActionResult<Agendamento>> PostAgendamento(Agendamento agendamento)
        {
            _context.Agendamento.Add(agendamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAgendamento), new { id = agendamento.Id }, agendamento);
        }

     
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAgendamento(int id, Agendamento agendamento)
        {
            if (id != agendamento.Id)
            {
                return BadRequest();
            }

            _context.Entry(agendamento).State = EntityState.Modified;

            return NoContent();
        }

       
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgendamento(int id)
        {
            var agendamento = await _context.Agendamento.FindAsync(id);
            if (agendamento == null)
            {
                return NotFound();
            }

            _context.Agendamento.Remove(agendamento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}