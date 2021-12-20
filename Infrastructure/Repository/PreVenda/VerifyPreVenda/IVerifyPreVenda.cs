using System.Threading.Tasks;

namespace Infrastructure.Repository.PreVenda.VerifyPreVenda
{
    public interface IVerifyPreVenda
    {
        Task<object> Execute(int id);
    }
}
