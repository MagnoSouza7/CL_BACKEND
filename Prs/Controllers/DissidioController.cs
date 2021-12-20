using Application.Repository.Dissidio;
using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prs.Controllers.Request.Dissidio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DissidioController : ControllerBase
    {
        private readonly IDissidioRepository dissidioRepository;

        public DissidioController(IDissidioRepository dissidioRepository)
        {
            this.dissidioRepository = dissidioRepository;
        }
        
        [HttpPost("ObterStatusDissidios")]
        [Authorize]
        public async Task<IActionResult> ObterStatusDissidios()
        {
            var resposta = await dissidioRepository.ObterStatusDissidios();

            return Ok(resposta);
        }
        
        [HttpPost("GetDissidioByEstadoId")]
        [Authorize]
        public async Task<IActionResult> GetDissidioByEstadoId(int id)
        {

            var resposta = await dissidioRepository.GetDissidioByEstadoId(id);

            return Ok(resposta);
        }
        
        [HttpPost("GetDissidioById")]
        [Authorize]
        public async Task<IActionResult> GetDissidioById(int id)
        {

            var dissidio = await dissidioRepository.GetDissidioById(id);

            return Ok(dissidio);
        }
        
        [HttpPost("CreateDissidio")]
        [Authorize]
        public async Task<IActionResult> CreateDissidio(DissidioRequestCreate request)
        {
            await dissidioRepository.CreateDissidio(
                request.EstadoId, 
                request.DataBase, 
                request.DataUltima, 
                request.PisoSalarial8h, 
                request.PisoSalarial6h, 
                request.Ticket8h, 
                request.Ticket6h, 
                request.BenefInd8h, 
                request.BenefInd6h, 
                request.Reajuste, 
                request.Observacoes, 
                request.VigenciaInicio, 
                request.VigenciaFinal, 
                request.Cnpj, 
                request.ConformeCargoFuncao, 
                request.Atalho,
                request.arquivo != null ? request.arquivo.Nome : null,
                request.arquivo != null ? request.arquivo.Tipo : null,
                request.arquivo != null ? request.arquivo.Base64 : null);

            return Ok();
        }
       

        [HttpPost("UpdateDissidio")]
        [Authorize]
        public async Task<IActionResult> UpdateDissidio(DissidioRequestUpdate request)
        {
            await dissidioRepository.IUpdateDissidio(
                request.Id,
                request.DataBase,
                request.DataUltima,
                request.PisoSalarial8h,
                request.PisoSalarial6h,
                request.Ticket8h,
                request.Ticket6h,
                request.BenefInd8h,
                request.BenefInd6h,
                request.Reajuste,
                request.Observacoes,
                request.VigenciaInicio,
                request.VigenciaFinal,
                request.Cnpj,
                request.ConformeCargoFuncao,
                request.Arquivo != null ? request.Arquivo.Nome : null,
                request.Arquivo != null ? request.Arquivo.Tipo : null,
                request.Arquivo != null ? request.Arquivo.Base64 : null,
                request.Atalho);

            return Ok();
        }

    }
}
