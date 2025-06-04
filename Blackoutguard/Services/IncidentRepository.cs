using BlackoutGuard.Models;

namespace BlackoutGuard.Services
{
    public class IncidentRepository
    {
        private List<Incident> incidentes = new List<Incident>();

        public void Adicionar(Incident incidente)
        {
            incidentes.Add(incidente);
            Console.WriteLine("✔ Incidente registrado com sucesso.");
        }

        public List<Incident> ListarTodos()
        {
            return incidentes;
        }
    }
}
