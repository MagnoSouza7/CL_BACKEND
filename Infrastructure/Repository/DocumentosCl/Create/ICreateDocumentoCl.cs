using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.DocumentosCl.Create
{
    public interface ICreateDocumentoCl
    {
        Task<object> Execute( string descricao, string nomeAnexo, string tipoAnexo, byte[] base64Anexo);
    }
}
