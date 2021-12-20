using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.Empresa
{
    public interface IEmpresaRepository
    {
        Task<object> GetAllEmpresa();
        Task<object> GetByIdEmpresa(int id);
        Task<object> CreateEmpresa(string nome);
        Task<object> UpdateEmpresa(string nome, int id, bool ativo);
    }
}
