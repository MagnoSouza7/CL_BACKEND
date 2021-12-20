using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.Bu
{
    public interface IBuRepository
    {
        Task<object> GetAllBu();
        Task<object> GetByIdBu(int id);
        Task<object> CreateBu(string nome);
        Task<object> UptadeBu(string nome, bool ativo, int id);

    }
}
