using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projetomecanica.API.Data;
using Projetomecanica.Api.Models;


public class VeiculosController : ControllerBase
{
    private readonly AppDbContext _context;

    public VeiculosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<veiculo>>> GetVeiculos()
    {
        return await _context.Veiculos.ToListAsync();
    }
    [HttpPut("{id}")]
    public async Task<ActionResult> Alterar(int id, veiculo veiculos)
    {
        var VeiculoAtual = await _context.Veiculos.FindAsync(id);
        if (VeiculoAtual == null)
        {
            return NotFound();
        }
        VeiculoAtual.Clienteid = veiculos.Clienteid;
        VeiculoAtual.Placa = veiculos.Placa;
        VeiculoAtual.Marca = veiculos.Marca;
        VeiculoAtual.Modelo = veiculos.Modelo ;
        VeiculoAtual.cor = veiculos.cor;



        return Ok("Veiculo alterado com sucesso!");
    }
    [HttpPost]
    public async Task<ActionResult> CriarVeiculo(veiculo veiculos)
    {
        _context.Veiculos.Add(veiculos);

        await _context.SaveChangesAsync();
        return Ok("Veiculo criado com sucesso!");
    }
    [HttpDelete]
    public async Task<ActionResult> DeletarVeiculo(int id)
    {
        var veiculo = await _context.Veiculos.FindAsync(id);
        if (veiculo == null)
        {
            return NotFound();
        }

        _context.Veiculos.Remove(veiculo);
        await _context.SaveChangesAsync();
        return Ok("Veiculo deletado com sucessor!");
    }

}