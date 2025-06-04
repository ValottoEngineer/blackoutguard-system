using BlackoutGuard.Models;

namespace BlackoutGuard.Services
{
    public class AlertService
    {
        public void VerificarEAlerta(Incident incidente)
        {
            if (incidente.TipoFalha.ToLower().Contains("ataque") || incidente.Impacto.ToLower().Contains("servidor"))
            {
                Console.WriteLine("⚠ ALERTA: Incidente crítico detectado!");
            }
        }
    }
}
