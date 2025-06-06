using BlackoutGuard.Models;
using BlackoutGuard.Services;

namespace BlackoutGuard.UI
{
    public class MainApp
    {
        private readonly IncidentRepository repo;
        private readonly AlertService alerts;
        private readonly ReportService reports;
        private readonly SimulationService simulador;

        public MainApp()
        {
            repo = new IncidentRepository();
            alerts = new AlertService();
            reports = new ReportService();
            simulador = new SimulationService();
        }

        public void Iniciar()
        {
            bool executando = true;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("✅ Login realizado com sucesso.\n");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("📘 BEM-VINDO AO SISTEMA BLACKOUTGUARD\n");
            Console.ResetColor();

            Console.WriteLine("Este sistema foi desenvolvido para registrar e monitorar falhas elétricas");
            Console.WriteLine("em ambientes comerciais e residenciais durante eventos de apagão ou instabilidade.");
            Console.WriteLine("Você pode usar este painel para:");
            Console.WriteLine(" - Cadastrar incidentes com local, tipo e impacto");
            Console.WriteLine(" - Gerar alertas automaticamente quando necessário");
            Console.WriteLine(" - Consultar histórico e exportar relatórios\n");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("👉 Navegue usando o menu abaixo. Escolha uma opção digitando o número correspondente.");
            Console.ResetColor();

            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();

            while (executando)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("===== BLACKOUTGUARD - MONITORAMENTO =====");
                Console.ResetColor();

                Console.WriteLine("1 - Registrar incidente");
                Console.WriteLine("2 - Listar incidentes");
                Console.WriteLine("3 - Gerar relatório");
                Console.WriteLine("4 - Simular falha automática");
                Console.WriteLine("5 - Exportar relatório para CSV");
                Console.WriteLine("0 - Sair");
                Console.Write("\nOpção: ");

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
                            Console.WriteLine($"Erro: {ex.Message}");
                        }
                        break;

                    case "2":
                        var lista = repo.ListarTodos();
                        foreach (var i in lista)
                            Console.WriteLine($"{i.DataHora} | {i.Local} | {i.TipoFalha} | {i.Impacto}");
                        Console.ReadKey();
                        break;

                    case "3":
                        reports.GerarRelatorio(repo.ListarTodos());
                        Console.ReadKey();
                        break;

                    case "4":
                        var incidenteSimulado = simulador.CriarSimulacao();
                        repo.Adicionar(incidenteSimulado);
                        alerts.VerificarEAlerta(incidenteSimulado);
                        Console.WriteLine("⚡ Simulação registrada.");
                        Console.ReadKey();
                        break;

                    case "5":
                        string caminhoCsv = "relatorio.csv";
                        reports.ExportarParaCSV(repo.ListarTodos(), caminhoCsv);
                        Console.ReadKey();
                        break;

                    case "0":
                        executando = false;
                        break;

                    default:
                        Console.WriteLine("❌ Opção inválida.");
                        Console.ReadKey();
                        break;
                }
            }

            Console.WriteLine("Encerrando sistema...");
        }
    }
}
