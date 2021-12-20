using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Categoria.GetById
{
    public interface IGetByIdCategoria
    {
        Task<object> Execute(int id);
    }
}
