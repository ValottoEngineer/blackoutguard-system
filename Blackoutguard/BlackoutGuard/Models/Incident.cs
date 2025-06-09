using System;

namespace BlackoutGuard.Models
{
    public class Incident
    {
        public DateTime DataHora { get; set; }
        public string Local { get; set; }
        public string TipoFalha { get; set; }
        public string Impacto { get; set; }

        public int ImpactoLevel
        {
            get
            {
                return Impacto switch
                {
                    "Crítico" => 4,
                    "Alto" => 3,
                    "Médio" => 2,
                    "Baixo" => 1,
                    _ => 0
                };
            }
        }

        public Incident(DateTime dataHora, string local, string tipoFalha, string impacto)
        {
            DataHora = dataHora;
            Local = local;
            TipoFalha = tipoFalha;
            Impacto = impacto;
        }
    }
}
