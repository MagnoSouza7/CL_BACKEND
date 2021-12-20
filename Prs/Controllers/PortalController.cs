using Application.Repository.Portal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prs.Controllers.Request.Portal;
using System.Threading.Tasks;

namespace Prs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PortalController : ControllerBase
    {
        private readonly IPortalRepository portalRepository;

        public PortalController(IPortalRepository portalRepository)
        {
            this.portalRepository = portalRepository;
        }

        
        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var portal = await portalRepository.GetAllPortal();

            return Ok(portal);

        }

        
        [HttpPost("GetById")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            var portalId = await portalRepository.GetByIdPortal(id);

            return Ok(portalId);
        }

        
        [HttpPost("Create")]
        [Authorize(Roles = "licitacao,administrador")]
        public async Task<IActionResult> Create(PortalRequestCreate portal)
        {
            var portalNew = await portalRepository.CreatePortal(portal.Nome, portal.Ativo);

            return Ok(portalNew);
        }

        
        [HttpPut("Update")]
        [Authorize(Roles = "licitacao,administrador")]
        public async Task<IActionResult> Update(PortalRequestUpdate portal)
        {
            var portalOld = await portalRepository.UpdatePortal(portal.Id, portal.Nome, portal.Ativo);

            return Ok();
        }
    }
}
