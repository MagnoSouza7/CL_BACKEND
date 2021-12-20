using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Edital.Delete
{
    public class DeleteEdital : IDeleteEdital
    {
        public async Task<Domain.Entities.Edital> Execute(int id)
        {
            using var context = new ApiContext();

            var edital = await context.Editais
                .Include(x => x.Anexo)
                .Include(x => x.Comentarios)
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();

            if (edital == null)
                return null;

            if (edital.Comentarios != null)
                context.Comentarios.RemoveRange(edital.Comentarios);

            Domain.Entities.Anexo anexo = null;

            if(edital.Anexo != null)
            {
                anexo = await context.Anexos
                    .Where(x => x.Id == edital.Anexo.Id)
                    .SingleOrDefaultAsync();
            }

            if (anexo != null)
            {
                context.Anexos.Remove(anexo);
            }

            var gerente = await context.ParecerGerenteContas
                .Include(x => x.Anexo1)
                .Include(x => x.Anexo2)
                .Where(x => x.Edital.Id == edital.Id)
                .SingleOrDefaultAsync();

            if(gerente != null)
            {
                if(gerente.Anexo1 != null)
                {
                    context.Anexos.Remove(gerente.Anexo1);
                }
                if(gerente.Anexo2 != null)
                {
                    context.Anexos.Remove(gerente.Anexo2);
                }
            }

            var diretor = await context.ParecerDiretorComerciais
                .Include(x => x.Anexo1)
                .Include(x => x.Anexo2)
                .Where(x => x.Edital.Id == edital.Id)
                .SingleOrDefaultAsync();

            if(diretor != null)
            {
                if(diretor.Anexo1 != null)
                {
                    context.Anexos.Remove(diretor.Anexo1);
                }
                if(diretor.Anexo2 != null)
                {
                    context.Anexos.Remove(diretor.Anexo2);
                }
            }

            var licitacoes = await context.ParecerLicitacoes
                .Include(x => x.Anexo1)
                .Include(x => x.Anexo2)
                .Where(x => x.Edital.Id == edital.Id)
                .SingleOrDefaultAsync();

            if(licitacoes != null)
            {
                if(licitacoes.Anexo1 != null)
                {
                    context.Anexos.Remove(licitacoes.Anexo1);
                }
                if(licitacoes.Anexo2 != null)
                {
                    context.Anexos.Remove(licitacoes.Anexo2);
                }
            }

            context.Editais.Remove(edital);
            await context.SaveChangesAsync();

            return edital;
        }
    }
}
