using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Portal.GetById
{
    public class GetByIdPortal : IGetByIdPortal
    {
        public async Task<object> Execute(int id)
        {
            using var context = new ApiContext();

            var portal = await context.Portais.AsNoTracking().Where(x => x.Ativo && x.Id == id).SingleOrDefaultAsync();

            return portal;
        }
    }
}
