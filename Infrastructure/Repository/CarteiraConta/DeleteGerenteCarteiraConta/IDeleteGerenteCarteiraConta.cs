using System.Threading.Tasks;

namespace Infrastructure.Repository.CarteiraConta.DeleteGerenteCarteiraConta
{
    public interface IDeleteGerenteCarteiraConta
    {
        Task<object> Execute(int id);
    }
}
