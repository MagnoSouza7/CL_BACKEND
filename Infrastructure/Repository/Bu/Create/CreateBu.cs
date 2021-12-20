using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Bu.Create
{
    public class CreateBu : ICreateBu
    {
        public async Task<object> Execute(string nome)
        {
            using var context = new ApiContext();
            {
                var buNew = new Domain.Entities.Bu
                {
                    Nome = nome,
                    Ativo = true,
                    DataCriacao = DateTime.Now,
                    DataAtualizacao = DateTime.Now
                };

                context.Bus.Add(buNew);

                await context.SaveChangesAsync();

                return buNew;
            }
        }
    }
}
