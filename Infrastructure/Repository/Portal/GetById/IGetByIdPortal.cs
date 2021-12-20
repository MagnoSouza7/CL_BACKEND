using System.Threading.Tasks;

namespace Infrastructure.Repository.Portal.GetById
{
    public interface IGetByIdPortal
    {
        Task<object> Execute(int id);
    }
}
