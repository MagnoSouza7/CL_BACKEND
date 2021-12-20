using Infrastructure.Repository.Anexo.ConversorTemp;
using Infrastructure.Repository.Anexo.Create;
using Infrastructure.Repository.Anexo.GetById;
using Infrastructure.Repository.Anexo.Update;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.Anexo
{
    public class AnexoRepository : IAnexoRepository
    {
        private readonly IConversorTemp conversorTemp;
        private readonly IGetByIdAnexo getById;
        private readonly ICreateAnexo createAnexo;
        private readonly IUpdateAnexo updateAnexo;

        public AnexoRepository(
            IConversorTemp conversorTemp,
            IGetByIdAnexo getById,
            ICreateAnexo createAnexo,
            IUpdateAnexo updateAnexo)
        {
            this.conversorTemp = conversorTemp;
            this.getById = getById;
            this.createAnexo = createAnexo;
            this.updateAnexo = updateAnexo;
        }

        public async Task ComversorTemp()
        {
            await conversorTemp.Execute();
        }

        public Domain.Entities.Anexo Create(string nome, string tipo, byte[] base64)
        {
            return createAnexo.Execute(nome, tipo, base64);
        }

        public Domain.Entities.Anexo Execute(int id, string nome, string tipo, byte[] base64, bool ativo)
        {
            return updateAnexo.Execute(id, nome, tipo, base64, ativo);
        }

        public async Task<Domain.Entities.Anexo> GetById(int id)
        {
            return await getById.Execute(id);
        }
    }
}
