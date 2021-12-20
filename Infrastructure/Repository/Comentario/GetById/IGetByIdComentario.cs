using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Comentario.GetById
{
    public interface IGetByIdComentario
    {
        Task<object> Execute(int id);

    }
}
