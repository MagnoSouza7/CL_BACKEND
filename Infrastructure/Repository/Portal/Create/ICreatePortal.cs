using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Portal.Create
{
    public interface ICreatePortal
    {
        Task<object> Execute(string nome, bool ativo);
    }
}
