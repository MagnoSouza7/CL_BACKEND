using Application.Repository.Clientes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prs.Controllers.Request.Cliente;
using System.Threading.Tasks;

namespace Prs.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClientesRepository clientesRepository;


        public ClienteController(IClientesRepository clientesRepository)
        {
            this.clientesRepository = clientesRepository;
        }

        
        [HttpPost("GetAllClientes")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var cliente = await clientesRepository.GetAllClientes();

            return Ok(cliente);
        }

        
        [HttpPost("GetById")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {

            var cliente = await clientesRepository.GetByIdCliente(id);

            return Ok(cliente);
        }

        
        [HttpPost("GetByName")]
        [Authorize]
        public async Task<IActionResult> GetByName(string nome)
        {
            var cliente = await clientesRepository.GetByNameCliente(nome);

            return Ok(cliente);
        }

        
        [HttpPost("Create")]
        [Authorize(Roles = "licitacao,administrador")]
        public async Task<IActionResult> Create(ClienteRequestCreate cliente)
        {
            var clienteNew = await clientesRepository.CreateCliente(cliente.Nome, cliente.Apelido, cliente.Cnpj);

            return Ok(clienteNew);
        }

        
        [HttpPut("Update")]
        [Authorize(Roles = "licitacao,administrador")] 
        public async Task<IActionResult> Update(ClienteRequestUpdate cliente)
        {
            var clienteOld = await clientesRepository.UpdateCliente(cliente.Nome, cliente.Apelido, cliente.Cnpj, cliente.Ativo, cliente.Id);

            return Ok(clienteOld);
        }
    }
}
