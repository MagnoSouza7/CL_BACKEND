using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Cliente.GetById
{
    public class GetByIdCliente : IGetByIdCliente
    {
        public async Task<object> Execute(int id)
        {
            using var context = new ApiContext();

            var cliente = await context.Clientes.AsNoTracking().Where(x => x.Id == id).SingleOrDefaultAsync();

            return (cliente);

        }
    }
}
