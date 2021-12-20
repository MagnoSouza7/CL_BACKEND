using System.Threading.Tasks;

namespace Infrastructure.Repository.Relatorio.GetDadosRelatorio
{
    public interface IGetFormRelatorio
    {
        Task<object> Execute();
    }
}
