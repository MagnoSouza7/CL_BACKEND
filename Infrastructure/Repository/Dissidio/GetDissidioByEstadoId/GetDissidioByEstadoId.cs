using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Dissidio.GetDissidioByEstadoId
{
    public class GetDissidioByEstadoId : IGetDissidioByEstadoId
    {
        public async Task<object> Execute(int id)
        {
            using var context = new ApiContext();

            /*var estado = await context.Estados.AsNoTracking().Where(x => x.Id == id).SingleOrDefaultAsync();*/

            var dissidio = await context.Dissidios
                .AsNoTracking()
                .AnyAsync(x => x.Estado.Id == id);

            var listaDissidiosRestantes = new List<object>();

            var dissidioRestantes = dissidio != false ? await context.Dissidios.AsNoTracking()
                .Where(x => x.Estado.Id == id)
                .OrderByDescending(x => x.DataBase)
                .ToListAsync() : new List<Domain.Entities.Dissidio>();

            foreach (var dissidioRestante in dissidioRestantes)
            {
                listaDissidiosRestantes.Add(new
                {
                    dissidioRestante.Id,
                    dissidioRestante.DataBase,
                    Vigencia = (dissidioRestante.VigenciaInicio <= DateTime.Now && dissidioRestante.VigenciaFinal > DateTime.Now) ? 0 :
                               (dissidioRestante.VigenciaInicio > DateTime.Now && dissidioRestante.VigenciaFinal > DateTime.Now) ? 1 : -1
                });
            }
            return listaDissidiosRestantes;





        }


    }
}
