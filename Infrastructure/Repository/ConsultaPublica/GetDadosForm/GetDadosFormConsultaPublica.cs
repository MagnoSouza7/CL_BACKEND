using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.ConsultaPublica.GetDadosForm
{
    public class GetDadosFormConsultaPublica : IGetDadosFormConsultaPublica
    {
        public async Task<object> Execute()
        {
            using var context = new ApiContext();

            var cliente = await context.Clientes
                .AsNoTracking()
                .Where(x => x.Ativo)
                .ToListAsync();

            var empresa = await context.Empresas
                .AsNoTracking()
                .Where(x => x.Ativo)
                .ToListAsync();

            return (new { cliente, empresa });
        }
    }
}
