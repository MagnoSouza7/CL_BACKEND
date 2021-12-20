using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Cliente.Create
{
    public class CreateCliente : ICreateCliente
    {
        public async Task<object> Execute(string nome, string apelido, string cnpj)
        {
            using var context = new ApiContext();

            var clienteNew = new Domain.Entities.Cliente
            {
                Nome = nome,
                Apelido = apelido,
                Cnpj = cnpj,
                Ativo = true,
                DataCriacao = DateTime.Now,
                DataAtualizacao = DateTime.Now
            };

            context.Clientes.Add(clienteNew);
            await context.SaveChangesAsync();

            return clienteNew;
        }
    }
}
