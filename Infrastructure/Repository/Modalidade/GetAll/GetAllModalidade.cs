using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Modalidade.GetAll
{
    public class GetAllModalidade : IGetAllModalidade
    {
        public async Task<object> Execute()
        {
            using var context = new ApiContext();

            var modalidade = await context.Modalidades
                .AsNoTracking()
                .ToListAsync();

            return modalidade;
        }
    }
}
