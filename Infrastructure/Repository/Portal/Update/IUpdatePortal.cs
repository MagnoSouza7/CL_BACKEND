using System.Threading.Tasks;

namespace Infrastructure.Repository.Portal.Update
{
    public interface IUpdatePortal
    {
        Task<object> Execute(int id, string nome, bool ativo);
    }
}
