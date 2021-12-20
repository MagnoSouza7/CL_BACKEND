using Infrastructure.Repository.ConsultaPublica.Create;
using Infrastructure.Repository.ConsultaPublica.Delete;
using Infrastructure.Repository.ConsultaPublica.GetAll;
using Infrastructure.Repository.ConsultaPublica.GetById;
using Infrastructure.Repository.ConsultaPublica.GetDadosForm;
using Infrastructure.Repository.ConsultaPublica.Update;
using System;
using System.Threading.Tasks;

namespace Application.Repository.ConsultaPublica
{
    public class ConsultaPublicaRepository : IConsultaPublicaRepository
    {
        private readonly IGetAllConsultaPublica getAllConsultaPublica;
        private readonly IGetByIdConsultaPublica getByIdConsultaPublica;
        private readonly IGetDadosFormConsultaPublica getDadosFormConsultaPublica;
        private readonly ICreateConsultaPublica createConsultaPublica;
        private readonly IUpdateConsultaPublica updateConsultaPublica;
        private readonly IDeleteConsultaPublica deleteConsultaPublica;

        public ConsultaPublicaRepository(
            IGetAllConsultaPublica getAllConsultaPublica,
            IGetByIdConsultaPublica getByIdConsultaPublica,
            IGetDadosFormConsultaPublica getDadosFormConsultaPublica,
            ICreateConsultaPublica createConsultaPublica,
            IUpdateConsultaPublica updateConsultaPublica,
            IDeleteConsultaPublica deleteConsultaPublica)
        {
            this.getAllConsultaPublica = getAllConsultaPublica;
            this.getByIdConsultaPublica = getByIdConsultaPublica;
            this.getDadosFormConsultaPublica = getDadosFormConsultaPublica;
            this.createConsultaPublica = createConsultaPublica;
            this.updateConsultaPublica = updateConsultaPublica;
            this.deleteConsultaPublica = deleteConsultaPublica;

        }

        public async Task<object> CreateConsultaPublica(
            int numConsulta, 
            int clienteId, 
            int empresaId, 
            string objeto,
            string horaResposta,
            string dataResposta,
            string nomeAnexo, 
            string tipoAnexo, 
            byte[] base64)
        {
            return await createConsultaPublica.Execute(numConsulta, clienteId, empresaId, objeto, horaResposta, dataResposta, nomeAnexo, tipoAnexo, base64);
        }

        public async Task DeleteConsultaPublica(int id)
        {
            await deleteConsultaPublica.Execute(id);

            return;
        }

        public async Task<object> GetAllConsultaPublica(
            int? numConsulta, 
            int? clienteId, 
            int? empresaId, 
            string dataRespostaInicio, 
            string dataRespostaFinal)
        {
            return await getAllConsultaPublica.Execute(numConsulta, clienteId, empresaId, dataRespostaInicio, dataRespostaFinal);
        }

        public async Task<object> GetByIdConsultaPublica(int id)
        {
            return await getByIdConsultaPublica.Execute(id);
        }

        public async Task<object> GetDadosFormConsultaPublica()
        {
            return await getDadosFormConsultaPublica.Execute();
        }

        public async Task<object> UpdateConsultaPublica(
            int id, 
            int numConsulta, 
            int clienteId, 
            int empresaId,
            string objeto,
            string horaResposta,
            string dataResposta,
            string NomeAnexo, 
            string tipoAnexo, 
            byte[] base64Anexo)
        {
            return await updateConsultaPublica.Execute(
                id,
                numConsulta,
                clienteId,
                empresaId,
                objeto,
                horaResposta,
                dataResposta,
                NomeAnexo,
                tipoAnexo,
                base64Anexo);
        }
    }
}
