using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RiskRadar.Data;
using RiskRadar.Models;
using RiskRadar.Services;

namespace RiskRadar.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DesastresController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly AlertaService _alertaService;

    public DesastresController(
        AppDbContext context,
        AlertaService alertaService)
    {
        _context = context;
        _alertaService = alertaService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(
            await _context.Desastres
                .Include(d => d.PessoaAfetada)
                .ToListAsync()
        );
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var desastre = await _context.Desastres
            .Include(d => d.PessoaAfetada)
            .FirstOrDefaultAsync(d => d.Id == id);

        if (desastre == null)
            return NotFound("Desastre não encontrado.");

        return Ok(desastre);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Desastre desastre)
    {
        var pessoa = await _context.Pessoas
            .FindAsync(desastre.PessoaAfetadaId);

        if (pessoa == null)
            return BadRequest("Pessoa afetada não encontrada.");

        desastre.DataOcorrencia = DateTime.Now;

        _context.Desastres.Add(desastre);
        await _context.SaveChangesAsync();

        await _alertaService.AtivarAlerta(desastre);

        return CreatedAtAction(
            nameof(GetById),
            new { id = desastre.Id },
            desastre);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Desastre desastre)
    {
        if (id != desastre.Id)
            return BadRequest("ID da URL diferente do ID do desastre.");

        var pessoa = await _context.Pessoas
            .FindAsync(desastre.PessoaAfetadaId);

        if (pessoa == null)
            return BadRequest("Pessoa afetada não encontrada.");

        _context.Entry(desastre).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var desastre = await _context.Desastres.FindAsync(id);

        if (desastre == null)
            return NotFound("Desastre não encontrado.");

        _context.Desastres.Remove(desastre);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}