using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Empresa.Update
{
    public interface IUpdateEmpresa
    {
        Task<object> Execute(string nome, int id, bool ativo);
    }
}
