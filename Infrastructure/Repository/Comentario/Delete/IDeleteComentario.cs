using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Comentario.Delete
{
    public interface IDeleteComentario
    {
        Task<object> Execute(int id);
    }
}
