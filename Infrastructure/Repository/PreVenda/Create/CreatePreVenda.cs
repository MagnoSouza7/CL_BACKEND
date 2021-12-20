using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.PreVenda.Create
{
    public class CreatePreVenda : ICreatePreVenda
    {
        public async Task<object> Execute(int usuarioId)
        {
            using var context = new ApiContext();

            var preVendaNew = new Domain.Entities.PreVenda
            {
                Usuario = await context.Usuarios.Where(x => x.Id == usuarioId).SingleOrDefaultAsync(),
                Ativo = true,
                DataCriacao = DateTime.Now,
                DataAtualizacao = DateTime.Now
            };

            context.PreVendas.Add(preVendaNew);
            await context.SaveChangesAsync();

            return preVendaNew;
        }
    }
}
