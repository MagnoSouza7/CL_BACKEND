using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Concorrente.GetAll
{
    public class GetAllConcorrente : IGetAllConcorrente
    {
        public async Task<object> Execute()
        {
            using var context = new ApiContext();

            var concorrentes = await context.Concorrentes
                .AsNoTracking()
                .ToListAsync();

            return concorrentes;
        }
    }
}
