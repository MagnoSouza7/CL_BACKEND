using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Categoria.GetAll
{
    public interface IGetAllCategoria
    {
        Task<object> Execute();
    }
}
