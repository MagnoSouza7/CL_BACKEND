using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Cliente.GetByName
{
    public interface IGetByNameCliente
    {
        Task<object> Execute(string nome);
    }
}
