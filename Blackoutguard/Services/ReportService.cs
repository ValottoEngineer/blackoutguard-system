using BlackoutGuard.Models;

namespace BlackoutGuard.Services
{
    public class ReportService
    {
        public void GerarRelatorio(List<Incident> incidentes)
        {
            Console.WriteLine("==== RELATÓRIO DE INCIDENTES ====");
            foreach (var i in incidentes)
            {
                Console.WriteLine($"{i.DataHora} | {i.Local} | {i.TipoFalha} | {i.Impacto}");
            }
        }
    }
}
