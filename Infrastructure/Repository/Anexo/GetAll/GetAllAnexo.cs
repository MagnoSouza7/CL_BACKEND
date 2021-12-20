using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Anexo.GetAll
{
    public class GetAllAnexo : IGetAllAnexo
    {
        public async Task<object> Execute()
        {
            using var context = new ApiContext();

            var anexos = await context.Anexos
                .AsNoTracking()
                .Where(x => x.Ativo)
                .ToListAsync();

            return anexos;
        }
    }
}
