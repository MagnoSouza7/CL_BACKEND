using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Dissidio.GetDissidioById
{
    public class GetDissidioById : IGetDissidioById
    {
        public async Task<object> Execute(int id)
        {
            using var context = new ApiContext();

            var dissidio = await context.Dissidios.AsNoTracking()
            .Include(x => x.Estado)
            .Include(x => x.Arquivo)
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();

            return dissidio;
        }
     
    }
    
}
