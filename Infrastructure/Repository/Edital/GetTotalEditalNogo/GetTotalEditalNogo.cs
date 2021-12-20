using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Edital.GetTotalEditalNogo
{
    public class GetTotalEditalNogo : IGetTotalEditalNogo
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

            var editais = await context.ParecerDiretorComerciais
                .Include(x => x.MotivosComum)
                .Include(x => x.Empresa)
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
                .Where(x => x.Ativo && x.Decisao == "NOGO"
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
                .ToListAsync();

            var resposta = new List<object>();

            foreach (var edital in editais)
            {
                edital.Edital.Gerente.Token = "";
                edital.Edital.Gerente.Login = "";

                edital.Edital.Diretor.Token = "";
                edital.Edital.Diretor.Login = "";

                resposta.Add(new
                {
                    edital.Edital.Id,
                    edital.Edital.NumEdital,
                    edital.Edital.Cliente,
                    edital.Edital.Estado,
                    edital.Edital.Modalidade,
                    edital.Edital.Etapa,
                    edital.Edital.DataHoraDeAbertura,
                    edital.Edital.Uasg,
                    edital.Edital.Categoria,
                    edital.Edital.Consorcio,
                    edital.Edital.ValorEstimado,
                    edital.Edital.AgendarVistoria,
                    edital.Edital.DataVistoria,
                    edital.Edital.ObjetosDescricao,
                    edital.Edital.ObjetosResumo,
                    edital.Edital.Observacoes,
                    edital.Edital.Regiao,
                    edital.Edital.Gerente,
                    edital.Edital.Diretor,
                    edital.Edital.Portal,
                    edital.MotivosComum,
                    Comentario = edital.Edital.Comentarios.OrderByDescending(x => x.DataCriacao).FirstOrDefault(),
                });
            }

            return resposta;
        }
    }
}
