using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.DocumentosCl.Delete
{
    public class DeleteDocumentoCl : IDeleteDocumentoCl
    {
        public async Task Execute(int id)
        {
            using var context = new ApiContext();

            var documento = await context.DocumentosCLs
                .Include(x => x.Anexo)
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();


            if (documento.Anexo != null)
                context.Anexos.Remove(documento.Anexo);
     

            context.DocumentosCLs.Remove(documento);

            await context.SaveChangesAsync();

        }
    }
}
