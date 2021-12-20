using Infrastructure.Repository.Email.GetByIdEdital;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.Email
{
    public class EmailRepository : IEmailRepository
    {
        private readonly IGetByIdEdital getByIdEdital;

        public EmailRepository(IGetByIdEdital getByIdEdital)
        {
            this.getByIdEdital = getByIdEdital;
        }

        public async Task<Domain.Entities.Edital> GetByIdEdital(int id)
        {
            return await getByIdEdital.Execute(id);
        }
    }
}
