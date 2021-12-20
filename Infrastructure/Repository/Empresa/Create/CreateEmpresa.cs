using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Empresa.Create
{
    public class CreateEmpresa : ICreateEmpresa
    {
        public async Task<object> Execute(string nome)
        {
            using var context = new ApiContext();

            var EmpresaNew = new Domain.Entities.Empresa
            {
                Nome = nome,
                Ativo = true,
                DataCriacao = DateTime.Now,
                DataAtualizacao = DateTime.Now
            };
            context.Empresas.Add(EmpresaNew);
            await context.SaveChangesAsync();

            return EmpresaNew;
        }
    }
}
