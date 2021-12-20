using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.Clientes
{
    public interface IClientesRepository
    {
        Task<object> GetAllClientes();
        Task<object> GetByIdCliente(int id);
        Task<object> GetByNameCliente(string nome);
        Task<object> CreateCliente(string nome, string apelido, string cnpj);
        Task<object> UpdateCliente(string nome, string apelido, string cnpj, bool ativo, int id);

    }
}
