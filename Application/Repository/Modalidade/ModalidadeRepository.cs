using Infrastructure.Repository.Modalidade.Create;
using Infrastructure.Repository.Modalidade.GetAll;
using Infrastructure.Repository.Modalidade.GetById;
using Infrastructure.Repository.Modalidade.Update;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.Modalidade
{
    public class ModalidadeRepository : IModalidadeRepository
    {
        private readonly IGetAllModalidade getAllModalidade;
        private readonly IGetByIdModalidade getByIdModalidade;
        private readonly ICreateModalidade createModalidade;
        private readonly IUpdateModalidade updateModalidade;

        public ModalidadeRepository(
            IGetAllModalidade getAllModalidade,
            IGetByIdModalidade getByIdModalidade,
            ICreateModalidade crateModalidade,
            IUpdateModalidade updateModalidade)
        {
            this.getAllModalidade = getAllModalidade;
            this.getByIdModalidade = getByIdModalidade;
            this.createModalidade = crateModalidade;
            this.updateModalidade = updateModalidade;
        }

        public Task<object> Create(string nome)
        {
            return createModalidade.Execute(nome);
        }

        public Task<object> GetAll()
        {
            return getAllModalidade.Execute();
        }

        public Task<object> GetById(int id)
        {
            return getByIdModalidade.Execute(id);
        }

        public Task<object> Update(int id, string nome, bool ativo)
        {
            return updateModalidade.Execute(id, nome, ativo);
        }
    }
}
