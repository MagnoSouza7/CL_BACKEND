using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.DocumentosCl.GetById
{
    public interface IGetByIdDocumento
    {
        Task<object> Execute(int id);
    }
}
