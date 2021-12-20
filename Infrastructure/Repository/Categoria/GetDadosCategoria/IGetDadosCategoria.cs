using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Categoria.GetDadosCategoria
{
    public interface IGetDadosCategoria
    {
        Task<object> Execute();
    }
}
