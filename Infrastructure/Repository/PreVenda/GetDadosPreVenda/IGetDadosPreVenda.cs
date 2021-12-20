using System.Threading.Tasks;

namespace Infrastructure.Repository.PreVenda.GetDadosPreVenda
{
    public interface IGetDadosPreVenda
    {
        Task<object> Execute();
    }
}
