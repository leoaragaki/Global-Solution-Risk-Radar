namespace RiskRadar.Models;

public class Alerta
{
    public int Id { get; set; }
    public string Mensagem { get; set; }
    public string Nivel { get; set; }
    public DateTime DataEnvio { get; set; }

    public int PessoaAfetadaId { get; set; }
    public PessoaAfetada? PessoaAfetada { get; set; }
}