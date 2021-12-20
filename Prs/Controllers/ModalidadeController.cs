using Application.Repository.Modalidade;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prs.Controllers.Request.Modalidade;
using System.Threading.Tasks;

namespace Prs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ModalidadeController : ControllerBase
    {
        private readonly IModalidadeRepository modalidadeRepository;

        public ModalidadeController(IModalidadeRepository modalidadeRepository)
        {
            this.modalidadeRepository = modalidadeRepository;
        }
        
        [HttpPost("GetAll")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            return Ok( await modalidadeRepository.GetAll() );
        }
        
        [HttpPost("GetById")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok( await modalidadeRepository.GetById(id) );
        }
        
        [HttpPost("Create")]
        [Authorize(Roles = "licitacao,administrador")]
        public async Task<IActionResult> Create(ModalidadeRequestCreate modalidade)
        {
            var modalidadeNew = await modalidadeRepository.Create(modalidade.Nome); 

            return Ok(modalidadeNew);
        }
        
        [HttpPut("Update")]
        [Authorize(Roles = "licitacao,administrador")]
        public async Task<IActionResult> Update(ModalidadeRequestUpdate modalidade)
        {
            var modalidadeOld = await modalidadeRepository.Update(
                modalidade.Id,
                modalidade.Nome,
                modalidade.Ativo);

            return Ok(modalidadeOld);
        }
    }
}
