using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Concorrente.GetByName
{
    public class GetByNameConcorrente : IGetByNameConcorrente
    {
        public async Task<object> Execute(string nome)
        {
            using var context = new ApiContext();

            var concorrente = await context.Concorrentes
                .AsNoTracking()
                .Where(x => x.Nome.ToLower().Contains(nome.ToLower()))
                .ToListAsync();

            return concorrente;
        }
    }
}
