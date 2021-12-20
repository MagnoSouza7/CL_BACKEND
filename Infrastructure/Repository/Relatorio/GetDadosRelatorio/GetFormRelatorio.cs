using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Relatorio.GetDadosRelatorio
{
    public class GetFormRelatorio : IGetFormRelatorio
    {
        public async Task<object> Execute()
        {
            using var context = new ApiContext();

            var clientes = await context.Clientes.AsNoTracking().Where(x => x.Ativo).OrderBy(x => x.Nome).ToListAsync();
            var modalidades = await context.Modalidades.AsNoTracking().Where(x => x.Ativo).OrderBy(x => x.Nome).ToListAsync();
            var portais = await context.Portais.AsNoTracking().Where(x => x.Ativo).OrderBy(x => x.Nome).ToListAsync();
            var usuarios = await context.Usuarios.AsNoTracking().Where(x => x.Ativo).OrderBy(x => x.Nome).ToListAsync();
            var preVendas = await context.PreVendas.Include(x => x.Usuario).AsNoTracking().Where(x => x.Ativo && x.Usuario.Ativo).OrderBy(x => x.Usuario.Nome).ToListAsync();
            var empresas = await context.Empresas.AsNoTracking().Where(x => x.Ativo).OrderBy(x => x.Nome).ToListAsync();
            var motivosComuns = await context.MotivosComuns.AsNoTracking().Where(x => x.Ativo).OrderBy(x => x.Nome).ToListAsync();
            var motivosPerdas = await context.MotivosPerdas.AsNoTracking().Where(x => x.Ativo).OrderBy(x => x.Nome).ToListAsync();
            var concorrentes = await context.Concorrentes.AsNoTracking().Where(x => x.Ativo).OrderBy(x => x.Nome).ToListAsync();
            var regioes = await context.Regioes.AsNoTracking().Where(x => x.Ativo).OrderBy(x => x.Nome).ToListAsync();
            var estados = await context.Estados.AsNoTracking().Where(x => x.Ativo).OrderBy(x => x.Nome).ToListAsync();
            var categorias = await context.Categorias.AsNoTracking().Where(x => x.Ativo).OrderBy(x => x.Nome).ToListAsync();
            var bus = await context.Bus.AsNoTracking().Where(x => x.Ativo).OrderBy(x => x.Nome).ToListAsync();

            return new
            {
                clientes,
                modalidades,
                portais,
                usuarios,
                preVendas,
                empresas,
                motivosComuns,
                motivosPerdas,
                concorrentes,
                regioes,
                estados,
                categorias,
                bus
            };
        }
    }
}
