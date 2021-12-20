using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.Concorrente
{
    public interface IConcorrenteRepository
    {
        Task<object> GetAll();
        Task<object> GetById(int id);
        Task<object> GetByName(string nome);
        Task<object> Create(string nome, string apelido, string cnpj);
        Task<object> Update(int id, string nome, string apelido, string cnpj, bool ativo);
    }
}
