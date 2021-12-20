using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Bu.Create
{
    public interface ICreateBu
    {
        Task<object> Execute(string nome);

    }
}
