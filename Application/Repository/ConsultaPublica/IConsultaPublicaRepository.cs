using System;
using System.Threading.Tasks;

namespace Application.Repository.ConsultaPublica
{
    public interface IConsultaPublicaRepository
    {
        Task<object> GetAllConsultaPublica(
            int? NumConsulta, 
            int? ClienteId, 
            int? EmpresaId, 
            string DataRespostaInicio, 
            string DataRespostaFinal);
        Task<object> GetByIdConsultaPublica(int id);
        Task<object> GetDadosFormConsultaPublica();
        Task<object> CreateConsultaPublica(
            int NumConsulta,
            int ClienteId,
            int EmpresaId,
            string objeto,
            string horaAbertura,
            string dataAbertura,
            string NomeAnexo,
            string tipoAnexo,
            byte[] Base64);
        Task<object> UpdateConsultaPublica(
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

        Task DeleteConsultaPublica(int id);



    }
}
