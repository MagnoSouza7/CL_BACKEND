using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.ConsultaPublica.GetAll
{
    public interface IGetAllConsultaPublica
    {
        Task<object> Execute(
            int? numConsulta, 
            int? clienteId, 
            int? empresaId,
            string dataRespostaInicio, 
            string dataRespostaFinal);
    }
}
