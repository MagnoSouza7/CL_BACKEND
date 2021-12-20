using Infrastructure.Repository.DocumentosCl;
using Infrastructure.Repository.DocumentosCl.Create;
using Infrastructure.Repository.DocumentosCl.Delete;
using Infrastructure.Repository.DocumentosCl.GetById;
using Infrastructure.Repository.DocumentosCl.Update;
using System.Threading.Tasks;

namespace Application.Repository.DocumentoCL
{
    public class DocumentoClRepository : IDocumentoClRepository
    {
        private readonly IGetAllDocumentos getAllDocumentos;
        private readonly IGetByIdDocumento getByIdDocumento;
        private readonly ICreateDocumentoCl createDocumentoCl;
        private readonly IUpdateDocumentoCl updateDocumentoCl;
        private readonly IDeleteDocumentoCl deleteDocumentoCl;

        public DocumentoClRepository(
            IGetAllDocumentos getAllDocumentos,
            IGetByIdDocumento getByIdDocumento,
            ICreateDocumentoCl createDocumentoCl,
            IUpdateDocumentoCl updateDocumentoCl,
            IDeleteDocumentoCl deleteDocumentoCl)
        {
            this.getAllDocumentos = getAllDocumentos;
            this.getByIdDocumento = getByIdDocumento;
            this.createDocumentoCl = createDocumentoCl;
            this.updateDocumentoCl = updateDocumentoCl;
            this.deleteDocumentoCl = deleteDocumentoCl;

        }

        public async Task<object> CreateDocumentoCl(string descricao, string nomeAnexo, string tipoAnexo, byte[] base64Anexo)
        {
            return await createDocumentoCl.Execute(descricao, nomeAnexo, tipoAnexo, base64Anexo);
        }

        public async Task DeleteDocumentoCl(int id)
        {
             await deleteDocumentoCl.Execute(id);

            return;
        }

        public async Task<object> GetAllDocumentos()
        {
            return await getAllDocumentos.Execute();
        }

        public async Task<object> GetByIdDocumentos(int id)
        {
            return await getByIdDocumento.Execute(id);
        }

        public async Task<object> UpdateDocumentoCl(int id, string descricao, string nomeAnexo, string tipoAnexo, byte[] base64Anexo)
        {
            return await updateDocumentoCl.Execute(id, descricao, nomeAnexo, tipoAnexo, base64Anexo);
        }
    }
}
