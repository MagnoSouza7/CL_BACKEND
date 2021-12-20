using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Anexo.Delete
{
    public interface IDeleteAnexo
    {
        Task<object> Execute(int id);
    }
}
