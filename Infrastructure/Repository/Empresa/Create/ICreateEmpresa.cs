using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Empresa.Create
{
    public interface ICreateEmpresa
    {
        Task<object> Execute(string nome);
    }
}
