using Application.Repository.Anexo;
using Domain.Entities;
using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prs.Controllers.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnexoController : ControllerBase
    {
        private readonly IAnexoRepository anexoRepository;

        public AnexoController(IAnexoRepository anexoRepository)
        {
            this.anexoRepository = anexoRepository;
        }

        
        [HttpPost("GetById")]
        [Authorize]
        public async Task<ActionResult<Anexo>> GetById(int id)
        {
            var anexo = await anexoRepository.GetById(id);

            if (anexo == null)
                return NotFound();

            return Ok(anexo);
        }

        
        [HttpPost("ConversorTemp")]
        [Authorize(Roles = "administrador")]
        public async Task<IActionResult> ConversorTemp()
        {
            await anexoRepository.ComversorTemp();

            return Ok();
        }
    }
}
