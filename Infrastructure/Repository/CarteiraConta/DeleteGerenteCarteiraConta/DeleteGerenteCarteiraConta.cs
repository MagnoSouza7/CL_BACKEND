using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.CarteiraConta.DeleteGerenteCarteiraConta
{
    public class DeleteGerenteCarteiraConta : IDeleteGerenteCarteiraConta
    {
        public async Task<object> Execute(int id)
        {
            using var context = new ApiContext();

            var carteiraOld = await context.CarteirasContas
            .Include(x => x.Gerente)
            .Include(x => x.Cliente)
            .AsTracking()
            .Where(x => x.Ativo && x.Gerente.Id == id)
            .ToListAsync();

            foreach (var carteira in carteiraOld)
            {
                carteira.Gerente = null;
            }

            context.CarteirasContas.UpdateRange(carteiraOld);

            await context.SaveChangesAsync();

            return carteiraOld;
        }

    }
}
