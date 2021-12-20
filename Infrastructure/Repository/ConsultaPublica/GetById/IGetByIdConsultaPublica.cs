using System.Threading.Tasks;

namespace Infrastructure.Repository.ConsultaPublica.GetById
{
    public interface IGetByIdConsultaPublica
    {
        Task<object> Execute(int id);
    }
}
