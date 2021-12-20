using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Cliente.GetAllClientes
{
    public class GetAllClientes : IGetAllClientes
    {
        public async Task<object> Execute() {
            using var context = new ApiContext();

            var clientes = await context.Clientes.AsNoTracking().ToListAsync();
            
            return clientes;
        }
}
}
