using Application.Services;
using Infrastructure.Repository.Usuario.CreateUser;
using Infrastructure.Repository.Usuario.GetUserByEmail;
using Infrastructure.Repository.Usuario.GetUserByLogin;
using Infrastructure.Repository.Usuario.Notification;
using Infrastructure.Repository.Usuario.RecreateUser;
using Infrastructure.Repository.Usuario.UpdateToken;
using Infrastructure.Repository.Usuario.UpdateDB;
using System.Threading.Tasks;
using Application.Repository.Ldap;
using Infrastructure.Repository.Usuario.GetAll;

namespace Application.Repository.Usuario
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IGetUserByLogin getUserByLogin;
        private readonly IGetUserByEmail getUserByEmail;
        private readonly ICreateUser createUser;
        private readonly IRecreateUser recreateUser;
        private readonly INotification notification;
        private readonly IUpdateToken updateToken;
        private readonly IUpdateDB updateDb;
        private readonly ILdapRepository ldapRepository;
        private readonly IGetAllUsuario getAllUsuario;

        public UsuarioRepository(
            IGetUserByLogin getUserByLogin,
            IGetUserByEmail getUserByEmail,
            ICreateUser createUser,
            INotification notification,
            IUpdateToken updateToken,
            IRecreateUser recreateUser,
            IUpdateDB updateDb,
            ILdapRepository ldapRepository,
            IGetAllUsuario getAllUsuario
        )
        {
            this.getUserByLogin = getUserByLogin;
            this.getUserByEmail = getUserByEmail;
            this.createUser = createUser;
            this.notification = notification;
            this.updateToken = updateToken;
            this.recreateUser = recreateUser;
            this.updateDb = updateDb;
            this.ldapRepository = ldapRepository;
            this.getAllUsuario = getAllUsuario;
        }

        public async Task<Domain.Entities.Usuario> GetUserByLogin(string login)
        {
            var user = await getUserByLogin.Execute(login);

            if (user == null)
                return null;

            if (!TokenService.ValidateToken(user.Token))
                return await updateToken.Execute(user, TokenService.GenerateToken(user));

            return user;
        }

        public async Task<Domain.Entities.Usuario> GetUserByEmail(string email)
            => await getUserByEmail.Execute(email);

        public async Task CreateUser(string nome, string login, string email, int roleId)
        {
            await createUser.Execute(nome, login, email, roleId);
        }

        public async Task RecreateUser(int id, string nome, string login, string email, int roleId, string token)
        {
            await recreateUser.Execute(id, nome, login, email, roleId, token);
        }

        public async Task<object> GetNotification(int id)
        {
            return await notification.Execute(id);
        }

        public async Task UpdateUser(int id, int roleId, bool ativo)
        {
            await updateDb.Execute(id, roleId, ativo);
        }

        public async Task<bool> AuthenticateUser(string login, string senha)
        {
            return await ldapRepository.Login(login, senha);
        }

        public async Task<object> GetAllUsuario()
        {
            return await getAllUsuario.Execute();
        }
    }
}
