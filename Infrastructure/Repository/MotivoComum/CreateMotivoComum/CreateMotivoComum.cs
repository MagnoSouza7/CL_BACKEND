using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.MotivoComum.CreateMotivoComum
{
    public class CreateMotivoComum : ICreateMotivoComum
    {
        public async Task<object> Execute(string nome)
        {
            using var context = new ApiContext();

            var motivo = new Domain.Entities.MotivosComum
            {
                Nome = nome,
                Ativo = true,
                DataCriacao = DateTime.Now,
                DataAtualizacao = DateTime.Now
            };

            context.MotivosComuns.Add(motivo);
            await context.SaveChangesAsync();

            return motivo;

        }
    }
}
