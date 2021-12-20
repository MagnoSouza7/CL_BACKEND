using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Concorrente.GetById
{
    public interface IGetByIdConcorrente
    {
        Task<object> Execute(int id);
    }
}
