using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.ConsultaPublica.GetAll
{
    public class GetAllConsultaPublica : IGetAllConsultaPublica
    {
        public async Task<object> Execute(int? NumConsulta, int? ClienteId, int? EmpresaId, string DataRespostaInicio, string DataRespostaFinal)
        {
            using var context = new ApiContext();

            var consulPublicaAtiva = await context.ConsultaPublicas
                .Include(x => x.Cliente)
                .Include(x => x.Empresa)
                .Include(x => x.Anexo)
                .Where(x => x.Ativo
                    && (x.DataResposta >= DateTime.Now)
                    && (NumConsulta != null && NumConsulta > 0 ? x.NumConsulta == NumConsulta : true)
                    && (ClienteId != null && ClienteId > 0 ? x.Cliente.Id == ClienteId : true)
                    && (EmpresaId != null && EmpresaId > 0 ? x.Empresa.Id == EmpresaId : true)
                    && (DataRespostaInicio != "" ? DateTime.Parse(DataRespostaInicio) <= x.DataResposta : true)
                    && (DataRespostaFinal != "" ? DateTime.Parse(DataRespostaFinal) >= x.DataResposta : true))
                .OrderByDescending(x => x.DataResposta)
                .AsNoTracking()
                .ToListAsync();

            var consulPublicaDesativado = await context.ConsultaPublicas
                .Include(x => x.Cliente)
                .Include(x => x.Empresa)
                .Include(x => x.Anexo)
                .Where(x => x.Ativo
                    && (x.DataResposta < DateTime.Now)
                    && (NumConsulta != null && NumConsulta > 0 ? x.NumConsulta == NumConsulta : true)
                    && (ClienteId != null && ClienteId > 0 ? x.Cliente.Id == ClienteId : true)
                    && (EmpresaId != null && EmpresaId > 0 ? x.Empresa.Id == EmpresaId : true)
                    && (DataRespostaInicio != "" ? DateTime.Parse(DataRespostaInicio) <= x.DataResposta : true)
                    && (DataRespostaFinal != "" ? DateTime.Parse(DataRespostaFinal) >= x.DataResposta : true))
                .OrderByDescending(x => x.DataResposta)
                .AsNoTracking()
                .ToListAsync();


            return new
            {
                consulPublicaAtiva,
                consulPublicaDesativado
            };
        }
    }
}
