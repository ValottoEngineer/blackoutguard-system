using System;
using System.IO;
using BlackoutGuard.Models;

namespace BlackoutGuard.Services
{
    public class ExportService
    {
        private readonly string caminho = "arquivos/exportacao.csv";

        public void ExportarParaCsv()
        {
            var incidentes = IncidentRepository.Instancia.ListarTodos();

            Directory.CreateDirectory("arquivos");

            using (StreamWriter sw = new StreamWriter(caminho))
            {
                sw.WriteLine("DataHora,Local,TipoFalha,Impacto,Nivel");

                foreach (var i in incidentes)
                {
                    sw.WriteLine($"{i.DataHora},{i.Local},{i.TipoFalha},{i.Impacto},{i.ImpactoLevel}");
                }
            }
        }
    }
}
