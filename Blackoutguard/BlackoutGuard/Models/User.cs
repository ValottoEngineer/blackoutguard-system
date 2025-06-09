namespace BlackoutGuard.Models
{
    /// <summary>
    /// Representa um usuário do sistema com autenticação básica.
    /// </summary>
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }

        /// <summary>
        /// Autentica o usuário com base no nome e senha.
        /// </summary>
        /// <param name="username">Nome de usuário informado</param>
        /// <param name="password">Senha informada</param>
        /// <returns>True se as credenciais forem válidas; caso contrário, false.</returns>
        public bool Authenticate(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                Console.WriteLine("⚠ Usuário ou senha não podem estar vazios.");
                return false;
            }

            return Username == username && Password == password;
        }

        // 🔐 Melhorias futuras:
        // - Carregar usuários de um arquivo JSON com múltiplos perfis
        // - Criptografar senha com SHA256 ou bcrypt
    }
}
