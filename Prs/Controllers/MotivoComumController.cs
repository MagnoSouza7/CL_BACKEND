using Application.Repository.MotivoComum;
using Domain.Entities;
using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prs.Controllers.Request.MotivoComum;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Prs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MotivoComumController : ControllerBase
    {
        private IMotivoComumRepository motivoComumRepository;

        public MotivoComumController(IMotivoComumRepository motivoComumRepository)
        {
            this.motivoComumRepository = motivoComumRepository;
        }

        [HttpPost("GetAll")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {

            var motivo = await motivoComumRepository.GetAllMotivoComum();
            return Ok(motivo);
        }

        [HttpPost("GetById")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {

            var motivo = await motivoComumRepository.GetByIdMotivoComum(id);
            return Ok(motivo);
        }

        [HttpPost("Create")]
        [Authorize(Roles = "licitacao,administrador")]
        public async Task<IActionResult> Create(MotivoComumRequestCreate motivo)
        {
            var motivoNew = await motivoComumRepository.CreateMotivoComum(motivo.Nome);
            return Ok(motivoNew);
        }

        [HttpPut("Update")]
        [Authorize(Roles = "licitacao,administrador")]
        public async Task<IActionResult> Update(MotivoComumRequestUpdate motivo)
        {
            var motivoOld = await motivoComumRepository.UpdateMotivoComum(motivo.Nome, motivo.Ativo, motivo.Id);
            return Ok(motivoOld);
        }
    }
}
