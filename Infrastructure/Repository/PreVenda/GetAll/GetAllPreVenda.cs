using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infrastructure.Repository.PreVenda.GetAll
{
    public class GetAllPreVenda : IGetAllPreVenda
    {
        public async Task<object> Execute()
        {
            using var context = new ApiContext();

            var preVendas = await context.PreVendas
            .Include(x => x.Usuario)
            .AsNoTracking()
            .ToListAsync();

            foreach (var preVenda in preVendas)
            {
                if(preVenda.Usuario != null)
                {
                    preVenda.Usuario.Email = "";
                    preVenda.Usuario.Login = "";
                    preVenda.Usuario.Token = "";
                    preVenda.Usuario.Role = null;
                }
            }

            return preVendas;
        }
    }
}
