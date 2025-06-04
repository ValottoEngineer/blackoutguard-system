using BlackoutGuard.Models;

namespace BlackoutGuard.Services
{
    public class SimulationService
    {
        public Incident CriarSimulacao()
        {
            string[] locais = { "Coworking - Andar 1", "Residencial - Andar 4", "Sala de Servidores", "Recepção" };
            string[] tipos = { "Queda", "Ataque", "Oscilação" };
            string[] impactos = { "Servidor reiniciado", "Sistema de acesso falhou", "Rede inoperante", "Sem iluminação" };

            var rnd = new Random();
            return new Incident(
                DateTime.Now,
                locais[rnd.Next(locais.Length)],
                tipos[rnd.Next(tipos.Length)],
                impactos[rnd.Next(impactos.Length)]
            );
        }
    }
}
