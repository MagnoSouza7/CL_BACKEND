using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Cliente.GetAllClientes
{
    public interface IGetAllClientes
    {
        Task<object> Execute();
    }
}
