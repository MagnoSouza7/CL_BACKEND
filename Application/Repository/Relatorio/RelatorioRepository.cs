using Infrastructure.Repository.Relatorio.Create;
using Infrastructure.Repository.Relatorio.GetDadosRelatorio;
using System.Threading.Tasks;

namespace Application.Repository.Relatorio
{
    public class RelatorioRepository : IRelatorioRepository
    {
        private readonly ICreateRelatorio createRelatorio;
        private readonly IGetFormRelatorio getFormRelatorio;

        public RelatorioRepository(
            ICreateRelatorio createRelatorio,
            IGetFormRelatorio getFormRelatorio)
        {
            this.createRelatorio = createRelatorio;
            this.getFormRelatorio = getFormRelatorio;
        }

        public async Task<object> CreateRepatorio(
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
            int? buId)
        {
            return await createRelatorio.Execute(
                numEdital,
                clienteId,
                dataAberturaInicio,
                dataAberturaFinal,
                modalidadeId,
                regiaoId,
                estadoId,
                uasg,
                consorcio,
                portalId,
                gerenteId,
                diretorId,
                valorEstimadoInicio,
                valorEstimadoFinal,
                parecerGerente,
                motivoComumId,
                preVendaId,
                parecerDiretor,
                empresaId,
                categoriaId,
                parecerLicitacao,
                motivoPerdaId,
                nossoValorInicio,
                nossoValorFinal,
                vencedorId,
                valorVencedorInicio,
                valorVencedorFinal,
                reponsavelId,
                buId);
        }

        public async Task<object> GetFormRelatorio()
        {
            return await getFormRelatorio.Execute();
        }
    }
}
