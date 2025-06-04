using System.Text.Json;

public class IncidentRepository
{
    private List<Incident> incidentes = new List<Incident>();
    private string caminhoArquivo = "incidentes.json";

    public IncidentRepository()
    {
        CarregarDados();
    }

    public void Adicionar(Incident incidente)
    {
        incidentes.Add(incidente);
        SalvarDados();
    }

    public List<Incident> ListarTodos()
    {
        return incidentes;
    }

    private void SalvarDados()
    {
        var json = JsonSerializer.Serialize(incidentes);
        File.WriteAllText(caminhoArquivo, json);
    }

    private void CarregarDados()
    {
        if (File.Exists(caminhoArquivo))
        {
            var json = File.ReadAllText(caminhoArquivo);
            incidentes = JsonSerializer.Deserialize<List<Incident>>(json) ?? new List<Incident>();
        }
    }
}
