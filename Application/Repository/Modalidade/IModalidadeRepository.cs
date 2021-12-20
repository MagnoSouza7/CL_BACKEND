using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.Modalidade
{
    public interface IModalidadeRepository
    {
        Task<object> GetAll();
        Task<object> GetById(int id);
        Task<object> Create(string nome);
        Task<object> Update(int id, string nome, bool ativo);
    }
}
