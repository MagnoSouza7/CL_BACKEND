using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Categoria.Create
{
    public class CreateCategoria : ICreateCategoria
    {
        public async Task<object> Execute(string nome, int BuId)
        {
            using var context = new ApiContext();

            var categoria = new Domain.Entities.Categoria
            {
                Nome = nome,
                Bu = await context.Bus.Where(x => x.Id == BuId).SingleOrDefaultAsync(),
                Ativo = true,
                DataAtualizacao = DateTime.Now,
                DataCriacao = DateTime.Now
            };

            await context.Categorias.AddAsync(categoria);

            await context.SaveChangesAsync();

            return categoria;
        }
    }
}
