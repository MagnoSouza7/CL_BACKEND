using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.CarteiraConta.DeleteGerenteComCarteira
{
    public interface IDeleteGerenteComCarteiraConta
    {
        Task<object> Execute(int id);
    }
}
