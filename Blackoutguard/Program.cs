using BlackoutGuard.Models;
using BlackoutGuard.Services;

class Program
{
    static void Main()
    {
        var user = new User { Username = "admin", Password = "1234" };

        Console.WriteLine("LOGIN:");
        Console.Write("Usuário: ");
        string inputUser = Console.ReadLine();

        Console.Write("Senha: ");
        string inputPass = Console.ReadLine();

        if (!user.Authenticate(inputUser, inputPass))
        {
            Console.WriteLine("❌ Usuário ou senha inválidos.");
            return;
        }

        Console.WriteLine("✅ Login realizado com sucesso.\n");

        var repo = new IncidentRepository();
        var alerts = new AlertService();
        var reports = new ReportService();

        bool executando = true;

        while (executando)
        {
            Console.WriteLine("\nEscolha uma opção:");
            Console.WriteLine("1 - Registrar incidente");
            Console.WriteLine("2 - Listar incidentes");
            Console.WriteLine("3 - Gerar relatório");
            Console.WriteLine("0 - Sair");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    try
                    {
                        Console.Write("Local: ");
                        string local = Console.ReadLine();

                        Console.Write("Tipo de falha (queda, oscilação, ataque): ");
                        string tipo = Console.ReadLine();

                        Console.Write("Impacto: ");
                        string impacto = Console.ReadLine();

                        var incidente = new Incident(DateTime.Now, local, tipo, impacto);
                        repo.Adicionar(incidente);
                        alerts.VerificarEAlerta(incidente);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erro ao registrar: {ex.Message}");
                    }
                    break;

                case "2":
                    var lista = repo.ListarTodos();
                    foreach (var i in lista)
                        Console.WriteLine($"{i.DataHora} | {i.Local} | {i.TipoFalha} | {i.Impacto}");
                    break;

                case "3":
                    reports.GerarRelatorio(repo.ListarTodos());
                    break;

                case "4":
                reports.ExportarParaCSV(repo.ListarTodos(), "relatorio.csv");
                break;


                case "0":
                    executando = false;
                    break;

                default:
                    Console.WriteLine("❌ Opção inválida.");
                    break;
            }
        }

        Console.WriteLine("Encerrando o sistema...");
    }
}