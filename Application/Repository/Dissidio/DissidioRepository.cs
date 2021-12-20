using Infrastructure.Repository.Dissidio.CreateDissidio;
using Infrastructure.Repository.Dissidio.GetDissidioByEstadoId;
using Infrastructure.Repository.Dissidio.GetDissidioById;
using Infrastructure.Repository.Dissidio.ObterStatusDissidios;
using Infrastructure.Repository.Dissidio.UpdateDissidio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.Dissidio
{
    public class DissidioRepository : IDissidioRepository
    {
        private readonly IObterStatusDissidios obterStatusDissidios;
        private readonly IGetDissidioByEstadoId getDissidioByEstadoId;
        private readonly IGetDissidioById getDissidioById;
        private readonly ICreateDissidio createDissidio;
        private readonly IUpdateDissidio updateDissidio; 

        public DissidioRepository (
            IObterStatusDissidios obterStatusDissidios,
            IGetDissidioByEstadoId getDissidioByEstadoId,
            IGetDissidioById getDissidioById,
            ICreateDissidio createDissidio,
            IUpdateDissidio updateDissidio)
        {
            this.obterStatusDissidios = obterStatusDissidios;
            this.getDissidioByEstadoId = getDissidioByEstadoId;
            this.getDissidioById = getDissidioById;
            this.createDissidio = createDissidio;
            this.updateDissidio = updateDissidio;
        }

        public async Task<object> ObterStatusDissidios()
        {
            return await obterStatusDissidios.Execute();
        }

        public async Task<object> GetDissidioByEstadoId(int id)
        {
            return await getDissidioByEstadoId.Execute(id);
        }

        public async Task<object> GetDissidioById(int id)
        {
            return await getDissidioById.Execute(id);
        }

        public async Task<object> CreateDissidio( 
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
            byte[] anexoBase)

        {
            return await createDissidio.Execute(
                estadoId, 
                dataBase, 
                dataUltima, 
                pisoSalarial8h, 
                pisoSalarial6h, 
                ticket8h, 
                ticket6h, 
                benefInd8h, 
                benefInd6h, 
                reajuste, 
                observacoes, 
                vigenciaInicio, 
                vigenciaFinal, 
                cnpj, 
                conformeCargoFuncao, 
                anexoNome, 
                anexoTipo, 
                anexoBase, 
                atalho );
        }

        public async Task<object> IUpdateDissidio(
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
            string atalho)
        {
            return await updateDissidio.Execute(
                id, 
                dataBase, 
                dataUltima, 
                pisoSalario18h, 
                pisoSalario16h, 
                ticket8h, 
                ticket6h, 
                benefInd8h, 
                benefInd6h, 
                reajuste, 
                observacao, 
                vigenciaInicio, 
                vigenciaFinal, 
                cnpj, 
                conformeCargoFuncao, 
                anexoNome, 
                anexoTipo, 
                anexoBase, 
                atalho);
        }
    }
}
