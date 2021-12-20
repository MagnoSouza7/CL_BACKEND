using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Comentario.GetLast
{
    public interface IGetLastComentario
    {
        Task<object> Execute(int editalId);
    }
}
