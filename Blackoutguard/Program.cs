using BlackoutGuard.UI;
using BlackoutGuard.Models;

namespace BlackoutGuard
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var user = new User
            {
                Username = "operador",
                Password = "energia2025"
            };

            Console.WriteLine("==== BLACKOUTGUARD - LOGIN ====");
            Console.Write("Login: ");
            string login = Console.ReadLine();

            Console.Write("Senha: ");
            string senha = Console.ReadLine();

            if (user.Authenticate(login, senha))
            {
                MainApp app = new MainApp();
                app.Iniciar();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n❌ Credenciais inválidas. Encerrando o sistema...");
                Console.ResetColor();
                Environment.Exit(0);
            }
        }
    }
}
