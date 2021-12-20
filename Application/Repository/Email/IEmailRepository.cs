using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.Email
{
    public interface IEmailRepository
    {
        Task<Domain.Entities.Edital> GetByIdEdital(int id);
    }
}
