using System.Threading.Tasks;

namespace Application.Repository.PreVenda
{
    public interface IPreVendaRepository
    {
        Task<object> GetAllPreVenda();
        Task<object> VerifyPreVenda(int id);
        Task<object> GetDadosPreVenda();
        Task<object> CreatePreVenda(int usuarioId);
        Task<object> UpdatePreVenda(int id, int usuarioId, bool ativo);

    }
}
