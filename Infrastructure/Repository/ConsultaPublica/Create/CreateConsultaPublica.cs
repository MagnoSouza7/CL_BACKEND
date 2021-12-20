using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.ConsultaPublica.Create
{
    public class CreateConsultaPublica : ICreateConsultaPublica
    {
        public async Task<object> Execute(
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
            using var context = new ApiContext();

            var anexo = new Domain.Entities.Anexo();

            if (nomeAnexo != null && tipoAnexo != null && base64 != null)
            {
                anexo = new Domain.Entities.Anexo
                {
                    Nome = nomeAnexo,
                    Base64 = base64,
                    Tipo = tipoAnexo,
                    Ativo = true,
                    DataAtualizacao = DateTime.Now,
                    DataCriacao = DateTime.Now
                };
            }
            else
            {
                anexo = null;
            }

            var consPublica = new Domain.Entities.ConsultaPublica
            {
                NumConsulta = numConsulta,
                Cliente = await context.Clientes
                    .Where(x => x.Id == clienteId)
                    .SingleOrDefaultAsync(),
                Empresa = await context.Empresas
                    .Where(x => x.Id == empresaId)
                    .SingleOrDefaultAsync(),
                Objeto = objeto,
                DataResposta = DateTime.Parse(dataResposta + " " + horaResposta),
                Ativo = true,
                Anexo = anexo != null ? anexo : null,
                DataCriacao = DateTime.Now
            };

            context.ConsultaPublicas.Add(consPublica);
            context.SaveChanges();

            return consPublica;
        }
    }
}
