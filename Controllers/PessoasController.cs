using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RiskRadar.Data;
using RiskRadar.Models;

namespace RiskRadar.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PessoasController : ControllerBase
{
    private readonly AppDbContext _context;

    public PessoasController(
        AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var pessoas =
            await _context.Pessoas.ToListAsync();

        return Ok(pessoas);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var pessoa =
            await _context.Pessoas.FindAsync(id);

        if (pessoa == null)
            return NotFound();

        return Ok(pessoa);
    }

    [HttpPost]
    public async Task<IActionResult> Post(
        PessoaAfetada pessoa)
    {
        _context.Pessoas.Add(pessoa);

        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetById),
            new { id = pessoa.Id },
            pessoa);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(
        int id,
        PessoaAfetada pessoa)
    {
        if (id != pessoa.Id)
            return BadRequest();

        _context.Entry(pessoa).State =
            EntityState.Modified;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(
        int id)
    {
        var pessoa =
            await _context.Pessoas.FindAsync(id);

        if (pessoa == null)
            return NotFound();

        _context.Pessoas.Remove(pessoa);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}