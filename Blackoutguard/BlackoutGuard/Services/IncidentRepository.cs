using BlackoutGuard.Models;
using System.Text.Json;

namespace BlackoutGuard.Services
{
    public class IncidentRepository
    {
        private List<Incident> incidentes = new List<Incident>();
        private readonly string caminhoArquivo = "incidentes.json";

        public IncidentRepository()
        {
            CarregarDados();
        }

        public void Adicionar(Incident incidente)
        {
            incidentes.Add(incidente);
            SalvarDados();
            Console.WriteLine("✔ Incidente registrado e salvo.");
        }

        public List<Incident> ListarTodos()
        {
            return incidentes;
        }

        private void SalvarDados()
        {
            try
            {
                var json = JsonSerializer.Serialize(incidentes, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(caminhoArquivo, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar dados: {ex.Message}");
            }
        }

        private void CarregarDados()
        {
            try
            {
                if (File.Exists(caminhoArquivo))
                {
                    var json = File.ReadAllText(caminhoArquivo);
                    incidentes = JsonSerializer.Deserialize<List<Incident>>(json) ?? new List<Incident>();
                    Console.WriteLine($"📂 {incidentes.Count} incidentes carregados do histórico.");
                }
                else
                {
                    incidentes = new List<Incident>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao carregar dados: {ex.Message}");
                incidentes = new List<Incident>();
            }
        }
    }
}
