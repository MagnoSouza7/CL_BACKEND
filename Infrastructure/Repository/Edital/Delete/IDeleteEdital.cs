using System.Threading.Tasks;

namespace Infrastructure.Repository.Edital.Delete
{
    public interface IDeleteEdital
    {
        Task<Domain.Entities.Edital> Execute(int id);
    }
}
