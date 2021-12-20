using System.Threading.Tasks;
using Application.Repository.ConsultaPublica;
using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prs.Controllers.Request.ConsultaPublica;

namespace Prs.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ConsultaPublicaController : ControllerBase
    {
        private readonly IConsultaPublicaRepository consultaPublicaRepository;
        private readonly ApiContext context;

        public ConsultaPublicaController(IConsultaPublicaRepository consultaPublicaRepository)
        {
            this.consultaPublicaRepository = consultaPublicaRepository;
            context = new ApiContext();
        }

        
        [HttpPost("GetAll")]
        [Authorize]
        public async Task<IActionResult> GetAll(ConsultaPublicaFiltroRequest filtroRequest)
        {
            var consulta = await consultaPublicaRepository.GetAllConsultaPublica(
                filtroRequest.NumConsulta,
                filtroRequest.ClienteId,
                filtroRequest.EmpresaId,
                filtroRequest.DataRespostaInicio,
                filtroRequest.DataRespostaFinal);

            return Ok(consulta);

        }

        
        [HttpPost("GetById")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            var consultaId = await consultaPublicaRepository.GetByIdConsultaPublica(id);

            return Ok(consultaId);
        }

        
        [HttpPost("GetDadosForm")]
        [Authorize]
        public async Task<IActionResult> GetDadosForm()
        {
            var Dados = await consultaPublicaRepository.GetDadosFormConsultaPublica();

            return Ok(Dados);
        }

        
        [HttpPost("Create")]
        [Authorize]
        public async Task<IActionResult> Create(ConsultaPublicaRequestCreate requestCreate)
        {
            var consultaNew = await consultaPublicaRepository.CreateConsultaPublica(
                requestCreate.NumConsulta,
                requestCreate.ClienteId,
                requestCreate.EmpresaId,
                requestCreate.Objeto,
                requestCreate.HoraResposta,
                requestCreate.DataResposta,
                requestCreate.Anexo != null ? requestCreate.Anexo.Nome : null,
                requestCreate.Anexo != null ? requestCreate.Anexo.Tipo : null,
                requestCreate.Anexo != null ? requestCreate.Anexo.Base64 : null);

            return Ok(consultaNew);
        }

        
        [HttpPut("Update")]
        [Authorize]
        public async Task<IActionResult> Update(ConsultaPublicaRequestUpdate requestUpdate)
        {
            var consultaOld = await consultaPublicaRepository.UpdateConsultaPublica(
                requestUpdate.Id,
                requestUpdate.NumConsulta,
                requestUpdate.ClienteId,
                requestUpdate.EmpresaId,
                requestUpdate.Objeto,
                requestUpdate.HoraResposta,
                requestUpdate.DataResposta,
                requestUpdate.Anexo != null ? requestUpdate.Anexo.Nome : null,
                requestUpdate.Anexo != null ? requestUpdate.Anexo.Tipo : null,
                requestUpdate.Anexo != null ? requestUpdate.Anexo.Base64 : null);

            return Ok(consultaOld);
        }

        
        [HttpDelete("Delete")]
        [Authorize(Roles = "licitacao,administrador")]
        public async Task<IActionResult> Delete(int id)
        {
            await consultaPublicaRepository.DeleteConsultaPublica(id);

            return Ok();
        }
    }
}
