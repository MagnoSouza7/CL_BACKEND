using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.ConsultaPublica.GetById
{
    public class GetByIdConsultaPublica : IGetByIdConsultaPublica
    {
        public async Task<object> Execute(int id)
        {
            using var context = new ApiContext();

            var consPublica = await context.ConsultaPublicas
                .Include(x => x.Cliente)
                .Include(x => x.Empresa)
                .Include(x => x.Anexo)
                .AsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            return consPublica;
        }
    }
}
