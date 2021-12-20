using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.ConsultaPublica.Delete
{
    public class DeleteConsultaPublica : IDeleteConsultaPublica
    {
        public async Task Execute(int id)
        {
            using var context = new ApiContext();

            var consPublica = await context.ConsultaPublicas
                .Include(x => x.Anexo)
                .AsTracking()
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();

            if (consPublica.Anexo != null)
            {
                context.Anexos.Remove(consPublica.Anexo);
            }

            context.ConsultaPublicas.Remove(consPublica);
            context.SaveChanges();

        }
    }
}
