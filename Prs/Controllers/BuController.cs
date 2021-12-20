using Application.Repository.Bu;
using Domain.Entities;
using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prs.Controllers.Request.Bu;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Prs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BuController : ControllerBase
    {
        private readonly IBuRepository buRepository;

        public BuController(IBuRepository buRepository)
        {
            this.buRepository = buRepository;        
        }

        
        [HttpPost("GetAll")]
        [Authorize]
        public async Task<IActionResult> GetAllBu()
        {
            var bu = await buRepository.GetAllBu();

            return Ok(bu);
        }

        
        [HttpPost("GetById")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            var bus = await buRepository.GetByIdBu(id);

            return Ok(bus);
        }

        
        [HttpPost("Create")]
        [Authorize(Roles = "licitacao,administrador")]
        public async Task<IActionResult> Create(BuRequestCreate bu)
        {
            var bus = await buRepository.CreateBu(bu.Nome);

            return Ok(bus);
        }

        
        [HttpPut("Update")]
        [Authorize(Roles = "licitacao,administrador")]
        public async Task<IActionResult> Update(BuRequestUpdate bu)
        {
            var bus = await buRepository.UptadeBu(bu.Nome, bu.Ativo, bu.Id);
            
            return Ok(bus);
        }
    }
}
