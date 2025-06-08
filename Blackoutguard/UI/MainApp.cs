using BlackoutGuard.Models;
using BlackoutGuard.Services;
using BlackoutGuard;

namespace BlackoutGuard.UI
{
    public class MainApp
    {
        private readonly IncidentRepository repo;
        private readonly AlertService alerts;
        private readonly ReportService reports;
        private readonly SimulationService simulador;
        private readonly ExportService exportador;

        public MainApp()
        {
            repo = new IncidentRepository();
            alerts = new AlertService();
            reports = new ReportService();
            simulador = new SimulationService();
            exportador = new ExportService();
        }

        public void Iniciar()
        {
            bool executando = true;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("✅ Login realizado com sucesso.\\n");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("📘 BEM-VINDO AO SISTEMA BLACKOUTGUARD\\n");
            Console.ResetColor();

            Console.WriteLine("Este sistema foi desenvolvido para registrar e monitorar falhas elétricas");
            Console.WriteLine("em ambientes comerciais e residenciais durante eventos de apagão ou instabilidade.");
            Console.WriteLine("\\nPressione qualquer tecla para continuar...");
            Console.ReadKey();

            while (executando)
            {
                Console.Clear();
                Console.WriteLine("===== MENU PRINCIPAL =====");
                Console.WriteLine("1. Registrar novo incidente");
                Console.WriteLine("2. Simular falha elétrica");
                Console.WriteLine("3. Listar histórico de incidentes");
                Console.WriteLine("4. Exportar relatório CSV");
                Console.WriteLine("5. Sair");

                Console.Write("\\nEscolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        RegistrarManual();
                        break;
                    case "2":
                        Simular();
                        break;
                    case "3":
                        Listar();
                        break;
                    case "4":
                        Exportar();
                        break;
                    case "5":
                        executando = false;
                        Console.WriteLine("\\nSistema encerrado.");
                        break;
                    default:
                        Console.WriteLine("⚠ Opção inválida.");
                        break;
                }

                Console.WriteLine("\\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }

        private void RegistrarManual()
        {
            Console.Write("Local: ");
            string local = Console.ReadLine();

            Console.Write("Tipo de Falha: ");
            string tipo = Console.ReadLine();

            Console.Write("Impacto: ");
            string impacto = Console.ReadLine();

            var incidente = new Incident(DateTime.Now, local, tipo, impacto);
            alerts.VerificarEAlerta(incidente);
            repo.Adicionar(incidente);
        }

        private void Simular()
        {
            var simulado = simulador.CriarSimulacao();
            Console.WriteLine($"> Simulação criada: {simulado.Local}, {simulado.TipoFalha}, {simulado.Impacto}, Nível: {simulado.ImpactoLevel}");
            alerts.VerificarEAlerta(simulado);
            repo.Adicionar(simulado);
        }

        private void Listar()
        {
            var lista = repo.ListarTodos();
            Console.WriteLine("==== HISTÓRICO DE INCIDENTES ====");
            foreach (var i in lista)
            {
                Console.WriteLine($"{i.DataHora} | {i.Local} | {i.TipoFalha} | {i.Impacto} | Nível: {i.ImpactoLevel}");
            }
        }

        private void Exportar()
        {
            Console.WriteLine("Exportando relatório padrão para arquivos/exportacao.csv...");
            exportador.ExportarParaCsv();
        }
    }
}