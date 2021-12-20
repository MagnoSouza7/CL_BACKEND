using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.MotivoPerda.GetAll
{
    public class GetAllMotivoPerda : IGetAllMotivoPerda
    {
        public async Task<object> Execute()
        {
            using var context = new ApiContext();

            var motivo = await context.MotivosPerdas.AsNoTracking().ToListAsync();

            return motivo;
        }
    }
}
