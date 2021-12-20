using Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Repository.DocumentosCl.Create
{
    public class CreateDocumentoCl : ICreateDocumentoCl
    {
        public async Task<object> Execute(string descricao, string nomeAnexo, string tipoAnexo, byte[] base64Anexo)
        {
            using var context = new ApiContext();

            var anexoNew = nomeAnexo != null ? new Domain.Entities.Anexo
            {
                Nome = nomeAnexo,
                Tipo = tipoAnexo,
                Base64 = base64Anexo
            } : null;

            var documentoNew = new DocumentoCL
            {
                Descricao = descricao,
                Anexo = anexoNew,
                Ativo = true,
                DataCriacao = DateTime.Now,
                DataAtualizacao = DateTime.Now

            };

            await context.DocumentosCLs.AddAsync(documentoNew);

            await context.SaveChangesAsync();

            return documentoNew;
        }
    }
}
