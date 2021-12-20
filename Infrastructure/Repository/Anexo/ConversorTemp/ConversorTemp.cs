using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Anexo.ConversorTemp
{
    public class ConversorTemp : IConversorTemp
    {
        public async Task Execute()
        {
            using var context = new ApiContext();

            var anexos = await context.Anexos.ToListAsync();

            foreach (var anexo in anexos)
            {
                try
                {
                    var arquivo = Convert.FromBase64String(Encoding.UTF8.GetString(anexo.Base64, 0, anexo.Base64.Length));
                    anexo.Base64 = arquivo;

                    context.Anexos.Update(anexo);
                    await context.SaveChangesAsync();
                }
                catch (Exception) { }
            }

            return;
        }
    }
}
