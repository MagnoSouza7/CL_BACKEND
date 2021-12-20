using Infrastructure.Repository.Modalidade.Update;
using Infrastructure.Repository.MotivoPerda.Create;
using Infrastructure.Repository.MotivoPerda.GetAll;
using Infrastructure.Repository.MotivoPerda.GetById;
using Infrastructure.Repository.MotivoPerda.Update;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.MotivoPerda
{
    public class MotivoPerdaRepository : IMotivoPerdaRepository
    {
        private readonly IGetAllMotivoPerda getAllMotivoPerda;
        private readonly IGetByIdMotivoPerda getByIdMotivoPerda;
        private readonly ICreateMotivoPerda createMotivoPerda;
        private readonly IUpdateMotivoPerda updateMotivoPerda;

        public MotivoPerdaRepository(IGetAllMotivoPerda getAllMotivoPerda, 
            IGetByIdMotivoPerda getByIdMotivoPerda, 
            ICreateMotivoPerda createMotivoPerda,
            IUpdateMotivoPerda updateMotivoPerda)
        {
            this.getAllMotivoPerda = getAllMotivoPerda;
            this.getByIdMotivoPerda = getByIdMotivoPerda;
            this.createMotivoPerda = createMotivoPerda;
            this.updateMotivoPerda = updateMotivoPerda;
        }

        public async Task<object> ICreateMotivoPerda(string nome)
        {
            return await createMotivoPerda.Execute(nome);
        }

        public async Task<object> IGetAllMotivoPerda()
        {
            return await getAllMotivoPerda.Execute();
        }

        public async Task<object> IGetByIdMotivoPerda(int id)
        {
            return await getByIdMotivoPerda.Execute(id);
        }

        public async Task<object> IUpdateMotivoPerda(string nome, int id, bool ativo)
        {
            return await updateMotivoPerda.Execute(nome, id, ativo);
        }
    }
}
