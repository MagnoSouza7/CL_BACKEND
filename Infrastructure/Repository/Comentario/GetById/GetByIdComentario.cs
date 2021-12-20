using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Comentario.GetById
{
    public class GetByIdComentario : IGetByIdComentario
    {
        public async Task<object> Execute(int id)
        {
            using var context = new ApiContext();

            var comentarios = await context.Editais
            .Include(x => x.Comentarios)
            .ThenInclude(x => x.Usuario)
            .AsNoTracking()
            .Where(x => x.Id == id)
            .Select(x => x.Comentarios)
            .SingleOrDefaultAsync();

            return comentarios;

        }

    }
}
