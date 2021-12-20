using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.Categoria
{
    public interface ICategoriaRepository
    {
        Task<object> GetAll();
        Task<object> GetById(int id);
        Task<object> GetDadosCategoria();
        Task<object> Create(string nome, int BuId);
        Task<object> Update(int id, string nome, int BuId, bool ativo);
    }
}
