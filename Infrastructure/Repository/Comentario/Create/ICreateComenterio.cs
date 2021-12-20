using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Comentario.Create
{
    public interface ICreateComenterio
    {
        Task<object> Execute(string mensagem, int usuarioId, int editalId); 
    }
}
