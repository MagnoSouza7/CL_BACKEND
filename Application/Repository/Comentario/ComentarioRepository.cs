using Infrastructure.Repository.Comentario.Create;
using Infrastructure.Repository.Comentario.Delete;
using Infrastructure.Repository.Comentario.GetById;
using Infrastructure.Repository.Comentario.GetLast;
using Infrastructure.Repository.Comentario.Update;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.Comentario
{
    public class ComentarioRepository : IComentarioRepository
    {
        private readonly IGetLastComentario getLastComentario;
        private readonly IGetByIdComentario getByIdComentario;
        private readonly ICreateComenterio createComenterio;
        private readonly IUpdateComentario updateComentario;
        private readonly IDeleteComentario deleteComentario;
    
      public ComentarioRepository(
          IGetLastComentario getLastComentario,
          IGetByIdComentario getByIdComentario,
          ICreateComenterio createComenterio,
          IUpdateComentario updateComentario,
          IDeleteComentario deleteComentario)
        {
            this.getLastComentario = getLastComentario;
            this.getByIdComentario = getByIdComentario;
            this.createComenterio = createComenterio;
            this.updateComentario = updateComentario;
            this.deleteComentario = deleteComentario;
        }

        public async Task<object> ICreateComentario(string mensagem, int usuarioId, int editalId)
        {
            return await createComenterio.Execute(mensagem, usuarioId, editalId);
        }

        public async Task<object> IDeleteComentario(int id)
        {
            return await deleteComentario.Execute(id);
        }

        public async Task<object> IGetByIdComentario(int id)
        {
            return await getByIdComentario.Execute(id);
        }

        public async Task<object> IGetLastComentario(int editalId)
        {
            return await getLastComentario.Execute(editalId);
        }

        public async Task<object> IUpdateComentario(int id ,string mensagem, int usuarioId, bool ativo)
        {
            return await updateComentario.Execute(id ,mensagem, usuarioId, ativo);
        }
    }

}
