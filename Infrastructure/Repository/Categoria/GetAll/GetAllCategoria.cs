using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Categoria.GetAll
{
    public class GetAllCategoria : IGetAllCategoria
    {
        public async Task<object> Execute()
        {
            using var context = new ApiContext();

            var categorias = await context.Categorias
                .Include(x => x.Bu)
                .AsNoTracking()
                .ToListAsync();

            return categorias;
        }
    }
}
