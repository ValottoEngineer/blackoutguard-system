using BlackoutGuard.Models;
using System.Text;

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

        public void ExportarParaCSV(List<Incident> incidentes, string caminhoArquivo)
        {
            try
            {
                var csv = new StringBuilder();
                csv.AppendLine("DataHora,Local,TipoFalha,Impacto");

                foreach (var i in incidentes)
                {
                    csv.AppendLine($"{i.DataHora},{i.Local},{i.TipoFalha},{i.Impacto}");
                }

                File.WriteAllText(caminhoArquivo, csv.ToString());
                Console.WriteLine($"📄 Relatório exportado para: {caminhoArquivo}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao exportar CSV: {ex.Message}");
            }
        }
    }
}
