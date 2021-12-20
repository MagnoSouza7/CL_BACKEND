using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.DocumentosCl.Delete
{
    public interface IDeleteDocumentoCl
    {
        Task Execute(int id);
    }
}
