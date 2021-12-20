using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Anexo.Create
{
    public interface ICreateAnexo
    {
        Domain.Entities.Anexo Execute(string nome, string tipo, byte[] base64);
    }
}
