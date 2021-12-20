using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Cliente.Update
{
    public class UpdateCliente : IUpdateCliente
    {
        public async Task<object> Execute(string nome, string apelido, string cnpj, bool ativo, int id)
        {
            using var context = new ApiContext();

            var clienteOld = await context.Clientes.AsTracking().Where(x => x.Id == id)
                .SingleOrDefaultAsync();

            clienteOld.Nome = nome;
            clienteOld.Apelido = apelido;
            clienteOld.Cnpj = cnpj;
            clienteOld.Ativo = ativo;
            clienteOld.DataAtualizacao = DateTime.Now;

            context.Clientes.Update(clienteOld);
            await context.SaveChangesAsync();

            return clienteOld;
        }
    }
}
