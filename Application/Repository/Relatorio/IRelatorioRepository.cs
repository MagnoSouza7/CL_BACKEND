using System.Threading.Tasks;

namespace Application.Repository.Relatorio
{
    public interface IRelatorioRepository
    {
        Task<object> GetFormRelatorio();
        Task<object> CreateRepatorio(
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
            int? buId);
    }
}
