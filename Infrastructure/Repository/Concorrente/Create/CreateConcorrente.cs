using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Concorrente.Create
{
    public class CreateConcorrente : ICreateConcorrente
    {
        public async Task<object> Execute(string nome, string apelido, string cnpj)
        {
            using var context = new ApiContext();

            var concorrente = new Domain.Entities.Concorrente
            {
                Nome = nome,
                Apelido = apelido,
                Cnpj = cnpj,
                Ativo = true,
                DataCriacao = DateTime.Now,
                DataAtualizacao = DateTime.Now
            };

            await context.Concorrentes.AddAsync(concorrente);

            await context.SaveChangesAsync();

            return concorrente;
        }
    }
}
