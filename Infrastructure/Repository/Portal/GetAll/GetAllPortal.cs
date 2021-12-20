using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Portal.GetAll
{
    public class GetAllPortal : IGetAllPortal
    {
        public async Task<object> Execute()
        {
            using var context = new ApiContext();

            var portal = await context.Portais.AsNoTracking().ToListAsync();

            return portal;
        }
    }
}
