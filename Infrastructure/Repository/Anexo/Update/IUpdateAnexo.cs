using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Anexo.Update
{
    public interface IUpdateAnexo
    {
        Domain.Entities.Anexo Execute(int id, string nome, string tipo, byte[] base64, bool ativo);
    }
}
