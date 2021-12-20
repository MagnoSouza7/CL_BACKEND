using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Empresa.Update
{
    public class UpdateEmpresa :IUpdateEmpresa
    {
        public async Task<object> Execute(string nome, int id, bool ativo)
        {
            using var context = new ApiContext();

            var empresaOld = await context.Empresas.AsNoTracking().Where(x => x.Id == id).SingleOrDefaultAsync();

            empresaOld.Nome = nome;
            empresaOld.Ativo = ativo;
            empresaOld.DataAtualizacao = DateTime.Now;

            context.Empresas.Update(empresaOld);
            await context.SaveChangesAsync();

            return empresaOld;

        }
    }
}
