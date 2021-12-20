using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.MotivoPerda.Create
{
    public class CreateMotivoPerda : ICreateMotivoPerda
    {
        public async Task<object> Execute(string nome)
        {
            using var context = new ApiContext();
            
            var motivo = new Domain.Entities.MotivosPerda
            {
                Nome = nome,
                Ativo = true,
                DataCriacao = DateTime.Now,
                DataAtualizacao = DateTime.Now
            };

            context.MotivosPerdas.Add(motivo);
            await context.SaveChangesAsync();

            return motivo;

        }
    }
}
