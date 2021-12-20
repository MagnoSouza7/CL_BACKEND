using Infrastructure.Repository.Empresa.Create;
using Infrastructure.Repository.Empresa.GetAll;
using Infrastructure.Repository.Empresa.GetById;
using Infrastructure.Repository.Empresa.Update;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.Empresa
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly IGetAllEmpresa getAllEmpresa;
        private readonly IGetByIdEmpresa getByIdEmpresa;
        private readonly ICreateEmpresa createEmpresa;
        private readonly IUpdateEmpresa updateEmpresa;

        public EmpresaRepository(
            IGetAllEmpresa getAllEmpresa,
            IGetByIdEmpresa getByIdEmpresa,
            ICreateEmpresa createEmpresa,
            IUpdateEmpresa updateEmpresa)
        {
            this.getAllEmpresa = getAllEmpresa;
            this.getByIdEmpresa = getByIdEmpresa;
            this.createEmpresa = createEmpresa;
            this.updateEmpresa = updateEmpresa;

        }

        public async Task<object> CreateEmpresa(string nome)
        {
            return await createEmpresa.Execute(nome);
        }

        public async Task<object> GetAllEmpresa()
        {
            return await getAllEmpresa.Execute();
        }

        public async Task<object> GetByIdEmpresa(int id)
        {
            return await getByIdEmpresa.Execute(id);
        }

        public async Task<object> UpdateEmpresa(string nome, int id, bool ativo)
        {
            return await updateEmpresa.Execute(nome, id, ativo);
        }
    }
}
