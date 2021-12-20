using System.Threading.Tasks;

namespace Infrastructure.Repository.ConsultaPublica.Delete
{
    public interface IDeleteConsultaPublica
    {
        Task Execute(int id);
    }
}
