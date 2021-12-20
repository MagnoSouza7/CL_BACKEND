using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Concorrente.Update
{
    public class UpdateConcorrente : IUpdateConcorrente
    {
        public async Task<object> Execute(int id, string nome, string apelido, string cnpj, bool ativo)
        {
            using var context = new ApiContext();

            var concorrente = await context.Concorrentes
                .AsTracking()
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();

            concorrente.Nome = nome;
            concorrente.Apelido = apelido;
            concorrente.Cnpj = cnpj;
            concorrente.Ativo = ativo;
            concorrente.DataAtualizacao = DateTime.Now;

            context.Concorrentes.Update(concorrente);

            await context.SaveChangesAsync();

            return concorrente;
        }
    }
}
