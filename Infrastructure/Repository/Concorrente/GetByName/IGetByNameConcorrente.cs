using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Concorrente.GetByName
{
    public interface IGetByNameConcorrente
    {
        Task<object> Execute(string nome);
    }
}
