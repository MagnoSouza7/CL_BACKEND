using Application.Repository.Edital;
using Application.Repository.Historico;
using Email;
using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prs.Controllers.Request;
using System.Globalization;
using System.Threading.Tasks;

namespace Prs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EditalController : ControllerBase
    {
        private readonly IEditalRepository editalRepository;
        private readonly IHistoricoRepository historicoRepository;

        public EditalController(
            IEditalRepository editalRepository, 
            IHistoricoRepository historicoRepository)
        {
            this.editalRepository = editalRepository;
            this.historicoRepository = historicoRepository;
        }
        
        [HttpPost("GetTotalEditalGanhos")]
        [Authorize]
        public async Task<IActionResult> GetTotalEditalGanhos(FiltrosRequest filtro)
        {
            return Ok(await editalRepository.GetTotalEditalGanhos(
                filtro.Id,
                filtro.NumEdital,
                filtro.ClienteId,
                filtro.DataAberturaInicio,
                filtro.DataAberturaFinal,
                filtro.ModalidadeId,
                filtro.RegiaoId,
                filtro.EstadoId,
                filtro.CategoriaId,
                filtro.Uasg,
                filtro.Consorcio,
                filtro.PortalId,
                filtro.GerenteId,
                filtro.DiretorId,
                filtro.ValorEstimadoInicio,
                filtro.ValorEstimadoFinal,
                filtro.BuId,
                filtro.EmpresaId,
                filtro.Anexo));
        }
        
        [HttpPost("GetTotalEdital")]
        [Authorize]
        public async Task<IActionResult> GetTotalEdital(FiltrosRequest filtro)
        {
            return Ok(await editalRepository.GetTotalEdital(
                filtro.Id,
                filtro.NumEdital,
                filtro.ClienteId,
                filtro.DataAberturaInicio,
                filtro.DataAberturaFinal,
                filtro.ModalidadeId,
                filtro.RegiaoId,
                filtro.EstadoId,
                filtro.CategoriaId,
                filtro.Uasg,
                filtro.Consorcio,
                filtro.PortalId,
                filtro.GerenteId,
                filtro.DiretorId,
                filtro.ValorEstimadoInicio,
                filtro.ValorEstimadoFinal,
                filtro.BuId,
                filtro.EmpresaId));
        }
        
        [HttpPost("GetTotalEditalPerda")]
        [Authorize]
        public async Task<IActionResult> GetTotalEditalPerda(FiltrosRequest filtro)
        {
            return Ok(await editalRepository.GetTotalEditalPerdeu(
                filtro.Id,
                filtro.NumEdital,
                filtro.ClienteId,
                filtro.DataAberturaInicio,
                filtro.DataAberturaFinal,
                filtro.ModalidadeId,
                filtro.RegiaoId,
                filtro.EstadoId,
                filtro.CategoriaId,
                filtro.Uasg,
                filtro.Consorcio,
                filtro.PortalId,
                filtro.GerenteId,
                filtro.DiretorId,
                filtro.ValorEstimadoInicio,
                filtro.ValorEstimadoFinal,
                filtro.BuId,
                filtro.EmpresaId));
        }
        
        [HttpPost("GetTotalEditalGo")]
        [Authorize]
        public async Task<IActionResult> GetTotalEditalGo(FiltrosRequest filtro)
        {
            return Ok(await editalRepository.GetTotalEditalGo(
                filtro.Id,
                filtro.NumEdital,
                filtro.ClienteId,
                filtro.DataAberturaInicio,
                filtro.DataAberturaFinal,
                filtro.ModalidadeId,
                filtro.RegiaoId,
                filtro.EstadoId,
                filtro.CategoriaId,
                filtro.Uasg,
                filtro.Consorcio,
                filtro.PortalId,
                filtro.GerenteId,
                filtro.DiretorId,
                filtro.ValorEstimadoInicio,
                filtro.ValorEstimadoFinal,
                filtro.BuId,
                filtro.EmpresaId,
                filtro.Anexo));
        }
        
        [HttpPost("GetTotalEditalNoGo")]
        [Authorize]
        public async Task<IActionResult> GetTotalEditalNoGo(FiltrosRequest filtro)
        {
            return Ok(await editalRepository.GetTotalEditalNoGo(
                filtro.Id,
                filtro.NumEdital,
                filtro.ClienteId,
                filtro.DataAberturaInicio,
                filtro.DataAberturaFinal,
                filtro.ModalidadeId,
                filtro.RegiaoId,
                filtro.EstadoId,
                filtro.CategoriaId,
                filtro.Uasg,
                filtro.Consorcio,
                filtro.PortalId,
                filtro.GerenteId,
                filtro.DiretorId,
                filtro.ValorEstimadoInicio,
                filtro.ValorEstimadoFinal,
                filtro.BuId,
                filtro.EmpresaId));
        }
        
        [HttpPost("GetTotalEditalSuspenso")]
        [Authorize]
        public async Task<IActionResult> GetTotalEditalSuspenso(FiltrosRequest filtro)
        {
            return Ok(await editalRepository.GetTotalEditalSuspenso(
                filtro.Id,
                filtro.NumEdital,
                filtro.ClienteId,
                filtro.DataAberturaInicio,
                filtro.DataAberturaFinal,
                filtro.ModalidadeId,
                filtro.RegiaoId,
                filtro.EstadoId,
                filtro.CategoriaId,
                filtro.Uasg,
                filtro.Consorcio,
                filtro.PortalId,
                filtro.GerenteId,
                filtro.DiretorId,
                filtro.ValorEstimadoInicio,
                filtro.ValorEstimadoFinal,
                filtro.BuId,
                filtro.EmpresaId));
        }
        
        [HttpPost("GetDadosCadastrarEdital")]
        [Authorize]
        public async Task<IActionResult> GetDadosCadastrarEdital()
        {
            return Ok(await editalRepository.GetDadosCadastrarEdital());
        }

        
        [HttpPost("GetById")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await editalRepository.GetById(id));
        }
        
        [HttpPost("VerifyExists")]
        [Authorize]
        public IActionResult VerifyExists(int id)
        {
            return Ok(editalRepository.VerifyExists(id));
        }
        
        [HttpPost("SuspenderEdital")]
        [Authorize(Roles = "licitacao,administrador")]
        public async Task<IActionResult> SuspenderEdital(int id, int responsavelId)
        {
            if (!editalRepository.VerifyExists(id))
                return NotFound();

            await editalRepository.Suspender(id);

            await historicoRepository.CriarHistorico("Edital Suspenso", responsavelId, id);

            return Ok();
        }
        
        [HttpPost("Create")]
        [Authorize]
        public async Task<IActionResult> Create(EditalRequestCreate edital)
        {
            var editalNew = await editalRepository.Create(
                edital.NumEdital,
                edital.ClienteId,
                edital.EstadoId,
                edital.ModalidadeId,
                edital.DataDeAbertura,
                edital.HoraDeAbertura,
                edital.Uasg,
                edital.CategoriaId,
                edital.Consorcio,
                edital.ValorEstimado,
                edital.AgendarVistoria,
                edital.DataVistoria,
                edital.ObjetosDescricao,
                edital.ObjetosResumo,
                edital.Observacoes,
                edital.RegiaoId,
                edital.GerenteId,
                edital.DiretorId,
                edital.PortalId,
                edital.Anexo != null ? edital.Anexo.Nome : null,
                edital.Anexo != null ? edital.Anexo.Tipo : null,
                edital.Anexo != null ? edital.Anexo.Base64 : null
            );

            EmailService.EnviarEmailNotificacaoSobreEdital(
                editalNew.Gerente.Nome, 
                editalNew.Gerente.Email, 
                editalNew, 
                "Assunto: Prezado GC – " + 
                editalNew.Gerente.Nome + 
                " favor emitir parecer para o Edital: ID" 
                + editalNew.Id + 
                " - " + 
                editalNew.Cliente.Nome + 
                " - " + 
                editalNew.Modalidade.Nome + 
                " - " + 
                editalNew.NumEdital + 
                " - " + 
                editalNew.DataHoraDeAbertura.ToString("dd/MM/yyyy - HH:mm", CultureInfo.CurrentCulture));

            EmailService.EnviarEmailNotificacaoSobreEdital(
                editalNew.Diretor.Nome, 
                editalNew.Diretor.Email, 
                editalNew, 
                "Assunto: Prezado GC – " + 
                editalNew.Diretor.Nome + 
                " favor emitir parecer para o Edital: ID" + 
                editalNew.Id + 
                " - " + 
                editalNew.Cliente.Nome + 
                " - " + 
                editalNew.Modalidade.Nome + 
                " - " + 
                editalNew.NumEdital + 
                " - " + 
                editalNew.DataHoraDeAbertura.ToString("dd/MM/yyyy - HH:mm", CultureInfo.CurrentCulture));

            EmailService.EnviarEmailNotificacaoSobreEdital(
                "Equipe de Licitação", 
                "licita@globalweb.com.br", 
                editalNew, 
                "Assunto: Prezado GC – " + 
                editalNew.Gerente.Nome + 
                " favor emitir parecer para o Edital: ID" + 
                editalNew.Id + 
                " - " + 
                editalNew.Cliente.Nome + 
                " - " + 
                editalNew.Modalidade.Nome + 
                " - " + 
                editalNew.NumEdital + 
                " - " + 
                editalNew.DataHoraDeAbertura.ToString("dd/MM/yyyy - HH:mm", CultureInfo.CurrentCulture));

            await historicoRepository.CriarHistorico("Edital criado", edital.ResponsavelRequestId, editalNew.Id);

            return Ok(editalNew);
        }
        
        [HttpPut("Update")]
        [Authorize]
        public async Task<IActionResult> Update(EditalRequestUpdate edital)
        {
            using var context = new ApiContext();

            var editalUpdate = await editalRepository.Update(
                edital.Id,
                edital.NumEdital,
                edital.ClienteId,
                edital.EstadoId,
                edital.ModalidadeId,
                edital.EtapaId,
                edital.DataDeAbertura,
                edital.HoraDeAbertura,
                edital.Uasg,
                edital.CategoriaId,
                edital.Consorcio,
                edital.ValorEstimado,
                edital.AgendarVistoria,
                edital.DataVistoria,
                edital.ObjetosDescricao,
                edital.ObjetosResumo,
                edital.Observacoes,
                edital.RegiaoId,
                edital.GerenteId,
                edital.DiretorId,
                edital.PortalId,
                edital.Ativo,
                edital.Anexo != null ? edital.Anexo.Id : 0,
                edital.Anexo != null ? edital.Anexo.Nome : null,
                edital.Anexo != null ? edital.Anexo.Tipo : null,
                edital.Anexo != null ? edital.Anexo.Base64 : null,
                edital.ResponsavelRequestId
            );

            if (editalUpdate == null)
                return NotFound();

            EmailService.EnviarEmailNotificacaoAlteracaoEdital(
                editalUpdate.Gerente.Nome, 
                editalUpdate.Gerente.Email, 
                editalUpdate, 
                "Alteração! Edital: ID" + 
                editalUpdate.Id);

            EmailService.EnviarEmailNotificacaoAlteracaoEdital(
                editalUpdate.Diretor.Nome, 
                editalUpdate.Diretor.Email, 
                editalUpdate, 
                "Alteração! Edital: ID" + 
                editalUpdate.Id);

            EmailService.EnviarEmailNotificacaoAlteracaoEdital(
                "Equipe de Licitação", 
                "licita@globalweb.com.br", 
                editalUpdate, 
                "Alteração! Edital: ID" + 
                editalUpdate.Id);

            return Ok(editalUpdate);
        }
        
        [HttpPut("Restaurar")]
        [Authorize]
        public async Task<IActionResult> Restaurar(EditalRequestUpdate edital)
        {
            using var context = new ApiContext();

            var etapa = 1;

            var editalUpdate = await editalRepository.Restaurar(
                edital.Id,
                edital.NumEdital,
                edital.ClienteId,
                edital.EstadoId,
                edital.ModalidadeId,
                etapa,
                edital.DataDeAbertura,
                edital.HoraDeAbertura,
                edital.Uasg,
                edital.CategoriaId,
                edital.Consorcio,
                edital.ValorEstimado,
                edital.AgendarVistoria,
                edital.DataVistoria,
                edital.ObjetosDescricao,
                edital.ObjetosResumo,
                edital.Observacoes,
                edital.RegiaoId,
                edital.GerenteId,
                edital.DiretorId,
                edital.PortalId,
                edital.Ativo,
                edital.Anexo != null ? edital.Anexo.Id : 0,
                edital.Anexo != null ? edital.Anexo.Nome : null,
                edital.Anexo != null ? edital.Anexo.Tipo : null,
                edital.Anexo != null ? edital.Anexo.Base64 : null,
                edital.ResponsavelRequestId
            );

            if (editalUpdate == null)
                return NotFound();

            EmailService.EnviarEmailNotificacaoAlteracaoEdital(
                editalUpdate.Gerente.Nome, 
                editalUpdate.Gerente.Email, 
                editalUpdate);

            return Ok(editalUpdate);
        }
        
        [HttpDelete("Delete")]
        [Authorize(Roles = "licitacao,administrador")]
        public async Task<IActionResult> Delete(int id)
        {
            var editalDeleted = await editalRepository.Delete(id);

            if (editalDeleted == null)
                return NotFound();
                     
            return Ok();
        }
    }
}
