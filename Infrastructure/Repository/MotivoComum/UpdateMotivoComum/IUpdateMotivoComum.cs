using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.MotivoComum.UpdateMotivoComum
{
    public interface IUpdateMotivoComum
    {
        Task<object> Execute(string nome, bool ativo, int id);
    }
}
