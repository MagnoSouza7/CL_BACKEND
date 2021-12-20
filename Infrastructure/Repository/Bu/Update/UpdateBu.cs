using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Bu.Update
{
    public class UpdateBu : IUpdateBu
    {
        public async Task<object> Execute(string nome, bool ativo, int id)
        {
            using var context = new ApiContext();

            var buOld = await context.Bus
                .AsTracking()
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();

            buOld.Nome = nome;
            buOld.Ativo = ativo;
            buOld.DataAtualizacao = DateTime.Now;

            context.Bus.Update(buOld);

            await context.SaveChangesAsync();

            return buOld;
        }
    }
}
