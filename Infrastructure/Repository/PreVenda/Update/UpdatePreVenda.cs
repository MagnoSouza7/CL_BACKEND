using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.PreVenda.Update
{
    public class UpdatePreVenda : IUpdatePreVenda
    {
        public async Task<object> Execute(int id, int usuarioId, bool ativo)
        {
            using var context = new ApiContext();

            var preVendaOld = await context.PreVendas
               .AsTracking()
               .Where(x => x.Id == id)
               .SingleOrDefaultAsync();

            preVendaOld.Usuario = await context.Usuarios.Where(x => x.Id == usuarioId).SingleOrDefaultAsync();
            preVendaOld.Ativo = ativo;
            preVendaOld.DataAtualizacao = DateTime.Now;

            context.PreVendas.Update(preVendaOld);
            await context.SaveChangesAsync();

            return preVendaOld;
        }
    }
}
