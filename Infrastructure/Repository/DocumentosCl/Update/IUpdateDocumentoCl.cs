using Infrastructure.Repository.Anexo.Update;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.DocumentosCl.Update
{
    public interface IUpdateDocumentoCl
    {
        public Task<object> Execute(int id, string descricao, string nomeAnexo, string tipoAnexo, byte[] base64Anexo);
    }
}
