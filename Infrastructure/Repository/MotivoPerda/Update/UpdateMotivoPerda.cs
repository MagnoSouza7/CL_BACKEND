using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.MotivoPerda.Update
{
    public class UpdateMotivoPerda : IUpdateMotivoPerda
    {
        public async Task<object> Execute(string nome, int id, bool ativo)
        {
            using var context = new ApiContext();

            var motivoOld = await context.MotivosPerdas.AsTracking()
            .Where(x => x.Id == id)
            .SingleOrDefaultAsync();

            motivoOld.Nome = nome;
            motivoOld.Ativo = ativo;
            motivoOld.DataAtualizacao = DateTime.Now;

            context.MotivosPerdas.Update(motivoOld);
            await context.SaveChangesAsync();

            return motivoOld;
        }
    }
}
