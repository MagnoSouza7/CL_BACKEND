using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.DocumentosCl
{
    public interface IGetAllDocumentos
    {
        Task<object> Execute();
    }
}
