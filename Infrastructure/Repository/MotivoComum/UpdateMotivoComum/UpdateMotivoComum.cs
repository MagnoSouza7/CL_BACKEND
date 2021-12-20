using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.MotivoComum.UpdateMotivoComum
{
    public class UpdateMotivoComum : IUpdateMotivoComum
    {
        public async Task<object> Execute(string nome, bool ativo, int id)
        {
            using var context = new ApiContext();

            var motivoOld = await context.MotivosComuns.AsTracking().Where(x => x.Id == id)
            .SingleOrDefaultAsync();

            motivoOld.Nome = nome;
            motivoOld.Ativo = ativo;
            motivoOld.DataAtualizacao = DateTime.Now;

            context.MotivosComuns.Update(motivoOld);
            await context.SaveChangesAsync();

            return motivoOld;

        }
    }
}
