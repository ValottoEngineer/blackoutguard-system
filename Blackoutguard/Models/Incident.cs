namespace BlackoutGuard.Models
{
    public class Incident
    {
        public DateTime DataHora { get; set; }
        public string Local { get; set; }
        public string TipoFalha { get; set; }
        public string Impacto { get; set; }

        public Incident(DateTime dataHora, string local, string tipoFalha, string impacto)
        {
            DataHora = dataHora;
            Local = local;
            TipoFalha = tipoFalha;
            Impacto = impacto;
        }
    }
}
