using System.Collections.Generic;
using BlackoutGuard.Models;

namespace BlackoutGuard.Services
{
    public class IncidentRepository
    {
        private static IncidentRepository instancia;
        private List<Incident> incidentes;

        // Singleton para uso global no sistema
        public static IncidentRepository Instancia
        {
            get
            {
                if (instancia == null)
                    instancia = new IncidentRepository();
                return instancia;
            }
        }

        public IncidentRepository()
        {
            incidentes = new List<Incident>();
        }

        // Adiciona um novo incidente
        public void Adicionar(Incident incidente)
        {
            incidentes.Add(incidente);
        }

        // Lista todos os incidentes registrados
        public List<Incident> ListarTodos()
        {
            return incidentes;
        }
    }
}
