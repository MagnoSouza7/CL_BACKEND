using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Comentario.Update
{
    public interface IUpdateComentario
    {
        Task<object> Execute(int id ,string mensagem, int usuarioId, bool ativo);
    }
}
