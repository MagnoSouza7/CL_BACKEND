using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Empresa.GetById
{
    public interface IGetByIdEmpresa
    {
        Task<object> Execute(int id);
    }
}
