using Application.Repository.Relatorio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prs.Controllers.Request.Relatorio;
using System.Threading.Tasks;

namespace Prs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RelatorioController : ControllerBase
    {
        private readonly IRelatorioRepository repositoryRelatorio;

        public RelatorioController(IRelatorioRepository repositoryRelatorio)
        {
            this.repositoryRelatorio = repositoryRelatorio;
        }

        
        [HttpPost("CreateRelatorio")]
        [Authorize(Roles = "licitacao,administrador")]
        public async Task<IActionResult> CreateRelatorio(RelatorioRequestCreate relatorio)
        {
            var resultado = await repositoryRelatorio.CreateRepatorio(
                    relatorio.NumEdital,
                    relatorio.ClienteId,
                    relatorio.DataAberturaInicio,
                    relatorio.DataAberturaFinal,
                    relatorio.ModalidadeId,
                    relatorio.RegiaoId,
                    relatorio.EstadoId,
                    relatorio.Uasg,
                    relatorio.Consorcio,
                    relatorio.PortalId,
                    relatorio.GerenteId,
                    relatorio.DiretorId,
                    relatorio.ValorEstimadoInicio,
                    relatorio.ValorEstimadoFinal,
                    relatorio.ParecerGerente,
                    relatorio.MotivoComumId,
                    relatorio.PreVendaId,
                    relatorio.ParecerDiretor,
                    relatorio.EmpresaId,
                    relatorio.CategoriaId,
                    relatorio.ParecerLicitacao,
                    relatorio.MotivoPerdaId,
                    relatorio.NossoValorInicio,
                    relatorio.NossoValorFinal,
                    relatorio.VencedorId,
                    relatorio.ValorVencedorInicio,
                    relatorio.ValorVencedorFinal,
                    relatorio.ReponsavelId,
                    relatorio.BuId
                );

            return Ok(resultado);

        }

        
        [HttpPost("GetFormRelatorio")]
        [Authorize(Roles = "licitacao,administrador")]
        public async Task<IActionResult> GetFormRelatorio()
        {
            return Ok( await repositoryRelatorio.GetFormRelatorio() );
        }
    }
}
