using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Comentario.Delete
{
    public class DeleteComentario : IDeleteComentario
    {
        public async Task<object> Execute(int id)
        {
            using var context = new ApiContext();

            var comentario = await context.Comentarios
            .AsNoTracking()
            .Where(x => x.Id == id)
            .SingleOrDefaultAsync();

            context.Comentarios.Remove(comentario);

            await context.SaveChangesAsync();

            return comentario;
        }
    }
}
