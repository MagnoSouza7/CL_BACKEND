using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.MotivoPerda.GetById
{
    public class GetByIdMotivoPerda : IGetByIdMotivoPerda
    {
        public async Task<object> Execute(int id)
        {
            using var context = new ApiContext();

            var motivo = await context.MotivosPerdas.AsNoTracking().Where(x => x.Ativo && x.Id == id).SingleOrDefaultAsync();

            return motivo;
        }
    }
}
