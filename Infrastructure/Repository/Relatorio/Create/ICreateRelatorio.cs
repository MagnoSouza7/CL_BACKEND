using System.Threading.Tasks;

namespace Infrastructure.Repository.Relatorio.Create
{
    public interface ICreateRelatorio
    {
        Task<object> Execute(
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
