using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.MotivoComum.CreateMotivoComum
{
    public interface ICreateMotivoComum
    {
        Task<object> Execute(string nome);
    }
}
