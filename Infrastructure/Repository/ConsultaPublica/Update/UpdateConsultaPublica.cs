using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.ConsultaPublica.Update
{
    public class UpdateConsultaPublica : IUpdateConsultaPublica
    {
        public async Task<object> Execute(
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
            using var context = new ApiContext();

            var anexo = new Domain.Entities.Anexo();

            var consPublica = await context.ConsultaPublicas
                .Include(x => x.Cliente)
                .Include(x => x.Empresa)
                .Include(x => x.Anexo)
                .AsTracking()
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();

            if (NomeAnexo != null && tipoAnexo != null && base64Anexo != null)
            {
                anexo = new Domain.Entities.Anexo
                {
                    Nome = NomeAnexo,
                    Base64 = base64Anexo,
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

            if (consPublica.Anexo != null)
            {
                context.Anexos.Remove(consPublica.Anexo);
            }

            consPublica.NumConsulta = numConsulta;
            consPublica.Empresa = await context.Empresas
                .Where(x => x.Id == empresaId)
                .SingleOrDefaultAsync();
            consPublica.Cliente = await context.Clientes
                .Where(x => x.Id == clienteId)
                .SingleOrDefaultAsync();
            consPublica.Objeto = objeto;
            consPublica.Ativo = true;
            consPublica.DataResposta = DateTime.Parse(dataResposta + " " + horaResposta);
            consPublica.Anexo = anexo;
            consPublica.DataAtualizacao = DateTime.Now;

            context.ConsultaPublicas.Update(consPublica);
            context.SaveChanges();

            return consPublica;

        }
    }
}
