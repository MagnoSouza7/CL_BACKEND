using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Empresa.GetById
{
    public class GetByIdEmpresa : IGetByIdEmpresa
    {
        
        public async Task<object> Execute(int id)
        {
            using var context = new ApiContext();

            var empresas = await context.Empresas.AsNoTracking().Where(x => x.Id == id).SingleOrDefaultAsync();

            return empresas;
        }
    }
}
