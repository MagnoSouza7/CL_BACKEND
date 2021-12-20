using Infrastructure.Repository.CarteiraConta.CreateCarteiraConta;
using Infrastructure.Repository.CarteiraConta.DeleteCarteiraConta;
using Infrastructure.Repository.CarteiraConta.DeleteGerenteCarteiraConta;
using Infrastructure.Repository.CarteiraConta.DeleteGerenteComCarteira;
using Infrastructure.Repository.CarteiraConta.GetAllCarteiraContas;
using Infrastructure.Repository.CarteiraConta.GetFormCarteiraConta;
using System.Threading.Tasks;

namespace Application.Repository.CarteiraConta
{
    public class CarteiraContaRepository : ICarteiraContaRepository
    {
        private readonly IGetAllCarteiraContas getAllCarteiraContas;
        private readonly ICreateCarteiraConta createCarteiraConta;
        private readonly IDeleteCarteiraConta deleteCarteiraConta;
        private readonly IGetFormCarteiraConta getFormCarteiraConta;
        private readonly IDeleteGerenteCarteiraConta deleteGerenteCarteiraConta;
        private readonly IDeleteGerenteComCarteiraConta deleteGerenteComCarteiraConta;

        public CarteiraContaRepository(
            IGetAllCarteiraContas getAllCarteiraContas,
            ICreateCarteiraConta createCarteiraConta,
            IDeleteCarteiraConta deleteCarteiraConta,
            IGetFormCarteiraConta getFormCarteiraConta,
            IDeleteGerenteCarteiraConta deleteGerenteCarteiraConta,
            IDeleteGerenteComCarteiraConta deleteGerenteComCarteiraConta)
        {
            this.getAllCarteiraContas = getAllCarteiraContas;
            this.createCarteiraConta = createCarteiraConta;
            this.deleteCarteiraConta = deleteCarteiraConta;
            this.getFormCarteiraConta = getFormCarteiraConta;
            this.deleteGerenteCarteiraConta = deleteGerenteCarteiraConta;
            this.deleteGerenteComCarteiraConta = deleteGerenteComCarteiraConta;
        }

        public async Task<object> GetFormCarteiraConta()
        {
            return await getFormCarteiraConta.Execute();
        }

        public async Task<object> GetAllCarteiraContas()
        {
            return await getAllCarteiraContas.Execute();
        }

        public async Task CreateCarteiraConta(int gerenteId, int clienteId)
        {
            await createCarteiraConta.Execute(gerenteId, clienteId);
        }

        public async Task DeleteCarteiraConta(int id)
        {
            await deleteCarteiraConta.Execute(id);
        }

        public async Task<object> DeleteGerenteCarteiraConta(int id)
        {
            return await deleteGerenteCarteiraConta.Execute(id);
        }

        public async Task<object> DeleteGerenteComCarteiraConta(int id)
        {
            return await deleteGerenteComCarteiraConta.Execute(id);
        }
    }
}
