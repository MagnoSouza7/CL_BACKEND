using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Email.GetByIdEdital
{
    public class GetByIdEdital : IGetByIdEdital
    {
        public async Task<Domain.Entities.Edital> Execute(int id)
        {
            using var context = new ApiContext();

            var edital = await context.Editais
                .Include(x => x.Cliente)
                .Include(x => x.Estado)
                .Include(x => x.Modalidade)
                .Include(x => x.Etapa)
                .Include(x => x.Categoria)
                    .ThenInclude(c => c.Bu)
                .Include(x => x.Regiao)
                .Include(x => x.Gerente)
                .Include(x => x.Diretor)
                .Include(x => x.Portal)
                .Include(x => x.Anexo)
                .Where(x => x.Id == id)
                .AsNoTracking()
                .SingleOrDefaultAsync();

            return edital;
        }
    }
}
