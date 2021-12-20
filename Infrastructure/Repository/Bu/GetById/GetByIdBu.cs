using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Bu.GetById
{
    public class GetByIdBu : IGetByIdBu
    {

        public async Task<object> Execute(int id)
        {
            using var context = new ApiContext();

            var bus = await context.Bus.AsNoTracking().Where(x => x.Ativo && x.Id == id).SingleOrDefaultAsync();

            return bus;
        }
    }
}
