using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Email.GetByIdEdital
{
    public interface IGetByIdEdital
    {
        Task<Domain.Entities.Edital> Execute(int id);
    }
}
