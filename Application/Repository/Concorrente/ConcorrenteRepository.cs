using Infrastructure.Repository.Concorrente.Create;
using Infrastructure.Repository.Concorrente.GetAll;
using Infrastructure.Repository.Concorrente.GetById;
using Infrastructure.Repository.Concorrente.GetByName;
using Infrastructure.Repository.Concorrente.Update;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.Concorrente
{
    public class ConcorrenteRepository : IConcorrenteRepository
    {
        private readonly IGetAllConcorrente getAllConcorrente;
        private readonly IGetByIdConcorrente getByIdConcorrente;
        private readonly IGetByNameConcorrente getByNameConcorrente;
        private readonly ICreateConcorrente createConcorrente;
        private readonly IUpdateConcorrente updateConcorrente;

        public ConcorrenteRepository(
            IGetAllConcorrente getAllConcorrente,
            IGetByIdConcorrente getByIdConcorrente,
            IGetByNameConcorrente getByNameConcorrente,
            ICreateConcorrente createConcorrente,
            IUpdateConcorrente updateConcorrente)
        {
            this.getAllConcorrente = getAllConcorrente;
            this.getByIdConcorrente = getByIdConcorrente;
            this.getByNameConcorrente = getByNameConcorrente;
            this.createConcorrente = createConcorrente;
            this.updateConcorrente = updateConcorrente;
        }

        public async Task<object> Create(string nome, string apelido, string cnpj)
        {
            return await createConcorrente.Execute(nome, apelido, cnpj);
        }

        public async Task<object> GetAll()
        {
            return await getAllConcorrente.Execute();
        }

        public async Task<object> GetById(int id)
        {
            return await getByIdConcorrente.Execute(id);
        }

        public async Task<object> GetByName(string nome)
        {
            return await getByNameConcorrente.Execute(nome);
        }

        public async Task<object> Update(int id, string nome, string apelido, string cnpj, bool ativo)
        {
            return await updateConcorrente.Execute(id, nome, apelido, cnpj, ativo);
        }
    }
}
