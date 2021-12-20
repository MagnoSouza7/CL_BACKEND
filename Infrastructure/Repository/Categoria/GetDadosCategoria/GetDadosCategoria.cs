using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Categoria.GetDadosCategoria
{
    public class GetDadosCategoria : IGetDadosCategoria
    {
        public async Task<object> Execute()
        {
            using var context = new ApiContext();

            var bus = await context.Bus.AsNoTracking().Where(x => x.Ativo).ToListAsync();

            return bus;
        }
    }
}
