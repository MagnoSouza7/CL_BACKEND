using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Concorrente.GetAll
{
    public interface IGetAllConcorrente
    {
        Task<object> Execute();
    }
}
