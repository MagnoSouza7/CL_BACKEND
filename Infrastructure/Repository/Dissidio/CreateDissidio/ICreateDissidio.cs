using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Dissidio.CreateDissidio
{
    public interface ICreateDissidio
    {
        Task<object> Execute(
            int estadoId,
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
