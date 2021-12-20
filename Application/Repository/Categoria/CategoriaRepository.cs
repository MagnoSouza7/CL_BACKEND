using Infrastructure.Repository.Categoria.Create;
using Infrastructure.Repository.Categoria.GetAll;
using Infrastructure.Repository.Categoria.GetById;
using Infrastructure.Repository.Categoria.GetDadosCategoria;
using Infrastructure.Repository.Categoria.Update;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.Categoria
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly IGetAllCategoria getAllCategoria;
        private readonly IGetByIdCategoria getByIdCategoria;
        private readonly IGetDadosCategoria getDadosCategoria;
        private readonly ICreateCategoria createCategoria;
        private readonly IUpdateCategoria updateCategoria;

        public CategoriaRepository(
            IGetAllCategoria getAllCategoria,
            IGetByIdCategoria getByIdCategoria,
            IGetDadosCategoria getDadosCategoria,
            ICreateCategoria createCategoria,
            IUpdateCategoria updateCategoria)
        {
            this.getAllCategoria = getAllCategoria;
            this.getByIdCategoria = getByIdCategoria;
            this.getDadosCategoria = getDadosCategoria;
            this.createCategoria = createCategoria;
            this.updateCategoria = updateCategoria;
        }

        public async Task<object> Create(string nome, int BuId)
        {
            return await createCategoria.Execute(nome, BuId);
        }

        public async Task<object> GetAll()
        {
            return await getAllCategoria.Execute();
        }

        public async Task<object> GetById(int id)
        {
            return await getByIdCategoria.Execute(id);
        }

        public async Task<object> GetDadosCategoria()
        {
            return await getDadosCategoria.Execute();
        }

        public async Task<object> Update(int id, string nome, int BuId, bool ativo)
        {
            return await updateCategoria.Execute(id, nome, BuId, ativo);
        }
    }
}
