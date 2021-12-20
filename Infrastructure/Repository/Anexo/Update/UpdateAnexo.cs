using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Anexo.Update
{
    public class UpdateAnexo : IUpdateAnexo
    {
        public Domain.Entities.Anexo Execute(int id, string nome, string tipo, byte[] base64, bool ativo)
        {
            using var context = new ApiContext();

            var anexoOld = context.Anexos
                .AsNoTracking()
                .Where(x => x.Id == id)
                .SingleOrDefault();

            var anexoNew = new Domain.Entities.Anexo
            {
                Id = id,
                Nome = nome,
                Tipo = tipo,
                Base64 = base64,
                Ativo = ativo,
                DataAtualizacao = DateTime.Now,
                DataCriacao = anexoOld.DataCriacao
            };

            return anexoNew;
        }
    }
}
