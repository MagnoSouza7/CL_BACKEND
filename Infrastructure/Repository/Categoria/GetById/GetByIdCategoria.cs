using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Categoria.GetById
{
    public class GetByIdCategoria : IGetByIdCategoria
    {
        public async Task<object> Execute(int id)
        {
            using var context = new ApiContext();

            var categoria = await context.Categorias
                .Include(x => x.Bu)
                .AsNoTracking()
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();

            return categoria;
        }
    }
}
