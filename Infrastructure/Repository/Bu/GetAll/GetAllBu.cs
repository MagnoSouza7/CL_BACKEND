using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Bu.GetAll
{
    public class GetAllBu : IGetAllBu
    { 
        public async Task<object> Execute()
        {
            using var context = new ApiContext();

            var bus = await context.Bus.AsNoTracking().ToListAsync();

            return bus;
        }
    }
}