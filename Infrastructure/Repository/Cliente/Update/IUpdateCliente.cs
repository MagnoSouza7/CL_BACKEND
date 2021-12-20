using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Cliente.Update
{
    public interface IUpdateCliente
    {
        Task<object> Execute(string nome, string apelido, string cnpj, bool ativo, int id);
    }
}
