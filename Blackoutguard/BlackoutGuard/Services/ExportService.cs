using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace BlackoutGuard
{
    public class ExportService
    {
        private const string JsonFilePath = "arquivos/incidentes.json";
        private const string CsvFilePath = "arquivos/exportacao.csv";

        public void ExportarParaCsv()
        {
            try
            {
                if (!File.Exists(JsonFilePath))
                {
                    Console.WriteLine("Nenhum incidente registrado ainda.");
                    return;
                }

                string jsonData = File.ReadAllText(JsonFilePath);
                var incidentes = JsonConvert.DeserializeObject<List<Incidente>>(jsonData);

                if (incidentes == null || incidentes.Count == 0)
                {
                    Console.WriteLine("Lista de incidentes vazia.");
                    return;
                }

                StringBuilder csvBuilder = new StringBuilder();
                csvBuilder.AppendLine("Data,Setor,Tipo,Impacto");

                foreach (var incidente in incidentes)
                {
                    csvBuilder.AppendLine($"{incidente.Data},{incidente.Setor},{incidente.Tipo},{incidente.Impacto}");
                }

                File.WriteAllText(CsvFilePath, csvBuilder.ToString());
                Console.WriteLine($"Relatório exportado com sucesso: {CsvFilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao exportar CSV: {ex.Message}");
            }
        }
    }

    public class Incidente
    {
        public string Data { get; set; }
        public string Setor { get; set; }
        public string Tipo { get; set; }
        public string Impacto { get; set; }
    }
}