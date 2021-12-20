using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Comentario.Update
{
    public class UpdateComentario : IUpdateComentario
    {
        public async Task<object> Execute( int id ,string mensagem, int usuarioId, bool ativo)
        {
            using var context = new ApiContext();

            var comentarioOld = await context.Comentarios
            .AsTracking()
            .Where(x => x.Id == id)
            .SingleOrDefaultAsync();

            comentarioOld.Mensagem = mensagem;
            comentarioOld.Usuario = await context.Usuarios.AsNoTracking().Where(x => x.Id == usuarioId).SingleOrDefaultAsync();
            comentarioOld.Ativo = ativo;
            comentarioOld.DataAtualizacao = DateTime.Now;

            context.Comentarios.Update(comentarioOld);
            await context.SaveChangesAsync();

            return comentarioOld;
        }

    }
}
