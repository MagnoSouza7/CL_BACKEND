using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Empresa.GetAll
{
    public class GetAllEmpresa :IGetAllEmpresa
    {
        public async Task<object> Execute()
        {
            using var context = new ApiContext();

            var empresa = await context.Empresas.AsNoTracking().ToListAsync();

            return empresa;
        }
    }
}
