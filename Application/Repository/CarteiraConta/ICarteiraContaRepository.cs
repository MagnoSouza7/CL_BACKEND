using System.Threading.Tasks;

namespace Application.Repository.CarteiraConta
{
    public interface ICarteiraContaRepository
    {
        Task<object> GetAllCarteiraContas();
        Task CreateCarteiraConta(int gerenteId, int clienteId);
        Task DeleteCarteiraConta(int id);
        Task<object> GetFormCarteiraConta();
        Task<object> DeleteGerenteCarteiraConta(int id);
        Task<object> DeleteGerenteComCarteiraConta(int id);
    }
}
