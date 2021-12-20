using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.DocumentosCl
{
    public class GetAllDocumentos : IGetAllDocumentos
    {
        public async Task<object> Execute()
        {
            using var context = new ApiContext();

            var documento = await context.DocumentosCLs.AsNoTracking()
                .Include(x => x.Anexo)
                .ToListAsync();

            return documento;

        }
    }
}
