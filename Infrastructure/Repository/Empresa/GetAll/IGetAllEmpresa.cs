using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Empresa.GetAll
{
    public interface IGetAllEmpresa
    {
        Task<object> Execute();
    }
}
