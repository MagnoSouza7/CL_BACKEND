using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.DocumentosCl.GetById
{
    public class GetByIdDocumento: IGetByIdDocumento
    {
        public async Task<object> Execute(int id)
        {
            using var context = new ApiContext();

            var documento = await context.DocumentosCLs.AsNoTracking()
                .Include(x=> x.Anexo)
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();

            return documento;
        }
    }
}
