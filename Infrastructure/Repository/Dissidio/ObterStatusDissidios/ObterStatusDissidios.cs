using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Dissidio.ObterStatusDissidios
{
    public class ObterStatusDissidios : IObterStatusDissidios
    {
        public async Task<object> Execute()
        {
            using var context = new ApiContext();

            var resposta = new List<object>();
            var estados = await context.Estados.AsNoTracking().Where(x => x.Ativo).OrderBy(x => x.Nome).ToListAsync();

            foreach (var estado in estados)
            {
                var estadoCustom = new
                {
                    estado,
                    Ok = await context.Dissidios.AnyAsync(x => x.Ativo && x.Estado.Id == estado.Id && x.VigenciaFinal > DateTime.Now)
                };

                resposta.Add(estadoCustom);
            }
            return resposta;
        }
    }
}
