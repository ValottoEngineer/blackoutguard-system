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
                        Console.WriteLine("📄 Relatório exportado para arquivos/exportacao.csv");
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
            try
            {
                Console.WriteLine("=== Registro Manual de Incidente ===");

                Console.Write("Local: ");
                string local = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(local))
                    throw new ArgumentException("O local não pode estar vazio.");

                Console.Write("Tipo de Falha: ");
                string tipo = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(tipo))
                    throw new ArgumentException("O tipo de falha não pode estar vazio.");

                Console.Write("Impacto (Baixo, Médio, Alto, Crítico): ");
                string impacto = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(impacto))
                    throw new ArgumentException("O impacto não pode estar vazio.");

                string[] impactosValidos = { "Baixo", "Médio", "Alto", "Crítico" };
                if (!Array.Exists(impactosValidos, i => i.Equals(impacto, StringComparison.OrdinalIgnoreCase)))
                    throw new ArgumentException("Impacto inválido. Use: Baixo, Médio, Alto ou Crítico.");

                var incidente = new Incident(DateTime.Now, local, tipo, impacto);
                alerts.VerificarEAlerta(incidente);
                repo.Adicionar(incidente);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("✔ Incidente registrado com sucesso.");
                Console.ResetColor();
            }
            catch (ArgumentException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"⚠ Erro de entrada: {ex.Message}");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"❌ Erro inesperado: {ex.Message}");
                Console.ResetColor();
            }
        }

        private static void Simular(SimulationService simulador, AlertService alerts, IncidentRepository repo)
        {
            var simulado = simulador.CriarSimulacao();
            Console.WriteLine($"> Simulação criada:");
            Console.WriteLine($"{simulado.Local} | {simulado.TipoFalha} | {simulado.Impacto} | Nível: {simulado.ImpactoLevel}");

            alerts.VerificarEAlerta(simulado);
            repo.Adicionar(simulado);
        }

        public static void ExibirHistorico(List<Incident> incidentes)
        {
            Console.WriteLine("==== HISTÓRICO DE INCIDENTES ====");
            if (incidentes.Count == 0)
            {
                Console.WriteLine("Nenhum incidente registrado ainda.");
                return;
            }

            foreach (var i in incidentes)
            {
                Console.WriteLine($"{i.DataHora} | {i.Local} | {i.TipoFalha} | {i.Impacto} | Nível: {i.ImpactoLevel}");
            }
        }
    }
}
