using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.DocumentoCL
{
    public interface IDocumentoClRepository
    {
        Task<object> GetAllDocumentos();
        Task<object> GetByIdDocumentos(int id);
        Task<object> CreateDocumentoCl(string descricao, string nomeAnexo, string tipoAnexo, byte[] base64Anexo);
        Task<object> UpdateDocumentoCl(int id, string descricao, string nomeAnexo, string tipoAnexo, byte[] base64Anexo);
        Task DeleteDocumentoCl(int id);

    }
}
