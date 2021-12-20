using Application.Repository.PreVenda;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prs.Controllers.Request.MotivoPerda;
using Prs.Controllers.Request.PreVenda;
using System.Threading.Tasks;

namespace Prs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PreVendaController : ControllerBase
    {
        private readonly IPreVendaRepository preVendaRepository;

        public PreVendaController(IPreVendaRepository preVendaRepository)
        {
            this.preVendaRepository = preVendaRepository;
        }

        
        [HttpPost("GetAll")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var preVenda = await preVendaRepository.GetAllPreVenda();

            return Ok(preVenda);
        }

        
        [HttpPost("VerifyPreVenda")]
        [Authorize]
        public async Task<IActionResult> VerifyPreVenda(int id)
        {
            var verifique = await preVendaRepository.VerifyPreVenda(id);

            return Ok(verifique);
        }

        
        [HttpPost("GetDadosPreVenda")]
        [Authorize]
        public async Task<IActionResult> GetDadosPreVenda()
        {
            var usuarios = await preVendaRepository.GetDadosPreVenda();

            return Ok(usuarios);
        }

        
        [HttpPost("Create")]
        [Authorize(Roles = "licitacao,administrador")]
        public async Task<IActionResult> Create(PreVendaRequestCreate preVenda)
        {
            var preVendaNew = await preVendaRepository.CreatePreVenda(preVenda.UsuarioId);

            return Ok(preVendaNew);
        }

        
        [HttpPut("Update")]
        [Authorize(Roles = "licitacao,administrador")]
        public async Task<IActionResult> Update(PreVendaRequestUpdate preVenda)
        {
            var preVendaOld = await preVendaRepository.UpdatePreVenda(preVenda.Id, preVenda.UsuarioId, preVenda.Ativo);

            return Ok(preVendaOld);
        }
    }
}
