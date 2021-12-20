using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.MotivoComum
{
    public interface IMotivoComumRepository
    {
        Task<object> GetAllMotivoComum();
        Task<object> GetByIdMotivoComum(int id);
        Task<object> CreateMotivoComum(string nome);
        Task<object> UpdateMotivoComum(string nome, bool ativo, int id);

    }
}
