using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Bu.GetById
{
    public interface IGetByIdBu
    {
        Task<object> Execute(int id);
    }
}
