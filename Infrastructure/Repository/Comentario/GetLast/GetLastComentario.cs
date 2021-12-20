using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Comentario.GetLast
{
    public class GetLastComentario : IGetLastComentario
    {
        public async Task<object> Execute(int editalId)
        {
            using var context = new ApiContext();

            var comentario = await context.Comentarios
            .AsNoTracking()
            .Where(x => x.Ativo && context.Editais.Any(e => e.Id == editalId && e.Comentarios.Contains(x)))
            .OrderByDescending(x => x.DataCriacao)
            .FirstOrDefaultAsync();

            return comentario;
        }
    }
}
