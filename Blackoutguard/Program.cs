using BlackoutGuard.Models;
using BlackoutGuard.UI;

class Program
{
    static void Main()
    {
        var user = new User { Username = "operador", Password = "energia2025" };

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

        var app = new MainApp();
        app.Iniciar();
    }
}
