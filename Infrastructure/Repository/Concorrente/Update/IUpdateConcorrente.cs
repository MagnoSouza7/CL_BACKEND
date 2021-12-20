using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Concorrente.Update
{
    public interface IUpdateConcorrente
    {
        Task<object> Execute(int id, string nome, string apelido, string cnpj, bool ativo);
    }
}
