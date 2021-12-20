using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Modalidade.Update
{
    public class UpdateModalidade : IUpdateModalidade
    {
        public async Task<object> Execute(int id, string nome, bool ativo)
        {
            using var context = new ApiContext();

            var modalidade = await context.Modalidades
                .AsTracking()
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();

            modalidade.Nome = nome;
            modalidade.Ativo = ativo;
            modalidade.DataAtualizacao = DateTime.Now;

            context.Modalidades.Update(modalidade);

            await context.SaveChangesAsync();

            return modalidade;
        }
    }
}
