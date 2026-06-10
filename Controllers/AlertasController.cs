using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RiskRadar.Data;
using RiskRadar.Models;

namespace RiskRadar.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlertasController : ControllerBase
{
    private readonly AppDbContext _context;

    public AlertasController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(
            await _context.Alertas
                .Include(a => a.PessoaAfetada)
                .ToListAsync()
        );
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var alerta = await _context.Alertas
            .Include(a => a.PessoaAfetada)
            .FirstOrDefaultAsync(a => a.Id == id);

        if (alerta == null)
            return NotFound("Alerta não encontrado.");

        return Ok(alerta);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Alerta alerta)
    {
        var pessoa = await _context.Pessoas
            .FindAsync(alerta.PessoaAfetadaId);

        if (pessoa == null)
            return BadRequest("Pessoa afetada não encontrada.");

        alerta.DataEnvio = DateTime.Now;

        _context.Alertas.Add(alerta);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetById),
            new { id = alerta.Id },
            alerta);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Alerta alerta)
    {
        if (id != alerta.Id)
            return BadRequest("ID da URL diferente do ID do alerta.");

        var pessoa = await _context.Pessoas
            .FindAsync(alerta.PessoaAfetadaId);

        if (pessoa == null)
            return BadRequest("Pessoa afetada não encontrada.");

        _context.Entry(alerta).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var alerta = await _context.Alertas.FindAsync(id);

        if (alerta == null)
            return NotFound("Alerta não encontrado.");

        _context.Alertas.Remove(alerta);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}