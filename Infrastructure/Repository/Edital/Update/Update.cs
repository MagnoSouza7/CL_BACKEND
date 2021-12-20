using Domain.Entities;
using Infrastructure.Repository.Anexo.Create;
using Infrastructure.Repository.Anexo.Update;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Edital.Update
{
    public class Update : IUpdate
    {
        private readonly IUpdateAnexo updateAnexo;
        private readonly ICreateAnexo createAnexo;

        public Update(IUpdateAnexo updateAnexo, ICreateAnexo createAnexo)
        {
            this.updateAnexo = updateAnexo;
            this.createAnexo = createAnexo;
        }

        public async Task<Domain.Entities.Edital> Execute(
            int id,
            string numEdital,
            int clienteId,
            int estadoId,
            int modalidadeId,
            int etapaId,
            string dataDeAbertura,
            string horaDeAbertura,
            string uasg,
            int categoriaId,
            string consorcio,
            decimal valorEstimado,
            string agendarVistoria,
            string dataVistoria,
            string objetosDescricao,
            string objetosResumo,
            string observacoes,
            int regiaoId,
            int gerenteId,
            int diretorId,
            int portalId,
            bool ativo,
            int idAnexo,
            string nomeAnexo,
            string tipoAnexo,
            byte[] base64Anexo,
            int responsavelRequestId
        )
        {
            using var context = new ApiContext();

            var editalOld = await context.Editais
                .Include(x => x.Etapa)
                .Include(x => x.Anexo)
                .AsNoTracking()
                .Where(x => x.Ativo)
                .SingleOrDefaultAsync(b => b.Id == id);

            if (editalOld == null)
                return null;

            var etapa = editalOld.Etapa;

            if (etapaId == 1)
            {
                etapa = await context.Etapas.Where(x => x.Id == 1).SingleAsync();
            }

            var anexo = new Domain.Entities.Anexo();

            if (idAnexo > 0)
            {
                var anexoOld = await context.Anexos
                    .AsNoTracking()
                    .Where(x => x.Id == idAnexo)
                    .SingleOrDefaultAsync();

                anexo = new Domain.Entities.Anexo
                {
                    Id = idAnexo,
                    Nome = nomeAnexo,
                    Tipo = tipoAnexo,
                    Base64 = base64Anexo,
                    Ativo = ativo,
                    DataAtualizacao = DateTime.Now,
                    DataCriacao = anexoOld.DataCriacao
                };
            }
            else
            {
                anexo = nomeAnexo != null ? new Domain.Entities.Anexo
                {
                    Nome = nomeAnexo,
                    Tipo = tipoAnexo,
                    Base64 = base64Anexo
                } : null;

                if (editalOld.Anexo != null)
                    context.Anexos.Remove(editalOld.Anexo);
            }

            var editalNew = new Domain.Entities.Edital
            {
                Id = id,
                NumEdital = numEdital,
                Cliente = await context.Clientes.FindAsync(clienteId),
                Estado = await context.Estados.FindAsync(estadoId),
                Modalidade = await context.Modalidades.FindAsync(modalidadeId),
                Etapa = etapa,
                DataHoraDeAbertura = DateTime.Parse(dataDeAbertura + " " + horaDeAbertura),
                Uasg = uasg,
                Categoria = await context.Categorias.FindAsync(categoriaId),
                Consorcio = consorcio,
                ValorEstimado = valorEstimado,
                AgendarVistoria = agendarVistoria,
                DataVistoria = (agendarVistoria == "Sim" || agendarVistoria == "Facultativo") ? DateTime.Parse(dataVistoria) : new DateTime(),
                ObjetosDescricao = objetosDescricao,
                ObjetosResumo = objetosResumo,
                Observacoes = observacoes,
                Regiao = await context.Regioes.FindAsync(regiaoId),
                Gerente = await context.Usuarios.FindAsync(gerenteId),
                Diretor = await context.Usuarios.FindAsync(diretorId),
                Portal = await context.Portais.FindAsync(portalId),
                Anexo = anexo,
                Ativo = ativo,
                DataCriacao = editalOld.DataCriacao,
                DataAtualizacao = DateTime.Now
            };

            context.Editais.Update(editalNew);

            await context.SaveChangesAsync();

            return editalNew;
        }
    }
}
