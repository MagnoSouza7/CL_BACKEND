using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Bu.GetAll
{
    public interface IGetAllBu
    {
        Task<object> Execute();  
    }
}
