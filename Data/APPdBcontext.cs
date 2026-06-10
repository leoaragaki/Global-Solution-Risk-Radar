using Microsoft.EntityFrameworkCore;
using RiskRadar.Models;

namespace RiskRadar.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<PessoaAfetada> Pessoas { get; set; }
    public DbSet<Desastre> Desastres { get; set; }
    public DbSet<Alerta> Alertas { get; set; }
}