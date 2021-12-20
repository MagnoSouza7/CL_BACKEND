using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.MotivoPerda
{
    public interface IMotivoPerdaRepository
    {
        Task<object> IGetAllMotivoPerda();
        Task<object> IGetByIdMotivoPerda(int id);
        Task<object> ICreateMotivoPerda(string nome);
        Task<object> IUpdateMotivoPerda(string nome, int id, bool ativo);

    }
}
