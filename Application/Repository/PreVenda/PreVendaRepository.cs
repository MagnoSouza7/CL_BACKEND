using Infrastructure.Repository.PreVenda.Create;
using Infrastructure.Repository.PreVenda.GetAll;
using Infrastructure.Repository.PreVenda.GetDadosPreVenda;
using Infrastructure.Repository.PreVenda.Update;
using Infrastructure.Repository.PreVenda.VerifyPreVenda;
using System.Threading.Tasks;

namespace Application.Repository.PreVenda
{
    public class PreVendaRepository : IPreVendaRepository
    {
        private readonly IGetAllPreVenda getAllPreVenda;
        private readonly IGetDadosPreVenda getDadosPreVenda;
        private readonly IVerifyPreVenda verifyPreVenda;
        private readonly ICreatePreVenda createPreVenda;
        private readonly IUpdatePreVenda updatePreVenda;

        public PreVendaRepository(
            IGetAllPreVenda getAllPreVenda,
            IGetDadosPreVenda getDadosPreVenda,
            IVerifyPreVenda verifyPreVenda,
            ICreatePreVenda createPreVenda,
            IUpdatePreVenda updatePreVenda)
        {
            this.getAllPreVenda = getAllPreVenda;
            this.getDadosPreVenda = getDadosPreVenda;
            this.verifyPreVenda = verifyPreVenda;
            this.createPreVenda = createPreVenda;
            this.updatePreVenda = updatePreVenda;
        }

        public async Task<object> CreatePreVenda(int usuarioId)
        {
            return await createPreVenda.Execute(usuarioId);
        }

        public async Task<object> GetAllPreVenda()
        {
            return await getAllPreVenda.Execute();
        }

        public async Task<object> GetDadosPreVenda()
        {
            return await getDadosPreVenda.Execute();
        }

        public async Task<object> UpdatePreVenda(int id, int usuarioId, bool ativo)
        {
            return await updatePreVenda.Execute(id, usuarioId, ativo);
        }

        public async Task<object> VerifyPreVenda(int id)
        {
            return await verifyPreVenda.Execute(id);
        }
    }
}
