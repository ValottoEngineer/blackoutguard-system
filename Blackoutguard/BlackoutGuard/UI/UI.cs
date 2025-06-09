using System;
using System.Collections.Generic;
using BlackoutGuard.Models;

namespace BlackoutGuard.UI
{
    public static class UI
    {
        public static void MostrarBoasVindas()
        {
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
        }

        public static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("===== MENU PRINCIPAL =====");
            Console.WriteLine("1. Registrar novo incidente");
            Console.WriteLine("2. Simular falha elétrica");
            Console.WriteLine("3. Listar histórico de incidentes");
            Console.WriteLine("4. Exportar relatório CSV");
            Console.WriteLine("5. Sair");
            Console.Write("\\nEscolha uma opção: ");
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