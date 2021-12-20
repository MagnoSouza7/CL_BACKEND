using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Modalidade.GetById
{
    public class GetByIdModalidade : IGetByIdModalidade
    {
        public async Task<object> Execute(int id)
        {
            using var context = new ApiContext();

            var modalidade = await context.Modalidades
                .AsNoTracking()
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();

            if (modalidade != null)
                return modalidade;
            else
                return new { mensagem = "Modalidade não existe no Banco de Dados" };
        }
    }
}
