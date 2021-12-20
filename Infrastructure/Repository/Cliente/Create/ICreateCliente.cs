using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Cliente.Create
{
    public interface ICreateCliente
    {
        Task<object> Execute(string nome, string apelido, string cnpj);
    }
}
