using System.Threading.Tasks;

namespace Infrastructure.Repository.PreVenda.Update
{
    public interface IUpdatePreVenda
    {
        Task<object> Execute(int id, int usuarioId, bool ativo);
    }
}
