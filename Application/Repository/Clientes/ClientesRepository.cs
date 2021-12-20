using Infrastructure.Repository.Cliente.Create;
using Infrastructure.Repository.Cliente.GetAllClientes;
using Infrastructure.Repository.Cliente.GetById;
using Infrastructure.Repository.Cliente.GetByName;
using Infrastructure.Repository.Cliente.Update;
using Infrastructure.Repository.Edital.Update;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.Clientes
{
    public class ClientesRepository : IClientesRepository
    {
        private readonly IGetAllClientes getAllClientes;
        private readonly IGetByIdCliente getByIdCliente;
        private readonly IGetByNameCliente getByNameCliente;
        private readonly ICreateCliente createCliente;
        private readonly IUpdateCliente updateCliente; 

        public ClientesRepository(IGetAllClientes getAllClientes, IGetByIdCliente getByIdCliente, IGetByNameCliente getByNameCliente, ICreateCliente createCliente, IUpdateCliente updateCliente)
        {
            this.getAllClientes = getAllClientes;
            this.getByIdCliente = getByIdCliente;
            this.getByNameCliente = getByNameCliente;
            this.createCliente = createCliente;
            this.updateCliente = updateCliente;
        }

        public async Task<object> CreateCliente(string nome, string apelido, string cnpj)
        {
            return await createCliente.Execute(nome, apelido, cnpj);
        }

        public async Task<object> GetAllClientes()
        {
            return await getAllClientes.Execute();
        }

        public async Task<object> GetByIdCliente(int id)
        {
            return await getByIdCliente.Execute(id);
        }

        public async Task<object> GetByNameCliente(string nome)
        {
            return await getByNameCliente.Execute(nome);
        }

        public async Task<object> UpdateCliente(string nome, string apelido, string cnpj,bool ativo, int id)
        {
            return await updateCliente.Execute(nome, apelido, cnpj, ativo, id);
        }
    }
}
