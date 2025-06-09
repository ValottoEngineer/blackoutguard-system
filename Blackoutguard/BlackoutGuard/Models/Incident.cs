using System;

namespace BlackoutGuard.Models
{
    /// <summary>
    /// Enumeração representando o nível de impacto do incidente.
    /// </summary>
    public enum ImpactLevel
    {
        Baixo,
        Moderado,
        Critico
    }

    /// <summary>
    /// Representa um incidente elétrico ocorrido no sistema.
    /// </summary>
    public class Incident
    {
        public DateTime DataHora { get; set; }
        public string Local { get; set; }
        public string TipoFalha { get; set; }
        public string Impacto { get; set; }
        public ImpactLevel ImpactoLevel { get; set; }

        public Incident() { }

        public Incident(DateTime dataHora, string local, string tipoFalha, string impacto)
        {
            DataHora = dataHora;
            Local = local;
            TipoFalha = tipoFalha;
            Impacto = impacto;
            ImpactoLevel = ClassificarImpacto(impacto);
        }

        /// <summary>
        /// Converte o texto do impacto em um nível de severidade pré-definido.
        /// </summary>
        private ImpactLevel ClassificarImpacto(string impacto)
        {
            if (impacto.ToLower().Contains("servidor") || impacto.ToLower().Contains("acesso") || impacto.ToLower().Contains("rede"))
                return ImpactLevel.Critico;
            if (impacto.ToLower().Contains("iluminação"))
                return ImpactLevel.Moderado;
            return ImpactLevel.Baixo;
        }
    }
}