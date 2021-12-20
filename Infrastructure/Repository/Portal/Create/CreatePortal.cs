using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Portal.Create
{
    public class CreatePortal : ICreatePortal
    {
        public async Task<object> Execute(string nome, bool ativo)
        {
            using var context = new ApiContext();

            var portalNew = new Domain.Entities.Portal
            {
                Nome = nome,
                Ativo = true,
                DataCriacao = DateTime.Now,
                DataAtualizacao = DateTime.Now
            };

            context.Portais.Add(portalNew);
            await context.SaveChangesAsync();

            return portalNew;
        }
    }
}
