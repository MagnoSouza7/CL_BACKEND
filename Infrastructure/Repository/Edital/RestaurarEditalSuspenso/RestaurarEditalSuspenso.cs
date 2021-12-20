using Infrastructure.Repository.Edital.Update;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Edital.RestaurarEditalSuspenso
{
    public class RestaurarEditalSuspenso : IRestaurarEditalSuspenso
    {
        private readonly IUpdate update;

        public RestaurarEditalSuspenso(IUpdate update)
        {
            this.update = update;
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
            int responsavelRequestId)
        {
            using var context = new ApiContext();

            var parecerLicitacao = await context.ParecerLicitacoes
                .AsNoTracking()
                .Where(x => x.Edital.Id == id).SingleAsync();

            context.ParecerLicitacoes.Remove(parecerLicitacao);

            var parecerDiretor = await context.ParecerDiretorComerciais
                .AsNoTracking()
                .AnyAsync(x => x.Edital.Id == id);

            if (parecerDiretor)
            {
                var parecer = await context.ParecerDiretorComerciais
                    .AsNoTracking()
                    .Where(x => x.Edital.Id == id).SingleAsync();

                context.ParecerDiretorComerciais.Remove(parecer);
            }

            var parecerGerente = await context.ParecerGerenteContas
                .AsNoTracking()
                .AnyAsync(x => x.Edital.Id == id);

            if(parecerGerente)
            {
                var parecer = await context.ParecerGerenteContas
                    .AsNoTracking()
                    .Where(x => x.Edital.Id == id).SingleAsync();

                context.ParecerGerenteContas.Remove(parecer);
            }

            await context.SaveChangesAsync();

            return await update.Execute(
                id,
                numEdital,
                clienteId,
                estadoId,
                modalidadeId,
                etapaId,
                dataDeAbertura,
                horaDeAbertura,
                uasg,
                categoriaId,
                consorcio,
                valorEstimado,
                agendarVistoria,
                dataVistoria,
                objetosDescricao,
                objetosResumo,
                observacoes,
                regiaoId,
                gerenteId,
                diretorId,
                portalId,
                ativo,
                idAnexo,
                nomeAnexo,
                tipoAnexo,
                base64Anexo,
                responsavelRequestId);


        }


    }
}
