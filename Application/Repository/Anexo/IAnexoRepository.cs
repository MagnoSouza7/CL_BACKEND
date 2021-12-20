using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.Anexo
{
    public interface IAnexoRepository
    {
        Task ComversorTemp();
        Task<Domain.Entities.Anexo> GetById(int id);
        Domain.Entities.Anexo Create(string nome, string tipo, byte[] base64);
        Domain.Entities.Anexo Execute(int id, string nome, string tipo, byte[] base64, bool ativo);
    }
}
