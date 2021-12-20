using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Concorrente.GetById
{
    public class GetByIdConcorrente : IGetByIdConcorrente
    {
        public async Task<object> Execute(int id)
        {
            using var context = new ApiContext();

            var concorrente = await context.Concorrentes
                .AsNoTracking()
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();

            return concorrente;
        }
    }
}
