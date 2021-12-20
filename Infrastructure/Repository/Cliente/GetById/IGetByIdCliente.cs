using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Cliente.GetById
{
    public interface IGetByIdCliente
    {
        Task<object> Execute(int id);
    }
}
