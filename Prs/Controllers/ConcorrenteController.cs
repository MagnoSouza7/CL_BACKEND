using Application.Repository.Concorrente;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prs.Controllers.Request.Concorrente;
using System.Threading.Tasks;

namespace Prs.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ConcorrenteController : ControllerBase
    {
        private readonly IConcorrenteRepository concorrenteRepository;

        public ConcorrenteController(IConcorrenteRepository concorrenteRepository)
        {
            this.concorrenteRepository = concorrenteRepository;
        }

        
        [HttpPost("GetAll")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            return Ok( await concorrenteRepository.GetAll() );
        }

        
        [HttpPost("GetById")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok( await concorrenteRepository.GetById(id) );
        }

        
        [HttpPost("GetByName")]
        [Authorize]
        public async Task<IActionResult> GetByName(string nome)
        {
            return Ok( await concorrenteRepository.GetByName(nome) );
        }

        
        [HttpPost("Create")]
        [Authorize(Roles = "licitacao,administrador")]
        public async Task<IActionResult> Create(ConcorrenteRequestCreate concorrente)
        {
            var concorrenteNew = await concorrenteRepository.Create(
                concorrente.Nome,
                concorrente.Apelido,
                concorrente.Cnpj);

            return Ok(concorrenteNew);
        }

        
        [HttpPut("Update")]
        [Authorize(Roles = "licitacao,administrador")]
        public async Task<IActionResult> Update(ConcorrenteRequestUpdate concorrente)
        {
            var concorrenteOld = await concorrenteRepository.Update(
                concorrente.Id,
                concorrente.Nome,
                concorrente.Apelido,
                concorrente.Cnpj,
                concorrente.Ativo);

            return Ok(concorrenteOld);
        }
    }
}
