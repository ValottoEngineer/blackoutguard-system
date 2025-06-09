using System;
using System.Collections.Generic;
using BlackoutGuard.Models;
using BlackoutGuard.Services;

namespace BlackoutGuard.UI
{
    public static class UI
    {
        public static void ExibirMenu(
            IncidentRepository repo,
            AlertService alerts,
            ReportService reports,
            SimulationService simulador,
            ExportService exportador)
        {
            bool executando = true;

            while (executando)
            {
                Console.Clear();
                Console.WriteLine("===== MENU PRINCIPAL =====");
                Console.WriteLine("1. Registrar novo incidente");
                Console.WriteLine("2. Simular falha elétrica");
                Console.WriteLine("3. Listar histórico de incidentes");
                Console.WriteLine("4. Exportar relatório CSV");
                Console.WriteLine("5. Sair");

                Console.Write("\nEscolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        RegistrarManual(repo, alerts);
                        break;
                    case "2":
                        Simular(simulador, alerts, repo);
                        break;
                    case "3":
                        var lista = repo.ListarTodos();
                        ExibirHistorico(lista);
                        break;
                    case "4":
                        exportador.ExportarParaCsv();
                        Console.WriteLine("📄 Exportação concluída.");
                        break;
                    case "5":
                        executando = false;
                        Console.WriteLine("✅ Sistema encerrado.");
                        break;
                    default:
                        Console.WriteLine("⚠ Opção inválida.");
                        break;
                }

                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }

        private static void RegistrarManual(IncidentRepository repo, AlertService alerts)
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

        private static void Simular(SimulationService simulador, AlertService alerts, IncidentRepository repo)
        {
            var simulado = simulador.CriarSimulacao();
            Console.WriteLine($"> Simulação criada: {simulado.Local}, {simulado.TipoFalha}, {simulado.Impacto}, Nível: {simulado.ImpactoLevel}");
            alerts.VerificarEAlerta(simulado);
            repo.Adicionar(simulado);
        }

        public static void ExibirHistorico(List<Incident> incidentes)
        {
            Console.WriteLine("==== HISTÓRICO DE INCIDENTES ====");
            foreach (var i in incidentes)
            {
                Console.WriteLine($"{i.DataHora} | {i.Local} | {i.TipoFalha} | {i.Impacto} | Nível: {i.ImpactoLevel}");
            }
        }
    }
}
