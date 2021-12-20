using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Math.EC.Rfc7748;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Usuario.GetAll
{
    public class GetAllUsuario : IGetAllUsuario
    {
        public async Task<object> Execute()
        {
            using var context = new ApiContext();

            var usuario = await context.Usuarios
                .AsNoTracking()
                .OrderBy(x => x.Nome)
                .Select(x => new { x.Nome, x.Id, x.Ativo }  )
                .ToListAsync();

            return usuario;
        }
    }
}
