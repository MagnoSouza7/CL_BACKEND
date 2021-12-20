using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Modalidade.Update
{
    public interface IUpdateModalidade
    {
        Task<object> Execute(int id, string nome, bool ativo);
    }
}
