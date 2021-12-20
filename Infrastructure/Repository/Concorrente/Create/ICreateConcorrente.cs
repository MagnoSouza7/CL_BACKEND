using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Concorrente.Create
{
    public interface ICreateConcorrente
    {
        Task<object> Execute(string nome, string apelido, string cnpj);
    }
}
