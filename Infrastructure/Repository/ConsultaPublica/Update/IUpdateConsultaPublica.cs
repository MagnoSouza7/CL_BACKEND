using System;
using System.Threading.Tasks;

namespace Infrastructure.Repository.ConsultaPublica.Update
{
    public interface IUpdateConsultaPublica
    {
        Task<object> Execute(
            int id, 
            int numConsulta, 
            int clienteId, 
            int empresaId,
            string objeto,
            string horaResposta,
            string dataResposta,
            string NomeAnexo, 
            string tipoAnexo, 
            byte[] base64Anexo);
    }
}
