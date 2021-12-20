using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Categoria.Update
{
    public class UpdateCategoria : IUpdateCategoria
    {
        public async Task<object> Execute(int id, string nome, int BuId, bool ativo)
        {
            using var context = new ApiContext();

            var categoriaOld = await context.Categorias
                .AsTracking()
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();

            categoriaOld.Nome = nome;
            categoriaOld.Bu = await context.Bus.FirstOrDefaultAsync(x => x.Id == BuId);
            categoriaOld.Ativo = ativo;
            categoriaOld.DataAtualizacao = DateTime.Now;

            context.Categorias.Update(categoriaOld);

            await context.SaveChangesAsync();

            return categoriaOld;
        }
    }
}
