using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.Comentario
{
    public interface IComentarioRepository
    {
        Task<object> IGetLastComentario(int editalId);
        Task<object> IGetByIdComentario(int id);
        Task<object> ICreateComentario(string mensagem, int usuarioId, int editalId);
        Task<object> IUpdateComentario(int id ,string mensagem, int usuarioId, bool ativo);
        Task<object> IDeleteComentario(int id);


    }
}
