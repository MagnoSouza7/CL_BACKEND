using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.Dissidio
{
    public interface IDissidioRepository
    {
        Task<object> ObterStatusDissidios();
        Task<object> GetDissidioByEstadoId(int id);
        Task<object> GetDissidioById(int id);

        Task<object> CreateDissidio( 
            int estadoId, 
            string dataBase, 
            string dataUltima, 
            decimal? pisoSalarial8h, 
            decimal? pisoSalarial6h, 
            decimal? ticket8h, 
            decimal? ticket6h, 
            decimal? benefInd8h, 
            decimal? benefInd6h, 
            decimal? reajuste, 
            string observacoes, 
            string vigenciaInicio, 
            string vigenciaFinal, 
            string cnpj, 
            string conformeCargoFuncao, 
            string atalho, 
            string anexoNome, 
            string anexoTipo, 
            byte[] anexoBase);
        Task<object> IUpdateDissidio(
            int id,
            string dataBase,
            string dataUltima,
            decimal? pisoSalario18h,
            decimal? pisoSalario16h,
            decimal? ticket8h,
            decimal? ticket6h,
            decimal? benefInd8h,
            decimal? benefInd6h,
            decimal? reajuste,
            string observacao,
            string vigenciaInicio,
            string vigenciaFinal,
            string cnpj,
            string conformeCargoFuncao,
            string anexoNome,
            string anexoTipo,
            byte[] anexoBase,
            string atalho);
    }
}
