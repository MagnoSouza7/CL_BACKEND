using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Dissidio.UpdateDissidio
{
    public class UpdateDissidio : IUpdateDissidio
    {
        public async Task<object> Execute(
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
            using var context = new ApiContext();

            var dissidio = await context.Dissidios
                .Include(x => x.Arquivo)
                .AsTracking()
                .Include(x => x.Estado)
                .Include(x => x.Arquivo)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if(dissidio.Arquivo != null && anexoNome != null)
            {
                context.Anexos.Remove(dissidio.Arquivo);
            }

            var arquivo = anexoNome != null ? new Domain.Entities.Anexo
            {
                Nome = anexoNome,
                Tipo = anexoTipo,
                Base64 = anexoBase
            } : null;

            dissidio.DataBase = DateTime.Parse(dataBase);
            dissidio.DataUltima = DateTime.Parse(dataUltima);
            dissidio.PisoSalarial8h = pisoSalario18h;
            dissidio.PisoSalarial6h = pisoSalario16h;
            dissidio.Ticket8h = ticket8h;
            dissidio.Ticket6h = ticket6h;
            dissidio.BenefInd8h = benefInd8h;
            dissidio.BenefInd6h = benefInd6h;
            dissidio.Reajuste = reajuste;
            dissidio.Observacoes = observacao;
            dissidio.VigenciaInicio = DateTime.Parse(vigenciaInicio);
            dissidio.VigenciaFinal = DateTime.Parse(vigenciaFinal);
            dissidio.Cnpj = cnpj;
            dissidio.ConformeCargoFuncao = conformeCargoFuncao;
            dissidio.Arquivo = arquivo;
            dissidio.Atalho = atalho;
            dissidio.DataAtualizacao = DateTime.Now;
            dissidio.Ativo = true;

            context.Dissidios.Update(dissidio);
            await context.SaveChangesAsync();

            return dissidio;

        }
    }
}
