using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Modalidade.Create
{
    public class CreateModalidade : ICreateModalidade
    {
        public async Task<object> Execute(string nome)
        {
            using var context = new ApiContext();

            var modalidade = new Domain.Entities.Modalidade
            {
                Nome = nome,
                Ativo = true,
                DataCriacao = DateTime.Now,
                DataAtualizacao = DateTime.Now
            };

            await context.Modalidades.AddAsync(modalidade);

            await context.SaveChangesAsync();

            return modalidade;

        }
    }
}
