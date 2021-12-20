using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.DocumentosCl.Update
{
    public class UpdateDocumentoCl : IUpdateDocumentoCl
    {  
        public async Task<object> Execute(int id, string descricao, string nomeAnexo, string tipoAnexo, byte[] base64Anexo)
        {
            using var context = new ApiContext();

            var anexo = nomeAnexo != null ? new Domain.Entities.Anexo
            {
                Nome = nomeAnexo,
                Tipo = tipoAnexo,
                Base64 = base64Anexo
            } : null;

            var documento = await context.DocumentosCLs
                .Include(x => x.Anexo)
                .AsTracking()
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();

            if (documento.Anexo != null)
            {
                context.Anexos.Remove(documento.Anexo);
            }

            documento.Descricao = descricao;
            documento.Anexo = anexo;

            context.DocumentosCLs.Update(documento);
            context.SaveChanges();

            return documento;
        }
    }
}
