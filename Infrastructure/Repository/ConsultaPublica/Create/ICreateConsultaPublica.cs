using System;
using System.Threading.Tasks;

namespace Infrastructure.Repository.ConsultaPublica.Create
{
    public interface ICreateConsultaPublica
    {
        Task<object> Execute(
            int numConsulta, 
            int clienteId, 
            int empresaId, 
            string objeto,
            string horaAbertira,
            string dataAbertura,
            string nomeAnexo, 
            string tipoAnexo, 
            byte[] base64);
    }
}
