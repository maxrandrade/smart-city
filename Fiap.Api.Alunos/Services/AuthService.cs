using Fiap.Api.Alunos.Services;
using Fiap.Web.Alunos.Models;

namespace Fiap.Web.Alunos.Services
{
    public class AuthService : IAuthService
    {
        private List<UserModel> _users = new List<UserModel>
                {
                    new UserModel { UserId = 1, Username = "admin", Password = "admin", Role = "admin" },
                    new UserModel { UserId = 2, Username = "guest", Password = "guest", Role = "guest" },
                };


        public UserModel Authenticate(string username, string password)
        {
            // Aqui você normalmente faria a verificação de senha de forma segura
            return _users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }
    }
}
