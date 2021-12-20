using System.Threading.Tasks;
using Application.Repository.DocumentoCL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prs.Controllers.Request.DocumentoCl;

namespace Prs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DocumentoController : ControllerBase
    {
        private readonly IDocumentoClRepository documentoClRepository;

        public DocumentoController(IDocumentoClRepository documentoClRepository)
        {
            this.documentoClRepository = documentoClRepository;
        }
        
        [HttpPost("GetAll")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var documentos = await documentoClRepository.GetAllDocumentos();

            return Ok(documentos);
        }
        
        [HttpPost("GetById")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            var documento = await documentoClRepository.GetByIdDocumentos(id);

            return Ok(documento);
        }
        
        [HttpPost("Create")]
        [Authorize]
        public async Task<IActionResult> Create(DocumentoClRequesteCreate documento)
        {
            var documentoNew = await documentoClRepository.CreateDocumentoCl(
                documento.Descricao, 
                documento.Anexo.Nome, 
                documento.Anexo.Tipo, 
                documento.Anexo.Base64);

            return Ok(documentoNew);
        }
        
        [HttpPut("Update")]
        [Authorize]
        public async Task<IActionResult> Update(DocumentoClRequesteUpdate documento)
        {
            var documentoOld = await documentoClRepository.UpdateDocumentoCl(
                documento.Id,
                documento.Descricao,
                documento.Anexo.Nome,
                documento.Anexo.Tipo,
                documento.Anexo.Base64
                );

            return Ok(documentoOld);
        }
        
        [HttpDelete("Delete")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            await documentoClRepository.DeleteDocumentoCl(id);

            return Ok();
        }
    }
}
