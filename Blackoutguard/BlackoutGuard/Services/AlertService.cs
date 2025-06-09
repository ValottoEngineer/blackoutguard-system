using System;
using BlackoutGuard.Models;

namespace BlackoutGuard.Services
{
    public class AlertService
    {
        public void VerificarEAlerta(Incident incidente)
        {
            if (incidente.ImpactoLevel >= 4)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("⚠ Alerta Crítico: Falha severa detectada!");
                Console.ResetColor();
            }
            else if (incidente.ImpactoLevel == 3)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("⚠ Alerta Moderado: Verifique o local impactado.");
                Console.ResetColor();
            }
        }
    }
}
