using Infrastructure.Repository.Bu.Create;
using Infrastructure.Repository.Bu.GetAll;
using Infrastructure.Repository.Bu.GetById;
using Infrastructure.Repository.Bu.Update;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.Bu
{
    public class BuRepository : IBuRepository
    {
        private readonly IGetAllBu getAllBu;
        private readonly IGetByIdBu getByIdBu;
        private readonly ICreateBu createBu;
        private readonly IUpdateBu updateBu;
        public BuRepository(IGetAllBu getAllBu, IGetByIdBu getByIdBu, ICreateBu createBu, IUpdateBu updateBu ) 
        {
            this.getAllBu = getAllBu;
            this.getByIdBu = getByIdBu;
            this.createBu = createBu;
            this.updateBu = updateBu;
        }

        public async Task<object> CreateBu(string nome)
        {
            return await createBu.Execute(nome);
        }

        public async Task<object> GetAllBu()
        {
            return await getAllBu.Execute();
        }

        public async Task<object> GetByIdBu(int id)
        {
            return await getByIdBu.Execute(id);
        }

        public async Task<object> UptadeBu(string nome, bool ativo, int id)
        {
            return await updateBu.Execute(nome, ativo, id);
        }
    }
}
