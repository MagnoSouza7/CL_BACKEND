using Application.Repository.Empresa;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prs.Controllers.Request.Empresa;
using System.Threading.Tasks;

namespace Prs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaRepository empresaRepository;
     

        public EmpresaController(IEmpresaRepository empresaRepository)
        {
            this.empresaRepository = empresaRepository;
         
        }
        
        [HttpPost("GetAll")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var empresa = await empresaRepository.GetAllEmpresa();

            return Ok(empresa);
        }
        
        [HttpPost("GetById")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            var empresa = await empresaRepository.GetByIdEmpresa(id);

            return Ok(empresa);
        }
        
        [HttpPost("Create")]
        [Authorize(Roles = "licitacao,administrador")]
        public async Task<IActionResult> Create(EmpresaRequestCreate emp)
        {
            var empresaNew = await empresaRepository.CreateEmpresa(emp.Nome);

            return Ok(empresaNew);
        }
        
        [HttpPut("Update")]
        [Authorize(Roles = "licitacao,administrador")]
        public async Task<IActionResult> Update(EmpresaRequestUpdate emp)
        {
            var empresaOld = await empresaRepository.UpdateEmpresa(emp.Nome, emp.Id, emp.Ativo);

            return Ok(empresaOld);
        }
    }
}
