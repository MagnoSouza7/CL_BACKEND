using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Edital.GetDadosCadastrarEdital
{
    public class GetDadosCadastrarEdital : IGetDadosCadastrarEdital
    {
        public async Task<object> Execute()
        {
            using var context = new ApiContext();

            var clientes = await context.Clientes.AsNoTracking().Where(x => x.Ativo).OrderBy(x => x.Nome).ToListAsync();
            var modalidades = await context.Modalidades.AsNoTracking().Where(x => x.Ativo).OrderBy(x => x.Nome).ToListAsync();
            var regioes = await context.Regioes.AsNoTracking().Where(x => x.Ativo).OrderBy(x => x.Nome).ToListAsync();
            var estados = await context.Estados.AsNoTracking().Where(x => x.Ativo).OrderBy(x => x.Nome).ToListAsync();
            var portais = await context.Portais.AsNoTracking().Where(x => x.Ativo).OrderBy(x => x.Nome).ToListAsync();
            var categorias = await context.Categorias.AsNoTracking().Where(x => x.Ativo).OrderBy(x => x.Nome).ToListAsync();
            var bus = await context.Bus.AsNoTracking().Where(x => x.Ativo).OrderBy(x => x.Nome).ToListAsync();
            var gerentes = await context.Usuarios.AsNoTracking().Where(x => x.Ativo).OrderBy(x => x.Nome).ToListAsync();
            var diretores = await context.Usuarios.AsNoTracking().Where(x => x.Ativo).OrderBy(x => x.Nome).ToListAsync();
            var empresas = await context.Empresas.AsNoTracking().Where(x => x.Ativo).OrderBy(x => x.Nome).ToListAsync();

            return new
            {
                clientes,
                modalidades,
                regioes,
                estados,
                portais,
                categorias,
                bus,
                gerentes,
                diretores,
                empresas
            };
        }
    }
}
