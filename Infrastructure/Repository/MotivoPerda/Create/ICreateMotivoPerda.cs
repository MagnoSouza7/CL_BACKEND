using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.MotivoPerda.Create
{
    public interface ICreateMotivoPerda
    {
        Task<object> Execute(string nome);
    }
}
