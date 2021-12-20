using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Categoria.Update
{
    public interface IUpdateCategoria
    {
        Task<object> Execute(int id, string nome, int BuId, bool ativo);
    }
}
