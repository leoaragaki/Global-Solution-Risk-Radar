using RiskRadar.Data;
using RiskRadar.Models;

namespace RiskRadar.Services;

public class AlertaService
{
    private readonly AppDbContext _context;

    public AlertaService(AppDbContext context)
    {
        _context = context;
    }

    public async Task AtivarAlerta(Desastre desastre)
    {
        if (desastre.Gravidade.ToUpper() == "CRITICA")
        {
            desastre.AlarmeAtivado = true;

            var alerta = new Alerta
            {
                Mensagem = "ALERTA DE EMERGÊNCIA - CATÁSTROFE DETECTADA",
                Nivel = desastre.Gravidade,
                DataEnvio = DateTime.Now,
                PessoaAfetadaId = desastre.PessoaAfetadaId
            };

            _context.Alertas.Add(alerta);
            await _context.SaveChangesAsync();
        }
    }
}