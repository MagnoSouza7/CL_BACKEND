using System.Threading.Tasks;

namespace Infrastructure.Repository.PreVenda.Create
{
    public interface ICreatePreVenda
    {
        Task<object> Execute(int usuarioId);
    }
}
