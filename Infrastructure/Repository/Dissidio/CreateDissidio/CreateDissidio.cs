using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Dissidio.CreateDissidio
{
    public class CreateDissidio : ICreateDissidio
    {
        public async Task<object> Execute(
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
            string atalho)
        {
            using var context = new ApiContext();

            var arquivo = anexoNome != null ? new Domain.Entities.Anexo
            {
                Nome = anexoNome,
                Tipo = anexoTipo,
                Base64 = anexoBase
            } : null;

            var dissidio = new Domain.Entities.Dissidio
            {
                Estado = await context.Estados.Where(x => x.Id == estadoId).SingleOrDefaultAsync(),
                DataBase = DateTime.Parse(dataBase),
                DataUltima = DateTime.Parse(dataUltima),
                PisoSalarial8h = pisoSalario18h,
                PisoSalarial6h = pisoSalario16h,
                Ticket8h = ticket8h,
                Ticket6h = ticket6h,
                BenefInd8h = benefInd8h,
                BenefInd6h = benefInd6h,
                Reajuste = reajuste,
                Observacoes = observacao,
                VigenciaInicio = DateTime.Parse(vigenciaInicio),
                VigenciaFinal = DateTime.Parse(vigenciaFinal),
                Cnpj = cnpj,
                ConformeCargoFuncao = conformeCargoFuncao,
                Arquivo = arquivo,
                Atalho = atalho,
                DataCriacao = DateTime.Now,
                Ativo = true
            };

            await context.Dissidios.AddAsync(dissidio);

            await context.SaveChangesAsync();
            
            return dissidio;

        }


    }
}
