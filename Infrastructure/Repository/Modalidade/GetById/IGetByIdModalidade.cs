using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Modalidade.GetById
{
    public interface IGetByIdModalidade
    {
        Task<object> Execute(int id);
    }
}
