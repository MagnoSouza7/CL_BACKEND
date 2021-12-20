using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Edital.GetTotalEditalSuspenso
{
    public class GetTotalEditalSuspenso : IGetTotalEditalSuspenso
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
            var editais = await context.ParecerLicitacoes
                .Include(x => x.Edital)
                    .ThenInclude(x => x.Cliente)
                .Include(x => x.Edital)
                    .ThenInclude(x => x.Estado)
                .Include(x => x.Edital)
                    .ThenInclude(x => x.Modalidade)
                .Include(x => x.Edital)
                    .ThenInclude(x => x.Etapa)
                .Include(x => x.Edital)
                    .ThenInclude(x => x.Categoria)
                .Include(x => x.Edital)
                    .ThenInclude(x => x.Regiao)
                .Include(x => x.Edital)
                    .ThenInclude(x => x.Gerente)
                .Include(x => x.Edital)
                    .ThenInclude(x => x.Diretor)
                .Include(x => x.Edital)
                    .ThenInclude(x => x.Portal)
                .Include(x => x.Edital)
                    .ThenInclude(x => x.Comentarios)
                        .ThenInclude(x => x.Usuario)
                .AsNoTracking()
                .Where(x => x.Ativo && x.Resultado == "SUSPENSO"
                    && (id != null && id > 0 ? x.Edital.Id == id : true)
                    && (numEdital != "" ? x.Edital.NumEdital == numEdital : true)
                    && (clienteId != null && clienteId > 0 ? x.Edital.Cliente.Id == clienteId : true)
                    && (dataAberturaInicio != "" ? DateTime.Parse(dataAberturaInicio) <= x.Edital.DataHoraDeAbertura : true)
                    && (dataAberturaFinal != "" ? DateTime.Parse(dataAberturaFinal) >= x.Edital.DataHoraDeAbertura : true)
                    && (modalidadeId != null && modalidadeId > 0 ? x.Edital.Modalidade.Id == modalidadeId : true)
                    && (regiaoId != null && regiaoId > 0 ? x.Edital.Regiao.Id == regiaoId : true)
                    && (estadoId != null && estadoId > 0 ? x.Edital.Estado.Id == estadoId : true)
                    && (categoriaId != null && categoriaId > 0 ? x.Edital.Categoria.Id == categoriaId : true)
                    && (uasg != "" ? x.Edital.Uasg == uasg : true)
                    && (consorcio != "" ? x.Edital.Consorcio == consorcio : true)
                    && (portalId != null && portalId > 0 ? x.Edital.Portal.Id == portalId : true)
                    && (gerenteId != null && gerenteId > 0 ? x.Edital.Gerente.Id == gerenteId : true)
                    && (diretorId != null && diretorId > 0 ? x.Edital.Diretor.Id == diretorId : true)
                    && (valorEstimadoInicio != null && valorEstimadoInicio > 0 ? valorEstimadoInicio <= x.Edital.ValorEstimado : true)
                    && (valorEstimadoFinal != null && valorEstimadoFinal > 0 ? valorEstimadoFinal >= x.Edital.ValorEstimado : true)
                    && (buId != null && buId > 0 ? x.Edital.Categoria.Bu.Id == buId : true)
                    && (empresaId != null && empresaId > 0 ? context.ParecerDiretorComerciais.Any(p => p.Edital.Id == x.Id && p.Empresa.Id == empresaId) : true)
                )
                .OrderByDescending(x => x.Edital.DataHoraDeAbertura)
                .Select(x => x.Edital)
                .ToListAsync();

            var resposta = new List<object>();

            foreach (var edital in editais)
            {
                edital.Gerente.Token = "";
                edital.Gerente.Login = "";

                edital.Diretor.Token = "";
                edital.Diretor.Login = "";

                resposta.Add(new
                {
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
                    Comentario = edital.Comentarios.OrderByDescending(x => x.DataCriacao).FirstOrDefault(),
                });
            }

            return resposta;
        }
    }
}
