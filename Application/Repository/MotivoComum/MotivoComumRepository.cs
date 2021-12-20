using Infrastructure.Repository.MotivoComum.CreateMotivoComum;
using Infrastructure.Repository.MotivoComum.GetAllMotivoComum;
using Infrastructure.Repository.MotivoComum.GetByIdMotivoComum;
using Infrastructure.Repository.MotivoComum.UpdateMotivoComum;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.MotivoComum
{
    public class MotivoComumRepository : IMotivoComumRepository
    {
        private readonly IGetAllMotivoComum getAllMotivoComum;
        private readonly IGetByIdMotivoComum getByIdMotivoComum;
        private readonly ICreateMotivoComum createMotivoComum;
        private readonly IUpdateMotivoComum updateMotivoComum;


        public MotivoComumRepository(IGetAllMotivoComum getAllMotivoComum, 
            IGetByIdMotivoComum getByIdMotivoComum,
            ICreateMotivoComum createMotivoComum,
            IUpdateMotivoComum updateMotivoComum)
        {
            this.getAllMotivoComum = getAllMotivoComum;
            this.getByIdMotivoComum = getByIdMotivoComum;
            this.createMotivoComum = createMotivoComum;
            this.updateMotivoComum = updateMotivoComum;
        }

        public Task<object> CreateMotivoComum(string nome)
        {
            return createMotivoComum.Execute(nome);
        }

        public async Task<object> GetAllMotivoComum()
        {
            return await getAllMotivoComum.Execute();
        }

        public Task<object> GetByIdMotivoComum(int id)
        {
            return getByIdMotivoComum.Execute(id);
        }

        public Task<object> UpdateMotivoComum(string nome, bool ativo, int id)
        {
            return updateMotivoComum.Execute(nome, ativo, id);
        }
    }
}
