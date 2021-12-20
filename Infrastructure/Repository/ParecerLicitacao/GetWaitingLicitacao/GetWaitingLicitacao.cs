using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.ParecerLicitacao.GetWaitingLicitacao
{
    public class GetWaitingLicitacao : IGetWaitingLicitacao
    {
        public async Task<object> Execute(
            int? id,
            string numEdital,
            int? clienteId,
            string dataAberturaInicio,
            string dataAberturaFinal,
            int? modalidadeId,
            int? regiaoId,
            int? estadoId,
            int? categoriaId,
            string uasg,
            string consorcio,
            int? portalId,
            int? gerenteId,
            int? diretorId,
            decimal? valorEstimadoInicio,
            decimal? valorEstimadoFinal,
            int? buId,
            int? empresaId
        )
        {
            using var context = new ApiContext();

            var editais = await context.Editais
                .Include(x => x.Cliente)
                .Include(x => x.Estado)
                .Include(x => x.Modalidade)
                .Include(x => x.Etapa)
                .Include(x => x.Categoria)
                    .ThenInclude(x => x.Bu)
                .Include(x => x.Regiao)
                .Include(x => x.Gerente)
                .Include(x => x.Diretor)
                .Include(x => x.Portal)
                .Include(x => x.Comentarios)
                    .ThenInclude(x => x.Usuario)
                .Include(x => x.Anexo)
                .Where(x => x.Ativo && x.Etapa.Id == 3 
                    && x.DataHoraDeAbertura >= DateTime.Now && !context.ParecerLicitacoes.Any(p => p.Edital.Id == x.Id)
                    && (id != null && id > 0 ? x.Id == id : true)
                    && (numEdital != "" ? x.NumEdital == numEdital : true)
                    && (clienteId != null && clienteId > 0 ? x.Cliente.Id == clienteId : true)
                    && (dataAberturaInicio != "" ? DateTime.Parse(dataAberturaInicio) <= x.DataHoraDeAbertura : true)
                    && (dataAberturaFinal != "" ? DateTime.Parse(dataAberturaFinal) >= x.DataHoraDeAbertura : true)
                    && (modalidadeId != null && modalidadeId > 0 ? x.Modalidade.Id == modalidadeId : true)
                    && (regiaoId != null && regiaoId > 0 ? x.Regiao.Id == regiaoId : true)
                    && (estadoId != null && estadoId > 0 ? x.Estado.Id == estadoId : true)
                    && (categoriaId != null && categoriaId > 0 ? x.Categoria.Id == categoriaId : true)
                    && (uasg != "" ? x.Uasg == uasg : true)
                    && (consorcio != "" ? x.Consorcio == consorcio : true)
                    && (portalId != null && portalId > 0 ? x.Portal.Id == portalId : true)
                    && (gerenteId != null && gerenteId > 0 ? x.Gerente.Id == gerenteId : true)
                    && (diretorId != null && diretorId > 0 ? x.Diretor.Id == diretorId : true)
                    && (valorEstimadoInicio != null && valorEstimadoInicio > 0 ? valorEstimadoInicio <= x.ValorEstimado : true)
                    && (valorEstimadoFinal != null && valorEstimadoFinal > 0 ? valorEstimadoFinal >= x.ValorEstimado : true)
                    && (buId != null && buId > 0 ? x.Categoria.Bu.Id == buId : true)
                    && (empresaId != null && empresaId > 0 ? context.ParecerDiretorComerciais.Any(p => p.Edital.Id == x.Id && p.Empresa.Id == empresaId) : true)
                )
                .OrderBy(x => x.DataHoraDeAbertura)
                .AsNoTracking()
                .ToListAsync();

            var resposta = new List<object>();

            foreach (var edital in editais)
            {
                edital.Gerente.Token = "";
                edital.Gerente.Login = "";

                edital.Diretor.Token = "";
                edital.Diretor.Login = "";

                resposta.Add(new {
                    edital.Id,
                    edital.NumEdital,
                    edital.Cliente,
                    edital.Estado,
                    edital.Modalidade,
                    edital.Etapa,
                    edital.DataHoraDeAbertura,
                    edital.Uasg,
                    edital.Categoria,
                    edital.Consorcio,
                    edital.ValorEstimado,
                    edital.AgendarVistoria,
                    edital.DataVistoria,
                    edital.ObjetosDescricao,
                    edital.ObjetosResumo,
                    edital.Observacoes,
                    edital.Regiao,
                    edital.Gerente,
                    edital.Diretor,
                    edital.Portal,
                    edital.Anexo,
                    Comentario = edital.Comentarios.OrderByDescending(x => x.DataCriacao).FirstOrDefault(), 
                    Empresa = await context.ParecerDiretorComerciais
                        .Include(x => x.Empresa)
                        .Include(x => x.Edital)
                        .AsNoTracking()
                        .Where(x => x.Edital.Id == edital.Id)
                        .Select(x => x.Empresa)
                        .FirstAsync()
                });
            }

            return resposta;
        }
    }
}
