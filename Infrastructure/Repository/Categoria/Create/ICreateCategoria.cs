using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Categoria.Create
{
    public interface ICreateCategoria
    {
        Task<object> Execute(string nome, int BuId);
    }
}
