using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Anexo.Delete
{
    public class DeleteAnexo : IDeleteAnexo
    {
        public async Task<object> Execute(int id)
        {
            using var context = new ApiContext();

            var anexo = await context.Anexos
                .AsNoTracking()
                .Where(x => x.Ativo && x.Id == id)
                .SingleOrDefaultAsync();

            if (anexo == null)
                return null;

            anexo.Ativo = false;

            context.Anexos.Update(anexo);

            await context.SaveChangesAsync();

            return new { Mensagem = "Anexo desativado" };
        }
    }
}
