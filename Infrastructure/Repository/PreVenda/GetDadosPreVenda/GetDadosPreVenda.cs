using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.PreVenda.GetDadosPreVenda
{
    public class GetDadosPreVenda : IGetDadosPreVenda
    {
        public async Task<object> Execute()
        {
            using var context = new ApiContext();

            var usuarios = await context
                .Usuarios
                .AsNoTracking()
                .Where(x => x.Ativo)
                .Select(x => new { x.Id, x.Nome, x.Ativo})
                .ToListAsync();

            return usuarios;
        }
    }
}
