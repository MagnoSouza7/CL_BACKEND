using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infrastructure.Repository.PreVenda.VerifyPreVenda
{
    public class VerifyPreVenda : IVerifyPreVenda
    {
        public async Task<object> Execute(int id)
        {
            using var context = new ApiContext();

            var preVenda = await context.PreVendas
                .Include(x => x.Usuario)
                .AnyAsync(x => x.Usuario.Id == id);

            return preVenda;
        }
    }
}
