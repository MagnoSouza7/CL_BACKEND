using Application.Repository.Comentario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prs.Controllers.Request.Comentario;
using System.Threading.Tasks;

namespace Prs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ComentarioController : ControllerBase
    {
        private readonly IComentarioRepository comentarioRepository;

        public ComentarioController(IComentarioRepository comentarioRepository)
        {
            this.comentarioRepository = comentarioRepository;

        }
        
        [HttpPost("Getlast")]
        [Authorize]
        public async Task<IActionResult> GetLast(int editalId)
        {

            var comentario = await comentarioRepository.IGetLastComentario(editalId);

            return Ok(comentario);
        }

        
        [HttpPost("GetById")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            var comentario = await comentarioRepository.IGetByIdComentario(id);

            return Ok(comentario);
        }

        
        [HttpPost("Create")]
        [Authorize(Roles = "administrador")]
        public async Task<IActionResult> Create(ComentarioCreate comentario)
        {

            var comentarioNew = await comentarioRepository.ICreateComentario(comentario.Mensagem, comentario.Usuario, comentario.EditalId);

            return Ok(comentarioNew);
        }

        
        [HttpPut("Update")]
        [Authorize]
        public async Task<IActionResult> Update(ComentarioUpdate comentario)
        {
            var comentarioOld = await comentarioRepository.IUpdateComentario(comentario.Id, comentario.Mensagem,comentario.Usuario, comentario.Ativo);

            return Ok(comentarioOld);
        }

        
        [HttpDelete("Delete")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var comentarioDelete = await comentarioRepository.IDeleteComentario(id);

            return Ok(comentarioDelete);
        }
    }
}
