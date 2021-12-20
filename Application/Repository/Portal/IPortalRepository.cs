using System.Threading.Tasks;

namespace Application.Repository.Portal
{
    public interface IPortalRepository
    {
        Task<object> GetAllPortal();
        Task<object> GetByIdPortal(int id);
        Task<object> CreatePortal(string nome, bool ativo);
        Task<object> UpdatePortal(int id, string nome, bool ativo);

    }
}
