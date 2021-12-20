using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Modalidade.Create
{
    public interface ICreateModalidade
    {
        Task<object> Execute(string nome);
    }
}
