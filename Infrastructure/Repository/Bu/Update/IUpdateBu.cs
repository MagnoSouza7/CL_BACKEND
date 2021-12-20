using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Bu.Update
{
    public interface IUpdateBu
    {
        Task<object> Execute(string nome, bool ativo, int id);
    }
}
