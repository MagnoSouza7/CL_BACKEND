using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Cliente.GetByName
{
    public class GetByNameCliente : IGetByNameCliente
    {
        public async Task<object> Execute(string nome)
        {
            using var context = new ApiContext();

            var cliente = await context.Clientes.AsNoTracking().Where(x => x.Nome.ToLower()
            .Contains(nome.ToLower()))
            .ToListAsync();

            return (cliente);

        }
    }
}
