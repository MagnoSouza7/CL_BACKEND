using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.MotivoPerda.Update
{
    public interface IUpdateMotivoPerda
    {
        Task<object> Execute(string nome, int id, bool ativo);
    }
}
