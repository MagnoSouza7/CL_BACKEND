using Application.Repository.Categoria;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prs.Controllers.Request.Categoria;
using System.Threading.Tasks;

namespace Prs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepository categoriaRepository;

        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            this.categoriaRepository = categoriaRepository;
        }
        
        [HttpPost("GetAll")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            return Ok( await categoriaRepository.GetAll() );
        }

        
        [HttpPost("GetDadosCategoria")]
        [Authorize]
        public async Task<IActionResult> GetDadosCategoria()
        {
            return Ok( await categoriaRepository.GetDadosCategoria() );
        }

        
        [HttpPost("GetById")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok( await categoriaRepository.GetById(id) );
        }

        
        [HttpPost("Create")]
        [Authorize(Roles = "administrador")]
        public async Task<IActionResult> Create(CategoriaRequestCreate categoria)
        {
            var categoriaNew = await categoriaRepository.Create(categoria.Nome, categoria.BuId);

            return Ok(categoriaNew);
        }

        
        [HttpPut("Update")]
        [Authorize(Roles = "administrador")]
        public async Task<IActionResult> Update(CategoriaRequestUpdate categoria)
        {
            var categoriaOld = await categoriaRepository.Update(
                categoria.Id,
                categoria.Nome,
                categoria.BuId,
                categoria.Ativo);

            return Ok(categoriaOld);
        }
    }
}
