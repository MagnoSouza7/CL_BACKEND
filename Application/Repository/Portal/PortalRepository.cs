using Infrastructure.Repository.Portal.Create;
using Infrastructure.Repository.Portal.GetAll;
using Infrastructure.Repository.Portal.GetById;
using Infrastructure.Repository.Portal.Update;
using System.Threading.Tasks;

namespace Application.Repository.Portal
{
    public class PortalRepository : IPortalRepository
    {
        private readonly IGetAllPortal getAllPortal;
        private readonly IGetByIdPortal getByIdPortal;
        private readonly ICreatePortal createPortal;
        private readonly IUpdatePortal updatePortal;

        public PortalRepository(
            IGetAllPortal getAllPortal,
            IGetByIdPortal getByIdPortal,
            ICreatePortal createPortal,
            IUpdatePortal updatePortal)
        {
            this.getAllPortal = getAllPortal;
            this.getByIdPortal = getByIdPortal;
            this.createPortal = createPortal;
            this.updatePortal = updatePortal;
        }

        public async Task<object> CreatePortal(string nome, bool ativo)
        {
            return await createPortal.Execute(nome, ativo);
        }

        public async Task<object> GetAllPortal()
        {
            return await getAllPortal.Execute();
        }

        public async Task<object> GetByIdPortal(int id)
        {
            return await getByIdPortal.Execute(id);
        }

        public async Task<object> UpdatePortal(int id, string nome, bool ativo)
        {
            return await updatePortal.Execute(id, nome, ativo);
        }
    }
}
