using BlackoutGuard.Services;

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
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("✅ Login realizado com sucesso.\n");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("📘 BEM-VINDO AO SISTEMA BLACKOUTGUARD\n");
            Console.ResetColor();

            Console.WriteLine("Este sistema foi desenvolvido para registrar e monitorar falhas elétricas");
            Console.WriteLine("em ambientes comerciais e residenciais durante eventos de apagão ou instabilidade.");
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();

            UI.ExibirMenu(repo, alerts, reports, simulador, exportador);
        }
    }
}
