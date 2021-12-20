using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Anexo.GetById
{
    public class GetByIdAnexo : IGetByIdAnexo
    {
        public async Task<Domain.Entities.Anexo> Execute(int id)
        {
            using var context = new ApiContext();

            var anexo = await context.Anexos
                .AsNoTracking()
                .Where(x => x.Ativo)
                .SingleOrDefaultAsync(x => x.Id == id);

            if (anexo == null)
                return null;

            return anexo;

        }
    }
}
