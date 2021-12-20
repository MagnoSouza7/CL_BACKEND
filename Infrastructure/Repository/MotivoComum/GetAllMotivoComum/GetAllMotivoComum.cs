using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.MotivoComum.GetAllMotivoComum
{
    public class GetAllMotivoComum : IGetAllMotivoComum
    {
        public async Task<object> Execute()
        {
            using var context = new ApiContext();

            var motivo = await context.MotivosComuns.AsNoTracking().ToListAsync();

            return (motivo);
        }
    }
}
