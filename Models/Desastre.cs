namespace RiskRadar.Models;

public class Desastre
{
    public int Id { get; set; }
    public string Tipo { get; set; }
    public string Gravidade { get; set; }
    public DateTime DataOcorrencia { get; set; }
    public bool AlarmeAtivado { get; set; }

    public int PessoaAfetadaId { get; set; }
    public PessoaAfetada? PessoaAfetada { get; set; }
}