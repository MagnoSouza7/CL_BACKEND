using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Comentario.Create
{
    public class CreateComenterio : ICreateComenterio
    {
        public async Task<object> Execute(string mensagem, int usuarioId, int editalId)
        {
            using var context = new ApiContext();

            var edital = await context.Editais
            .Include(x => x.Comentarios)
            .Where(x => x.Ativo && x.Id == editalId)
            .SingleOrDefaultAsync();


            var comentarioNew = new Domain.Entities.Comentario
            {
                Mensagem = mensagem,
                Usuario = await context.Usuarios.Where(x => x.Id == usuarioId).SingleOrDefaultAsync(),
                Ativo = true,
                DataCriacao = DateTime.Now
            };

            edital.Comentarios.Add(comentarioNew);

            context.Editais.Update(edital);
            await context.SaveChangesAsync();

            return comentarioNew;
        }
    }
}
