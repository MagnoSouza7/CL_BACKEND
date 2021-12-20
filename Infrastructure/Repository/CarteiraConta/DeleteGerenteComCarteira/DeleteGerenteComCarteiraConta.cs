using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.CarteiraConta.DeleteGerenteComCarteira
{
    public class DeleteGerenteComCarteiraConta : IDeleteGerenteComCarteiraConta
    {
        public async Task<object> Execute(int id)
        {
            using var context = new ApiContext();

            var carteiras = await context.CarteirasContas
            .Include(x => x.Gerente)
            .AsTracking()
            .Where(x => x.Ativo && x.Gerente.Id == id)
            .ToListAsync();

            context.CarteirasContas.RemoveRange(carteiras);

            await context.SaveChangesAsync();

            return carteiras;

        }


    }
}
