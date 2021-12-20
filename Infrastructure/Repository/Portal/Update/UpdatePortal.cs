using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Portal.Update
{
    public class UpdatePortal : IUpdatePortal
    {
        public async Task<object> Execute(int id, string nome, bool ativo)
        {
            using var context = new ApiContext();

            var portalOld = await context.Portais
                .AsTracking()
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();

            portalOld.Nome = nome;
            portalOld.Ativo = ativo;
            portalOld.DataAtualizacao = DateTime.Now;

            context.Portais.Update(portalOld);
            await context.SaveChangesAsync();

            return portalOld;
        }
    }
}
