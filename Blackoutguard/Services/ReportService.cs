public void ExportarParaCSV(List<Incident> incidentes, string caminhoArquivo)
{
    using (StreamWriter writer = new StreamWriter(caminhoArquivo))
    {
        writer.WriteLine("Data,Local,TipoFalha,Impacto");
        foreach (var i in incidentes)
        {
            writer.WriteLine($"{i.DataHora},{i.Local},{i.TipoFalha},{i.Impacto}");
        }
    }

    Console.WriteLine("📄 Relatório exportado com sucesso.");
}
