using Application.Repository.Email;
using Email;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Prs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailRepository emailRepository;
        
        public EmailController(IEmailRepository emailRepository)
        {
            this.emailRepository = emailRepository;
        }

        
        [HttpPost("SendTestEmail")]
        [Authorize(Roles = "administrador")]
        public IActionResult SendTestEmail(string nome, string email, string assunto, string conteudo)
        {
            EmailService.EnviarCustom(nome, email, assunto, conteudo);

            return Ok();
        }

        
        [HttpPost("SendTestEmailEdital")]
        [Authorize(Roles = "administrador")]
        public async Task<IActionResult> SendTestEmailEditalAsync(string nome, string email, int editalId)
        {
            var edital = await emailRepository.GetByIdEdital(editalId);

            EmailService.EnviarEmailNotificacaoSobreEdital(nome, email, edital);

            return Ok();
        }
    }
}
