using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Anexo.Create
{
    public class CreateAnexo : ICreateAnexo
    {
        public Domain.Entities.Anexo Execute(string nome, string tipo, byte[] base64)
        {
            using var context = new ApiContext();

            var anexoNew = new Domain.Entities.Anexo();

            if (nome != null && tipo != null && base64 != null)
            {
                anexoNew = new Domain.Entities.Anexo
                {
                    Nome = nome,
                    Tipo = tipo,
                    Base64 = base64,
                    Ativo = true,
                    DataAtualizacao = DateTime.Now,
                    DataCriacao = DateTime.Now
                };
            }
            else
            {
                anexoNew = null;
            }


            return anexoNew;
        }
    }
}
