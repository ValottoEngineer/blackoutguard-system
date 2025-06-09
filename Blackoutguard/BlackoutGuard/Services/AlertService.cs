using BlackoutGuard.Models;

namespace BlackoutGuard.Services
{
    /// <summary>
    /// Serviço responsável por avaliar e emitir alertas com base em incidentes registrados.
    /// </summary>
    public class AlertService
    {
        /// <summary>
        /// Avalia o incidente e exibe um alerta se for considerado crítico.
        /// </summary>
        /// <param name="incidente">O incidente a ser avaliado.</param>
        public void VerificarEAlerta(Incident incidente)
        {
            // Estratégia baseada em enum e análise simples de criticidade
            if (incidente.ImpactoLevel == ImpactLevel.Critico || incidente.TipoFalha.ToLower().Contains("ataque"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("⚠ ALERTA: Incidente crítico detectado!");
                Console.ResetColor();
            }
        }
    }
}
