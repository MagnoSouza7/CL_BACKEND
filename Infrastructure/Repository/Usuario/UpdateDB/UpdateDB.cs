using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Usuario.UpdateDB
{
    public class UpdateDB : IUpdateDB
    {
        public async Task Execute(int id, int roleId, bool ativo)
        {
            using var context = new ApiContext();

            
            var userOld = await context.Usuarios
                        .Include(x => x.Role)
                        .AsTracking()
                        .Where(x => x.Id == id)
                        .SingleOrDefaultAsync();


                        userOld.Ativo = ativo;
                        userOld.Role = await context.Roles.Where(x => x.Id == roleId).SingleOrDefaultAsync();

                        context.Usuarios.Update(userOld);
                        await context.SaveChangesAsync();

            
        }
    }
}
