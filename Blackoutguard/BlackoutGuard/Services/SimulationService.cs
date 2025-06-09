using System;
using BlackoutGuard.Models;

namespace BlackoutGuard.Services
{
    public class SimulationService
    {
        private readonly Random random = new Random();

        public Incident CriarSimulacao()
        {
            string[] locais = { "Centro Comercial", "Hospital", "Estação de Metrô", "Prédio Residencial" };
            string[] tipos = { "Queda de energia", "Curto-circuito", "Sobrecarga", "Pane elétrica" };
            string[] impactos = { "Baixo", "Médio", "Alto", "Crítico" };

            string local = locais[random.Next(locais.Length)];
            string tipo = tipos[random.Next(tipos.Length)];
            string impacto = impactos[random.Next(impactos.Length)];

            return new Incident(DateTime.Now, local, tipo, impacto);
        }
    }
}
