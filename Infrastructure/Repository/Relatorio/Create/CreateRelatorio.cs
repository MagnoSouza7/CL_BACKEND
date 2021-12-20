using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Relatorio.Create
{
    public class CreateRelatorio : ICreateRelatorio
    {
        public async Task<object> Execute(
            string numEdital,
            int? clienteId,
            string dataAberturaInicio,
            string dataAberturaFinal,
            int? modalidadeId,
            int? regiaoId,
            int? estadoId,
            string uasg,
            string consorcio,
            int? portalId,
            int? gerenteId,
            int? diretorId,
            decimal valorEstimadoInicio,
            decimal valorEstimadoFinal,
            string parecerGerente,
            int? motivoComumId,
            int? preVendaId,
            string parecerDiretor,
            int? empresaId,
            int? categoriaId,
            string parecerLicitacao,
            int? motivoPerdaId,
            decimal nossoValorInicio,
            decimal nossoValorFinal,
            int? vencedorId,
            decimal valorVencedorInicio,
            decimal valorVencedorFinal,
            int? reponsavelId,
            int? buId
            )
        {
            using var context = new ApiContext();

            List<Domain.Entities.Edital> editaisFiltrados = new List<Domain.Entities.Edital>();

            var ativarFiltroEditais = numEdital != "" ||
                                      clienteId > 0 ||
                                      dataAberturaInicio != "" ||
                                      dataAberturaFinal != "" ||
                                      modalidadeId > 0 ||
                                      regiaoId > 0 ||
                                      estadoId > 0 ||
                                      categoriaId > 0 ||
                                      uasg != "" ||
                                      consorcio != "" ||
                                      portalId > 0 ||
                                      clienteId > 0 ||
                                      gerenteId > 0 ||
                                      diretorId > 0 ||
                                      valorEstimadoInicio > 0 ||
                                      valorEstimadoFinal > 0 ||
                                      buId > 0;

            var ativarFiltroParecerGc = parecerGerente != "" ||
                                        motivoComumId > 0 ||
                                        preVendaId > 0;

            var ativarFiltroParecerDc = parecerDiretor != "" ||
                                        empresaId > 0;

            var ativarFiltroParecerLicitacao = parecerLicitacao != "" ||
                                               motivoPerdaId > 0 ||
                                               nossoValorInicio > 0 ||
                                               nossoValorFinal > 0 ||
                                               vencedorId > 0 ||
                                               valorVencedorInicio > 0 ||
                                               valorVencedorFinal > 0 ||
                                               reponsavelId > 0;

            if (ativarFiltroEditais)
            {
                var filtroEditais = await context.Editais
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
                    .Where(x =>
                        x.Ativo &&
                        (numEdital != "" ? x.NumEdital == numEdital : true) &&
                        (clienteId > 0 ? x.Cliente.Id == clienteId : true) &&
                        (dataAberturaInicio != "" ? DateTime.Parse(dataAberturaInicio) <= x.DataHoraDeAbertura : true) &&
                        (dataAberturaFinal != "" ? DateTime.Parse(dataAberturaFinal) >= x.DataHoraDeAbertura : true) &&
                        (modalidadeId > 0 ? x.Modalidade.Id == modalidadeId : true) &&
                        (regiaoId > 0 ? x.Regiao.Id == regiaoId : true) &&
                        (estadoId > 0 ? x.Estado.Id == estadoId : true) &&
                        (categoriaId > 0 ? x.Categoria.Id == categoriaId : true) &&
                        (uasg != "" ? x.Uasg == uasg : true) &&
                        (consorcio != "" ? x.Consorcio == consorcio : true) &&
                        (portalId > 0 ? x.Portal.Id == portalId : true) &&
                        (clienteId > 0 ? x.Cliente.Id == clienteId : true) &&
                        (gerenteId > 0 ? x.Gerente.Id == gerenteId : true) &&
                        (diretorId > 0 ? x.Diretor.Id == diretorId : true) &&
                        (valorEstimadoInicio > 0 ? valorEstimadoInicio <= x.ValorEstimado : true) &&
                        (valorEstimadoFinal > 0 ? valorEstimadoFinal >= x.ValorEstimado : true) &&
                        (buId > 0 ? x.Categoria.Bu.Id == buId : true))
                    .AsNoTracking()
                    .ToListAsync();

                editaisFiltrados.AddRange(filtroEditais);
            }

            if (ativarFiltroParecerGc)
            {
                var filtroParecerGerente = await context.ParecerGerenteContas
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
                            .ThenInclude(x => x.Bu)
                    .Include(x => x.Edital)
                        .ThenInclude(x => x.Regiao)
                    .Include(x => x.Edital)
                        .ThenInclude(x => x.Gerente)
                    .Include(x => x.Edital)
                        .ThenInclude(x => x.Diretor)
                    .Include(x => x.Edital)
                        .ThenInclude(x => x.Portal)
                    .Include(x => x.MotivoComum)
                    .Include(x => x.Empresa)
                    .Include(x => x.PreVenda)
                        .ThenInclude(x => x.Usuario)
                    .Where(x =>
                        x.Ativo &&
                        (parecerGerente != "" ? x.Parecer == parecerGerente : true) &&
                        (motivoComumId > 0 ? x.MotivoComum.Id == motivoComumId : true) &&
                        (preVendaId > 0 ? x.PreVenda.Id == preVendaId : true))
                    .Where(x => ativarFiltroEditais ? editaisFiltrados.Contains(x.Edital) : true)
                    .AsNoTracking()
                    .ToListAsync();

                editaisFiltrados.Clear();
                editaisFiltrados.AddRange(filtroParecerGerente.Select(x => x.Edital).ToList());
            }

            if (ativarFiltroParecerDc)
            {
                var filtroParecerDiretor = await context.ParecerDiretorComerciais
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
                            .ThenInclude(x => x.Bu)
                    .Include(x => x.Edital)
                        .ThenInclude(x => x.Regiao)
                    .Include(x => x.Edital)
                        .ThenInclude(x => x.Gerente)
                    .Include(x => x.Edital)
                        .ThenInclude(x => x.Diretor)
                    .Include(x => x.Edital)
                        .ThenInclude(x => x.Portal)
                    .Include(x => x.Empresa)
                    .Include(x => x.MotivosComum)
                    .Include(x => x.Gerente)
                    .Where(x =>
                        x.Ativo &&
                        (parecerDiretor != "" ? x.Decisao == parecerDiretor : true) &&
                        (empresaId > 0 ? x.Empresa.Id == empresaId : true))
                    .Where(x => ativarFiltroEditais || ativarFiltroParecerGc ? editaisFiltrados.Contains(x.Edital) : true)
                    .AsNoTracking()
                    .ToListAsync();

                editaisFiltrados.Clear();
                editaisFiltrados.AddRange(filtroParecerDiretor.Select(x => x.Edital).ToList());
            }

            if (ativarFiltroParecerLicitacao)
            {
                var filtroParecerLicitacao = await context.ParecerLicitacoes
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
                            .ThenInclude(x => x.Bu)
                    .Include(x => x.Edital)
                        .ThenInclude(x => x.Regiao)
                    .Include(x => x.Edital)
                        .ThenInclude(x => x.Gerente)
                    .Include(x => x.Edital)
                        .ThenInclude(x => x.Diretor)
                    .Include(x => x.Edital)
                        .ThenInclude(x => x.Portal)
                    .Include(x => x.MotivoPerda)
                    .Include(x => x.Responsavel)
                    .Include(x => x.Vencedor)
                    .Where(x =>
                        x.Ativo &&
                        (parecerLicitacao != "" ? x.Resultado == parecerLicitacao : true) &&
                        (motivoPerdaId > 0 ? x.MotivoPerda.Id == motivoPerdaId : true) &&
                        (nossoValorInicio > 0 ? x.NossoValor >= nossoValorInicio : true) &&
                        (nossoValorFinal > 0 ? x.NossoValor <= nossoValorFinal : true) &&
                        (vencedorId > 0 ? x.Vencedor.Id == vencedorId : true) &&
                        (valorVencedorInicio > 0 ? x.ValorVencedor >= valorVencedorInicio : true) &&
                        (valorVencedorFinal > 0 ? x.ValorVencedor <= valorVencedorFinal : true) &&
                        (reponsavelId > 0 ? x.Responsavel.Id == reponsavelId : true))
                    .Where(x => ativarFiltroEditais || ativarFiltroParecerGc || ativarFiltroParecerDc ? editaisFiltrados.Contains(x.Edital) : true)
                    .AsNoTracking()
                    .ToListAsync();

                editaisFiltrados.Clear();
                editaisFiltrados.AddRange(filtroParecerLicitacao.Select(x => x.Edital).ToList());
            }

            List<object> resposta = new List<object>();

            foreach (var edital in editaisFiltrados)
            {
                resposta.Add(new
                {
                    edital,

                    parecerGc = await context.ParecerGerenteContas.AsNoTracking()
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
                                                            .ThenInclude(x => x.Bu)
                                                    .Include(x => x.Edital)
                                                        .ThenInclude(x => x.Regiao)
                                                    .Include(x => x.Edital)
                                                        .ThenInclude(x => x.Gerente)
                                                    .Include(x => x.Edital)
                                                        .ThenInclude(x => x.Diretor)
                                                    .Include(x => x.Edital)
                                                        .ThenInclude(x => x.Portal)
                                                    .Include(x => x.MotivoComum)
                                                    .Include(x => x.Empresa)
                                                    .Include(x => x.PreVenda)
                                                        .ThenInclude(x => x.Usuario)
                                                    .Where(x => x.Edital.Id == edital.Id).FirstOrDefaultAsync(),

                    parecerDc = await context.ParecerDiretorComerciais.AsNoTracking()
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
                                                            .ThenInclude(x => x.Bu)
                                                    .Include(x => x.Edital)
                                                        .ThenInclude(x => x.Regiao)
                                                    .Include(x => x.Edital)
                                                        .ThenInclude(x => x.Gerente)
                                                    .Include(x => x.Edital)
                                                        .ThenInclude(x => x.Diretor)
                                                    .Include(x => x.Edital)
                                                        .ThenInclude(x => x.Portal)
                                                    .Include(x => x.Empresa)
                                                    .Include(x => x.MotivosComum)
                                                    .Include(x => x.Gerente)
                                                    .Where(x => x.Edital.Id == edital.Id).FirstOrDefaultAsync(),

                    parecerLicitacao = await context.ParecerLicitacoes.AsNoTracking()
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
                                                            .ThenInclude(x => x.Bu)
                                                    .Include(x => x.Edital)
                                                        .ThenInclude(x => x.Regiao)
                                                    .Include(x => x.Edital)
                                                        .ThenInclude(x => x.Gerente)
                                                    .Include(x => x.Edital)
                                                        .ThenInclude(x => x.Diretor)
                                                    .Include(x => x.Edital)
                                                        .ThenInclude(x => x.Portal)
                                                    .Include(x => x.MotivoPerda)
                                                    .Include(x => x.Responsavel)
                                                    .Include(x => x.Vencedor)
                                                    .Where(x => x.Edital.Id == edital.Id).FirstOrDefaultAsync()
                });
            }

            return resposta;
        }
    }
}
