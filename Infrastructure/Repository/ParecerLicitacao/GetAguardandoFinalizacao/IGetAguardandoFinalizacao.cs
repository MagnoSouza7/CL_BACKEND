using System.Threading.Tasks;

namespace Infrastructure.Repository.ParecerLicitacao.GetAguardandoFinalizacao
{
    public interface IGetAguardandoFinalizacao
    {
        Task<object> Execute(
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
            int? empresaId);
    }
}
