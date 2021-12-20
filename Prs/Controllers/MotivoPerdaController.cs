using Application.Repository.MotivoComum;
using Application.Repository.MotivoPerda;
using Domain.Entities;
using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prs.Controllers.Request.MotivoPerda;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Prs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MotivoPerdaController : ControllerBase
    {
        private readonly IMotivoPerdaRepository motivoPerdaRepository;

        public MotivoPerdaController(IMotivoPerdaRepository motivoPerdaRepository)
        {
            this.motivoPerdaRepository = motivoPerdaRepository;
        }

        [HttpPost("GetAll")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {

            var motivo = await motivoPerdaRepository.IGetAllMotivoPerda();

            return Ok(motivo);
        }

        [HttpPost("GetById")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {

            var motivo = await motivoPerdaRepository.IGetByIdMotivoPerda(id);

            return Ok(motivo);
        }

        [HttpPost("Create")]
        [Authorize(Roles = "licitacao,administrador")]
        public async Task<IActionResult> Create(MotivoPerdaRequestCreate motivoPerda)
        {
            var motivoNew = await motivoPerdaRepository.ICreateMotivoPerda(motivoPerda.Nome);

            return Ok(motivoNew);
        }

        [HttpPut("Update")]
        [Authorize(Roles = "licitacao,administrador")]
        public async Task<IActionResult> Update(MotivoPerdaRequestUpdate motivoPerda)
        {
            var motivoOld = await motivoPerdaRepository.IUpdateMotivoPerda(motivoPerda.Nome, motivoPerda.Id, motivoPerda.Ativo);

            return Ok(motivoOld);
        }
    }
}
